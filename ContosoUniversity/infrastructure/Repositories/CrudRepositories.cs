using System;
using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Domain.Interfaces;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        protected readonly DBLocalContosoUniversity _dbContext;
        protected IEnumerable<T>? _entities;

        private void SetEntity(Type entityType)
        {
            if (entityType == typeof(Person))
            {
                _entities = (IEnumerable<T>)_dbContext.Persons;
            }
            else if (entityType == typeof(Course))
            {
                _entities = (IEnumerable<T>)_dbContext.Courses;
            }
            else if (entityType == typeof(Department))
            {
                _entities = (IEnumerable<T>)_dbContext.Departments;
            }
            else
            {
                throw new ArgumentException($"Entity type '{entityType.Name}' not supported.");
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities ?? Enumerable.Empty<T>();
        }

        public T GetById(int id)
        {
            return _entities?.SingleOrDefault(x => x.Id == id) ?? throw new ArgumentException("Entity not found.");
        }

        public IEnumerable<T> FindBy(Func<T, bool> filter)
        {
            return _entities?.Where(filter) ?? Enumerable.Empty<T>();
        }

        public CrudRepository()
        {
            _dbContext = new DBLocalContosoUniversity();
            SetEntity(typeof(T));
        }
    }
}
