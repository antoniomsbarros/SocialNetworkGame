using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.players;

namespace SocialNetwork.core.services.connectionRequests
{
    public class IntroductionRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntroductionRequestRepository _repository;
        private readonly PlayerService _playerService;
        public IntroductionRequestService(IUnitOfWork _unitOfWork1, IIntroductionRequestRepository _repository1,
            PlayerService playerService)
        {
            _unitOfWork = _unitOfWork1;
            _repository = _repository1;
            _playerService = playerService;
        }

        public async Task<List<ConnectionIntroductionDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            

            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Text,_playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(), _playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrenghtsender.Strenght, cat.Dto().Tags));
            return dtos;
        }
        
        
        public async Task<List<ConnectionIntroductionDTO>> GetAllPendingIntroduction(string playerIntroductionemail)
        {
            var playerIntroduction= await _playerService.GetByEmailAsync(new Email(playerIntroductionemail));
            if (playerIntroduction==null)
            {
                return null;
            }
            var list = await Task.Run(() => _repository.GetAllPendingIntroductionAsync(new PlayerId(playerIntroduction.id)));
            
            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Text,_playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email ,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(),_playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrenghtsender.Strenght, cat.Dto().Tags));
            return dtos;
        }

        public async Task<ConnectionIntroductionDTO> GetByIdAsync(ConnectionRequestId connectionRequestId)
        {
            var cat = await this._repository.GetByIdAsync(connectionRequestId);
            if (cat == null)
                return null;

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(),
                cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(),
                cat.PlayerReceiver.AsString(),
                cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrenghtsender.Strenght, cat.Dto().Tags);
        }

        public async Task<ConnectionIntroductionDTO> UpdateIntroductionStatus(
            ConnectionIntroductionDTO connectionIntroductionDto)
        {
            var cat = await _repository.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto.Id));
            if (cat == null)
            {
                return null;
            }

            ConnectionRequestStatusEnum statusEnum =
                (ConnectionRequestStatusEnum) Enum.Parse(typeof(ConnectionRequestStatusEnum),
                    connectionIntroductionDto.IntroductionStatus);
            cat.ChangeIntroductionStatus(new ConnectionRequestStatus(statusEnum));
            await _unitOfWork.CommitAsync();
            
            return new ConnectionIntroductionDTO(cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(),
                cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(),
                cat.PlayerReceiver.AsString(),
                cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrenghtsender.Strenght, cat.Dto().Tags);
        }

        public async Task<ConnectionIntroductionDTO> UpdateAsync(ConnectionIntroductionDTO connectionIntroductionDto)
        {
            var introductionRequest =
                await _repository.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto.Id));

            if (introductionRequest==null)
            {
                return null;
            }
            ConnectionRequestStatusEnum statusEnum =
                (ConnectionRequestStatusEnum) Enum.Parse(typeof(ConnectionRequestStatusEnum),
                    connectionIntroductionDto.IntroductionStatus);
            
            ConnectionRequestStatusEnum statusEnum1 =
                (ConnectionRequestStatusEnum) Enum.Parse(typeof(ConnectionRequestStatusEnum),
                    connectionIntroductionDto.ConnectionRequestStatus);
            
            introductionRequest.ChangeIntroductionStatus(new ConnectionRequestStatus(statusEnum));
            introductionRequest.ChangePlayerIntroduction(new PlayerId(connectionIntroductionDto.PlayerIntroduction));
            introductionRequest.ChangeTextIntroduction(new TextBox(connectionIntroductionDto.TextIntroduction));
            introductionRequest.ChangeStatus(new ConnectionRequestStatus(statusEnum1));
            introductionRequest.ChangeTags(connectionIntroductionDto.Tags);
            introductionRequest.ChangeText(new TextBox(connectionIntroductionDto.Text));
            introductionRequest.ChangeConnectionStrenght(new ConnectionStrenght(connectionIntroductionDto.ConnectionStrenght));
            introductionRequest.ChangeCreationDate(new CreationDate(connectionIntroductionDto.CreationDate));
            introductionRequest.ChangePlayerSender(new PlayerId(connectionIntroductionDto.PlayerSender));
            introductionRequest.ChangePLayerRecever(new PlayerId(connectionIntroductionDto.PlayerReceiver));
            
            await _unitOfWork.CommitAsync();
            
            return introductionRequest.Dto();
        }

    }
}