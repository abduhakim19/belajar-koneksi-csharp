using System;
using System.Data.SqlClient;

public class DatabaseManager
{
	public static SqlConnection GetConnection()
	{

        string connectionString = "Data Source=HAKIM-COMPUTER;Database=db_hr_dts;Connect Timeout=30;Integrated Security=True";
        var conn = new SqlConnection(connectionString);
        return conn;
	}
}
