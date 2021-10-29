namespace LEI_21s5_3dg_41.Domain.Categories
{
    public class CreatingCategoryDto
    {
        public string Description { get; set; }


        public CreatingCategoryDto(string description)
        {
            this.Description = description;
        }
    }
}