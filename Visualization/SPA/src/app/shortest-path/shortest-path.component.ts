import { Component, OnInit } from '@angular/core';
import { PathDto } from '../DTO/PathDto';
import { ShortestPathService } from '../services/shortest-path.service';


@Component({
  selector: 'app-shortest-path',
  templateUrl: './shortest-path.component.html',
  styleUrls: ['./shortest-path.component.css']
})
export class ShortestPathComponent implements OnInit {

  shortestPath : PathDto  ={} as PathDto;

  constructor(
    private shortestPathService: ShortestPathService) { }

  ngOnInit(): void{
  }

  getShortestPath(userFrom:string,userDest:string):void{


    if (!userFrom|| !userDest) {
      alert("Invalid user(s)!")
      return;
    }

    this.shortestPathService.getShortestPath(userFrom,userDest).
    subscribe(
      {
        next: p => {this.shortestPath=p as PathDto,console.log(p)},
        error: e => {console.error(e)}
      });
  }
}
