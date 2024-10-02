using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.ResponseModel
{
    public class RatingReponseModel
    {
        public string Commenter { get; set; }
        public int Point { get; set; }
        public string Comment { get; set; }
    }
}
