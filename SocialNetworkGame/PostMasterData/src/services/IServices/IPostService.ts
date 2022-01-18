import { Result } from "../../core/logic/Result";
import { ICommentDTO } from "../../dto/ICommentDTO";
import { IPostDTO } from "../../dto/IPostDTO";
import {IReactionDTO} from "../../dto/IReactionDTO";
import {IReactionComentDTO} from "../../dto/IReactionComentDTO";
import {StrengthPLayersDTO} from "../../dto/StrengthPLayersDTO";

export default interface IPostService  {
  getPlayerFeed(playerId: string): Promise<Result<IPostDTO[]>>;
  newPost(postDTO: IPostDTO): Promise<Result<IPostDTO>>;
  addComment(postDTO: IPostDTO, commentDTO: ICommentDTO): Promise<Result<IPostDTO>>;
  addReaction(postDTO: IPostDTO, ReactionDTO: IReactionDTO): Promise<Result<IPostDTO>>;
  addReactionComment(param: IPostDTO, body: IReactionComentDTO): Promise<Result<IPostDTO>>;
  getstrength(body: StrengthPLayersDTO): Promise<Result<StrengthPLayersDTO>>;
}
