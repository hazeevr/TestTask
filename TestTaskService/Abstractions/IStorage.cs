using TestTaskService.Data.Entities;

namespace TestTaskService.Abstractions
{
    public interface IStorage
    {
        Entity? GetById(Guid id);
        void Add(Entity entity);
    }
}
