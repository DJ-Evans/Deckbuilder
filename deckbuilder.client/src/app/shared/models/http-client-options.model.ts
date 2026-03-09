import { HttpParams, HttpHeaders } from "@angular/common/http";

export class HttpClientOptions<observe, responsetype> {
  headers?: HttpHeaders | {
    [header: string]: string | string[];
  };
  observe?: observe;
  params?: HttpParams | {
    [param: string]: string | string[];
  };
  reportProgress?: boolean;
  responseType?: responsetype;
  withCredentials?: boolean;
}