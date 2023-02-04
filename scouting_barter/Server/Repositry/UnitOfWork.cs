using scouting_barter.Server.Data;
using scouting_barter.Server.IRepository;
using scouting_barter.Server.Models;
using scouting_barter.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace scouting_barter.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderItem> _orderitems;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Product> _products;
        private IGenericRepository<ProductCategory> _productcategories;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Order> Orders
            => _orders ??= new GenericRepository<Order>(_context);
        public IGenericRepository<OrderItem> OrderItems
            => _orderitems ??= new GenericRepository<OrderItem>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<ProductCategory> ProductCategories
            => _productcategories ??= new GenericRepository<ProductCategory>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            //foreach (var entry in entries)
            //{
                //((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                //((BaseDomainModel)entry.Entity).UpdatedBy = user;
                //if (entry.State == EntityState.Added)
                //{
                    //((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    //((BaseDomainModel)entry.Entity).CreatedBy = user;
                //}
            //}

            await _context.SaveChangesAsync();
        }
    }
}