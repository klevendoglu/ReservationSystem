import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ReservationSystem',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44397',
    redirectUri: baseUrl,
    clientId: 'ReservationSystem_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone ReservationSystem',
  },
  apis: {
    default: {
      url: 'https://localhost:44397',
      rootNamespace: 'ReservationSystem',
    },
  },
} as Environment;
