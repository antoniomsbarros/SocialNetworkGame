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
        private readonly IIntroductionRequestRepository _repository;
        private readonly PlayerService _playerService;

        public IntroductionRequestService(IUnitOfWork unitOfWork1, IIntroductionRequestRepository repository,
            PlayerService playerService)
        {
            _unitOfWork = unitOfWork1;
            _repository = repository;
            _playerService = playerService;
        }

        public async Task<List<ConnectionIntroductionDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();


            List<ConnectionIntroductionDTO> dtos = list.ConvertAll(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Content,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(),
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Content, cat.CreationDate.ToString(), cat.ConnectionStrengthConf.Strength,
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
                _repository.GetAllPendingIntroductionAsync(new PlayerId(playerIntroduction.id)));

            List<ConnectionIntroductionDTO> dtos = list.ConvertAll(cat =>
                new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Content,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerIntroduction.AsString())).Result.email,
                    cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(),
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerSender.AsString())).Result.email,
                    _playerService.GetByIdAsync(new PlayerId(cat.PlayerReceiver.AsString())).Result.email,
                    cat.Text.Content, cat.CreationDate.ToString(), cat.ConnectionStrengthConf.Strength,
                    cat.ToDto().Tags));
            return dtos;
        }

        public async Task<ConnectionIntroductionDTO> GetByIdAsync(ConnectionRequestId connectionRequestId)
        {
            var cat = await this._repository.GetByIdAsync(connectionRequestId);
            if (cat == null)
                return null;

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Content, cat.PlayerIntroduction.AsString(),
                cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(),
                cat.PlayerReceiver.AsString(),
                cat.Text.Content, cat.CreationDate.ToString(), cat.ConnectionStrengthConf.Strength, cat.ToDto().Tags);
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

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Content, cat.PlayerIntroduction.AsString(),
                cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(),
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(),
                cat.PlayerReceiver.AsString(),
                cat.Text.Content, cat.CreationDate.ToString(), cat.ConnectionStrengthConf.Strength, cat.ToDto().Tags);
        }

        public async Task<IntroductionRequestDto> UpdateAsync(ConnectionIntroductionDTO connectionIntroductionDto)
        {
            var introductionRequest =
                await _repository.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto.Id));

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
            //introductionRequest.ChangeTags(connectionIntroductionDto.Tags);
            introductionRequest.ChangeText(new TextBox(connectionIntroductionDto.Text));
            introductionRequest.ChangeConnectionStrength(
                new ConnectionStrength(connectionIntroductionDto.ConnectionStrength));
            introductionRequest.ChangeCreationDate(new CreationDate(connectionIntroductionDto.CreationDate));
            introductionRequest.ChangePlayerSender(new PlayerId(connectionIntroductionDto.PlayerSender));
            introductionRequest.ChangePLayerReceiver(new PlayerId(connectionIntroductionDto.PlayerReceiver));

            await _unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }

/*
        public async Task<IntroductionRequestDto> AddIntroduction(
            CreateConnectionIntroductionDTO dto)
        {
            IntroductionRequest introductionRequest = new IntroductionRequest(
                ConnectionRequestStatus.ValueOf(ConnectionRequestStatusEnum.OnHold),
                new PlayerId(dto.PlayerSender),
                new PlayerId(dto.PlayerReceiver),
                TextBox.ValueOf(dto.Text),
                TextBox.ValueOf(dto.TextIntroduction),
                new PlayerId(dto.PlayerIntroduction),
                ConnectionRequestStatus.ValueOf(ConnectionRequestStatusEnum.OnHold),
                ConnectionStrength.ValueOf(dto.ConnectionStrength),
                dto.Tags.ConvertAll(tag => Tag.ValueOf(tag)));


            await _repository.AddAsync(introductionRequest);
            await _unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }
        */

        public async Task<List<IntroductionRequestDto>> GetAllPendingApproval(string playerEmail)
        {
            var playerReceiver = await _playerService.GetByEmailAsync(Email.ValueOf(playerEmail));

            if (playerReceiver == null)
            {
                return null;
            }

            var list = _repository.GetAllPendingApprovalAsync(new PlayerId(playerReceiver.id));
            return list.ConvertAll(introRequest => introRequest.ToDto());
        }

        public async Task<object> DeleteAsync(string introductionRequestId)
        {
            var introductionRequest = await _repository.GetByIdAsync(new ConnectionRequestId(introductionRequestId));
            if (introductionRequest == null)
            {
                return null;
            }

            _repository.Remove(introductionRequest);
            await _unitOfWork.CommitAsync();
            return introductionRequest.ToDto();
        }
    }
}