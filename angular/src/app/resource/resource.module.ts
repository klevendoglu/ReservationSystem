import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceComponent } from './resource.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [ResourceComponent],
  imports: [
    SharedModule,
    CommonModule,
    NgbDatepickerModule,
    ResourceRoutingModule
  ]
})
export class ResourceModule { }
