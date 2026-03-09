import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor(private router: Router) { }

  handleError(error: HttpErrorResponse): string {
    if (error.status === 404) {
      return this.handleNotFound(error);
    }

    if (error.status === 400) {
      return this.handleBadRequest(error);
    }

    if (error.status === 500) {
      return this.handleServerError();
    }

    return '';
  }

  handleNotFound(error: HttpErrorResponse): string {
    this.router.navigate(['/404']);
    return error.message;
  }

  handleBadRequest(error: HttpErrorResponse): string {
    let message = '';
      const values = Object.values(error.error);
      values.map(m => {
        message += m + '<br>';
      });

      return message.slice(0, -4);
  }

  handleServerError(): string {
    let message = 'Something went wrong. Please try again later.';
    return message;
  }
}