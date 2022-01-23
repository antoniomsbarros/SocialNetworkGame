export interface DirectRequestDto {
  id: string;
  playerSender: string;
  playerReceiver: string;
  text: string;
  connectionStrength: number;
  tags: string[];
  connectionRequestStatus: number;
}
