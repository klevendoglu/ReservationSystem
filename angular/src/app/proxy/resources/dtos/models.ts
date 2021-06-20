import type { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ResourceDto } from './resource/models';
import type { ReservationItemDto } from '../../reservations/dtos/reservation/models';
import { ResourceCategory } from '@proxy/resource-category.enum';

export interface CreateResourceInputDto {
  name: string;
  location?: string;
  description?: string;
  image?: string;
  serial?: string;
  maxReservationHours: number;
  managerId: string;
  parentId?: string;
  category: number;
}

export interface GetResourcesInput extends PagedAndSortedResultRequestDto {
  managerId?: string;
  resourceId?: string;
  filter?: string;
  parentId?: string;
  category?: ResourceCategory;
  onlyChildren: boolean;
  onlyParents: boolean;
}

export interface ResourceScheduleOutputDto {
  resource: ResourceDto;
  reservationItems: ReservationItemDto[];
}

export interface UpdateResourceInputDto {
  name: string;
  location?: string;
  description?: string;
  image?: string;
  serial?: string;
  maxReservationHours: number;
  managerId: string;
  parentId?: string;
  category: number;
}
