import mongoose from 'mongoose';
import { ICommentPersistence } from '../../dataschema/ICommentPersistence';
import { Schema } from "mongoose";


const CommentSchema = new mongoose.Schema(
  {
    domainId: { type: String, unique: true },
    reactions: [{ type: Schema.Types.ObjectId, ref: "Reaction"}],
    playerCreator: { type: String },
    commentText: { type: String },
    creationDate: { type: String },
  },
  {
    timestamps: true
  }
);

export default mongoose.model<ICommentPersistence & mongoose.Document>('Comment', CommentSchema);
