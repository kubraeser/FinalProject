using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId = 1, CategoryId= 1,ProductName = "Bardak", UnitPrice = 15,UnitsInStock = 15},
            new Product{ProductId = 2, CategoryId= 2,ProductName = "Kamera", UnitPrice = 500,UnitsInStock = 3},
            new Product{ProductId = 3, CategoryId= 3,ProductName = "Telefon", UnitPrice = 1500,UnitsInStock = 2},
            new Product{ProductId = 4, CategoryId= 4,ProductName = "Klavye", UnitPrice = 150,UnitsInStock = 65},
            new Product{ProductId = 4, CategoryId= 5,ProductName = "Fare", UnitPrice = 85,UnitsInStock = 1}


            };
        }
        public void Add(Product product)
        {
            _products.Add(product);

        }

        public void Delete(Product product)
        {
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId) ;
            //    {
            //        ProductToDelete = p;
            //    }
            //}
            Product ProductToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);

            _products.Remove(ProductToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.ProductId = product.ProductId;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;


        }
    }
}
