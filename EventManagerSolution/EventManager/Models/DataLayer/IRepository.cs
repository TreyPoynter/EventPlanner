﻿namespace EventManager.Models.DataLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> List(QueryOptions<T> options);
        T? GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
