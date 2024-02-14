namespace TestTaskService.Data.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.Now;
        }
        public Entity(Guid? id, DateTime? operationDate, decimal? amount)
        {
            Id = id ?? Guid.NewGuid();
            OperationDate = operationDate ?? DateTime.Now;
            Amount = amount ?? 0;
        }
    }
}
