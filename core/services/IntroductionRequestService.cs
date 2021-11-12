using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.infrastructure;

namespace SocialNetwork.core.model.posts.application
{
    public class IntroductionRequestService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntroductionRequestRepository _repository;
        
        public IntroductionRequestService(IUnitOfWork _unitOfWork1, IIntroductionRequestRepository _repository1 )
        {
            
            _unitOfWork = _unitOfWork1;
            _repository = _repository1;
           
        }

        public async Task<List<ConnectionIntroductionDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat => new ConnectionIntroductionDTO(
                    cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(), cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(), 
                    cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(), cat.PlayerReceiver.AsString(), 
                    cat.Text.Text, cat.CreationDate.ToString()));
            return dtos;
        }

        public async Task<List<ConnectionIntroductionDTO>> GetAllPendingIntroduction(PlayerId playerIntroductionId)
        {
            var list = await Task.Run(() => _repository.GetAllPendingIntroductionAsync(playerIntroductionId));
            List<ConnectionIntroductionDTO> dtos = list.ConvertAll<ConnectionIntroductionDTO>(cat => new ConnectionIntroductionDTO(
                cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(), cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(), 
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(), cat.PlayerReceiver.AsString(), 
                cat.Text.Text, cat.CreationDate.ToString()));
            return dtos;
        }
        public async Task<ConnectionIntroductionDTO> GetByIdAsync(ConnectionRequestId connectionRequestId)
        {
            
            var cat = await this._repository.GetByIdAsync(connectionRequestId);
            if(cat == null )
                return null;

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(), cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(), 
                cat.ConnectionRequestStatus.CurrentStatus.ToString(), cat.PlayerSender.AsString(), cat.PlayerReceiver.AsString(), 
                cat.Text.Text, cat.CreationDate.ToString());
        }/*
        public async Task<ConnectionIntroductionDTO> AddAsync(CreatingIntroductionConnectionDTO dto)
        {
            var connectionRequest = new ConnectionRequest(new ConnectionRequestStatus(dto.ConnectionRequestStatus), 
                new PlayerId(dto.PlayerSender),new PlayerId(dto.PlayerReceiver),new TextBox(dto.Text));
            await this._repo.AddAsync(connectionRequest);
            await this._unitOfWork.CommitAsync();
            
            await checkCategoryIdAsync(connectionRequest.Id.AsString());
            
            var introductionRequest = new IntroductionRequest(connectionRequest.Id.Value, );
            await 
            

            await this._unitOfWork.CommitAsync();

            return new CategoryDto { Id = category.Id.AsGuid(), Description = category.Description };
        }*/
        
        
    }
}