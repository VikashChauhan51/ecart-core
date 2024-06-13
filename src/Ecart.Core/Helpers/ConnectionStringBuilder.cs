using Ecart.Core.Configurations;
using System.Runtime.CompilerServices;

namespace Ecart.Core.Helpers;
public static class ConnectionStringBuilder
{

    public static string BuildConnectionString(SqlConfig sqlConfig)
    {
        DefaultInterpolatedStringHandler stringHandler = new DefaultInterpolatedStringHandler();
        stringHandler.AppendLiteral("Server=");
        stringHandler.AppendLiteral(sqlConfig.ServerName);
        stringHandler.AppendLiteral(";");
        stringHandler.AppendLiteral("Database=");
        stringHandler.AppendLiteral(sqlConfig.DbName);
        stringHandler.AppendLiteral(";");
        stringHandler.AppendFormatted(sqlConfig.Credentials); 
        stringHandler.AppendLiteral("Trust Server Certificate=true;");
        return stringHandler.ToStringAndClear();
    }
}
