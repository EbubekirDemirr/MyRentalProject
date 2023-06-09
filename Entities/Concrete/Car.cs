using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car: IEntity
    {
        public int CarId { get; set; } // Burada class adı nesne adı Car PK ise CarId anlaşılır yani kod bunu anlıyor bakıyor class adı Car Prop adı da CarId hee bu PK diyor
        public string CarName { get; set; }
        public int BrandId { get; set;}
        public int ColorId { get; set;}
        public decimal DailyPrice { get; set;} 
        public DateTime ModelYear { get; set;}
        public string Description { get; set;}
        public Brand Brand  { get; set; }
        public Color Color { get; set; }
    }
                    
}
