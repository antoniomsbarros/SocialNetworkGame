﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.services.connectionRequests
{
    public class DirectRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDirectRequestRepository _repo;

        public DirectRequestService(IUnitOfWork unitOfWork, IDirectRequestRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<List<DirectRequestDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.ConvertAll<DirectRequestDTO>(directRequest => directRequest.ToDto());
        }

        public async Task<DirectRequestDTO> AddAsync(CreateDirectRequestDto directRequestDto)
        {
            DirectRequest directRequest = new(new PlayerId(directRequestDto.PlayerSender),
                new PlayerId(directRequestDto.PlayerReceiver), TextBox.ValueOf(directRequestDto.Text),
                ConnectionStrenght.ValueOf(directRequestDto.ConnectionStrength),
                directRequestDto.Tags.ConvertAll(tags => Tag.ValueOf(tags)));

            await _repo.AddAsync(directRequest);
            await _unitOfWork.CommitAsync();

            return directRequest.ToDto();
        }
    }
}