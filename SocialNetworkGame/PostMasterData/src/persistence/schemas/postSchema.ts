import mongoose from 'mongoose';
import { Schema } from "mongoose";
import { IPostPersistence } from '../../dataschema/IPostPersistence';


const PostSchema = new mongoose.Schema(
  {
    domainId: { type: String, unique: true },
    reactions: [{ type: Schema.Types.ObjectId, ref: 'Reaction' }],
    comments: [{ type: Schema.Types.ObjectId, ref: 'Comment' }],
    tags: { type: [String] },
    playerCreator: { type: String },
    creationDate: { type: String },
    postText: { type: String },
  },
  {
    timestamps: true
  }
);

export default mongoose.model<IPostPersistence & mongoose.Document>('Post', PostSchema);
