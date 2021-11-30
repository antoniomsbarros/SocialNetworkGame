export interface ConnectionIntroductionDTO{
  id: string;
  connectionRequestStatus: string;
  playerSender:string;
  playerReceiver:string;
  text:string;
  creationDate:string;
  textIntroduction:string;
  playerIntroduction:string;
  introductionStatus: string;
  connectionStrengthConf : number;
  tags:string[];

}
