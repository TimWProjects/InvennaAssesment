import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { GeographicalDataItem } from '../Interfaces/GeographicalDataItem';

@Injectable({
  providedIn: 'root',
})
export class GeographicalDataService {
  private apiUrl = '/api/geographicaldata';

  constructor(private http: HttpClient) { }

  getAll(): Observable<GeographicalDataItem[]> {
    return this.http.get<GeographicalDataItem[]>(this.apiUrl).pipe(
      catchError(error => {
        console.error('Error fetching items:', error);
        return throwError(() => error);
      })
    );
  }

  getById(id: number): Observable<GeographicalDataItem> {
    return this.http.get<GeographicalDataItem>(`${this.apiUrl}/${id}`).pipe(
      catchError(error => {
        console.error('Error fetching items by id:', error);
        return throwError(() => error);
      })
    );
  }

  add(item: GeographicalDataItem): Observable<GeographicalDataItem> {
    return this.http.post<GeographicalDataItem>(this.apiUrl, item).pipe(
      catchError(error => {
        console.error('Error posting items:', error);
        return throwError(() => error);
      })
    );
  }

  update(id: number, item: GeographicalDataItem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, item).pipe(
      catchError(error => {
        console.error('Error updating items:', error);
        return throwError(() => error);
      })
    );
  }

  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`).pipe(
      catchError(error => {
        console.error('Error deleting items:', error);
        return throwError(() => error);
      })
    );
  }
}
