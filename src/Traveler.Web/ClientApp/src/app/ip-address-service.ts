import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class IpAddressService {

  ipAddress$: Observable<string>;
  private ipAddressSubject = new Subject<string>();

  constructor() {
    this.ipAddress$ = this.ipAddressSubject.asObservable();
  }

  setIpAddress(value) {
    this.ipAddressSubject.next(value);
  }
}
