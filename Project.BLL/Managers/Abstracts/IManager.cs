﻿using Project.ENTITIES.CoreIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IManager<T> where T:IEntity
    {
        //List Commands

        List<T> GetAll();
        List<T> GetActives();
        Task<List<T>> GetActivesAsync();
        List<T> GetPassives();
        List<T> GetModifieds();
       

        //Modify Commands
        string Add(T item);
        Task AddAsync(T item);
        Task<string> AddRangeAsync(List<T> list);
        string AddRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        string Destroy(T item);
        string DestroyRange(List<T> list);
         

        //Linq Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        //Find Commands
        T Find(int id);
        Task<T> FindAsync(int id);
        
        List<T> GetLastDatas(int count);
        List<T> GetFirstDatas(int count);
    }
}
