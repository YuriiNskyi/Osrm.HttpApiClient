# Osrm.HttpApiClient
Http API Client for OSRM library.

[![NuGet](https://img.shields.io/nuget/v/Osrm.HttpApiClient.svg?style=flat)](https://www.nuget.org/packages/Osrm.HttpApiClient/)

`$ dotnet add package Osrm.HttpApiClient` / `PM> Install-Package Osrm.HttpApiClient`

## Table of Contents

- [Getting Started](#getting-started)
- [Questions](#questions)
- [Planned](#planned)
- [License](#license)

## Getting started

Nothing much to add, this is simple HTTP client for OSRM, let's proceed to these clean and fluent examples:

```c#
public static RouteRequest<GeoJsonGeometry> Full_GeoJson_route_query
    => OsrmServices
        .GeoJsonRoute(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219)))
        .Overview(Overview.Full)
        .ReturnAlternatives()
        .ReturnAnnotations()
        .ReturnSteps()
        .Build();

public static RouteRequest<PolylineGeometry> Full_Polyline_route_query
    => OsrmServices
        .PolylineRoute(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219)))
        .Overview(Overview.Full)
        .ReturnAlternatives()
        .ReturnAnnotations()
        .ReturnSteps()
        .Build();

public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_with_three_coordinates 
    => OsrmServices
        .GeoJsonRoute(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219)))
        .Overview(Overview.False)
        .Build();

public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_excluding_the_usage_of_motorways 
    => OsrmServices
        .GeoJsonRoute(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407)))
        .Exclude(ClassName.From("motorway"))
        .Build();

public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_using_polyline 
    => OsrmServices
        .GeoJsonRoute(
            Driving,
            PolylineCoordinates.Create("ofp_Ik_vpAilAyu@te@g`E"))
        .Overview(Overview.False)
        .Build();

public static NearestRequest Querying_nearest_three_snapped_locations 
    => OsrmServices
        .Nearest(
            Driving,
            Coordinate.Create(13.388860, 52.517037, Bearing.Create(0, 20)))
        .NearestSegments(3)
        .Build();

public static TableRequest A_3x3_matrix 
    => OsrmServices
        .Table(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219)))
        .Build();

public static TableRequest An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations 
    => OsrmServices
        .Table(
            Driving,
            PolylineCoordinates.Create("egs_Iq_aqAppHzbHulFzeMe`EuvKpnCglA"))
        .Sources(0, 1, 3)
        .Destinations(2, 4)
        .Build();

public static TableRequest A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH 
    => OsrmServices
        .Table(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219)))
        .Annotations(Annotations.DurationAndDistance)
        .Build();

public static TripRequest<GeoJsonGeometry> Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last 
    => OsrmServices
        .GeoJsonTrip(
            Driving,
            GeographicalCoordinates.Create(
                Coordinate.Create(13.388860, 52.517037),
                Coordinate.Create(13.397634, 52.529407),
                Coordinate.Create(13.428555, 52.523219),
                Coordinate.Create(13.418555, 52.523215)))
        .WithRoundTrip(
            SourceCoordinate.First,
            DestinationCoordinate.Last)
        .Build();
```

Check full examples inside [Osrm.Examples](https://github.com/YuriiNskyi/Osrm.HttpApiClient/tree/main/src/Osrm.Examples) project. Also, check [Osrm.ConsoleExamples](https://github.com/YuriiNskyi/Osrm.HttpApiClient/tree/main/src/Osrm.ConsoleExamples).

So, the best way to start building your request, is to use handy static methods from `OsrmServices` class. Anyway, you can use plain models, if you want, it's up to you.

Currently supported services are:

- [Nearest service](http://project-osrm.org/docs/v5.23.0/api/#nearest-service)
- [Route service](http://project-osrm.org/docs/v5.23.0/api/#route-service)
- [Table service](http://project-osrm.org/docs/v5.23.0/api/#table-service)
- [Match service](http://project-osrm.org/docs/v5.23.0/api/#match-service)
- [Trip service](http://project-osrm.org/docs/v5.23.0/api/#trip-service)

Feel free to open PR's, in case something warns you or you found anything buggy here!

## Questions

### How can I use it with ASP.NET Core?

Simply registering `OsrmHttpApiClient` in DI container:

```c#
services.AddHttpClient<OsrmHttpApiClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("http://router.project-osrm.org");
});
```

### Which serialization library is using?

[System.Text.Json](https://www.nuget.org/packages/System.Text.Json), which is built into `net5.0`. Simple, fast, unobtrusive.

`Polyline` and `Polyline6` geometry types are supported by corresponding JSON serializers.

Check `OsrmHttpApiClient.DefaultJsonSerializerOptions` field for used options.

### Can I modify something in this library?

Sure! 

In case you want to change JSON serializer options - set them new to the `JsonSerializerOptions` property inside `OsrmHttpApiClient`.

In case you want to change any model, they are all unsealed, feel free to inherit them and change whatever you want. This library was designed in mind to always keep valid state inside models, so when modifying models, it's your responsibility to keep that valid state limitations.

## Planned

- Add `Tile` service.
- Slightly refactor, extract models to separate packages.
- Create some benchmarks.
- Create separate, zero-alloc version of this library.

## License

This library is licensed under the MIT License.