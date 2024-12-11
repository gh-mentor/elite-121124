using System;
using System.Data.SQLite;

public class LoginManager
{
    private string dbName;
    private SQLiteConnection conn;
    private SQLiteCommand cmd;

    public LoginManager(string dbName)
    {
        this.dbName = dbName;
        this.conn = null;
        this.cmd = null;
    }

    private void ConnectToDb()
    {
        this.conn = new SQLiteConnection($"Data Source={this.dbName};Version=3;");
        this.conn.Open();
        this.cmd = this.conn.CreateCommand();
    }

    public bool Login(string username, string password)
    {
        ConnectToDb();

        string query = $"SELECT * FROM users WHERE username = '{username}' AND password = '{password}'";
        this.cmd.CommandText = query;

        SQLiteDataReader reader = this.cmd.ExecuteReader();

        bool result = reader.HasRows;

        reader.Close();
        this.conn.Close();

        return result;
    }
}