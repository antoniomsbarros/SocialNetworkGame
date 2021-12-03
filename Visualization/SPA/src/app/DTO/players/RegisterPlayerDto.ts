import {EmotionalStatus} from "../../sign-in/sign-in.component";

export interface RegisterPlayerDto {
  email: string;
  password: string;
  phoneNumber: string;
  facebookProfile?: string;
  linkedinProfile?: string;
  dateOfBirth: Date;
  shortName?: string;
  fullName?: string;
  emotionalStatus: EmotionalStatus;
}
