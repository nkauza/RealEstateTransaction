import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { forkJoin, Observable } from 'rxjs';
import { Transaction } from '../model/transaction';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  private serviceUrl = 'https://localhost:44382/api/Transactions';

  

  constructor(private http: HttpClient) {}

  getTransactions(): Observable<Transaction[]> {
    return this.http
      .get(this.serviceUrl)
      .pipe<Transaction[]>(map((data: any) => data.Transactions));
  }

  updateTransactions(Transactions: Transaction[]): Observable<void> {
    const header = new HttpHeaders();

    header.append('Content-Type', `application/json`);
    return this.http.post<void>(`${this.serviceUrl}`, Transactions, { headers: header });
  }
}
