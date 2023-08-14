using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using CasgemMicroservice.Services.Order.Infrastructure.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Order.Infrastructure.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _orderContext;

        public Repository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _orderContext.Set<T>().Add(entity);
            await _orderContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
           _orderContext.Set<T>().Remove(entity);
            await _orderContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _orderContext.Set<T>().AsNoTracking().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _orderContext.Set<T>().FindAsync(id);
          
        }

      

        public async Task<T> UpdateAsync(T entity)
        {
           _orderContext.Set<T>().Update(entity);
            await _orderContext.SaveChangesAsync();
            return entity;
        }
    }
}
