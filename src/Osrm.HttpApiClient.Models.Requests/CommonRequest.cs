using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Uri, nq}")]
    public abstract record CommonRequest : IOsrmRequest
    {
        private IReadOnlyCollection<ClassName> _exclude = Array.Empty<ClassName>();
        private Snapping _snapping = Snapping.Default;

        protected CommonRequest(string profile, Coordinates coordinates)
        {
            Profile = string.IsNullOrWhiteSpace(profile) 
                ? PredefinedProfiles.Car
                : profile;
            Coordinates = coordinates;
        }

        /// <summary>
        /// One of the following values: route, nearest, table, match, trip, tile.
        /// </summary>
        public abstract string Service { get; }

        /// <summary>
        /// Version of the protocol implemented by the service. v1 for all OSRM 5.x installations
        /// </summary>
        public string Version => "v1";

        /// <summary>
        /// Mode of transportation, is determined statically by the Lua profile that is used to prepare the data using osrm-extract.
        /// Typically car, bike or foot if using one of the supplied profiles.
        /// </summary>
        public string Profile { get; } = PredefinedProfiles.Car;

        /// <summary>
        /// String of format {longitude},{latitude};{longitude},{latitude}[;{longitude},{latitude} ...] or polyline({polyline}) or polyline6({polyline6}).
        /// </summary>
        public Coordinates Coordinates { get; }

        /// <summary>
        /// Adds a Hint to the response which can be used in subsequent requests, see hints parameter.
        /// </summary>
        public bool GenerateHints { get; set; } = true;

        /// <summary>
        /// Additive list of classes to avoid, order does not matter.
        /// </summary>
        public IReadOnlyCollection<ClassName> Exclude 
        {
            get => _exclude;
            set => _exclude = value ?? Array.Empty<ClassName>();
        }

        /// <summary>
        /// Default snapping avoids is_startpoint (see profile) edges, any will snap to any edge in the graph.
        /// </summary>
        public Snapping Snapping 
        {
            get => _snapping;
            set => _snapping = value ?? Snapping.Default;
        }

        /// <summary>
        /// Removes waypoints from the response. Waypoints are still calculated, but not serialized.
        /// Could be useful in case you are interested in some other part of response and do not want to transfer waste data.
        /// </summary>
        public bool SkipWaypoints { get; set; } = false;

        public virtual IReadOnlyCollection<RequestOption> AdditionalOptions { get; } = Array.Empty<RequestOption>();

        public string Uri
        {
            get
            {
                var options = Coordinates.Options
                    .Concat(AdditionalOptions)
                    .Concat(new[]
                    {
                        RequestOption.Create("generate_hints", GenerateHints.ToLowerInvariant()),
                        Exclude.Any()
                            ? RequestOption.Create("exclude", Exclude.Select(e => e.Value).Join(RequestConstants.Comma))
                            : RequestOption.Empty,
                        RequestOption.Create("snapping", Snapping.Value),
                        RequestOption.Create("skip_waypoints", SkipWaypoints.ToLowerInvariant()),
                    })
                    .Where(o => o.HasValue)
                    .Select(o => o.ToString())
                    .Join(RequestConstants.Ampersand);

                var requestUri = $"{Service}/{Version}/{Profile}/{Coordinates.Value}?{options}";

                return requestUri;
            }
        }
    }
}
