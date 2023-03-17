namespace Pizzas.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;


public class BD {

    private static string _connectionString =  @"Server=A-PHZ2-CIDI-008;DataBase=DAI-Pizzas;Trusted_Connection=True;";


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

    public static Pizza CrearPizza(Pizza pizzas)
    {
        string sqlQuery = "INSERT INTO Pizza(Id, Nombre, LibreGluten, Importe, Descripcion)";
            sqlQuery += "VALUES (@pId, @pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sqlQuery,new {pId = pizzas.Id, pNombre = pizzas.Nombre, pLibreGluten = pizzas.LibreGluten, pImporte = pizzas.Importe, pDescripcion = pizzas.Descripcion });
        }
        return pizzas;
        
    }

    public static void ActualizarPizza(int id, Pizza pizza1) 
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("UPDATE Pizza SET Nombre = @pNombre, LibreGluten =  @pLibreGluten, Importe =  @pImporte, Descripcion = @pDescripcion WHERE Id = @pId", 
                new { pId = id, pNombre = pizza1.Nombre, pLibreGluten = pizza1.LibreGluten, pImporte = pizza1.Importe, pDescripcion = pizza1.Descripcion }); 
            }
    }

    public static int EliminarPizza (int IdPizza){
        int ejecutados = 0;
        string SQL = "Delete from Pizza where IdPizza = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString)){       
            ejecutados = db.Execute(SQL, new {pId = IdPizza});
        }  
        return ejecutados;   

    }

}