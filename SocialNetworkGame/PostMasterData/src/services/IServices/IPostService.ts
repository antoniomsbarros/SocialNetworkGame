import { Result } from "../../core/logic/Result";
import { ICommentDTO } from "../../dto/ICommentDTO";
import { IPostDTO } from "../../dto/IPostDTO";

export default interface IPostService  {
  getPlayerFeed(playerId: string): Promise<Result<IPostDTO[]>>;
  newPost(postDTO: IPostDTO): Promise<Result<IPostDTO>>;
  addComment(postDTO: IPostDTO, commentDTO: ICommentDTO): Promise<Result<IPostDTO>>;
}
