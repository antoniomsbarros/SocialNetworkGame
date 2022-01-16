import { Types, Document } from "mongoose";
import { Comment } from "../domain/comment";
import { Reaction } from "../domain/reaction";
import { ICommentPersistence } from "./ICommentPersistence";
import { IReactionPersistence } from "./IReactionPersistence";

export interface IPostPersistence {
    domainId: string;
    postText: string;
    reactions: Document["_id"][];
    comments: Document["_id"][];
    creationDate: string;
    playerCreator: string;
    tags: string[];
}