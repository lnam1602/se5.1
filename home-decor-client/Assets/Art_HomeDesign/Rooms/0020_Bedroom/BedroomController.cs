using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Collections;


public class BedRoomController : MonoBehaviour
{
    public GameObject background_default;
    public GameObject ceiling_default;
    public GameObject wall_default;
    public GameObject wallright_default;
    public GameObject floor_default;
    private Queue<GameObject> objectQueue = new Queue<GameObject>();
    public void onReplay()
    {
        Debug.Log("On Replay");
        // Read all object in room3

        var furnitures = new List<GameObject>();
        // Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase("Room3");
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM Room3";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();

        while (dataReader.Read())
        {
            var id = dataReader.GetInt32(0);
            var objectName = dataReader.GetString(1);

            Debug.Log($"id: {id}, objectName: {objectName}");

            GameObject obj = GameObject.Find(objectName);
            furnitures.Add(obj);
        }

        foreach (var obj in furnitures)
        {
            obj.SetActive(false);
        }

        dbConnection.Close();
        // Show all furnitures again
        StartCoroutine(ShowObjectsWithDelay(furnitures));
    }

    void AddGameObject()
    {
        objectQueue.Enqueue(background_default);
        objectQueue.Enqueue(ceiling_default);
        objectQueue.Enqueue(wall_default);
        objectQueue.Enqueue(wallright_default);
        objectQueue.Enqueue(floor_default);
    }

    private IEnumerator ShowObjectsWithDelay(List<GameObject> gameObjects)
    {
        AddGameObject();
        while (objectQueue.Count > 0)
        {
            // Lấy đối tượng đầu hàng đợi
            GameObject currentObj = objectQueue.Dequeue();

            // Hiển thị đối tượng
            currentObj.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f); // Đổi giá trị độ trễ tại đây

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
                id INTEGER AUTO_INCREMENT PRIMARY KEY,
                object_name VARCHAR(255) NOT NULL
            )
        ";
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }

    public List<VisualObjectBehaviour> visualObjectBehaviours = new List<VisualObjectBehaviour>();
}