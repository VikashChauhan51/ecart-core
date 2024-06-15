
namespace Ecart.Core.Configurations;
public class SqlConfig
{
    public string ServerName { get; init; } = string.Empty;
    public int ServerPort { get; init; }
    public string DatabaseName { get; init; } = string.Empty;
    public string Credentials { get; init; } = string.Empty;

}
