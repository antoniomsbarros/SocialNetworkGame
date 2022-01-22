import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {PostDto} from "../../dto/posts/PostDto";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {CommentDto} from "../../dto/posts/CommentDto";
import {PostsService} from "../../services/posts/posts.service";
import {ReactionDto} from "../../dto/posts/ReactionDto";
import {ReactionCommentDto} from "../../DTO/posts/ReactionCommentDto";
import {PlayersService} from "../../services/players/players.service";
import {  firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-profile-posts',
  templateUrl: './profile-posts.component.html',
  styleUrls: ['./profile-posts.component.css']
})
export class ProfilePostsComponent implements OnInit {
  userEmail!: string;
  playerFeed: PostDto[] = [];
  commentingPosts!: string[];
  currentPlayerHasNoPosts: boolean = false;


  getCommentText = new FormGroup({
    comment: new FormControl('', [Validators.required, Validators.minLength(1)]),
  });

  get commentText(): any {
    return this.getCommentText.get('comment');
  }



  newPost = new FormGroup({
    postText: new FormControl('', [Validators.required]),
  });

  get postText(): any {
    return this.newPost.get('postText');
  }


  constructor(private postService: PostsService, private route: ActivatedRoute, private playerService: PlayersService) {
  }

  getPlayerFeed() {
    this.route.params.subscribe(params => {
      this.userEmail = params['email'];
    });

    if (this.userEmail) {
      this.postService.getPlayerFeed(this.userEmail).subscribe(feed => {
        this.playerFeed = feed.reverse();
        if (!this.playerFeed.length)
          this.currentPlayerHasNoPosts = true;
      });
    }
  }

  ngOnInit(): void {
    this.refreshFeed();
  }

  likeReducer(previousValue: number, currentValue: ReactionDto) : number {
    return ["Like", "0"].includes(currentValue.reactionValue) ? previousValue + 1 : previousValue;
  }

  dislikeReducer(previousValue: number, currentValue: ReactionDto) : number {
    return ["Dislike", "1"].includes(currentValue.reactionValue) ? previousValue + 1 : previousValue;
  }

  refreshFeed(): void {
    this.commentingPosts = [];
    this.playerFeed = [];
    this.getPlayerFeed();
  }

  startCommenting(postId: string) {
    this.commentingPosts = !this.commentingPosts.includes(postId) ? [postId] : [];
    this.commentText.value = ""
  }

  updatePost(oldPostId: string, updatedPost: PostDto): void {
    const postIndex = this.playerFeed.findIndex(post => post.id == oldPostId)
    this.playerFeed[postIndex] = updatedPost;
  }

  addCommentToPost(postId: string) {
    if (!this.commentText.value.length)
      return;
    this.commentingPosts = !this.commentingPosts.includes(postId) ? [postId] : [];
    this.postService.addCommentToPost(postId, {
      commentText: this.commentText.value,
      playerCreator: this.getCurrentPlayer()
    } as CommentDto).subscribe(updatedPost => {
      this.updatePost(postId, updatedPost);
    })
  }

  addReactionToPost(postId: string, reactionValue: string) {
    this.postService.addReactionToPost(postId, {
      playerId: this.getCurrentPlayer(),
      reactionValue: reactionValue
    } as ReactionCommentDto).subscribe(updatedPost => {
      this.updatePost(postId, updatedPost);
    })
  }

  addReactionToComment(postId: string, commentId: string, reactionValue: string) {
    this.postService.addReactionToComment(postId, commentId, {
      playerId: this.getCurrentPlayer(),
      reactionValue: reactionValue,
      commentId: commentId
    } as ReactionCommentDto).subscribe(updatedPost => {
      this.updatePost(postId, updatedPost);
    })
  }

  postReactedByCurrentUser(postId: string, reactionValues: string[]): boolean {
    let post = this.playerFeed.find(post => post.id == postId);
    if (!post) return false;
    for (let reaction of post.reactions) {
      if (reaction.playerId == this.getCurrentPlayer() && reactionValues.includes(reaction.reactionValue)) {
        return true;
      }
    }
    return false;
  }

  commentReactedByCurrentUser(postId: string, commentId: string, reactionValues: string[]): boolean {
    let post = this.playerFeed.find(post => post.id == postId);
    if (!post) return false;
    let comment = post.comments.find(comment => comment.domainId == commentId);
    if (!comment) return false;
    for (let reaction of comment.reactions) {
      if (reaction.playerId == this.getCurrentPlayer() && reactionValues.includes(reaction.reactionValue)) {
        return true;
      }
    }
    return false;
  }

  isOurProfileFeed(): boolean {
    return this.userEmail == this.getCurrentPlayer();
  }

  getCurrentPlayer(): string {
    return this.playerService.getCurrentLoggedInUser() || "";
  }

  addNewPost() {
    if (!this.postText.value.length) return;
    this.postService.addNewPost({
      postText: this.postText.value,
      playerCreator: this.getCurrentPlayer(),
      tags: ["a", "b"]
    } as PostDto).subscribe(post => {
      this.playerFeed.unshift(post);
    })
  }

  getTimeSince(creationDate: string): string {
    let seconds = Math.floor(new Date().getTime() / 1000 - parseInt(creationDate));
    let interval = seconds / 31536000;
    if (interval > 1) {
      return Math.floor(interval) + " years";
    }
    interval = seconds / 2592000;
    if (interval > 1) {
      return Math.floor(interval) + " months";
    }
    interval = seconds / 86400;
    if (interval > 1) {
      return Math.floor(interval) + " days";
    }
    interval = seconds / 3600;
    if (interval > 1) {
      return Math.floor(interval) + " hours";
    }
    interval = seconds / 60;
    if (interval > 1) {
      return Math.floor(interval) + " minutes";
    }
    return Math.floor(seconds) + " seconds";
  }

}
