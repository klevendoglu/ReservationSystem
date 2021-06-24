import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ResourceRoutingModule } from './resource-routing.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

import { ResourceComponent } from './resource.component';


@NgModule({
  declarations: [ResourceComponent],
  imports: [
    SharedModule,
    NgbDatepickerModule,
    ResourceRoutingModule
  ]
})
export class ResourceModule { }
