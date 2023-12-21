using System;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Collections;


public class ReplayButton : MonoBehaviour
{
    public void onReplay()
    {
        Debug.Log("On Replay");
        // Read all object in room3

        IDbConnection dbConnectionRoom = CreateAndOpenDatabase("RoomCurrent");
        IDbCommand dbCommandCheckRoom = dbConnectionRoom.CreateCommand();
        dbCommandCheckRoom.CommandText = $"SELECT object_name FROM RoomCurrent WHERE id = 1";
        object res = dbCommandCheckRoom.ExecuteScalar();
        string room = Convert.ToString(res);

        var furnitures = new List<GameObject>();
        // Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase(room);
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = $@"SELECT * FROM {room}";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();

        while (dataReader.Read())
        {
            var objectName = dataReader.GetString(1);
            GameObject obj = GameObject.Find(objectName);
            furnitures.Add(obj);
        }

        foreach (var obj in furnitures)
        {
            obj.SetActive(false);
        }

        dbConnectionRoom.Close();
        dbConnection.Close();
        // Show all furnitures again
        StartCoroutine(ShowObjectsWithDelay(furnitures));
    }



    private IEnumerator ShowObjectsWithDelay(List<GameObject> gameObjects)
    {

        yield return new WaitForSeconds(1f); // Đổi giá trị độ trễ tại đây

        foreach (var obj in gameObjects)
        {
            yield return new WaitForSeconds(0.5f);
            obj.SetActive(true);
        }
    }

    private IDbConnection CreateAndOpenDatabase(string tableName)
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = $@"
            CREATE TABLE IF NOT EXISTS {tableName} (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                object_name TEXT NOT NULL
            )
        ";
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }

    public List<VisualObjectBehaviour> visualObjectBehaviours = new List<VisualObjectBehaviour>();
}

