namespace MAUI_NewsApp.Data.DTO
{
    public class Category
    {
        public string Name { get; set; }

        public string MaterialIcon { get; set; }

        public Category(string name, string icon)
        {
            this.Name = name;
            this.MaterialIcon = icon;
        }
    }
}
