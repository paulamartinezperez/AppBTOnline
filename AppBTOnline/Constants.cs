namespace AppBTOnline;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public static class Constants
{
    public const string DatabaseFilename = "MySQLBTO";

    public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
    $"server=147.96.85.89;port=8080;database=BDappBTOnline;user=BDappBTOnline;password=BDappBTOnline;";

}
