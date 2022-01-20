import { Entity } from "../core/domain/Entity";
import { ReactionValue } from "./reactionValue";
import { UniqueEntityID } from "../core/domain/UniqueEntityID";
import { Result } from "../core/logic/Result";
import { Guard } from "../core/logic/Guard";


interface ReactionProps {
    reactionValue: ReactionValue;
    creationDate: string;
    playerId: string;
}

export class Reaction extends Entity<ReactionProps> {
  private constructor (props: ReactionProps, id?: UniqueEntityID) {
    super(props, id);
  }

  get id (): UniqueEntityID {
    return this._id;
  }

  get reactionValue(): ReactionValue {
    return this.props.reactionValue;
  }

  get creationDate(): string {
    return this.props.creationDate;
  }

  get playerId(): string {
    return this.props.playerId;
  }


  public static create(props: ReactionProps, id?: UniqueEntityID): Result<Reaction> {
    const guardedProps = [
      { argument: props.reactionValue, argumentName: 'reactionValue' },
      { argument: props.creationDate, argumentName: 'creationDate' },
      { argument: props.playerId, argumentName: 'playerId' },
    ];

    const guardResult = Guard.againstNullOrUndefinedBulk(guardedProps);

    if (!guardResult.succeeded) {
      return Result.fail<Reaction>(guardResult.message)
    }
    else {
      const reaction = new Reaction({
        ...props
      }, id);

      return Result.ok<Reaction>(reaction);
    }
  }


}
