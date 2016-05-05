﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NorthwindRepository.Interfaces;
using System.Data.Entity.Core.Objects;
using DAL;

namespace NorthwindRepository.Repositories
{
    public class CustomerRepository : IEntityRepository<Customer, string>
    {
        NORTHWNDEntities context = new NORTHWNDEntities();
        public void Delete(string id)
        {
            try
            {
                var cust = this.Search(id);
                context.Customers.Remove(cust);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IQueryable<Customer> GetAllData()
        {
            var cust = from c in context.Customers select c;
            return cust;
        }

        public void Insert(Customer entity)
        {
            try
            {
                context.Customers.Add(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customer Search(string id)
        {
            var cust = context.Customers.Find(id);
            return cust;
        }

        public void Update(Customer entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
