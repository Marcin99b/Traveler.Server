import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {
  }

  powerChange(event) {
    console.log("power: " + event.value + "%");
  }

  steeringChange(event) {
    console.log("steering: " + event.value + "%");
  }
}
