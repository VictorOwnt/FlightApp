﻿using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Category> _categories;
        public CategoryRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _categories = dbContext.Categories;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
