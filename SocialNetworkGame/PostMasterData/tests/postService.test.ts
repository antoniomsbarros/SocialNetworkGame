import 'reflect-metadata';

import * as sinon from 'sinon';
import { Response, Request, NextFunction } from 'express';
import { Container } from 'typedi';
import config from "../config";
import IPostService from '../src/services/IServices/IPostService';
import PostController from '../src/controllers/PostController';
import { Result } from '../src/core/logic/Result';
import { IPostDTO } from '../src/dto/IPostDTO';
import LoggerInstance from '../src/loaders/logger';

import IPostRepo from "../src/services/IRepos/IPostRepo"
import PostService from '../src/services/postService';
import { PostMap } from '../src/mappers/PostMap';


describe('post service test', () => {
  beforeEach(function () {
		this.timeout(100000)

		Container.set('logger', LoggerInstance);

		const postSchema = {
			name: 'postSchema',
			schema: '../src/persistence/schemas/postSchema'
		}

		const commentSchema = {
			name: 'commentSchema',
			schema: '../src/persistence/schemas/commentSchema'
		};

		const reactionSchema = {
			name: 'reactionSchema',
			schema: '../src/persistence/schemas/reactionSchema'
		};

		const schemas = [
			postSchema,
			reactionSchema,
			commentSchema
		];

		const postRepo = {
			name: config.repos.post.name,
			path: "../src/repos/postRepo"
		}

		const repos = [postRepo]

		schemas.forEach(m => {
			let schema = require(m.schema).default;
			Container.set(m.name, schema);
		});


		repos.forEach(m => {
			let repoClass = require(m.path).default;
			let repoInstance = Container.get(repoClass);
			Container.set(m.name, repoInstance);
		});

	});



  it('get player feed', async function () {
    this.timeout(100000)

		let fakeRes = [{
			id: "11123123213",
			postText: "text test",
			reactions: [],
			comments: [],
			creationDate: "1642174376.629",
			playerCreator: "test_player@email.com",
			tags: ["a", "b"],
		}]

    let postRepo = Container.get("PostRepo");

    const service = new PostService(postRepo as IPostRepo);

		let req: Partial<Request> = {};
		req.params = {
			playerId: "test_player@email.com"
		}

		let res: Partial<Response> = {
			json: sinon.spy()
		};
		let next: Partial<NextFunction> = () => { };

		const ctrl = new PostController(service as IPostService);
		await ctrl.getPlayerFeed(<Request>req, <Response>res, <NextFunction>next);


		sinon.assert.calledOnce(res.json);
		sinon.assert.calledWith(res.json, sinon.match(fakeRes));

	});

});