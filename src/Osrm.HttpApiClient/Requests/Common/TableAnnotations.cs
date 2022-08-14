using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record TableAnnotations
    {
        public TableAnnotations(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly TableAnnotations Duration = new ("duration");
        public static readonly TableAnnotations Distance = new ("distance");
        public static readonly TableAnnotations DurationAndDistance = new ("duration,distance");
    }
}
