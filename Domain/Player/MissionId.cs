using LEI_21s5_3dg_41.Domain.Shared;
using System;
using Newtonsoft.Json;

namespace LEI_21s5_3dg_41.Domain.Player
{
    public class MissionId :EntityId
    {
        [JsonConstructor]
        public MissionId(Guid value) : base(value)
        {
        }

        public MissionId(String value) : base(value)
        {
        }

        override
        protected  Object createFromString(String text){
            return new Guid(text);
        }

        override
        public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }
        
       
        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}