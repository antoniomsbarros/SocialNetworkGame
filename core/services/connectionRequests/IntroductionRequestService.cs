using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.players;

namespace SocialNetwork.core.services.connectionRequests
{
    public class IntroductionRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntroductionRequestRepository _repository1;
        private readonly PlayerService _playerService;

        public IntroductionRequestService(IUnitOfWork unitOfWork1, IIntroductionRequestRepository repository1,
            PlayerService playerService)
        {
            _unitOfWork = unitOfWork1;
            _repository1 = repository1;
            _playerService = playerService;
        }

        public async Task<List<ConnectionIntroductionDTO>> GetAllAsync()
        {
            var list = await _repository1.GetAllAsync();


            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Text,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(),
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrengthSender.Strenght,
                    cat.ToDto().Tags));
            return dtos;
        }


        public async Task<List<ConnectionIntroductionDTO>> GetAllPendingIntroduction(string playerIntroductionemail)
        {
            var playerIntroduction = await _playerService.GetByEmailAsync(new Email(playerIntroductionemail));
            if (playerIntroduction == null)
            {
                return null;
            }

            var list = await Task.Run(() =>
                _repository1.GetAllPendingIntroductionAsync(new PlayerId(playerIntroduction.id)));

            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Text,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(),
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrengthSender.Strenght,
                    cat.ToDto().Tags));
            return dtos;
        }

        public async Task<ConnectionIntroductionDTO> GetByIdAsync(ConnectionRequestId connectionRequestId)
        {
            var cat = await this._repository1.GetByIdAsync(connectionRequestId);
            if (cat == null)
                return null;

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(),
                cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(),
                cat.PlayerReceiver.AsString(),
                cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrengthSender.Strenght, cat.ToDto().Tags);
        }

        public async Task<ConnectionIntroductionDTO> UpdateIntroductionStatus(
            ConnectionIntroductionDTO connectionIntroductionDto)
        {
            var cat = await _repository1.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto.Id));
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
                cat.Text.Text, cat.CreationDate.ToString(), cat.ConnectionStrengthSender.Strenght, cat.ToDto().Tags);
        }

        public async Task<ConnectionIntroductionDTO> UpdateAsync(ConnectionIntroductionDTO connectionIntroductionDto)
        {
            var introductionRequest =
                await _repository1.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto.Id));

            if (introductionRequest == null)
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
            introductionRequest.ChangeConnectionStrenght(
                new ConnectionStrenght(connectionIntroductionDto.ConnectionStrength));
            introductionRequest.ChangeCreationDate(new CreationDate(connectionIntroductionDto.CreationDate));
            introductionRequest.ChangePlayerSender(new PlayerId(connectionIntroductionDto.PlayerSender));
            introductionRequest.ChangePLayerReceiver(new PlayerId(connectionIntroductionDto.PlayerReceiver));

            await _unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }


        public async Task<ConnectionIntroductionDTO> AddIntroduction(
            CreateConnectionIntroductionDTO connectionIntroductionDto)
        {
            ConnectionRequestStatus connectionRequestStatus =
                new ConnectionRequestStatus(ConnectionRequestStatusEnum.OnHold);

            IntroductionRequest introductionRequest = new IntroductionRequest(
                connectionRequestStatus,
                new PlayerId(connectionIntroductionDto.PlayerSender),
                new PlayerId(connectionIntroductionDto.PlayerReceiver),
                TextBox.ValueOf(connectionIntroductionDto.Text),
                TextBox.ValueOf(connectionIntroductionDto.TextIntroduction),
                new PlayerId(connectionIntroductionDto.PlayerIntroduction), connectionRequestStatus,
                ConnectionStrenght.ValueOf(connectionIntroductionDto.ConnectionStrenght),
                connectionIntroductionDto.Tags.ConvertAll(tag => Tag.ValueOf(tag)));


            await this._repository1.AddAsync(introductionRequest);
            await this._unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }


        public async Task<object> DeleteAsync(string introductionRequestId)
        {
            var introductionRequest = await _repository1.GetByIdAsync(new ConnectionRequestId(introductionRequestId));
            if (introductionRequest==null)
            {
                return null;
            }
            _repository1.Remove(introductionRequest);
            await _unitOfWork.CommitAsync();
            return introductionRequest.ToDto();
        }

    }
}