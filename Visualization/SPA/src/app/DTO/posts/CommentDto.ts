import {ReactionDto} from "./ReactionDto";

export interface CommentDto {
  domainId: string;
  reactions: ReactionDto[];
  playerCreator: string;
  commentText: string;
  creationDate: string;
}
