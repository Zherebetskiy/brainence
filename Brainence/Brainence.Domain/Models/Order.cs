using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brainence.Domain.Models
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }     

        [NotMapped]
        public Status Status { get; set; }

        public string StoreStatus
        {
            get { return Status.ToString(); }
            set
            {
                if (Enum.TryParse(value, out Status Status))
                {
                    this.Status = Status;
                };
            }
        }
        public int QuantityId { get; set; }
        public Quantity Quantity { get; set; }
    }
}
