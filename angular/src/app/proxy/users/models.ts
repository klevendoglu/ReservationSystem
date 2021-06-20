import type { EntityDto } from '@abp/ng.core';

export interface UserDto extends EntityDto<string> {
  name?: string;
  surname?: string;
  userName?: string;
  emailAddress?: string;
  profilePictureId?: string;
  isEmailConfirmed: boolean;
  roles: UserRoleDto[];
  lastLoginTime?: string;
  isActive: boolean;
  creationTime?: string;
}

export interface UserRoleDto extends EntityDto<string> {
  roleId?: string;
  roleName?: string;
}
