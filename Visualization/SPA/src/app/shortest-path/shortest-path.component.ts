import { Component, OnInit } from '@angular/core';
import { PathDto } from '../DTO/PathDto';
import { ShortestPathService } from '../services/shortest-path.service';
import {Location} from "@angular/common";


@Component({
  selector: 'app-shortest-path',
  templateUrl: './shortest-path.component.html',
  styleUrls: ['./shortest-path.component.css']
})
export class ShortestPathComponent implements OnInit {

  shortestPath : PathDto  ={} as PathDto;

  constructor(
    private shortestPathService: ShortestPathService, private location: Location) { }

  ngOnInit(): void{
  }

  getShortestPath(userDest:string):void{
    if (!userDest) {
      alert("Invalid user(s)!")
      return;
    }
/*
    this.shortestPathService.getShortestPath(userDest).
    subscribe(
      {
        next: p => {this.shortestPath=p as PathDto,console.log(p)},
        error: e => {console.error(e)}
      });*/
  }

  goBack(): void {
    this.location.back();
  }
}
