using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result =from c in context.Products
                join cat in context.Categories
                on c.CategoryId equals cat.CategoryId
                select new ProductDetailDto
                { ProductId = c.ProductId, ProductName = c.ProductName, CategoryName = cat.CategoryName, UnitPrice = c.UnitPrice, UnitsInStock = c.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
