using System.ComponentModel.DataAnnotations;

namespace BookApi.Model
{
    public class Books
    {
        [Key]
        public long? bookId { get; set; }
        public string? title { get; set; }
        public string? genre { get; set; }
        public string? author { get; set; }
        public decimal? price { get; set; }
        public string? userName { get; set; }
        public string? name { get; set; }
    }
}
