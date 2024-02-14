using System.Collections.Concurrent;
using TestTaskService.Abstractions;
using TestTaskService.Data.Entities;

namespace TestTaskService.Data
{
    public class Storage:IStorage
    {
        private ConcurrentDictionary<Guid, Entity> _storage;

        public Storage()
        {
            _storage = new ConcurrentDictionary<Guid, Entity>();
        }

        public Entity? GetById(Guid id)
        {
            if (_storage.TryGetValue(id, out var entity))
                return entity;

            return null;
        }

        public void Add(Entity entity)
        {
            _storage.AddOrUpdate(entity.Id, entity, (key, oldvalue) => throw new InvalidOperationException("Entity with same key already exists."));
        }
    }
}
