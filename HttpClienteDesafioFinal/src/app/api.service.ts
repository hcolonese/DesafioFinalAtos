import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly API = 'https://localhost:7097/vendas'
  // API_KEY = 'YOUR_API_KEY';
  constructor(private httpClient: HttpClient) { }

}
