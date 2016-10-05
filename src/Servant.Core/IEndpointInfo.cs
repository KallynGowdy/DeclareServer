
namespace Servant.Core
{
    public class EndpointInfo
    {
        string Version { get; }
        string Culture { get; }
        string Identifier { get; }
        Schema Schema { get; }
        Permission[] Permissions { get; }

        public EndpointInfo(string id, string version, Schema schema, string culture, params Permission[] permissions)
        {
            this.Identifier = id;
            this.Version = version;
            this.Schema = schema;
            this.Culture = culture;
            this.Permissions = permissions;
        }
    }
}