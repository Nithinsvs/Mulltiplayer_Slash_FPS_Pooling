using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class HitCount : MonoBehaviour
{

    [SerializeField] private int hitCountUnModified = 0;
    [SerializeField] private int hitCountShift = 0;
    [SerializeField] private int hitCountControl = 0;

    private KeyCode modifier = default;


    private void Start()
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM HitCountTableSimple";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();

        while(dataReader.Read())
        {
            var id = dataReader.GetInt32(0);
            var hits = dataReader.GetInt32(1);

            if (id == (int)KeyCode.LeftShift)
                hitCountShift = hits;
            else if (id == (int)KeyCode.LeftControl)
                hitCountControl = hits;
            else
                hitCountUnModified = hits;
        }

        dbConnection.Close();

        Debug.Log("hitCountUnModified: " + hitCountUnModified);
        Debug.Log("hitCountShift: " + hitCountShift);
        Debug.Log("hitCountControl: " + hitCountControl);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            modifier = KeyCode.LeftShift;
        else if (Input.GetKey(KeyCode.LeftControl))
            modifier = KeyCode.LeftControl;
        else
            modifier = default;
    }


    private void OnMouseDown()
    {
        var hitCount = 0;
        switch (modifier)
        {
            case KeyCode.LeftShift:
                hitCount = ++hitCountShift;
                break;
            case KeyCode.LeftControl:
                hitCount = ++hitCountControl;
                break;
            default:
                hitCount = ++hitCountUnModified;
                break;
        }

        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "INSERT OR REPLACE INTO HitCountTableSimple (id, hits) VALUES (" + (int)modifier + "," + hitCount + ")";
        dbCommand.ExecuteNonQuery();

        dbConnection.Close();

        Debug.Log("hitCountUnModified: " + hitCountUnModified);
        Debug.Log("hitCountShift: " + hitCountShift);
        Debug.Log("hitCountControl: " + hitCountControl);
    }

    private IDbConnection CreateAndOpenDatabase()
    {
        //Open a database connection
        string dbURI = "URI=file:MyDatabase.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbURI);
        dbConnection.Open();

        //Create a table for hit count in database
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS HitCountTableSimple (id INTEGER PRIMARY KEY, hits INTEGER)";
        dbCommand.ExecuteReader();

        return dbConnection;
    }
}
