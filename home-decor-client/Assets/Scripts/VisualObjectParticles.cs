using System;
using System.Collections.Generic;
using GGMatch3;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class VisualObjectParticles : MonoBehaviour
{
    private VisualObjectParticles.PieceCreatorPool GetPool(VisualObjectParticles.PositionType type)
    {
        for (int i = 0; i < this.pieceCreatorPools.Count; i++)
        {
            VisualObjectParticles.PieceCreatorPool pieceCreatorPool = this.pieceCreatorPools[i];
            if (pieceCreatorPool.type == type)
            {
                return pieceCreatorPool;
            }
        }
        return null;
    }

    public void CreateParticles(VisualObjectParticles.PositionType positionType, GameObject parent, VisualObjectBehaviour visualObjectBehaviour)
    {
        VisualObjectVariation activeVariation = visualObjectBehaviour.activeVariation;
        for (int i = 0; i < activeVariation.sprites.Count; i++)
        {
            String variation = activeVariation.name;
            AddAndUpdateSQL(variation);
            VisualSprite visualSprite = activeVariation.sprites[i];
            if (!visualSprite.visualSprite.isShadow)
            {
                SpriteRenderer spriteRenderer = visualSprite.spriteRenderer;
                GameObject gameObject = this.CreateParticles(positionType, parent);
                GGUtil.Show(gameObject);
                if (!(gameObject == null))
                {
                    Match3ParticleSystem component = gameObject.GetComponent<Match3ParticleSystem>();
                    if (!(component == null))
                    {
                        List<ParticleSystem> allParticleSystems = component.GetAllParticleSystems();
                        for (int j = 0; j < allParticleSystems.Count; j++)
                        {
                            ParticleSystem particleSystem = allParticleSystems[j];
                            var temp = particleSystem.shape;

                            temp.spriteRenderer = spriteRenderer;
                            ParticleSystemRenderer component2 = particleSystem.GetComponent<ParticleSystemRenderer>();
                            component2.sortingLayerID = this.sortingLayer.sortingLayerId;
                            component2.sortingOrder = spriteRenderer.sortingOrder + 1;
                        }
                        component.StartParticleSystems();
                    }
                }
            }
        }

    }

    public void AddAndUpdateSQL(String variation)
    {
        string var = variation.Split("_")[0];
        IDbConnection dbConnectionRoom = CreateAndOpenDatabase("RoomCurrent");
        IDbCommand dbCommandCheckRoom = dbConnectionRoom.CreateCommand();
        dbCommandCheckRoom.CommandText = $"SELECT object_name FROM RoomCurrent WHERE id = 1";
        object res = dbCommandCheckRoom.ExecuteScalar();
        string room = Convert.ToString(res);
        List<string> dataList = new List<string>();
        IDbConnection dbConnection = CreateAndOpenDatabase(room);
        IDbCommand dbCommandCheckIfExists = dbConnection.CreateCommand();
        dbCommandCheckIfExists.CommandText = $"SELECT object_name FROM {room}";
        IDataReader dataReader = dbCommandCheckIfExists.ExecuteReader();
        while (dataReader.Read())
        {
            string data = dataReader.GetString(0).Split("_")[0]; // Lấy dữ liệu từ cột 'object_name'
            dataList.Add(data); // Thêm dữ liệu vào danh sách
        }
        int count = dataList.IndexOf(var);
        if (count == -1)
        {
            IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
            dbCommandInsertValue.CommandText = $"INSERT INTO {room} (object_name) VALUES ('{variation}')";
            dbCommandInsertValue.ExecuteNonQuery();
        }
        else
        {
            IDbCommand dbCommandUpdateValue = dbConnection.CreateCommand();
            dbCommandUpdateValue.CommandText = $"UPDATE {room} SET object_name = '{variation}' WHERE id = {count + 1}";
            dbCommandUpdateValue.ExecuteNonQuery();
        }
        dbConnectionRoom.Close();
        dbConnection.Close();
    }

    private IDbConnection CreateAndOpenDatabase(string tableName)
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        // Create a command for creating a table in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = $@"
            CREATE TABLE IF NOT EXISTS {tableName} (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                object_name TEXT NOT NULL
            )
        ";

        // Execute the query to create the table
        dbCommandCreateTable.ExecuteNonQuery();

        return dbConnection;
    }

    public GameObject CreateParticles(VisualObjectParticles.PositionType positionType, GameObject parent)
    {
        VisualObjectParticles.PieceCreatorPool pool = this.GetPool(positionType);
        if (pool == null)
        {
            return null;
        }
        GameObject prefab = pool.prefab;
        if (prefab == null)
        {
            return null;
        }
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
        gameObject.transform.parent = parent.transform;
        return gameObject;
    }

    [SerializeField]
    private SpriteSortingSettings sortingLayer = new SpriteSortingSettings();

    [SerializeField]
    private List<VisualObjectParticles.PieceCreatorPool> pieceCreatorPools = new List<VisualObjectParticles.PieceCreatorPool>();

    public enum PositionType
    {
        ChangeSuccess,
        BuySuccess
    }

    [Serializable]
    public class PieceCreatorPool
    {
        public VisualObjectParticles.PositionType type;

        public GameObject prefab;
    }
}
