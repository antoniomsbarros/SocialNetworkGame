import {Component, OnInit} from '@angular/core';
import {PathDto} from "../DTO/PathDto";
import {RelactionShipServiceService} from "../services/relaction-ship-service.service";

@Component({
  selector: 'app-safest-path',
  templateUrl: './safest-path.component.html',
  styleUrls: ['./safest-path.component.css']
})
export class SafestPathComponent implements OnInit {
  safestPath: PathDto = {} as PathDto;

  constructor(private relationshipService: RelactionShipServiceService) {
  }

  ngOnInit(): void {
  }


  getShortestPath(playerEmail: string): void {
    if (!playerEmail) {
      alert("Invalid user(s)!")
      return;
    }
    this.relationshipService.getSafestPath(playerEmail).subscribe(
      {
        next: p => {
          this.safestPath = p as PathDto
        },
        error: e => {
          console.error(e)
        }
      });
  }
}
