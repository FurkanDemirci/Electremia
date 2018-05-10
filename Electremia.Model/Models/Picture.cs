namespace Electremia.Model.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        // The Id of Post or Product.
        public int Id { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
    }
}