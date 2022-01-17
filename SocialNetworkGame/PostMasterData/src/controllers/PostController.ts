import { Request, Response, NextFunction } from 'express';
import { Inject, Service } from 'typedi';
import config from "../../config";


import { Result } from "../core/logic/Result";
import IPostController from './IControllers/IPostController';
import IPostService from '../services/IServices/IPostService';
import { IPostDTO } from '../dto/IPostDTO';
import { ICommentDTO } from '../dto/ICommentDTO';
import {IReactionDTO} from "../dto/IReactionDTO";
import {IReactionComentDTO} from "../dto/IReactionComentDTO";

@Service()
export default class PostController implements IPostController /* TODO: extends ../core/infra/BaseController */ {
  constructor(
      @Inject(config.services.post.name) private postServiceInstance : IPostService
  ) {}

  public async getPlayerFeed(req: Request, res: Response, next: NextFunction) {
    try {
      const playerId = req.params.playerId;
      const postsOrError = await this.postServiceInstance.getPlayerFeed(playerId) as Result<IPostDTO[]>;

      if (postsOrError.isFailure) {
        return res.status(402).send();
      }
      const postDTO = postsOrError.getValue();
      return res.json(postDTO).status(200);
    }
    catch (e) {
      return next(e);
    }
  };

  public async newPost(req: Request, res: Response, next: NextFunction) {
    try {
      const postOrError = await this.postServiceInstance.newPost(req.body as IPostDTO) as Result<IPostDTO>;

      if (postOrError.isFailure) {
        return res.status(409).send();
      }

      const postDTO = postOrError.getValue();
      return res.json(postDTO).status(200);
    }
    catch (e) {
      return next(e);
    }
  }

  public async addComment(req: Request, res: Response, next: NextFunction) {
    try {
      const postOrError = await this.postServiceInstance.addComment({
        id: req.params.postId
      } as IPostDTO, req.body as ICommentDTO) as Result<IPostDTO>;

      if (postOrError.isFailure) {
        return res.status(409).send();
      }

      const postDTO = postOrError.getValue();
      return res.json(postDTO).status(200);
    }
    catch (e) {
      return next(e);
    }
  }

  public async addReaction(req: Request, res: Response, next: NextFunction) {
    try {
      const postORError=await this.postServiceInstance.addReaction({
        id:req.params.postId
      }as IPostDTO, req.body as IReactionDTO) as Result<IPostDTO>;

      if (postORError.isFailure) {
        return res.status(409).send();
      }
      const  postDTO=postORError.getValue();
      return  res.json(postDTO).status(200);
    }catch (e) {
      return next(e);
    }
  }

  public async addReactionComent(req: Request, res: Response, next: NextFunction) {
    try {
      const postORError=await this.postServiceInstance.addReactionComment({
        id:req.params.postId
      }as IPostDTO, req.body as IReactionComentDTO) as Result<IPostDTO>;

      if (postORError.isFailure) {
        return res.status(409).send();
      }
      const  postDTO=postORError.getValue();
      return  res.json(postDTO).status(200);
    }catch (e) {
      return next(e)
    }

  }


}
