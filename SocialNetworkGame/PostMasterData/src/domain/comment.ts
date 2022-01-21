import { Entity } from "../core/domain/Entity";
import { Reaction } from "./reaction"
import { UniqueEntityID } from "../core/domain/UniqueEntityID";
import { Result } from "../core/logic/Result";
import { Guard } from "../core/logic/Guard";

interface CommentProps {
    reactions: Reaction[],
    playerCreator: string;
    commentText: string;
    creationDate: string;
}

export class Comment extends Entity<CommentProps> {
  
  private constructor (props: CommentProps, id?: UniqueEntityID) {
    super(props, id);
  }


  get id (): UniqueEntityID {
    return this._id;
  }


  get reactions(): Reaction[] {
    return this.props.reactions;
  }

  get playerCreator(): string {
    return this.props.playerCreator;
  }

  get commentText(): string {
    return this.props.commentText;
  }

  get creationDate(): string {
    return this.props.creationDate;
  }


  public static create(props: CommentProps, id?: UniqueEntityID): Result<Comment> {
    const guardedProps = [
      { argument: props.reactions, argumentName: 'reactions' },
      { argument: props.playerCreator, argumentName: 'playerCreator' },
      { argument: props.commentText, argumentName: 'commentText' },
      { argument: props.creationDate, argumentName: 'creationDate' },
    ];

    const guardResult = Guard.againstNullOrUndefinedBulk(guardedProps);

    if (!guardResult.succeeded) {
      return Result.fail<Comment>(guardResult.message)
    }     
    else {
      const comment = new Comment({
        ...props
      }, id);

      return Result.ok<Comment>(comment);
    }
  }

  public addReaction(reaction:Reaction):boolean{
    if (this.props.reactions && this.props.reactions.includes(reaction)) {
      return false;
    }

    if (this.props.reactions) {
      for (let existingReaction of this.props.reactions) {
        if (existingReaction.playerId == reaction.playerId) {
          if (existingReaction.reactionValue.equals(reaction.reactionValue)) {
            this.removeReaction(reaction);
            return true;
          } else {
            this.removeReaction(reaction);
            this.props.reactions.push(reaction)
            return true;
          }
        }
      }
    }

    if (!this.props.reactions)
      this.props.reactions=[]

    this.props.reactions.push(reaction)
    return true;
  }

  public removeReaction(reaction: Reaction): void {
    for (let existingReaction of this.props.reactions) {
      if (existingReaction.props.playerId == reaction.playerId) {
        const index=this.props.reactions.indexOf(existingReaction, 0);
        if (index>-1){
          this.props.reactions.splice(index, 1);
        }
      }
    }
  }
}
