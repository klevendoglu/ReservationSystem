import type { ResourceDto } from '../../../resources/dtos/resource/models';
import type { Status } from '../../../status.enum';
import type { FullAuditedEntityDto } from '@abp/ng.core';
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
  startTime: string;
  requestedHours: number;
  endTime?: string;
  status: Status;
}

export interface CreateReservationInputDto {
  reserverNotes?: string;
  status: Status;
  requestedItems: CreateReservationItemInputDto[];
  isReservationApprovalRequired: boolean;
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

export interface UpdateReservationInputDto {
  id?: string;
  managerNotes?: string;
  status: Status;
}
