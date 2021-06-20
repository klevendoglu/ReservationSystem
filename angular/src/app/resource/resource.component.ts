import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ResourceService } from '@proxy/resources';
import { ResourceDto } from '@proxy/resources/dtos/resource';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';

@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})

export class ResourceComponent implements OnInit {
  resource = { items: [], totalCount: 0 } as PagedResultDto<ResourceDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedResource = {} as ResourceDto;

  constructor(
    public readonly list: ListService,
    private _resourceService: ResourceService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const resourceStreamCreator = query => this._resourceService.getList(query);

    this.list.hookToQuery(resourceStreamCreator).subscribe(response => {
      this.resource = response;
    });
  }

  createResource() {
    this.selectedResource = {} as ResourceDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editResource(id: string) {
    this._resourceService.get(id).subscribe(resource => {
      this.selectedResource = resource;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedResource.name || null, Validators.required],
      description: [this.selectedResource.description || null],
      location: [this.selectedResource.description || null],
      serial: [this.selectedResource.serial || null],
      image: [this.selectedResource.image || null],
      managerId: [this.selectedResource.managerId || null],
      category: [this.selectedResource.category || null],
      parentId: [this.selectedResource.parentId || null],
      maxReservationHours: [this.selectedResource.maxReservationHours || null, Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedResource.id) {
      this._resourceService.update(this.selectedResource.id, this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    } else {
      this._resourceService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this._resourceService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
