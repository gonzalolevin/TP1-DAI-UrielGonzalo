namespace Pizzas.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;


public class BD {

    private static string _connectionString =  @"Server=A-PHZ2-CIDI-015;DataBase=DAI-Pizzas;Trusted_Connection=True;";


public static List<Pizza> ListarPizzas(){
        List<Pizza> ListaPizzas = new List<Pizza>();
        string sql = "SELECT * FROM Pizzas";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            ListaPizzas = db.Query<Pizza>(sql).ToList();
        }
        return ListaPizzas;
    }

    public static Pizza VerInfoPizza(int Id)
    {
        Pizza pizzas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sqlQuery = "SELECT * FROM Pizzas WHERE Id = @pId";
            pizzas = db.QueryFirstOrDefault<Pizza>(sqlQuery, new{pId=Id});
        }
        return pizzas;
    }

}