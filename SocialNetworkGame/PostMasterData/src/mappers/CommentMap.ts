import { Container } from 'typedi';

import { Mapper } from "../core/infra/Mapper";
import { Document, Model } from 'mongoose';
import { UniqueEntityID } from "../core/domain/UniqueEntityID";
import { Comment } from "../domain/comment";
import { ICommentDTO } from "../dto/ICommentDTO";
import { ICommentPersistence } from "../dataschema/ICommentPersistence";
import PostRepo from "../repos/postRepo";
import { ReactionMap } from './ReactionMap';

export class CommentMap extends Mapper<Comment> {
  
  public static toDTO(comment: Comment): ICommentDTO {
    return {
      domainId: comment.id.toString(),
      reactions: comment.reactions ? comment.reactions.map(r => ReactionMap.toDTO(r)) : [],
      playerCreator: comment.playerCreator,
      commentText: comment.commentText,
      creationDate: comment.creationDate
    } as ICommentDTO;
  }




  public static async toDomain(rawComment: any | Model<ICommentPersistence & Document> ): Promise<Comment> {
    const repo = Container.get(PostRepo);
    const commentOrError = Comment.create({
        commentText: rawComment.commentText,
        reactions: rawComment.reactions ? await Promise.all(rawComment.reactions.map(async reaction => {
          return await repo.findReactionByDomainId(reaction.domainId);
        })) : [],
        creationDate: rawComment.creationDate,
        playerCreator: rawComment.playerCreator,
      }, new UniqueEntityID(rawComment.domainId)
    );


    commentOrError.isFailure ? console.log(commentOrError.error) : '';

    return commentOrError.isSuccess ? commentOrError.getValue() : null;
  }


  public static toPersistence (comment: Comment): any {
    return {
      domainId: comment.id.toString(),
      reactions: comment.reactions ? comment.reactions.map(r => r.id.toString()) : [],
      playerCreator: comment.playerCreator,
      commentText: comment.commentText,
      creationDate: comment.creationDate
    }
  }
}