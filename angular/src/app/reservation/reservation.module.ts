import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ReservationRoutingModule } from './reservation-routing.module';
import { NgbDatepickerModule, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';

import { ReservationComponent } from './reservation.component';
import { HandleRequestedItemModalComponent } from './modal/handle-requested-item-modal.component';
import { CreateReservationModalComponent } from './modal/create-reservation-modal.component';

@NgModule({
  declarations: [
    ReservationComponent,
    HandleRequestedItemModalComponent,
    CreateReservationModalComponent,
  ],
  imports: [SharedModule, ReservationRoutingModule, NgbDatepickerModule, NgbTimepickerModule],
})
export class ReservationModule {}
