export interface NetworkFromPlayerPerspectiveDto {
  playerTags: any;
  playerId: string;
  playerName: string;
  emotionalStatus: string;
  relationshipStrength:number;
  relationshipId: string;
  RelationshipTags: string[];
  relationships: NetworkFromPlayerPerspectiveDto[];
}
