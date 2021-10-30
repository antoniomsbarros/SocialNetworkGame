using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;

using System;


namespace LEI_21s5_3dg_41.Domain.Player
{
    public class Player : Entity<PlayerId>, IAggregateRoot
    {
        public string facebookProfile { get;  private set; }

        public string email { get;  private set; }

        public string phoneNumber { get;  private set; }

    	public string linkedinProfile { get;  private set; }

        public DateTime dateOfBirth { get;  private set; }
        public ProfileId profileId { get;  private set; }

        public List<MissionId> missions { get;  private set; }

        public List<RelationShip> relationShips { get;  private set; }

        public Player (string facebookProfile, string email,string phoneNumber, string linkedinProfile, DateTime dateOfBirth, ProfileId profileId
                        , List<MissionId> missions, List<RelationShip> relationShips ){
                            this.facebookProfile=facebookProfile;
                            this.email=email;
                            this.phoneNumber=phoneNumber;
                            this.linkedinProfile=linkedinProfile;
                            this.dateOfBirth=dateOfBirth;
                            this.missions=missions;
                            this.relationShips=relationShips;
                        }

        public Player (string email){
            this.email=email;
            missions=new List<MissionId>();
            relationShips=new List<RelationShip>();
        }

        public void ChangeFacebookProfile(string facebookProfile){
            if (string.IsNullOrEmpty(facebookProfile))
            {
                throw new BusinessRuleValidationException("Facebook Profile cant be empty.");
            }
            this.facebookProfile=facebookProfile;
        }
        public void ChangeLinkedinProfile(string linkedinProfile){
            if (string.IsNullOrEmpty(linkedinProfile))
            {
                throw new BusinessRuleValidationException("Linkedin Profile cant be empty.");
            }
            this.linkedinProfile=linkedinProfile;
        }



    }
}