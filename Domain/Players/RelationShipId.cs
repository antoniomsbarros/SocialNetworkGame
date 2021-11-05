using System;
using LEI_21s5_3dg_41.Domain.Shared;
using Newtonsoft.Json;
namespace LEI_21s5_3dg_41.Domain.Players
{
    public class RelationShipId : EntityId
    {
        [JsonConstructor]
        public RelationShipId(Guid value) : base(value)
        {
        }

        public RelationShipId(String value) : base(value)
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