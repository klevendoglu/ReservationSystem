import type { CreateResourceInputDto, GetResourcesInput, ResourceScheduleOutputDto, UpdateResourceInputDto } from './dtos/models';
import type { ResourceDto } from './dtos/resource/models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateReservationItemInputDto } from '../reservations/dtos/reservation/models';
import type { UserDto } from '../users/models';

@Injectable({
  providedIn: 'root',
})
export class ResourceService {
  apiName = 'Default';

  checkReservationHoursByInput = (input: CreateReservationItemInputDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/resource/check-reservation-hours',
      body: input,
    },
    { apiName: this.apiName });

  checkResourceAvailabilityByInput = (input: CreateReservationItemInputDto) =>
    this.restService.request<any, ResourceDto>({
      method: 'POST',
      url: '/api/app/resource/check-resource-availability',
      body: input,
    },
    { apiName: this.apiName });

  create = (input: CreateResourceInputDto) =>
    this.restService.request<any, ResourceDto>({
      method: 'POST',
      url: '/api/app/resource',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resource/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ResourceDto>({
      method: 'GET',
      url: `/api/app/resource/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetResourcesInput) =>
    this.restService.request<any, PagedResultDto<ResourceDto>>({
      method: 'GET',
      url: '/api/app/resource',
      params: { managerId: input.managerId, resourceId: input.resourceId, filter: input.filter, parentId: input.parentId, category: input.category, onlyChildren: input.onlyChildren, onlyParents: input.onlyParents, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getResourceManagers = () =>
    this.restService.request<any, ListResultDto<UserDto>>({
      method: 'GET',
      url: '/api/app/resource/resource-managers',
    },
    { apiName: this.apiName });

  getResourceScheduleById = (id: string) =>
    this.restService.request<any, ResourceScheduleOutputDto>({
      method: 'GET',
      url: `/api/app/resource/${id}/resource-schedule`,
    },
    { apiName: this.apiName });

  getResourcesLibraryByInput = (input: GetResourcesInput) =>
    this.restService.request<any, PagedResultDto<ResourceDto>>({
      method: 'GET',
      url: '/api/app/resource/resources-library',
      params: { managerId: input.managerId, resourceId: input.resourceId, filter: input.filter, parentId: input.parentId, category: input.category, onlyChildren: input.onlyChildren, onlyParents: input.onlyParents, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getResourcesMeetingRoomByInput = (input: GetResourcesInput) =>
    this.restService.request<any, PagedResultDto<ResourceDto>>({
      method: 'GET',
      url: '/api/app/resource/resources-meeting-room',
      params: { managerId: input.managerId, resourceId: input.resourceId, filter: input.filter, parentId: input.parentId, category: input.category, onlyChildren: input.onlyChildren, onlyParents: input.onlyParents, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getResourcesStudioByInput = (input: GetResourcesInput) =>
    this.restService.request<any, PagedResultDto<ResourceDto>>({
      method: 'GET',
      url: '/api/app/resource/resources-studio',
      params: { managerId: input.managerId, resourceId: input.resourceId, filter: input.filter, parentId: input.parentId, category: input.category, onlyChildren: input.onlyChildren, onlyParents: input.onlyParents, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: UpdateResourceInputDto) =>
    this.restService.request<any, ResourceDto>({
      method: 'PUT',
      url: `/api/app/resource/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
