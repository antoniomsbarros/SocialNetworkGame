using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.services.players
{
    public class PlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _repo;

        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            return list.ConvertAll<PlayerDto>(player => player.ToDto());
        }

        public async Task<PlayerDto> GetByIdAsync(PlayerId id)
        {
            var player = await _repo.GetByIdAsync(id);

            if (player == null)
                return null;

            return player.ToDto();
        }

        public async Task<PlayerDto> GetByEmailAsync(Email email)
        {
            var player = await _repo.GetByEmailAsync(email);

            if (player == null)
                return null;

            return player.ToDto();
        }

        public async Task<PlayerDto> AddAsync(RegisterPlayerDto playerAsPlayerDto)
        {
            Player player = new Player(Email.ValueOf(playerAsPlayerDto.email),
                PhoneNumber.ValueOf(playerAsPlayerDto.phoneNumber),
                FacebookProfile.ValueOf(playerAsPlayerDto.facebookProfile),
                LinkedinProfile.ValueOf(playerAsPlayerDto.linkedinProfile),
                DateOfBirth.ValueOf(playerAsPlayerDto.dateOfBirth),
                Name.ValueOf(playerAsPlayerDto.shortName, playerAsPlayerDto.fullName),
                EmotionalStatus.ValueOf(playerAsPlayerDto.emotionalStatus));

            await _repo.AddAsync(player);
            await _unitOfWork.CommitAsync();

            return player.ToDto();
        }

        public async Task<PlayerDto> UpdateAsync(UpdatePlayerDto playerDto)
        {
            var player = await _repo.GetByEmailAsync(Email.ValueOf(playerDto.email));

            if (player == null)
                return null;

            if (playerDto.shortName != null)
                player.ChangeName(Name.ValueOf(playerDto.shortName, playerDto.fullName));

            if (playerDto.dateOfBirth != null)
                player.ChangeDateOfBirth(DateOfBirth.ValueOf(playerDto.dateOfBirth));

            if (playerDto.facebookProfile != null)
                player.LinkFacebook(FacebookProfile.ValueOf(playerDto.facebookProfile));

            if (playerDto.linkedinProfile != null)
                player.LinkLinkedin(LinkedinProfile.ValueOf(playerDto.linkedinProfile));

            if (playerDto.phoneNumber != null)
                player.ChangePhoneNumber(PhoneNumber.ValueOf(playerDto.phoneNumber));

            if (playerDto.tags != null)
                player.ChangeTags(playerDto.tags.ConvertAll<Tag>(t => Tag.ValueOf(t)));


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

        public async Task<PlayerDto> ChangeHumorState(String state, Email email)
        {
            var player = await _repo.GetByEmailAsync(email);

            if (player == null)
                return null;
            if (state.Equals(EmotionalStatusEnum.Astonishment.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Astonishment));
            else if (state.Equals(EmotionalStatusEnum.Eagerness.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Eagerness));
            else if (state.Equals(EmotionalStatusEnum.Curiosity.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Curiosity));
            else if (state.Equals(EmotionalStatusEnum.Inspiration.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Inspiration));
            else if (state.Equals(EmotionalStatusEnum.Desire.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Desire));
            else if (state.Equals(EmotionalStatusEnum.Love.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Love));
            else if (state.Equals(EmotionalStatusEnum.Fascination.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Fascination));
            else if (state.Equals(EmotionalStatusEnum.Admiration.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Admiration));
            else if (state.Equals(EmotionalStatusEnum.Joyfulness.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Joyfulness));
            else if (state.Equals(EmotionalStatusEnum.Satisfaction.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Satisfaction));
            else if (state.Equals(EmotionalStatusEnum.Softened.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Softened));
            else if (state.Equals(EmotionalStatusEnum.Relaxed.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Relaxed));
            else if (state.Equals(EmotionalStatusEnum.Awaiting.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Awaiting));
            else if (state.Equals(EmotionalStatusEnum.Deferent.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Deferent));
            else if (state.Equals(EmotionalStatusEnum.Calm.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Calm));
            else if (state.Equals(EmotionalStatusEnum.Boredom.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Boredom));
            else if (state.Equals(EmotionalStatusEnum.Sadness.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Sadness));
            else if (state.Equals(EmotionalStatusEnum.Isolation.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Isolation));
            else if (state.Equals(EmotionalStatusEnum.Disappointment.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Disappointment));
            else if (state.Equals(EmotionalStatusEnum.Contempt.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Contempt));
            else if (state.Equals(EmotionalStatusEnum.Jealousy.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Jealousy));
            else if (state.Equals(EmotionalStatusEnum.Irritation.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Irritation));
            else if (state.Equals(EmotionalStatusEnum.Disgust.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Disgust));
            else if (state.Equals(EmotionalStatusEnum.Alarm.ToString()))
                player.SetEmotionalStatusTo(new EmotionalStatus(EmotionalStatusEnum.Alarm));


            await _unitOfWork.CommitAsync();


            return player.ToDto();
        }
    }
}