import { Injectable, EventEmitter } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../environments/environment';
import { MyToastrService } from './mytoastr.service';

const API_URL = environment.hubUrl; // + 'Note'; // CommentHub
@Injectable({
  providedIn: 'root'
})
export class NotifyHubService {
  connection: any;
  public refresh: EventEmitter<any> = new EventEmitter();
  public newNotif: EventEmitter<any> = new EventEmitter();
  constructor(private toastr: MyToastrService) {
    // this.noteHubCnx();
  }

  noteHubCnx(): void {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(API_URL + 'notify')
      .build();
    // connecter au hub
    this.connection.start().then(r => console.log(r)).catch(e => console.log(e));

    // this.connection.on('BroadcastIncident', (r: any) => this.notifyIncident(r));
    // this.connection.on('BroadcastEnvoi', (r: any) => this.notifyEnvoi(r));
    this.connection.on('BroadcastActualite', (r: any) => this.notify(r));
  }

  notify(r: any) {
    // console.log('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>');
    this.newNotif.next(true);
    this.refresh.next(r);

    // this.toastr.toastNotif(r); // .onTap.subscribe(() => console.log(r));
  }

  // notifyEnvoi(r: Envoi) {
  //   console.log(r);
  //   this.toastr.toastInfo('Info', `-Bande : ${r.idBande} / personne : ${r.idPersonne}`);
  //   // this.snackBar.notifyOk();
  // }

  // notifyIncident(r: Incident) {
  //   console.log(r);
  //   this.toastr.toastWarning('Alerte', `${r.msg}`);
  //   // this.snackBar.notifyAlert(`Alerte : ${r.msg} / personne : ${r.dateAlerte}`);
  // }
}
