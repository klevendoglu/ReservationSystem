import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { Component, OnInit } from '@angular/core';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ReservationSystemService } from '@proxy/reservations';
import { ReservationDto } from '@proxy/reservations/dtos/reservation';
import { CreateReservationModalComponent } from './modal/create-reservation-modal.component';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
})
export class ReservationComponent implements OnInit {
  reservation = { items: [], totalCount: 0 } as PagedResultDto<ReservationDto>;

  constructor(
    public readonly list: ListService,
    private _reservationSystemService: ReservationSystemService,
    private _modalService: NgbModal,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const resourceStreamCreator = query => this._reservationSystemService.getList(query);

    this.list.hookToQuery(resourceStreamCreator).subscribe(response => {
      debugger
      this.reservation = response;
    });
  }

  createReservation() {
    this.openCreateReservationModal();
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this._reservationSystemService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  openCreateReservationModal() {
    const modalRef = this._modalService.open(CreateReservationModalComponent, {
      size: 'lg',
      windowClass: 'custom-modal',
      centered: true,
      backdrop: 'static',
      keyboard: false,
    });
    modalRef.result.then(
      (res: boolean) => {
        if (res) this.list.get();
      },
      dismiss => {}
    );
  }
}
