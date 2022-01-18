import { Request, Response, NextFunction } from 'express';

export default interface IPostController  {
  getPlayerFeed(req: Request, res: Response, next: NextFunction);
  newPost(req: Request, res: Response, next: NextFunction);
  addComment(req: Request, res: Response, next: NextFunction);
  addReaction(req: Request, res: Response, next: NextFunction);
  addReactionComent(req: Request, res: Response, next: NextFunction);
  calculatestrenght(req: Request, res: Response, next: NextFunction);
}
