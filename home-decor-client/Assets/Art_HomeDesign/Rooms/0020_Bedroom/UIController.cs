using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Collections;

public class UIController : MonoBehaviour
{
    public void onReplay() {
        Debug.Log("On Replay");

        var furnitures = new List<GameObject>();

        // Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM DecorationOrder";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();

        while (dataReader.Read())
        {
            var id = dataReader.GetInt32(0);
            var objectName = dataReader.GetString(1);

            Debug.Log($"id: {id}, objectName: {objectName}");

            var obj = GameObject.Find(objectName);
            furnitures.Add(obj);
        }

        dbConnection.Close();

        // Hide all furnitures
        foreach(var obj in furnitures)
        {
            obj.SetActive(false);
        }

        // Show all furnitures again
        StartCoroutine(ShowObjectsWithDelay(furnitures));
    }

    private IEnumerator ShowObjectsWithDelay(List<GameObject> gameObjects)
    {
        foreach(var obj in gameObjects)
        {
            yield return new WaitForSeconds(0.5f);
            obj.SetActive(true);
        }
    }

    private IDbConnection CreateAndOpenDatabase()
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = @"
            CREATE TABLE IF NOT EXISTS DecorationOrder (
                id INTEGER AUTO_INCREMENT PRIMARY KEY,
                object_name VARCHAR(255) NOT NULL
            )
            ";
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }
}
