using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class Text: IValueObject
    {
        public string text { get; }


        public Text(string text){
            if(Textisvalid(text)){
                this.text=text;
            }
            throw new BusinessRuleValidationException("The connection test cant be empty");
        }

        public static bool Textisvalid(string text){
            if(text.Length>0){
                return true;
            }
            return false;
        }
    }
}