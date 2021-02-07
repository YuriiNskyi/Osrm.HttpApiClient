using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Overview
    {
        public Overview(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Overview Simplified = new ("simplified");
        public static readonly Overview Full = new ("full");
        public static readonly Overview False = new ("false");
    }
}
