export interface DirectRequestDto {
  playerSender: string;
  playerReceiver: string;
  text: string;
  connectionStrength: number;
  tags: string[];
}
