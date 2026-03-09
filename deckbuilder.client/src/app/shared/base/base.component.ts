import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { ErrorHandlerService } from '../services/error-handler.service';
import { appInjector } from '../app.injector';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-base',
  template: '',
})
export abstract class BaseComponent {
  @Input() loaded: boolean = false;

  public errorMessage: string = '';
  public showError: boolean = false;
  public messageService!: MessageService;

  constructor() {
    const injector = appInjector();
    this.messageService = injector.get(MessageService);
  }

  /**
   * Displays the message as a success toast.
   * @param message The message to display.
   */
  protected toastSuccess(message: string | undefined = undefined): void {
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: message,
    });
  }

  /**
   * Displays the message as an error toast.
   * @param message The message to display.
   */
  protected toastError(message: string | undefined = undefined): void {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: message,
    });
  }

  /**
   * Displays the message as a warning toast.
   * @param message The message to display.
   */
  protected toastWarn(message: string | undefined = undefined): void {
    this.messageService.add({
      severity: 'warn',
      summary: 'Warn',
      detail: message,
    });
  }

  /**
   * Handles display the error as a error toast.
   * @param errors The errors to display.
   */
  protected handleErrorResult(errors: {
    error: string[] | { errors: { [key: string]: string[] } };
  }): void {
    // validation errors
    if (
      errors.error &&
      typeof errors.error !== 'string' &&
      'errors' in errors.error
    ) {
      const errorMessages = this.parseErrorsResult(errors.error.errors);
      for (const errorMessage of errorMessages) {
        this.toastError(errorMessage);
      }
    } else {
      // other error
      let errorString = this.parseErrorResult(errors);
      if (!errorString) {
        // handle non 400s
        errorString = 'An unexpected error has occurred.';
      }
      this.toastError(errorString);
    }
  }

  /**
   * Parses the errors and returns a single string will all the errors.
   * @param errors The list of errors.
   */
  protected parseErrorResult(errors: {
    error: string[] | { errors: { [key: string]: string[] } };
  }): string {
    const errorResults = errors.error;
    if (
      errorResults &&
      Array.isArray(errorResults) &&
      errorResults.length > 0
    ) {
      return errorResults.join(' ');
    }

    return '';
  }

  /**
   * Parses the errors and returns a single string will all the errors.
   * @param errors The list of errors.
   */
  protected parseErrorsResult(errors: { [key: string]: string[] }): string[] {
    const errorMessages: string[] = [];
    for (const key of Object.keys(errors)) {
      for (const errorMessage of errors[key]) {
        errorMessages.push(errorMessage);
      }
    }
    return errorMessages;
  }
}
