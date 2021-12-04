import {EmotionalStatus} from "../../sign-in/sign-in.component";

export interface UpdateEmotionalStatusDto {
  email: string;
  emotionalStatus: EmotionalStatus;
}
