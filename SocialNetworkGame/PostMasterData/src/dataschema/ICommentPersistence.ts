import { Schema, Document } from "mongoose";
import { Reaction } from "../domain/reaction";
import { IReactionPersistence } from "./IReactionPersistence";

export interface ICommentPersistence {
    domainId: string;
    reactions: Document["_id"][];
    playerCreator: string;
    commentText: string;
    creationDate: string;
}