import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { UserDto } from '../../../users/models';

export interface ResourceDto extends FullAuditedEntityDto<string> {
  name?: string;
  location?: string;
  description?: string;
  image?: string;
  serial?: string;
  managerId?: string;
  manager: UserDto;
  creatorUser: UserDto;
  category: number;
  parentId?: string;
  parent: ResourceDto;
  maxReservationHours: number;
}
