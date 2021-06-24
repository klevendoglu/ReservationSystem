import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ReservationDto } from '@proxy/reservations/dtos/reservation';
import { ResourceService } from '@proxy/resources';
import { GetResourcesInput } from '@proxy/resources/dtos';
import { ResourceDto } from '@proxy/resources/dtos/resource';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss'],
})
export class ReservationComponent implements OnInit {
  resource = { items: [], totalCount: 0 } as PagedResultDto<ReservationDto>;

  isModalOpen = false;

  parentResources$: Observable<ResourceDto[]>;

  selectedReservation = {} as ReservationDto;

  constructor(
    public readonly list: ListService,
    private _resourceService: ResourceService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {
    this.parentResources$ = _resourceService
      .getList({ onlyParents: true, maxResultCount: 999 })
      .pipe(map(r => r.items));
  }



  ngOnInit(): void {}
}
