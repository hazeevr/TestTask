using TestTaskService.Abstractions;
using TestTaskService.Models;

namespace TestTaskService.Services
{
    public class EntityService: IEntityService
    {
        private readonly IStorage _storage;
        public EntityService(IStorage storage)
        {
            _storage = storage;
        }

        public async ValueTask<EntityModel?> GetById(Guid id)
        {
            var entity = _storage.GetById(id);
            return await Task.FromResult(entity != null ? new EntityModel(entity) : null);            
        }

        public async ValueTask<Guid> Add(EntityModel model)
        {
            var newEntity = model.ToEntity();
            _storage.Add(newEntity);
            return await Task.FromResult(newEntity.Id);
        }
    }
}
