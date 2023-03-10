import { Container } from 'typedi';

import { Mapper } from "../core/infra/Mapper";

import { Document, Model } from 'mongoose';
import { IPostPersistence } from "../dataschema/IPostPersistence";
import { UniqueEntityID } from "../core/domain/UniqueEntityID";

import { IPostDTO } from "../dto/IPostDTO";
import { Post } from "../domain/post";
import PostRepo from "../repos/postRepo";
import { CommentMap } from './CommentMap';
import {ReactionMap} from "./ReactionMap";

export class PostMap extends Mapper<Post> {

  public static toDTO(post: Post): IPostDTO {
    return {
      id: post.id.toString(),
      postText: post.postText,
      creationDate: post.creationDate,
      playerCreator: post.playerCreator,
      reactions: post.reactions ? post.reactions.map(r => ReactionMap.toDTO(r)) : [],
      comments: post.comments ? post.comments.map(r => CommentMap.toDTO(r)) : [],
      tags: post.tags
    } as IPostDTO;
  }

  public static async toDomain (rawPost: any | Model<IPostPersistence & Document> ): Promise<Post> {
    const repo = Container.get(PostRepo);
    const postOrError = Post.create({
        postText: rawPost.postText,
        reactions: rawPost.reactions ? await Promise.all(rawPost.reactions.map(async reaction => {
          return await repo.findReactionByDomainId(reaction.domainId);
        })) : [],
        comments: rawPost.comments ? await Promise.all(rawPost.comments.map(async comment => {
          return await repo.findCommentByDomainId(comment.domainId);
        })) : [],

        creationDate: rawPost.creationDate,
        playerCreator: rawPost.playerCreator,
        tags: rawPost.tags
      }, new UniqueEntityID(rawPost.domainId)
    );

    postOrError.isFailure ? console.log(postOrError.error) : '';

    return postOrError.isSuccess ? postOrError.getValue() : null;
  }

  public static toPersistence (post: Post): any {
    return {
      domainId: post.id.toString(),
      postText: post.postText,
      creationDate: post.creationDate,
      playerCreator: post.playerCreator,
      reactions: post.reactions ? post.reactions.map(reaction => reaction.id.toString()): [],
      comments: post.comments ? post.comments.map(comment => comment.id.toString()) : [],
      tags: post.tags
    }
  }
}
