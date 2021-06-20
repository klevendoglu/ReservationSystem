import { mapEnumToOptions } from '@abp/ng.core';

export enum ResourceCategory {
  StudioOrStudioEquipment = 1,
  MeetingRoom = 2,
  LectureHall = 3,
  LibraryRoom = 4,
}

export const ResourceCategoryOptions = mapEnumToOptions(ResourceCategory);
