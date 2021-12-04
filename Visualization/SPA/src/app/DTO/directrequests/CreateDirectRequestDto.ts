export interface CreateDirectRequestDto {
  playerSender: string;
  playerReceiver: string;
  text: string;
  connectionStrength: number;
  tags: string[];
}
