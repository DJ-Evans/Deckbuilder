import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { appInjector } from "../app.injector";
import { Observable } from "rxjs";
import { HttpClientOptions } from "../models/http-client-options.model";
import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class BaseApiService {
private options = { withCredentials: false, 'access-control-allow-origin': environment.clientUrl, 'Content-Type': 'application/json' };
constructor(private httpClient: HttpClient) {}

    get<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(`${environment.apiUrl}/${url}`, this.options);
      }

    post<T>(url: string, body: object, options: HttpClientOptions<"body", "json"> = new HttpClientOptions<"body", "json">()): Observable<T> {
        return this.httpClient.post<T>(`${environment.apiUrl}/${url}`, body, options);
      }
}