using LC.DTO.SQLBase;

namespace LC.DTO
{
    public class Product:SQLTable
    {
        private string _name;
        public string Name
        {
            set
            {
                this._name = value;
                this.OnPropertyChanged("Name");
            }
            get
            {
                return _name;
            }
        }

        private string _description;
        public string Description
        {
            set
            {
                this._description = value;
                this.OnPropertyChanged("Description");
            }
            get
            {
                return this._description;
            }
        }


        private decimal _price;
        public decimal Price
        {
            set
            {
                this._price = value;
                this.OnPropertyChanged("Price");
            }
            get
            {
                return this._price;
            }
        }

        private int _Quantity;
        public int Quantity
        {
            set
            {
                this._Quantity = value;
                this.OnPropertyChanged("Quantity");
            }
            get
            {
                return this._Quantity;
            }
        }
    }
}
