using System.Data;
using System.Data.SqlClient;

namespace ADO.Net.DataAccess;

public class Sql
{
    private const string _connectionStrings = "Server=DESKTOP-HQUMO3A\\SQLEXPRESS;Database=ADONet;Trusted_Connection=true";
    private static SqlConnection _connection = new(_connectionStrings);

    public int ExecuteCommand(string command)
    {
        int result = 0;
        try
        {
            _connection.Open();
            SqlCommand cmd = new(command, _connection);
            result = cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        finally { _connection.Close(); }
        return result;

    }
    public DataTable ExecuteQuery(string query)
    {
        DataTable table = new();
        try
        {
            _connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,_connection);
            sqlDataAdapter.Fill(table);

        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        finally { _connection.Close(); }
        return table;

    }
}
