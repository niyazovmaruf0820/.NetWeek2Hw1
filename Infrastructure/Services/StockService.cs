using Dapper;
using Domain.Models;
using Infrastructure.Dapper;
using Npgsql;
using Npgsql.Internal;
namespace Infrastructure.Services;

public class StockService
{
    private DapperContext dapperContext = new DapperContext();
    public void AddStock(Stocks stock)
    {
        dapperContext.Connection().Execute("insert into Stocks(Name,Address)values(@name,@address)", stock);
    }
    public List<StockProducts> GetStockProducts()
    {
        var sql1 = "select Id from Stocks";
        var listId = dapperContext.Connection().Query<int>(sql1).ToList();
        var sql2 = @"select * from Stock where Id = @id;
                     select * from Products where Id = @id;";
        List<StockProducts> stockProducts = new List<StockProducts>();
        foreach (var item in listId)
        {
            using (var sp = dapperContext.Connection().QueryMultiple(sql2, new { Id = item }))
            {
                StockProducts stockProduct1 = new StockProducts();
                stockProduct1.Stock = sp.ReadFirst<Stocks>();
                stockProduct1.ListProducts = sp.Read<Products>().ToList();
                stockProducts.Add(stockProduct1);
            }
        }
        return stockProducts;
    }
    public StockProducts GetStockProductsById(int id)
    {
        var sql = @"
               select * from Stock where id_stock=@id;
               select * from Products where id_stock = @id;
                ";

        using (var multiple = dapperContext.Connection().QueryMultiple(sql, new { Id = id }))
        {
            var stockProducts = new StockProducts();
            stockProducts.Stock = multiple.ReadFirst<Stocks>();
            stockProducts.ListProducts = multiple.Read<Products>().ToList();
            return stockProducts;
        }
    }
    public void Moving(int prId,int id1, int id2,int quan)
    {
        var sql1 = "update Products set Quantity = Quantity - @quantity where Id = @id and StockId = @stockId";
        var sql2 = "update Products set Quantity = Quantity + @quantity where Id = @id and StockId = @stockId";
        dapperContext.Connection().Execute(sql1,new {Quantity = quan,Id = prId,StockId1 = id1});
        dapperContext.Connection().Execute(sql1,new {Quantity = quan,Id = prId,StockId1 = id2});
    }
}
