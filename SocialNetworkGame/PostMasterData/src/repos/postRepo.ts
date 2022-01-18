import { Service, Inject } from 'typedi';

import { Document, FilterQuery, Model, Types, Schema, ObjectId } from 'mongoose';
import { IPostPersistence } from '../dataschema/IPostPersistence';

import IPostRepo from '../services/IRepos/IPostRepo';
import { PostId } from '../domain/postId';
import { Post } from '../domain/post';
import { PostMap } from '../mappers/PostMap';
import { ICommentPersistence } from '../dataschema/ICommentPersistence';
import { CommentMap } from '../mappers/CommentMap';
import { Comment } from '../domain/comment';
import { ReactionMap } from '../mappers/ReactionMap';
import { IReactionPersistence } from '../dataschema/IReactionPersistence';
import {Reaction} from "../domain/reaction";

@Service()
export default class PostRepo implements IPostRepo {
  private models: any;

  constructor(
    @Inject('postSchema') private postSchema : Model<IPostPersistence & Document>,
    @Inject('commentSchema') private commentSchema : Model<ICommentPersistence & Document>,
    @Inject('reactionSchema') private reactionSchema : Model<IReactionPersistence & Document>,

    @Inject('logger') private logger
  ) { }

  private createBaseQuery (): any {
    return {
      where: {},
    }
  }

  public async exists (postId: PostId | string): Promise<boolean> {
    const idX = postId instanceof PostId ? (<PostId>postId).id.toValue() : postId;

    const query = { domainId: idX};
    const postDocument = await this.postSchema.findOne( query );

    return !!postDocument === true;
  }

  public async save (post: Post): Promise<Post> {
    const query = { domainId: post.id.toString() };

    const postDocument = await this.postSchema.findOne( query );

    try {
      if (postDocument === null ) {
        const rawPost: any = PostMap.toPersistence(post);

        const postCreated = await this.postSchema.create(rawPost);
        return PostMap.toDomain(postCreated);
      } else {
        postDocument.postText = post.postText;

        postDocument.reactions = await Promise.all(post.reactions.map(async (reaction) => {
          const reactionRecord = await this.reactionSchema.findOne({ domainId: reaction.id.toString() } as FilterQuery<IReactionPersistence & Document>);
          if (reactionRecord != null) {
            return reactionRecord._id;
          } else {
            let reactionCreated = await this.reactionSchema.create(ReactionMap.toPersistence(reaction));
            return reactionCreated._id;
          }
        }));

        postDocument.comments = await Promise.all(post.comments.map(async (comment) => {
          const commentRecord = await this.commentSchema.findOne({ domainId: comment.id.toString() } as FilterQuery<ICommentPersistence & Document>);

          if (commentRecord != null) {

            commentRecord.reactions=await  Promise.all(comment.reactions.map(async (reaction)=>{
              const reactionrecord=await this.reactionSchema.findOne({domainId:reaction.id.toString() }as FilterQuery<IReactionPersistence & Document>);
              if (reactionrecord != null) {
                return reactionrecord._id;
              } else {
                let reactionCreated = await this.reactionSchema.create(ReactionMap.toPersistence(reaction));
                return reactionCreated._id;
              }
            }))
             await this.commentSchema.findByIdAndUpdate(commentRecord._id, commentRecord);
            return commentRecord._id;
          } else {

            commentRecord.reactions=await  Promise.all(comment.reactions.map(async (reaction)=>{
              const reactionrecord=await this.reactionSchema.findOne({domainId:reaction.id.toString() }as FilterQuery<IReactionPersistence & Document>);

              if (reactionrecord != null) {
                return reactionrecord._id;
              } else {
                let reactionCreated = await this.reactionSchema.create(ReactionMap.toPersistence(reaction));
                return reactionCreated._id;
              }

            }))

            let commentCreated = await this.commentSchema.create(CommentMap.toPersistence(comment));
            return commentCreated._id;
          }
        }));
        console.log(postDocument.comments)
        postDocument.creationDate = post.creationDate;
        postDocument.playerCreator = post.playerCreator;
        postDocument.tags = Array.from(post.tags);

        await postDocument.save();
        return post;
      }
    } catch (err) {
      throw err;
    }
  }



  public async findByDomainId (postId: PostId | string): Promise<Post> {
    const query = { domainId: postId};
    const postRecord = await this.postSchema.findOne( query as FilterQuery<IPostPersistence & Document> ).populate("comments").populate("reactions");
    if( postRecord != null) {
      return PostMap.toDomain(postRecord);
    }
    else
      return null;
  }


  public async findPostsByPlayerId (playerId: string): Promise<Post[]> {
    const query = { playerCreator: playerId};
    const postRecords = await this.postSchema.find(query as FilterQuery<IPostPersistence & Document>).populate("comments").populate("reactions");
    if (postRecords != null) {
      return await Promise.all(postRecords.map(postRecord => PostMap.toDomain(postRecord)));
    }
    else
      return [];
  }



  public async findCommentById (commentId: ObjectId): Promise<Comment> {
    const query = { _id: commentId};
    const commentRecord = await this.commentSchema.findOne( query as FilterQuery<ICommentPersistence & Document> ).populate("reactions");
    if(commentRecord != null) {
      return CommentMap.toDomain(commentRecord);
    }
    else
      return null;
  }

  public async findCommentByDomainId (commentId: string): Promise<Comment> {
    const query = { domainId: commentId};
    const commentRecord = await this.commentSchema.findOne( query as FilterQuery<ICommentPersistence & Document> ).populate("reactions");
    if(commentRecord != null) {
      return CommentMap.toDomain(commentRecord);
    }
    else
      return null;
  }
  public async findReactionByDomainId(reactionId:string):Promise<Reaction>{
    const query={domainId:reactionId};

    const reactionRecord= await this.reactionSchema.findOne(query as FilterQuery<IReactionPersistence & Document>);
      if (reactionRecord!=null){
        return ReactionMap.toDomain(reactionRecord);
      }else {
        return null;
      }
  }
}
