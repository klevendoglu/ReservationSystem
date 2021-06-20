import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/resources',
        name: '::Menu:Resources',
        parentName: '::Menu:ReservationSystem',
        layout: eLayoutType.application,
        requiredPolicy: 'ReservationSystem.Resources',
      },
      {
        path: '/reservations',
        name: '::Menu:Reservations',
        parentName: '::Menu:ReservationSystem',
        layout: eLayoutType.application,
        requiredPolicy: 'ReservationSystem.Reservations',
      }
    ]);
  };
}
