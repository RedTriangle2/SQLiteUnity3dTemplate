using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite; //calls the library of SQLite
//https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=net-cli
using UnityEngine;
using System.Data;

public class SimpleDB : MonoBehaviour
{
    // Global Variabl Created Here

    private string dbName = "URI = file:Inventory.db";

    // Start is called before the first frame update
    void Start()
    {
        //calls Method to create Database
        CreateDB();
        AddWeapon("pistol", 25);
        AddWeapon("sword", 6);
        // TODO: Call the method and delte Rifle
        DeleteWeaspon("Rifle");
       
        Debug.Log(" SQL started Working!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: CREATE METHOD FOR CreateDB()
    private void CreateDB()
    {
      using(var connection = new SqliteConnection(dbName))
      {
        connection.Open ();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "CREATE TABLE IF NOT EXISTS weapons(name VARCHAR (20), qte INT)";
            command.ExecuteNonQuery();
        }
        connection.Close ();
      }
    }

    //TODO: create method for adding weapon into the database
    public void AddWeapon(string weaponName, int weaponQte)
    {
      using(var connection = new SqliteConnection(dbName))
      {
        connection.Open ();
        using (var command = connection.CreateCommand())
        {
            //SQL code goes here
            command.CommandText = "INSERT INTO weapons (name, qte) VALUES (@name, @qte);";// Adds the SQL code as the argument to add a value of Rifle of 17 as the  values
            //command.Parameters allows you to add and Assign the parameter with the value form within Values
            command.Parameters.AddWithValue ("@name", weaponName);
            command.Parameters.AddWithValue ("@qte", weaponQte);
            command.ExecuteNonQuery();
        }
        connection.Close ();
      }
    }

    public void DeleteWeaspon(string weaponName)
    {
      using(var connection = new SqliteConnection(dbName))
      {
        connection.Open ();
        using (var command = connection.CreateCommand())
        {
            //SQL code goes here
            //TODO: DELETE FROM weapons WHERE name = @name
            command.CommandText = "DELETE FROM weapons WHERE name = @name;";// Adds the SQL code as the argument to add a value of Rifle of 17 as the  values
            //command.Parameters allows you to add and Assign the parameter with the value form within Values
            command.Parameters.AddWithValue ("@name", weaponName);
            command.ExecuteNonQuery();
        }
        connection.Close ();
      }
    }

}
