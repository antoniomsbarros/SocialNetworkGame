import expressLoader from './express';
import dependencyInjectorLoader from './dependencyInjector';
import mongooseLoader from './mongoose';
import Logger from './logger';

import config from '../../config';

export default async ({ expressApp }) => {
  const mongoConnection = await mongooseLoader();
  Logger.info('✌️ DB loaded and connected!');



  const postSchema = {
    name: 'postSchema',
    schema: '../persistence/schemas/postSchema'
  }

  const commentSchema = {
    name: 'commentSchema',
    schema: '../persistence/schemas/commentSchema'
  };

  const reactionSchema = {
    name: 'reactionSchema',
    schema: '../persistence/schemas/reactionSchema'
  };



  const postController = {
    name: config.controllers.post.name,
    path: config.controllers.post.path
  }



  const postRepo = {
    name: config.repos.post.name,
    path: config.repos.post.path
  }



  const postService = {
    name: config.services.post.name,
    path: config.services.post.path
  }

  await dependencyInjectorLoader({
    mongoConnection,
    schemas: [
      postSchema,
      reactionSchema,
      commentSchema
    ],
    controllers: [
      postController
    ],
    repos: [
      postRepo
    ],
    services: [
      postService
    ]
  });
  Logger.info('✌️ Schemas, Controllers, Repositories, Services, etc. loaded');

  await expressLoader({ app: expressApp });
  Logger.info('✌️ Express loaded');
};
