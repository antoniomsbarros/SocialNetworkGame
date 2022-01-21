import {ReactionDto} from "./ReactionDto";
import {CommentDto} from "./CommentDto";

export interface PostDto {
  id: string;
  postText: string;
  reactions: ReactionDto[];
  comments: CommentDto[];
  creationDate: string;
  playerCreator: string;
  tags: string[];
}
