import { Component, OnInit } from '@angular/core';
import {DirectRequestService} from "../services/directrequests/direct-request.service";
import {DirectRequestDto} from "../dto/directrequests/DirectRequestDto";
import {PlayersService} from "../services/players/players.service";

@Component({
  selector: 'app-get-pending-direct-requests',
  templateUrl: './get-pending-direct-requests.component.html',
  styleUrls: ['./get-pending-direct-requests.component.css']
})
export class GetPendingDirectRequestsComponent implements OnInit {

  constructor(private directRequestService: DirectRequestService,
              private playerService: PlayersService) { }

  ngOnInit(): void {
    this.getPendingDirectRequests()
  }

  pendingRequests: DirectRequestDto[] = []

  getPendingDirectRequests() {
    let user = this.playerService.getCurrentLoggedInUser()
    if (!user) return
    this.directRequestService.getPendingDirectRequests(user).subscribe(requests => {
      this.pendingRequests = requests
      console.log(requests)
    })
  }
}
