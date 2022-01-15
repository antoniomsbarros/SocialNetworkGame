export interface NetworkFromPlayerPerspectiveDto {
  playerTags: any;
  playerId: string;
  playerName: string;
  emotionalStatus: string;
  relationshipStrengthDest: number;
  relationshipStrengthOrig:number;
  relationshipId: string;
  RelationshipTags: string[];
  relationships: NetworkFromPlayerPerspectiveDto[];
}
