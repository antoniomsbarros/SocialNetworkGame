using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.model.tags.repository;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.services.players
{
    public class PlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _repo;
        private readonly PlayerBuilder _playerBuilder;
        private readonly TagsService _tagsService;
        private readonly ITagRepository _repoTags;
        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository repo,ITagRepository repoTags)
        {
            
            _unitOfWork = unitOfWork;
            _repo = repo;
            _playerBuilder = new PlayerBuilder();
            _repoTags = repoTags;
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.ConvertAll(player => player.ToDto());
        }

        public async Task<PlayerDto> GetByIdAsync(PlayerId id)
        {
            var player = await _repo.GetByIdAsync(id);
            return player?.ToDto();
        }

        public async Task<PlayerDto> GetByEmailAsync(Email email)
        {
            var player = await _repo.GetByEmailAsync(email);
            return player?.ToDto();
        }

        private Player CreatePlayer(RegisterPlayerDto dto)
        {
            _playerBuilder
                .WithEmail(Email.ValueOf(dto.email))
                .WithDateOfBirth(DateOfBirth.ValueOf(dto.dateOfBirth))
                .WithPhoneNumber(PhoneNumber.ValueOf(dto.phoneNumber))
                .WithEmotionalStatus(EmotionalStatus.ValueOf(dto.emotionalStatus));

            if (dto.fullName != null && dto.shortName != null)
                _playerBuilder.WithName(Name.ValueOf(dto.shortName, dto.fullName));

            if (dto.facebookProfile != null)
                _playerBuilder.WithFacebookProfile(FacebookProfile.ValueOf(dto.facebookProfile));

            if (dto.linkedinProfile != null)
                _playerBuilder.WithLinkedinProfile(LinkedinProfile.ValueOf(dto.linkedinProfile));

            return _playerBuilder.Build();
        }

        public async Task<PlayerDto> AddAsync(RegisterPlayerDto dto)
        {
            var player = CreatePlayer(dto);
            await _repo.AddAsync(player);
            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }

        public async Task<PlayerDto> AddAsyncWithoutSave(RegisterPlayerDto dto)
        {
            var player = CreatePlayer(dto);
            await _repo.AddAsync(player);

            return player.ToDto();
        }

        public async Task<PlayerDto> UpdateAsync(UpdatePlayerDto playerDto)
        {
            var player = await _repo.GetByEmailAsync(Email.ValueOf(playerDto.email));

            if (player == null)
                return null;

            player.SetName(Name.ValueOf(playerDto.shortName, playerDto.fullName));

            if (playerDto.dateOfBirth != null)
                player.ChangeDateOfBirth(DateOfBirth.ValueOf(playerDto.dateOfBirth.Value));

            if (playerDto.facebookProfile != null)
                player.LinkFacebook(FacebookProfile.ValueOf(playerDto.facebookProfile));

            if (playerDto.linkedinProfile != null)
                player.LinkLinkedin(LinkedinProfile.ValueOf(playerDto.linkedinProfile));

            if (playerDto.phoneNumber != null)
                player.ChangePhoneNumber(PhoneNumber.ValueOf(playerDto.phoneNumber));

            if (playerDto.tags != null)
                player.ChangeTags(playerDto.tags.ConvertAll(tags => new TagId(tags)));

            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }

        public async Task<PlayerDto> DeleteAsync(PlayerId id)
        {
            var player = await _repo.GetByIdAsync(id);

            if (player == null)
                return null;

            _repo.Remove(player);
            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }
        
        public async Task<PlayerDto> DeleteAsync(string email)
        {
            var player = await _repo.GetByEmailAsync(new Email(email));

            if (player == null)
                return null;

            _repo.Remove(player);
            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }

        public async Task<PlayerDto> ChangeEmotionalStatus(UpdateEmotionalStatusDto dto)
        {
            var player = await _repo.GetByEmailAsync(new Email(dto.id));

            if (player == null)
                return null;

            player.SetEmotionalStatusTo(EmotionalStatus.ValueOf(dto.newEmotionalStatus));

            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }

        public async Task SaveChanges()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> CountAsync()
        {
            var playernumber =await _repo.getNumberofPlayers();
            return playernumber;
        }
        
        public async Task<List<TagCloudDto>> GetTagCloudFromPlayers()
        {
            var players = await GetAllAsync();
          
            List<String> tags = new List<string>();
            
            List<TagCloudDto> tagClouds = new List<TagCloudDto>();
            
            foreach (var p in players) 
            {
                foreach (var tag in p.tags)
                {
                    tags.Add(tag);
                }
            }

            List<string> distinctTags = tags.Distinct().ToList();
          
            int count = 0;

            foreach (var dt in distinctTags)
            {
                foreach (var t in tags)
                {
                    if (dt.Equals(t))
                    {
                        count++;
                       
                    }
                }
                
                double percentagem = ((double) count / tags.Count) * 100.0;
                var tag = await _repoTags.GetByIdAsync(new TagId(dt));
                tagClouds.Add(new TagCloudDto(dt,tag.TagName.Value, Math.Round(percentagem, 2)));
                count = 0;
            }
            return tagClouds;
        }
    }
}