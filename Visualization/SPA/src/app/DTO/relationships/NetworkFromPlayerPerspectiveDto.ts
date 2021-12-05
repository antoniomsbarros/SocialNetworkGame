export interface NetworkFromPlayerPerspectiveDto {
  relationshipId: string;
  relationshipStrength: number;
  RelationshipTags: string[];
  playerId: string;
  playerName: string;
  playerTags: string[];
  relationships: NetworkFromPlayerPerspectiveDto[];
}
