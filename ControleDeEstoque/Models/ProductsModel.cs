using System.Collections.Generic;

namespace ControleDeEstoque.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
        public UsersModel? User { get; set; }
    }
}
