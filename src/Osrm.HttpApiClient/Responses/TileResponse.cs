using System;

namespace Osrm.HttpApiClient
{
    public record TileResponse
    {
        public byte[] VectorTile { get; set; } = Array.Empty<byte>();
    }
}
