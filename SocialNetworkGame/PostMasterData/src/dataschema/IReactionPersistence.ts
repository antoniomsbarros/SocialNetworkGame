import { ReactionValue } from "../domain/reactionValue";

export interface IReactionPersistence {
    domainId: string;
    reactionValue: string;
    creationDate: string;
    playerId: string;
}