import {TestBed} from '@angular/core/testing';

import {PlayersService} from './players.service';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {TagsService} from "../tags.service";

describe('PlayersService', () => {
  let service: PlayersService;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [HttpClientTestingModule],
      providers: [PlayersService]});
    service = TestBed.inject(PlayersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
