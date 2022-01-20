import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {PostDto} from "../../dto/posts/PostDto";
import {CommentDto} from "../../dto/posts/CommentDto";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ReactionDto} from "../../dto/posts/ReactionDto";
import {ReactionCommentDto} from "../../DTO/posts/ReactionCommentDto";

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private postsRoute: string = "http://localhost:3000/api/posts/"; // TODO add ssl

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {
  }


  getPlayerFeed(email: string): Observable<PostDto[]> {
    return this.http.get<PostDto[]>(this.postsRoute + email);
  }

  addCommentToPost(postId: string, commentDto: CommentDto): Observable<PostDto> {
    return this.http.post<PostDto>(this.postsRoute + postId + "/comments", commentDto);
  }

  addReactionToPost(postId: string, reactionDto: ReactionDto): Observable<PostDto> {
    return this.http.post<PostDto>(this.postsRoute + postId + "/reactions", reactionDto);
  }

  addReactionToComment(postId: string, commentId: string, reactionDto: ReactionCommentDto): Observable<PostDto> {
    return this.http.post<PostDto>(this.postsRoute + postId + "/comments/reactions", reactionDto);
  }

  addNewPost(postDto: PostDto): Observable<PostDto> {
    return this.http.post<PostDto>(this.postsRoute, postDto);
  }
}
