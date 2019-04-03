using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brainence.Domain.Models
{
    public class Quantity
    {
        [NotMapped]
        public QuantityType Type { get; set; }

        public string StoreType
        {
            get { return Type.ToString(); }
            set
            {
                if (Enum.TryParse(value, out QuantityType Type))
                {
                    this.Type = Type;
                };
            }
        }
        public double Amount { get; set; }
        public Order Order { get; set; }
    }
}
