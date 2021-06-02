import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
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
    scope: 'offline_access ReservationSystem',
  },
  apis: {
    default: {
      url: 'https://localhost:44397',
      rootNamespace: 'ReservationSystem',
    },
  },
} as Environment;
