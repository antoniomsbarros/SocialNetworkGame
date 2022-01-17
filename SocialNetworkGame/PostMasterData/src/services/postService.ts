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
      //console.log(reactionOrError)
      if (reactionOrError.isFailure) {
        return Result.fail<IPostDTO>(reactionOrError.errorValue());
      }
      const createdReaction=reactionOrError.getValue();
      post.addReaction(createdReaction);

      await this.postRepo.save(post);
      console.log(post)
      return  Result.ok<IPostDTO>(PostMap.toDTO(post)as IPostDTO)
    }catch (e) {
      throw e;
    }
  }



  public async addReactionComment(param: IPostDTO, body: IReactionComentDTO): Promise<Result<IPostDTO>> {
    return Promise.resolve(undefined);
    try {
      let post: Post;
      const postOrError= await this.getPost(param.id);
      if (postOrError.isFailure) {
        return Result.fail<IPostDTO>(postOrError.error);
      } else {
        post = postOrError.getValue();
      }
    let coment: Comment;


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
  private  getComent(postDTO: IPostDTO, comentid:string):ICommentDTO{

      return  postDTO.comments.find(item=>item.domainId===comentid);



  }







}
