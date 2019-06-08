import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  private hubConnection: HubConnection;
  nick = '';
  message = '';
  messages: string[] = [];

  constructor(private httpClient: HttpClient) {

  }


  ngOnInit() {
    this.nick = window.prompt('Your name:', 'John');
    
    this.hubConnection = new HubConnectionBuilder().withUrl("/signalr").build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));


    this.hubConnection.on('sendToAll', (nick, message) => {
      this.messages.push(`${nick}: ${message}`);
    });

  }

  public sendMessage(): void {
    this.httpClient.post("/api/chat/sendMessage",
      <MessageInfo>
      {
        name: this.nick,
        message: this.message
      }).subscribe();
  }

}

interface MessageInfo {
  name: string;
  message: string;
}
