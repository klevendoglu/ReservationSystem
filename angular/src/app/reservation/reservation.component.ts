import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ReservationSystemService } from '@proxy/reservations';
import { ReservationDto } from '@proxy/reservations/dtos/reservation';
import { ResourceService } from '@proxy/resources';
import { ResourceDto } from '@proxy/resources/dtos/resource';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class ReservationComponent implements OnInit {
  reservation = { items: [], totalCount: 0 } as PagedResultDto<ReservationDto>;

  isModalOpen = false;

  form: FormGroup;

  parentResources$: Observable<ResourceDto[]>;
  childResources$: Observable<ResourceDto[]>;
  requestedItems$: BehaviorSubject<ResourceDto[]> = new BehaviorSubject([]);

  //selectedReservation = {} as ReservationDto;

  constructor(
    public readonly list: ListService,
    private _resourceService: ResourceService,
    private _reservationSystemService: ReservationSystemService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {
    this.parentResources$ = _resourceService
      .getList({ onlyParents: true, maxResultCount: 999 })
      .pipe(map(r => r.items));
  }

  ngOnInit(): void {
    const resourceStreamCreator = query => this._reservationSystemService.getList(query);

    this.list.hookToQuery(resourceStreamCreator).subscribe(response => {
      this.reservation = response;
    });
  }

  createReservation() {
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm() {
    this.form = this.fb.group({
      parentResourceId: [null, Validators.required],
    });
  }

  onParentResourceChange(parentId: string) {
    debugger;
    this.childResources$ = this._resourceService
      .getList({ parentId: parentId, maxResultCount: 999 })
      .pipe(map(r => r.items));
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    this._reservationSystemService.create(this.form.value).subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  showResourceSchedule(id: string) {}

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this._reservationSystemService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
