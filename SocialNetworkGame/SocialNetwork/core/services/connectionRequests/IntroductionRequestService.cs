using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.services.connectionRequests
{
    public class IntroductionRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntroductionRequestRepository _repository;
        private readonly PlayerService _playerService;
        private readonly TagsService _tagsService;
        public IntroductionRequestService(IUnitOfWork unitOfWork, IIntroductionRequestRepository repository,
            PlayerService playerService,TagsService tagsService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _playerService = playerService;
            _tagsService = tagsService;
        }

        public async Task<List<IntroductionRequestDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.ConvertAll(introRequest => introRequest.ToDto());
        }


        public async Task<List<IntroductionRequestDto>> GetAllPendingIntroduction(string playerIntroEmail)
        {
            var playerIntro = await _playerService.GetByEmailAsync(new Email(playerIntroEmail));
            
            if (playerIntro == null)
            {
                return null;
            }
            var list = _repository.GetAllPendingIntroductionAsync(new PlayerId(playerIntro.id));
            
            List<IntroductionRequestDto> list1= list.ConvertAll(introRequest => introRequest.ToDto());
            List<IntroductionRequestDto> list2 = new List<IntroductionRequestDto>();
            
            return list1;

        }

        public async Task<IntroductionRequestDto> GetByIdAsync(ConnectionRequestId id)
        {
            var introRequest = await _repository.GetByIdAsync(id);
            if (introRequest == null)
                return null;

            return introRequest.ToDto();
        }

        public async Task<IntroductionRequestDto> UpdateStatus(UpdateIntroductionRequestStatus dto)
        {
            var cat = await _repository.GetByIdAsync(new ConnectionRequestId(dto.id));

            if (cat == null)
            {
                return null;
            }

            cat.ChangeIntroductionStatus(ConnectionRequestStatus.ValueOf(dto.newStatus));
            await _unitOfWork.CommitAsync();

            return cat.ToDto();
        }

        public async Task<IntroductionRequestDto> UpdateAsync(UpdateIntroductionRequestDto dto)
        {
            var introductionRequest =
                await _repository.GetByIdAsync(new ConnectionRequestId(dto.Id));

            if (introductionRequest == null)
            {
                return null;
            }

            if (dto.Text != null)
                introductionRequest.ChangeText(TextBox.ValueOf(dto.Text));

            if (dto.TextIntroduction != null)
                introductionRequest.ChangeTextIntroduction(TextBox.ValueOf(dto.TextIntroduction));

            introductionRequest.ChangeStatus(ConnectionRequestStatus.ValueOf(dto.IntroductionStatus));
            introductionRequest.ChangeIntroductionStatus(ConnectionRequestStatus.ValueOf(dto.IntroductionStatus));

            await _unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }

        public async Task<IntroductionRequestDto> AddIntroduction(CreateIntroductionRequestDto dto)
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
                dto.Tags.ConvertAll(tag => new TagId((tag))));

            await _repository.AddAsync(introductionRequest);
            await _unitOfWork.CommitAsync();

            return introductionRequest.ToDto();
        }

        public async Task<List<IntroductionRequestDto>> GetAllPendingApproval(Email playerEmail)
        {
            var playerReceiver = await _playerService.GetByEmailAsync(playerEmail);

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