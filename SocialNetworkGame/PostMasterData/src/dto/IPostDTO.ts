import { ICommentDTO } from "./ICommentDTO";
import { IReactionDTO } from "./IReactionDTO";

export interface IPostDTO {
    id: string;
    postText: string;
    reactions: IReactionDTO[];
    comments: ICommentDTO[];
    creationDate: string;
    playerCreator: string;
    tags: string[];
  }
  