using TestTaskService.Models;

namespace TestTaskService.Abstractions
{
    public interface IEntityService
    {
        ValueTask<EntityModel?> GetById(Guid id);
        ValueTask<Guid> Add(EntityModel model);
    }
}
