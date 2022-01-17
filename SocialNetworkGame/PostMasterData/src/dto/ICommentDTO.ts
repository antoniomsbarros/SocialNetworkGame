import { IReactionDTO } from "./IReactionDTO";

  export interface ICommentDTO {
      domainId: string;
      reactions: IReactionDTO[];
      playerCreator: string;
      commentText: string;
      creationDate: string;
  }
  