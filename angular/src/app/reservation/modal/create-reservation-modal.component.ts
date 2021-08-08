import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ReservationSystemService } from '@proxy/reservations';
import { ResourceService } from '@proxy/resources';
import { ResourceDto } from '@proxy/resources/dtos/resource';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { HandleRequestedItemModalComponent } from './handle-requested-item-modal.component';
import {
  CreateReservationInputDto,
  CreateReservationItemInputDto,
} from '@proxy/reservations/dtos/reservation';

@Component({
  selector: 'create-reservation-modal',
  templateUrl: 'create-reservation-modal.component.html',
})
export class CreateReservationModalComponent implements OnInit {
  form: FormGroup;

  childResources$: Observable<ResourceDto[]>;

  parentResources$: Observable<ResourceDto[]>;

  requestedItems$: BehaviorSubject<CreateReservationItemInputDto[]> = new BehaviorSubject([]);

  constructor(
    public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private _resourceService: ResourceService,
    private _reservationSystemService: ReservationSystemService,
    private _modalService: NgbModal
  ) {
    this.parentResources$ = _resourceService
      .getList({ onlyParents: true, maxResultCount: 999 })
      .pipe(map(r => r.items));
  }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.form = this.fb.group({
      parentResourceId: [null, Validators.required],
      reserverNotes: [null],
    });
  }

  onParentResourceChange(parentId: string) {
    this.childResources$ = this._resourceService
      .getList({ parentId: parentId, maxResultCount: 999 })
      .pipe(map(r => r.items));
  }

  showResourceSchedule(id: string) {}

  handleRequestedItem(resource: ResourceDto) {
    this.openHandleRequestedItemModal(resource);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const model: CreateReservationInputDto = this.buildModel();
    this._reservationSystemService.create(model).subscribe(() => {
      this.form.reset();
      this.activeModal.close(true);
    });
  }

  openHandleRequestedItemModal(resource: ResourceDto) {
    const modalRef = this._modalService.open(HandleRequestedItemModalComponent, {
      size: 'lg',
      windowClass: 'custom-modal',
      centered: true,
      backdrop: 'static',
      keyboard: false,
    });
    modalRef.componentInstance.selectedChildResource = resource;
    modalRef.result.then(
      (res: FormGroup) => {
        if (res?.valid) {
          this.addOrUpdateRequestedItem({
            startTime: new Date(
              Date.UTC(
                res.value.startDate.year,
                res.value.startDate.month - 1,
                res.value.startDate.day,
                res.value.startTime.hour,
                res.value.startTime.minute
              )
            ),
            requestedHours: res.value.requestedHours,
            name: resource.name,
            resourceId: resource.id,
          });
        }
      },
      dismiss => {}
    );
  }

  addOrUpdateRequestedItem(requestedItem: CreateReservationItemInputDto) {
    this.requestedItems$
      .pipe(take(1))
      .subscribe((requestedItems: CreateReservationItemInputDto[]) => {
        const index = requestedItems.findIndex(s => s.resourceId == requestedItem.resourceId);
        if (index > -1) requestedItems.splice(index, 1);

        requestedItems.push(requestedItem);

        this.requestedItems$.next(requestedItems);
      });
  }

  removeRequestedItem(resourceId: string) {
    if (!resourceId) return;

    this.requestedItems$
      .pipe(take(1))
      .subscribe((requestedItems: CreateReservationItemInputDto[]) => {
        if (requestedItems.length <= 0) return;

        let index = requestedItems.findIndex(s => s.resourceId == resourceId);
        requestedItems.splice(index, 1);

        this.requestedItems$.next(requestedItems);
      });
  }

  private buildModel(): CreateReservationInputDto {
    const model: CreateReservationInputDto = {
      reserverNotes: this.form.value.reserverNotes,
      requestedItems: this.requestedItems$?.getValue()?.map(item => ({
        requestedHours: item.requestedHours,
        reservationId: item.reservationId,
        resourceId: item.resourceId,
        name: item.name,
        startTime: item.startTime,
      })),
    };
    return model;
  }
}
