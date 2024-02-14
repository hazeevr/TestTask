using TestTaskService.Data.Entities;

namespace TestTaskService.Models
{
    public class EntityModel
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }

        public EntityModel() { }
        public EntityModel(Entity entity)
        {
            this.Id = entity.Id;
            this.OperationDate = entity.OperationDate;
            this.Amount = entity.Amount;
        }

        public Entity ToEntity()
        {
            return new Entity(this.Id, this.OperationDate, this.Amount);            
        }
    }

}
