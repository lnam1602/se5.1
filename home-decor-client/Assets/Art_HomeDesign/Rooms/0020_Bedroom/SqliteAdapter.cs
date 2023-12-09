using UnityEngine;
using System.Data;
using Mono.Data.Sqlite; 

public class SqliteAdapter : MonoBehaviour
{
    [SerializeField] private int hitCount = 0;

    void Start()
    {
        Debug.Log("Start");
        // Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM DecorationOrder";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();

        while (dataReader.Read())
        {
            var id = dataReader.GetInt32(0);
            var objectName = dataReader.GetString(1);
            var order = dataReader.GetInt32(2);

            Debug.Log($"id: {id}, objectName: {objectName}, orderNo: {order}");
        }

        AddDecorationOBject();

        // Remember to always close the connection at the end.
        dbConnection.Close();

        Debug.Log("Close");
    }

    private void AddDecorationOBject()
    {
        // Insert hits into the table.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = @"
            INSERT INTO DecorationOrder (
                object_name,
                order_no
            )
            VALUES (
                'bed',
                1
            )";
        dbCommandInsertValue.ExecuteNonQuery();

        // Remember to always close the connection at the end.
        dbConnection.Close();
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
                object_name VARCHAR(255) NOT NULL,
                order_no INTEGER
            )
            ";
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }
}
