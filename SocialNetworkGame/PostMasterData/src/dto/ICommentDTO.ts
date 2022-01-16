
  export interface ICommentDTO {
      domainId: string;
      reactions: string[]; // TODO populate reaction DTO
      playerCreator: string;
      commentText: string;
      creationDate: string;
  }
  