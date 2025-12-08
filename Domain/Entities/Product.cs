namespace Domain.Entities
{
    public class Product
    {
        private string _name;
        private decimal _price;

        public Guid Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("El nombre no puede ir vacio");
                }

                _name = value;
            }
        }

        public decimal Precio
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El precio no puede menor uqe cero");
                }
                _price = value;
            }
        }

        //Constructor
        public Product(Guid id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Precio = price;
        }
    }
}
