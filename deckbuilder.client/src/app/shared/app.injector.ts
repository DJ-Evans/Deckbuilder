import { Injector } from "@angular/core";

/*
 * Used to get dependencies manually instead of through the constructor.
 */
let appInjectorRef: Injector;
export const appInjector = (injector?: Injector): Injector => {
  if (injector) {
    appInjectorRef = injector;
    console.log('appInjector: SET!');
  }
  if (!appInjectorRef) {
    console.error('appInjector: accessed before set!');
  }

  return appInjectorRef;
};