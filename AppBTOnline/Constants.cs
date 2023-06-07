namespace AppBTOnline;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public static class Constants
{
    public const string DatabaseFilename = "MySQLBTO";

    public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
    $"server=localhost;port=8080;database=BDappBTOnline;user=root;password=T3m2D1t1$;";

}
