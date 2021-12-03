export interface CreateIntroductionRequestDto{
    PlayerSender:string;

    PlayerReceiver:string;

    Text:string;

    TextIntroduction:string;

    PlayerIntroduction:string;

    ConnectionStrength:number;
    Tags:string[];
}
