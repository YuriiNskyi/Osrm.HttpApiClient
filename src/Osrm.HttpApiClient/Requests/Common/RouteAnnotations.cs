using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record RouteAnnotations
    {
        public RouteAnnotations(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly RouteAnnotations True = new("true");
        public static readonly RouteAnnotations False = new("false");
        public static readonly RouteAnnotations Nodes = new("nodes");
        public static readonly RouteAnnotations Distance = new("distance");
        public static readonly RouteAnnotations Duration = new("duration");
        public static readonly RouteAnnotations Datasources = new("datasources");
        public static readonly RouteAnnotations Weight = new("weight");
        public static readonly RouteAnnotations Speed = new("speed");
    }
}
