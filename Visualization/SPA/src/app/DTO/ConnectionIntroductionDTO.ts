export interface ConnectionIntroductionDTO{
  id: string;
  connectionRequestStatus: number;
  playerSender:string;
  playerReceiver:string;
  text:string;
  creationDate:string;
  textIntroduction:string;
  playerIntroduction:string;
  introductionStatus: number;
  connectionStrengthConf : number;
  tags:string[];
}
