using Dapper;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
public class Program
{
    private static void Main(string[] args)
    {
        string oracleConnStr = @"my oracle connect string";
        string sql = @"select modify_date from secuuser where user_id = 'eddy'";
        using (var ocn = new OracleConnection(oracleConnStr))
        {
            TypeString ts = ocn.QueryFirstOrDefault<TypeString>(sql);
            Console.WriteLine("Oracle");
            Console.WriteLine($"Type [String] Vlue = {ts.modify_date}");
            TypeDate td = ocn.QueryFirstOrDefault<TypeDate>(sql);
            Console.WriteLine($"Type [Date] Vlue = {td.modify_date}");
        }
        string postgresConnStr = @"my postgres connect string";
        using (var pcn = new NpgsqlConnection(postgresConnStr))
        {
            Console.WriteLine("Postgres");
            TypeString ts = pcn.QueryFirstOrDefault<TypeString>(sql);
            Console.WriteLine($"Type [String] Vlue = {ts.modify_date}");
            TypeDate td = pcn.QueryFirstOrDefault<TypeDate>(sql);
            Console.WriteLine($"Type [Date] Vlue = {td.modify_date}");
        }
    }
    public class TypeString
    { 
        public string modify_date { get;set; }
    }
    public class TypeDate
    { 
        public DateTime modify_date { get;set; }
    }
}