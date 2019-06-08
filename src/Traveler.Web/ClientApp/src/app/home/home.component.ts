import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  private hubConnection: HubConnection;
  nick = '';
  message = '';
  messages: any[] = [];
  messages$: Observable<any[]>;

  constructor(private httpClient: HttpClient) {
    this.messages$.subscribe(x => this.messages);
  }



  ngOnInit() {
    this.nick = window.prompt('Your name:', 'John');
    
    this.hubConnection = new HubConnectionBuilder().withUrl("/signalr").build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this.hubConnection.on('sendToAll', (nick, text) => {
      this.messages.push({ nick: nick, text: text });
    });

  }

  public sendMessage(): void {

    console.log(this.hubConnection.state);
    this.hubConnection.invoke('sendToAll', this.nick, this.message)
      .then(() => {
        this.message = "";
      })
      .catch(err => console.log(err));
  }

}

interface MessageInfo {
  name: string;
  message: string;
}
