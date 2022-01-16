import * as sinon from 'sinon';

import { Response, Request, NextFunction } from 'express';

import { Container } from 'typedi';
import config from "../../config";

import { Result } from '../core/logic/Result';

import IPostService from '../services/IServices/IPostService';
import PostController from './PostController';
import { IPostDTO } from '../dto/IPostDTO';

describe('post controller', function () {
	beforeEach(function() {
    });

    it('createRole: returns json with id+name values', async function () {
        let body = { "name":'role12' };
        let req: Partial<Request> = {};
		req.body = body;

        let res: Partial<Response> = {
			json: sinon.spy()
        };
		let next: Partial<NextFunction> = () => {};

		let roleServiceClass = require(config.services.role.path).default;
		let roleServiceInstance = Container.get(roleServiceClass)
		Container.set(config.services.role.name, roleServiceInstance);

		roleServiceInstance = Container.get(config.services.role.name);
		//sinon.stub(roleServiceInstance, "createRole").returns( Result.ok<IPostDTO>( {"id":"123", "name": req.body.name} ));

		const ctrl = new PostController(roleServiceInstance as IPostService);

		//await ctrl.createRole(<Request>req, <Response>res, <NextFunction>next);

		sinon.assert.calledOnce(res.json);
		sinon.assert.calledWith(res.json, sinon.match({ "id": "123","name": req.body.name}));
	});
});