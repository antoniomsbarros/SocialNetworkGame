import mongoose from 'mongoose';
import { Schema } from "mongoose";
import { IReactionPersistence } from '../../dataschema/IReactionPersistence';
import { ReactionValue } from '../../domain/reactionValue';


const ReactionSchema = new mongoose.Schema(
  {
    domainId: { type: String, unique: true },
    playerId: { type: String },
    creationDate: { type: String },
    reactionValue: { type: String }
  },
  {
    timestamps: true
  }
);

export default mongoose.model<IReactionPersistence & mongoose.Document>('Reaction', ReactionSchema);
