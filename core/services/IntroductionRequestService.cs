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
        /// <summary>
        /// esta classe está me a dar problemas para conseguir enviar para o postman
        /// </summary>
       /* private readonly IntroductionRequestRepository _introductionRequestRepository;
        private readonly ConnectionRequestRepository _connectionRequestRepository;*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntroductionRequestRepository _repository;
        private readonly IConnectionRequestRepository _requestRepository;
        public IntroductionRequestService(/*SocialNetworkDbContext context, */IUnitOfWork _unitOfWork1, 
            IIntroductionRequestRepository _repository1 /*,IConnectionRequestRepository requestRepository*/)
        {
            /*_introductionRequestRepository = context.repositories().IntroductionRequest();
            _connectionRequestRepository = context.repositories().ConnectionRequest();*/
            _unitOfWork = _unitOfWork1;
            _repository = _repository1;
           // _requestRepository = requestRepository;
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

        public async Task<ConnectionIntroductionDTO> GetByIdAsync(ConnectionRequestId connectionRequestId)
        {
            var cat1 = await this._requestRepository.GetByIdAsync(connectionRequestId);
            var cat = await this._repository.GetByIdAsync(connectionRequestId);
            
            if(cat == null || cat1==null)
                return null;

            return new ConnectionIntroductionDTO(cat.TextIntroduction.Text, cat.PlayerIntroduction.AsString(), cat.IntroductionStatus.CurrentStatus.ToString(), cat.Id.AsString(), 
                cat1.ConnectionRequestStatus.CurrentStatus.ToString(), cat1.PlayerSender.AsString(), cat1.PlayerReceiver.AsString(), 
                cat1.Text.Text, cat1.CreationDate.ToString());
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