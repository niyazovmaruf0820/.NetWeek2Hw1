using Dapper;
using Domain.Models;
using Infrastructure.Dapper;

namespace Infrastructure.Services;

public class ProductService
{
    private DapperContext dapperContext = new DapperContext();
    public List<Products> GetProducts()
    {
        return dapperContext.Connection().Query<Products>("select * from Products").ToList();
    }
    public void AddProduct(Products products)
    {
        dapperContext.Connection().Execute("insert into Products(Name,Quantity,StockId)values(@name,@quantity,@stockId)",products);
    }
    public void DeleteProduct(int id)
    {
        dapperContext.Connection().Execute("delete from Products where Id = @id",new {Id = id});
    }
    public void UpdateProduct(Products products)
    {
        dapperContext.Connection().Execute("update Products set Name = @name,Quantity = @quantity,StockId = @stockId where Id = @id",products);
    }
}
