import { Repo } from "../../core/infra/Repo";
import { Post } from "../../domain/post";
import { PostId } from "../../domain/postId";
import {CommentId} from "../../domain/commentId";
import {Comment} from "../../domain/comment";


export default interface IPostRepo extends Repo<Post> {
	save(post: Post): Promise<Post>;
	findByDomainId (postId: PostId | string): Promise<Post>
	findPostsByPlayerId (playerId: string): Promise<Post[]>

}
