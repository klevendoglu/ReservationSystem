import type { CreateReservationInputDto, ProcessReservationInput, ReservationDto, UpdateReservationInputDto } from './dtos/reservation/models';
import { RestService } from '@abp/ng.core';
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

  processReservation = (input: ProcessReservationInput) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/reservation-system/process-reservation',
      body: input,
    },
    { apiName: this.apiName });

  update = (input: UpdateReservationInputDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/reservation-system',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
