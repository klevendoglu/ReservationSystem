import type { EntityDto } from '@abp/ng.core';

export interface UserDto extends EntityDto<string> {
  name?: string;
  surname?: string;
  userName?: string;
  email?: string;
  emailConfirmed: boolean;
  roles: UserRoleDto[];
  phoneNumber?: string;
  phoneNumberConfirmed: boolean;
}

export interface UserRoleDto extends EntityDto<string> {
  roleId?: string;
  roleName?: string;
}
