﻿using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;
        public Repository()
        {
            this.models = new List<T>();
        }
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => this.models.AsReadOnly();


        abstract public T GetByName(string name);
        
        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
