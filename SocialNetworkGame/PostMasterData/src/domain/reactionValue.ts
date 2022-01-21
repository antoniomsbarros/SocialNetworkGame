import { ValueObject } from "../core/domain/ValueObject";
import { Result } from "../core/logic/Result";
import { Guard } from "../core/logic/Guard";

enum ReactionValueEnum {
  Like = 0,
  Dislike = 1
}


interface ReactionValueProps {
  reaction: ReactionValueEnum
}

export class ReactionValue extends ValueObject<ReactionValueProps> {
  get value (): ReactionValueEnum {
    return this.props.reaction;
  }

  private constructor (props: ReactionValueProps) {
    super(props);
  }

  public static create(reactionValue: string): Result<ReactionValue> {
    const guardResult = Guard.againstNullOrUndefined(reactionValue, 'reaction');
    if (!guardResult.succeeded) {
      return Result.fail<ReactionValue>(guardResult.message);
    } else {
      return Result.ok<ReactionValue>(new ReactionValue({
        reaction: ReactionValueEnum[reactionValue]
      }))
    }
  }


  public equals(vo: ReactionValue): boolean {
    return this.props.reaction.toString() == ReactionValueEnum[vo.props.reaction];
  }

}
