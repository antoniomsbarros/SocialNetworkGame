using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.relationships;

namespace SocialNetwork.core.services.connectionRequests
{
    public class DirectRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDirectRequestRepository _repo;
        private readonly PlayerService _playerService;
        private readonly RelationshipService _relationshipService;

        public DirectRequestService(IUnitOfWork unitOfWork, IDirectRequestRepository repo, PlayerService playerService,
            RelationshipService relationshipService)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
            _playerService = playerService;
            _relationshipService = relationshipService;
        }

        public async Task<List<DirectRequestDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.ConvertAll<DirectRequestDto>(directRequest => directRequest.ToDto());
        }

        public async Task<DirectRequestDto> AddAsync(CreateDirectRequestDto directRequestDto)
        {
            DirectRequest directRequest = new(new PlayerId(directRequestDto.PlayerSender),
                new PlayerId(directRequestDto.PlayerReceiver), TextBox.ValueOf(directRequestDto.Text),
                ConnectionStrength.ValueOf(directRequestDto.ConnectionStrength),
                directRequestDto.Tags.ConvertAll(tags => new TagId(tags)));

            await _repo.AddAsync(directRequest);
            await _unitOfWork.CommitAsync();

            return directRequest.ToDto();
        }

        public async Task<List<DirectRequestDto>> GetPendingRequests(string playerEmail)
        {
            var player = await _playerService.GetByEmailAsync(new Email(playerEmail));
            
            if (player == null)
            {
                return null;
            }
            
            var list = _repo.GetPendingRequestsAsync(new PlayerId(player.id));
            
            List<DirectRequestDto> list1= list.ConvertAll(introRequest => introRequest.ToDto());
            List<DirectRequestDto> list2 = new List<DirectRequestDto>();

            foreach (var VARIABLE in list1)
            {
                DirectRequestDto introductionRequestDto = VARIABLE;
                PlayerDto PlayerReceiver=await _playerService.GetByIdAsync(new PlayerId(VARIABLE.PlayerReceiver));
                PlayerDto PlayerSender=await _playerService.GetByIdAsync(new PlayerId(VARIABLE.PlayerSender));
                introductionRequestDto.PlayerSender = PlayerSender.email;
                introductionRequestDto.PlayerReceiver = PlayerReceiver.email;
                list2.Add(introductionRequestDto);
            }
            return list2;
        }
        
        
        public async Task<DirectRequestDto> UpdateRequestStatus(UpdateDirectRequestStatus dto)
        {
            var cat = await _repo.GetByIdAsync(new ConnectionRequestId(dto.id));

            if (cat == null)
            {
                return null;
            }

            cat.ChangeStatus(ConnectionRequestStatus.ValueOf(dto.newStatus));

            if (dto.newStatus == ConnectionRequestStatusEnum.Approved)
            {
                await _relationshipService.AddAsync(new RelationshipPostDto(dto.playerReceiverEmail, dto.playerSenderEmail,
                    cat.ConnectionStrengthConf.Strength, cat.TagsConf.ConvertAll(t=>t.Value.ToString())));
            
                await _relationshipService.AddAsync(new RelationshipPostDto(dto.playerSenderEmail, dto.playerReceiverEmail,
                    10, new List<string>()));
            }


            
            await _unitOfWork.CommitAsync();

            return cat.ToDto();
        }
    }
}