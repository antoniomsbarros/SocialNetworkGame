import { Router } from 'express';
import { celebrate, Joi } from 'celebrate';

import { Container } from 'typedi';

import config from "../../../config";
import IPostController from '../../controllers/IControllers/IPostController';

const route = Router();

export default (app: Router) => {
  app.use('/posts', route);

  const ctrl = Container.get(config.controllers.post.name) as IPostController;

  route.get('/:playerId', (req, res, next) => ctrl.getPlayerFeed(req, res, next));
  route.post('', (req, res, next) => ctrl.newPost(req, res, next))
  route.post('/:postId/comments', (req, res, next) => ctrl.addComment(req, res, next))
  route.post("/:postId/reactions",(req, res, next) => ctrl.addReaction(req, res, next))
  route.post("/:postId/comments/reactions",(req, res, next) => ctrl.addReactionComent(req, res, next))
  route.post("/calculatestrengh",(req, res, next) => ctrl.calculatestrenght(req, res, next) )
};
