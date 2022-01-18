import { Service, Inject } from 'typedi';
import config from "../../config";
import { Result } from "../core/logic/Result";
import IPostService from './IServices/IPostService';
import { IPostDTO } from '../dto/IPostDTO';
import IPostRepo from './IRepos/IPostRepo';
import { Post } from '../domain/post';
import { PostMap } from '../mappers/PostMap';
import { ICommentDTO } from '../dto/ICommentDTO';
import { Comment } from '../domain/comment';
import { CommentMap } from '../mappers/CommentMap';
import {IReactionDTO} from "../dto/IReactionDTO";
import {Reaction} from "../domain/reaction";
import {ReactionValue} from "../domain/reactionValue";
import {IReactionComentDTO} from "../dto/IReactionComentDTO";
import {Identifier} from "../core/domain/Identifier";
import {StrengthPLayersDTO} from "../dto/StrengthPLayersDTO";

@Service()
export default class PostService implements IPostService {
  constructor(
      @Inject(config.repos.post.name) private postRepo : IPostRepo
  ) {}

  public async getPlayerFeed(playerId: string): Promise<Result<IPostDTO[]>> {
    try {
      const posts = await this.postRepo.findPostsByPlayerId(playerId);

      return Result.ok<IPostDTO[]>(posts.map(post => PostMap.toDTO(post)))
    } catch (e) {
      throw e;
    }
  }
  public async getstrength(body: StrengthPLayersDTO): Promise<Result<StrengthPLayersDTO>> {
    return Promise.resolve(undefined);
    try {
      const  postplayer1=await this.postRepo.findPostsByPlayerId(body.playerIdOrigin);
      const postplayer2=await this.postRepo.findPostsByPlayerId(body.playerIdDest);
      let countlike=0;
      let countdislike=0;
      //reaction in a post of player
      for (let i = 0; i < postplayer1.length; i++) {
        for (let j = 0; j < postplayer1[i].reactions.length; j++) {
          if (postplayer1[i].reactions[j].playerId.toString()==body.playerIdDest){
            if (postplayer1[i].reactions[j].reactionValue.value.toString()=="Like"){
              countlike++;
            }
            if (postplayer1[i].reactions[j].reactionValue.value.toString()=="Dislike"){
              countdislike++;
            }
          }
        }
        //reaction in a coment of the player
        for (let j = 0; j < postplayer1[i].comments.length; j++) {
          if (postplayer1[i].comments[j].playerCreator.toString()==body.playerIdDest){
            for (let k = 0; k < postplayer1[i].comments[j].reactions.length; k++) {
              if (postplayer1[i].comments[j].reactions[k].playerId.toString()==body.playerIdOrigin){
                if (postplayer1[i].comments[j].reactions[k].reactionValue.value.toString()=="Like"){
                  countlike++;
                }
                if (postplayer1[i].comments[j].reactions[k].reactionValue.value.toString()=="Dislike"){
                  countdislike++;
                }
              }
            }
          }
        }
      }

      // reaction of post in the other player
      for (let i = 0; i < postplayer2.length; i++) {
        for (let j = 0; j < postplayer2[i].reactions.length; j++) {
          if (postplayer2[i].reactions[j].playerId.toString() == body.playerIdOrigin) {
            if (postplayer2[i].reactions[j].reactionValue.value.toString() == "Like") {
              countlike++;
            }
            if (postplayer2[i].reactions[j].reactionValue.value.toString() == "Dislike") {
              countdislike++;
            }
          }
        }
        //reaction in a coment of the player
        for (let j = 0; j < postplayer2[i].comments.length; j++) {
          if (postplayer2[i].comments[j].playerCreator.toString()==body.playerIdOrigin){
            for (let k = 0; k < postplayer2[i].comments[j].reactions.length; k++) {
              if (postplayer2[i].comments[j].reactions[k].playerId.toString()==body.playerIdDest){
                if (postplayer2[i].comments[j].reactions[k].reactionValue.value.toString()=="Like"){
                  countlike++;
                }
                if (postplayer2[i].comments[j].reactions[k].reactionValue.value.toString()=="Dislike"){
                  countdislike++;
                }
              }
            }
          }
        }
      }
      body.strength=(countlike-countdislike);
      return Result.ok<StrengthPLayersDTO>(body)
    }catch (e){
      throw e;
    }

  }
  public async newPost(postDTO: IPostDTO): Promise<Result<IPostDTO>> {
    try {
      const postOrError = await Post.create({
        postText: postDTO.postText,
        reactions: [],
        comments: [],
        creationDate: postDTO.creationDate,
        playerCreator: postDTO.playerCreator,
        tags: postDTO.tags,
      });


      if (postOrError.isFailure) {
        return Result.fail<IPostDTO>(postOrError.errorValue());
      }
      const createdPost = postOrError.getValue();

      await this.postRepo.save(createdPost);

      return Result.ok<IPostDTO>(PostMap.toDTO(createdPost) as IPostDTO)
    } catch (e) {
      throw e;
    }
  }

  public async addComment(postDTO: IPostDTO, commentDTO: ICommentDTO): Promise<Result<IPostDTO>> {
    try {
      let post: Post;
      const postOrError = await this.getPost(postDTO.id);
      if (postOrError.isFailure) {
        return Result.fail<IPostDTO>(postOrError.error);
      } else {
        post = postOrError.getValue();
      }


      const commentOrError = await Comment.create({
        reactions: [],
        playerCreator: commentDTO.playerCreator,
        commentText: commentDTO.commentText,
        creationDate: commentDTO.commentText,
      });


      if (commentOrError.isFailure) {
        return Result.fail<IPostDTO>(commentOrError.errorValue());
      }
      const createdComment = commentOrError.getValue();
      post.addComment(createdComment);
      await this.postRepo.save(post);
      return Result.ok<IPostDTO>(PostMap.toDTO(post) as IPostDTO)
    } catch (e) {
      throw e;
    }
  }
  public async addReaction(postDTO: IPostDTO, ReactionDTO: IReactionDTO): Promise<Result<IPostDTO>> {
    try {
      let post: Post;
      const postOrError= await this.getPost(postDTO.id);
      if (postOrError.isFailure) {
        return Result.fail<IPostDTO>(postOrError.error);
      } else {
        post = postOrError.getValue();
      }

      const reactionOrError=await Reaction.create({
        creationDate: ReactionDTO.creationDate,
        playerId: ReactionDTO.playerId,
        reactionValue:  ReactionValue.create(ReactionDTO.reactionValue).getValue()
      });

      if (reactionOrError.isFailure) {
        return Result.fail<IPostDTO>(reactionOrError.errorValue());
      }
      const createdReaction=reactionOrError.getValue();
      post.addReaction(createdReaction);

      await this.postRepo.save(post);
      return  Result.ok<IPostDTO>(PostMap.toDTO(post)as IPostDTO)
    }catch (e) {
      throw e;
    }
  }



  public async addReactionComment(param: IPostDTO, body: IReactionComentDTO): Promise<Result<IPostDTO>> {

    try {
      let post: Post;

      const postOrError= await this.getPost(param.id);
      if (postOrError.isFailure) {
        return Result.fail<IPostDTO>(postOrError.error);
      } else {
        post = postOrError.getValue();
      }

      for ( let i = 0; i < post.comments.length; i++) {
        if (post.comments[i].id.toString()==body.comentId){
          const reactionOrError=await Reaction.create({
            creationDate: body.creationDate,
            playerId: body.playerId,
            reactionValue:  ReactionValue.create(body.reactionValue).getValue()
          });
          post.comments[i].reactions.push(reactionOrError.getValue());
          break;
        }
      }

      await this.postRepo.save(post);
      return  Result.ok<IPostDTO>(PostMap.toDTO(post)as IPostDTO)
    }catch (e) {
      throw e;
    }
  }


  private async getPost (postId: string): Promise<Result<Post>> {
    const post = await this.postRepo.findByDomainId(postId);
    const found = !!post;

    if (found) {
      return Result.ok<Post>(post);
    } else {
      return Result.fail<Post>("Couldn't find post by id=" + post);
    }
  }









}
