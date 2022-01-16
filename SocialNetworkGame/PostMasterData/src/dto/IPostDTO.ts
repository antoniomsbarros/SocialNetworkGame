import { ICommentDTO } from "./ICommentDTO";

export interface IPostDTO {
    id: string;
    postText: string;
    reactions: string[]; // TODO populate reaction DTO
    comments: ICommentDTO[];
    creationDate: string;
    playerCreator: string;
    tags: string[];
  }
  