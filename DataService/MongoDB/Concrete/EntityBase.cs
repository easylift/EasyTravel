using System;

namespace DataService.MongoDB.Concrete
{
    public  abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
