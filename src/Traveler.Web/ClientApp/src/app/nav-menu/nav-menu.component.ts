import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent {
  isExpanded = false;

  ipAddress = "";
  ipAddressIsValid = false;
  isConnected = false;

  constructor(private httpClient: HttpClient) {

  }

  checkIpAddress() {
    this.ipAddressIsValid = 
      /^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/.test(this.ipAddress);

    if (this.ipAddressIsValid) {
      this.startConnection(this.ipAddress);
    }
  }

  startConnection(ipAddress: string) {
    this.httpClient.post<IpAddressResponse>("/api/connections/connect", <IpAddressRequest>
        {
          ipAddress: ipAddress
        })
      .subscribe(data => this.isConnected = data.isConnected,
                error => this.isConnected = false);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

interface IpAddressRequest {
  ipAddress: string;
}

interface IpAddressResponse {
  isConnected: boolean;
}
