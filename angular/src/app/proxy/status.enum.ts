import { mapEnumToOptions } from '@abp/ng.core';

export enum Status {
  Pending = 0,
  Approved = 1,
  Rejected = 2,
  Ready = 3,
  Open = 4,
  Assigned = 5,
  Closed = 6,
  InProcess = 7,
  Processed = 8,
  Finished = 9,
  Requested = 10,
  InUse = 11,
  Available = 12,
  Booked = 13,
  Dropped = 14,
  Withdrawn = 15,
}

export const StatusOptions = mapEnumToOptions(Status);
