using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite; //calls the library of SQLite
//https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=net-cli
using UnityEngine;
using System.Data;

public class SimpleDB : MonoBehaviour
{

    private string dbName = "URI = file:Inventory.db";

    // Start is called before the first frame update
    void Start()
    {
        //calls Method to create Database
        CreateDB();
        // AddWeapon
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
            command.CommandText = "CREATE TABLE IF NOT EXISTS wepons(name VARCHAR (20), qte INT)";
            command.ExecuteNonQuery();
        }
        connection.Close ();
      }
    }

    //TODO: create method for adiing weapo into the database
}
