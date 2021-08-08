import type { ResourceDto } from '../../../resources/dtos/resource/models';
import type { Status } from '../../../status.enum';
import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ResourceCategory } from '../../../resource-category.enum';
import type { UserDto } from '../../../users/models';

export interface ReservationItemDto {
  reservationId?: string;
  resourceId?: string;
  resource: ResourceDto;
  startTime?: string;
  requestedHours: number;
  endTime?: string;
  returnTime?: string;
  overDue?: number;
  status: Status;
  statusText?: string;
  isOverDue: boolean;
  isFinished: boolean;
  overDueFee: number;
}

export interface CreateReservationItemInputDto {
  reservationId?: string;
  resourceId?: string;
  name: string;
  startTime: Date;
  requestedHours: number;
}

export interface CreateReservationInputDto {
  reserverNotes?: string;
  requestedItems: CreateReservationItemInputDto[];
}

export interface GetReservationsInput extends PagedAndSortedResultRequestDto {
  reservationId?: string;
  status?: Status;
  managerId?: string;
  creatorUserId?: string;
  resourceId?: string;
  isOverDue: boolean;
  category?: ResourceCategory;
  filter?: string;
  hasUnreturnedResources?: boolean;
  hasOverdueFee: boolean;
}

export interface ProcessReservationInput {
  reservationId?: string;
  managerNotes?: string;
  reservationItems: ProcessReservationItemInputDto[];
}

export interface ProcessReservationItemInputDto {
  id?: string;
  status: Status;
}

export interface ReservationDto extends FullAuditedEntityDto {
  id?: string;
  status: Status;
  reserverNotes?: string;
  managerNotes?: string;
  creatorUser: UserDto;
  reservationItems: ReservationItemDto[];
  statusText?: string;
  isProcessed: boolean;
  isFinished: boolean;
  isPending: boolean;
}
