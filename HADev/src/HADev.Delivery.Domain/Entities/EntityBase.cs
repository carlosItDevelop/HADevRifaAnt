using System;


namespace HADev.Delivery.Domain.Entities

{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }

}
