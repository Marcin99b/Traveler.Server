import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';
import { IpAddressService } from "../ip-address-service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  power: number = 0;
  steering: number = 0;
  private ipAddress: string = "";

  constructor(private httpClient: HttpClient, private ipAddressService: IpAddressService) {
    this.ipAddressService.ipAddress$.subscribe(data => {
      this.ipAddress = data;
      console.log(data);
    });
  }

  ngOnInit(): void {
  }

  powerChange(event) {
    this.power = event.value;
    this.setSteering();
  }

  steeringChange(event) {
    this.steering = event.value;
    this.setSteering();
  }

  reset() {
    this.power = 0;
    this.steering = 0;
    this.setSteering();
  }

  setSteering() {
    if (this.ipAddress.length == 0) {
      return;
    }
    const model = <ISetSteeringRequest>{
      power: Math.abs(this.power),
      steering: this.steering,
      reverseGear: this.power < 0,
      ipAddress: this.ipAddress
    }
    this.httpClient.post("/api/steering/setSteering", model).subscribe();
  }
}

interface ISetSteeringRequest
{
  power: number;
  steering: number;
  reverseGear: boolean;
  ipAddress: string;
}
