﻿using System.Linq.Expressions;

namespace Core.IService
{
    public interface IService<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
    }
}
