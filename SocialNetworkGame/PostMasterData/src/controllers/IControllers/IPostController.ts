import { Request, Response, NextFunction } from 'express';

export default interface IPostController  {
  getPlayerFeed(req: Request, res: Response, next: NextFunction);
  newPost(req: Request, res: Response, next: NextFunction);
  addComment(req: Request, res: Response, next: NextFunction);
}