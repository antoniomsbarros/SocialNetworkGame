import { Component, OnInit } from '@angular/core';
import {DirectRequestService} from "../services/directrequests/direct-request.service";
import {DirectRequestDto} from "../dto/directrequests/DirectRequestDto";
import {PlayersService} from "../services/players/players.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-get-pending-direct-requests',
  templateUrl: './get-pending-direct-requests.component.html',
  styleUrls: ['./get-pending-direct-requests.component.css']
})
export class GetPendingDirectRequestsComponent implements OnInit {

  constructor(private directRequestService: DirectRequestService,
              private playerService: PlayersService,
              private toastService: ToastrService) { }

  ngOnInit(): void {
    this.getPendingDirectRequests()
  }

  pendingRequests: DirectRequestDto[] = []

  getPendingDirectRequests() {
    this.pendingRequests = []
    let user = this.playerService.getCurrentLoggedInUser()
    if (!user) return
    this.directRequestService.getPendingDirectRequests(user).subscribe(requests => {
      this.pendingRequests = requests
      console.log(requests)
    })
  }

  acceptDirectRequest(id: string) {
    let dto = this.pendingRequests.find(r => r.id == id);
    if (!dto) return;
    dto.connectionRequestStatus = 0;
    this.directRequestService.acceptOrRejectDirectRequest(dto).subscribe(r => {
      this.toastService.success("Request accepted");
      this.getPendingDirectRequests()
    })
  }

  rejectDirectRequest(id: string) {
    let dto = this.pendingRequests.find(r => r.id == id);
    if (!dto) return;
    dto.connectionRequestStatus = 1;
    this.directRequestService.acceptOrRejectDirectRequest(dto).subscribe(r => {
      this.toastService.success("Request rejected");
      this.getPendingDirectRequests()
    })
  }
}
