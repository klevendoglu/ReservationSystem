import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ReservationRoutingModule } from './reservation-routing.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

import { ReservationComponent } from './reservation.component';

@NgModule({
  declarations: [ReservationComponent],
  imports: [SharedModule, ReservationRoutingModule, NgbDatepickerModule],
})
export class ReservationModule {}
