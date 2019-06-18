import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  power: number = 0;
  steering: number = 0;

  constructor(private httpClient: HttpClient) {
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
    const model = <ISetSteeringRequest>{
      power: Math.abs(this.power),
      steering: this.steering,
      reverseGear: this.power < 0
    }
    this.httpClient.post("/api/steering/setSteering", model).subscribe();
  }
}

interface ISetSteeringRequest
{
  power: number;
  steering: number;
  reverseGear: boolean;
}
