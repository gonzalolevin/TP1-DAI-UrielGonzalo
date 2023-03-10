namespace Pizzas.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;


public class BD {

    private static string _connectionString =  @"Server=A-PHZ2-CIDI-015;DataBase=DAI-Pizzas;Trusted_Connection=True;";


public static List<Pizzas> ListarPizzas(){
        List<Pizzas> ListaPizzas = new List<Pizzas>();
        string sql = "SELECT * FROM Pizzas";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            ListaPizzas = db.Query<Pizzas>(sql).ToList();
        }
        return ListaPizzas;
    }

}