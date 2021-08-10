using System;
using System.Collections.Generic;

namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private readonly List<T> entities;

        public Repository(List<T> entities)
        {
            this.entities = entities;
        }

        public IEnumerable<T> All() => entities;
        
        public void Delete(IComparable id) => entities.Remove(entities.Find(CompareByID(id)));
        
        public T FindById(IComparable id) => entities.Find(CompareByID(id));
        
        public void Save(T item) => entities.Add(item);
        
        private Predicate<T> CompareByID(IComparable id) => match => match.Id.Equals(id);

    }
}
