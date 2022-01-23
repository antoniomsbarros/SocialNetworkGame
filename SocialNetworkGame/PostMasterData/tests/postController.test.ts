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


describe('test post controller', function () {
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

	it('create new post', async function () {
		this.timeout(100000)
		let body = {
			postText: "test text",
			playerCreator: "test_player@email.com",
			tags: ["tag1", "tag2"],
		};

		let req: Partial<Request> = {};
		req.body = body;

		let res: Partial<Response> = {
			json: sinon.spy()
		};
		let next: Partial<NextFunction> = () => { };

		let fakeRes = {
			id: "11123123213",
			postText: req.body.postText,
			reactions: [],
			comments: [],
			creationDate: "1642174376.629",
			playerCreator: req.body.playerCreator,
			tags: req.body.tags,
		}




		let postServiceClass = require("../src/services/postService").default;
		let postServiceInstance = Container.get(postServiceClass);
		Container.set(config.services.post.name, postServiceInstance);


		postServiceInstance = Container.get("PostService");
		sinon.stub(postServiceInstance, "newPost").returns(Result.ok<IPostDTO>(fakeRes))


		const ctrl = new PostController(postServiceInstance as IPostService);
		await ctrl.newPost(<Request>req, <Response>res, <NextFunction>next);


		sinon.assert.calledOnce(res.json);
		sinon.assert.calledWith(res.json, sinon.match(fakeRes));

		await Promise.resolve();
	})

	it('add new comment', async function () {
		this.timeout(100000)
		let body = {
			playerCreator: "test_player@email.com",
			commentText: "test comment",
		}

		let req: Partial<Request> = {};
		req.body = body;
		req.params = {
			postId: "11123123213"
		}

		let res: Partial<Response> = {
			json: sinon.spy()
		};
		let next: Partial<NextFunction> = () => { };

		let fakeRes = {
			id: "11123123213",
			postText: req.body.postText,
			reactions: [],
			comments: [{
				domainId: "1123132",
				reactions: [],
				playerCreator: "test_player@email.com",
				commentText: "test comment",
				creationDate: "11123123213"
			}],
			creationDate: "1642174376.629",
			playerCreator: req.body.playerCreator,
			tags: req.body.tags,
		}

		let postServiceClass = require("../src/services/postService").default;
		let postServiceInstance = Container.get(postServiceClass);
		Container.set(config.services.post.name, postServiceInstance);

		postServiceInstance = Container.get("PostService");
		sinon.stub(postServiceInstance, "addComment").returns(Result.ok<IPostDTO>(fakeRes))

		const ctrl = new PostController(postServiceInstance as IPostService);
		await ctrl.addComment(<Request>req, <Response>res, <NextFunction>next);


		sinon.assert.calledOnce(res.json);
		sinon.assert.calledWith(res.json, sinon.match(fakeRes));

		await Promise.resolve();
	});



	it('get player feed', async function () {
		this.timeout(100000)

		let req: Partial<Request> = {};
		req.params = {
			playerId: "test_player@email.com"
		}

		let res: Partial<Response> = {
			json: sinon.spy()
		};
		let next: Partial<NextFunction> = () => { };

		let fakeRes = [{
			id: "11123123213",
			postText: "text test",
			reactions: [],
			comments: [],
			creationDate: "1642174376.629",
			playerCreator: "test_player@email.com",
			tags: ["a", "b"],
		}]

		let postServiceClass = require("../src/services/postService").default;
		let postServiceInstance = Container.get(postServiceClass);
		Container.set(config.services.post.name, postServiceInstance);

		postServiceInstance = Container.get("PostService");
		sinon.stub(postServiceInstance, "getPlayerFeed").returns(Result.ok<IPostDTO[]>(fakeRes))

		const ctrl = new PostController(postServiceInstance as IPostService);
		await ctrl.getPlayerFeed(<Request>req, <Response>res, <NextFunction>next);


		sinon.assert.calledOnce(res.json);
		sinon.assert.calledWith(res.json, sinon.match(fakeRes));

		await Promise.resolve();
	});


});