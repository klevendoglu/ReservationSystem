import type { CreateReservationInputDto, GetReservationsInput, ProcessReservationInput, ReservationDto } from './dtos/reservation/models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ReservationSystemService {
  apiName = 'Default';

  create = (input: CreateReservationInputDto) =>
    this.restService.request<any, ReservationDto>({
      method: 'POST',
      url: '/api/app/reservation-system',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/reservation-system/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetReservationsInput) =>
    this.restService.request<any, PagedResultDto<ReservationDto>>({
      method: 'GET',
      url: '/api/app/reservation-system',
      params: { reservationId: input.reservationId, status: input.status, managerId: input.managerId, creatorUserId: input.creatorUserId, resourceId: input.resourceId, isOverDue: input.isOverDue, category: input.category, filter: input.filter, hasUnreturnedResources: input.hasUnreturnedResources, hasOverdueFee: input.hasOverdueFee, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  processReservation = (input: ProcessReservationInput) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/reservation-system/process-reservation',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
