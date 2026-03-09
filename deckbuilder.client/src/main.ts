import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app/app.module';
import { appInjector } from './app/shared/app.injector';

platformBrowser().bootstrapModule(AppModule, {
  ngZoneEventCoalescing: true,
}).then(moduleRef => {
  appInjector(moduleRef.injector);
})
  .catch(err => console.error(err));
