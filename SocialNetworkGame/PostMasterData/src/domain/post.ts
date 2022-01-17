import { AggregateRoot } from "../core/domain/AggregateRoot";
import { Reaction } from "./reaction"
import { Comment } from "./comment"
import { UniqueEntityID } from "../core/domain/UniqueEntityID";
import { Result } from "../core/logic/Result";
import { Guard } from "../core/logic/Guard";


interface PostProps {
    postText: string;
    reactions: Reaction[];
    comments: Comment[];
    creationDate: string;
    playerCreator: string;
    tags: string[];

}


export class Post extends AggregateRoot<PostProps> {
    get id (): UniqueEntityID {
        return this._id;
    }

    get postText(): string {
      return this.props.postText;
    }

    get reactions(): Reaction[] {
      return this.props.reactions;
    }

    get comments(): Comment[] {
      return this.props.comments;
    }

    get creationDate(): string {
      return this.props.creationDate;
    }

    get playerCreator(): string {
      return this.props.playerCreator;
    }

    get tags(): string[] {
      return this.props.tags;
    }


    private constructor (props: PostProps, id?: UniqueEntityID) {
      super(props, id);
    }

    public static create(props: PostProps, id?: UniqueEntityID): Result<Post> {
      const guardedProps = [
        { argument: props.postText, argumentName: 'postText' },
        { argument: props.reactions, argumentName: 'reactions' },
        { argument: props.comments, argumentName: 'comments' },
        { argument: props.creationDate, argumentName: 'creationDate' },
        { argument: props.playerCreator, argumentName: 'playerCreator' },
        { argument: props.tags, argumentName: 'tags' }
      ];

      const guardResult = Guard.againstNullOrUndefinedBulk(guardedProps);

      if (!guardResult.succeeded) {
        return Result.fail<Post>(guardResult.message)
      }
      else {
        const post = new Post({
          ...props
        }, id);

        return Result.ok<Post>(post);
      }
    }

    public assignTag(tag: string): boolean {
      if (this.props.tags.includes(tag)) {
        return false;
      }
      this.props.tags.push(tag);
      return true;
    }

    public removeTag(tag: string): void {
      const index = this.props.tags.indexOf(tag, 0);
      if (index > -1) {
        this.props.tags.splice(index, 1);
      }
    }

    public addComment(comment: Comment): boolean {
      if (this.props.comments && this.props.comments.includes(comment)) {
        return false;
      }

      if (!this.props.comments)
        this.props.comments = []

      this.props.comments.push(comment);
      return true;
    }

    public removeComment(comment: Comment): void {
      const index = this.props.comments.indexOf(comment, 0);
      if (index > -1) {
        this.props.comments.splice(index, 1);
      }
    }
    public addReaction(reaction:Reaction):boolean{
      if (this.props.reactions && this.props.reactions.includes(reaction)) {
        return false;
      }
      if (!this.props.comments)
        this.props.reactions=[]

      this.props.reactions.push(reaction)
      return true;
    }

    public removeReaction(reaction:Reaction):void{
      const index=this.props.reactions.indexOf(reaction, 0);
      if (index>-1){
        this.props.reactions.splice(index, 1);
      }
    }

    // TODO addReaction, removeReaction

}


