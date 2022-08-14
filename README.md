# Osrm.HttpApiClient
Http API Client for OSRM library. Supports FlatBuffers format as well.

[![NuGet](https://img.shields.io/nuget/v/Osrm.HttpApiClient.svg?style=flat)](https://www.nuget.org/packages/Osrm.HttpApiClient/)

`$ dotnet add package Osrm.HttpApiClient` / `PM> Install-Package Osrm.HttpApiClient`

## Table of Contents

- [Getting Started](#getting-started)
- [Questions](#questions)
- [Planned](#planned)
- [Benchmark results](#benchmark-results)
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

public static TileRequest Z_13_tile_for_downtown_San_Francisco
    => OsrmServices
        .Tile(
            Driving,
            x: 1310,
            y: 3166,
            zoom: 13);
```

Check full examples inside [Osrm.Examples](https://github.com/YuriiNskyi/Osrm.HttpApiClient/tree/main/src/Osrm.Examples) project. Also, check [Osrm.ConsoleExamples](https://github.com/YuriiNskyi/Osrm.HttpApiClient/tree/main/src/Osrm.ConsoleExamples).

So, the best way to start building your request, is to use handy static methods from `OsrmServices` class. Anyway, you can use plain models, if you want, it's up to you.

Currently supported services are:

- [Nearest service](http://project-osrm.org/docs/v5.23.0/api/#nearest-service)
- [Route service](http://project-osrm.org/docs/v5.23.0/api/#route-service)
- [Table service](http://project-osrm.org/docs/v5.23.0/api/#table-service)
- [Match service](http://project-osrm.org/docs/v5.23.0/api/#match-service)
- [Trip service](http://project-osrm.org/docs/v5.23.0/api/#trip-service)
- [Tile service](http://project-osrm.org/docs/v5.23.0/api/#tile-service)

Feel free to open PR's, in case something warns you or you found anything buggy here!

## Questions

### How can I use it with ASP.NET Core?

Simply register `OsrmHttpApiClient` in DI container:

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

[FlatSharp](https://github.com/jamescourtney/FlatSharp) is used to parse`.fbs` response. This is the only one external dependency.

### Can I modify something in this library?

Sure! 

In case you want to change JSON serializer options - set them new to the `JsonSerializerOptions` property inside `OsrmHttpApiClient`.

In case you want to change any model, they are all unsealed, feel free to inherit them and change whatever you want. This library was designed in mind to always keep valid state inside models, so when modifying models, it's your responsibility to keep that valid state limitations.

### What is X, Y and Zoom in Tile service?

You can find useful information here: [Slippy map tilenames](https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames).

`SlippyMapTiles` methods are also provided, to help with conversion between `lon/lat` and `X/Y`.

### How can I use FlatBuffers format?

You should pass `FlatBuffersFormat` to your builder. Furthermore, special `OsrmFlatBuffersHttpApiClient` and `OsrmFlatBuffersStaticHttpApiClient` are used to process `flatbuffers` format.

## Planned

- ~~Add `Tile` service.~~
- ~~Slightly refactor, extract models to separate packages.~~
- ~~Create some benchmarks.~~
- Create separate, zero-alloc version of this library.

## Benchmark results

Creation of the specified query objects is measured.

``` ini
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
```
| Method                                                       |      Mean |    Error |   StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
| ------------------------------------------------------------ | --------: | -------: | -------: | --------: | -----: | ----: | ----: | --------: |
| Full_GeoJson_route_query                                     |  83.30 ns | 1.644 ns | 2.922 ns |  82.77 ns | 0.0975 |     - |     - |     408 B |
| Full_Polyline_route_query                                    |  87.41 ns | 1.705 ns | 2.094 ns |  86.57 ns | 0.0975 |     - |     - |     408 B |
| Query_on_Berlin_with_three_coordinates                       |  80.44 ns | 1.074 ns | 0.897 ns |  80.30 ns | 0.0975 |     - |     - |     408 B |
| Query_on_Berlin_excluding_the_usage_of_motorways             |  92.39 ns | 1.904 ns | 3.847 ns |  91.12 ns | 0.0918 |     - |     - |     384 B |
| Query_on_Berlin_using_polyline                               |  55.30 ns | 1.152 ns | 2.048 ns |  54.91 ns | 0.0343 |     - |     - |     144 B |
| Querying_nearest_three_snapped_locations                     |  61.50 ns | 1.303 ns | 1.694 ns |  61.07 ns | 0.0612 |     - |     - |     256 B |
| A_3x3_matrix                                                 |  84.98 ns | 1.751 ns | 2.084 ns |  84.10 ns | 0.1070 |     - |     - |     448 B |
| A_1x3_duration_matrix                                        |  97.34 ns | 2.005 ns | 4.994 ns |  97.00 ns | 0.1147 |     - |     - |     480 B |
| An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations |  68.64 ns | 1.428 ns | 1.700 ns |  69.32 ns | 0.0612 |     - |     - |     256 B |
| A_3x3_duration_matrix                                        |  91.09 ns | 1.895 ns | 4.354 ns |  90.03 ns | 0.1070 |     - |     - |     448 B |
| A_3x3_duration_matrix_for_CH                                 |  93.48 ns | 1.944 ns | 4.659 ns |  92.36 ns | 0.1070 |     - |     - |     448 B |
| A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH       |  94.02 ns | 1.607 ns | 1.850 ns |  94.12 ns | 0.1070 |     - |     - |     448 B |
| Round_trip_in_Berlin_with_three_stops                        |  86.12 ns | 2.575 ns | 7.471 ns |  84.09 ns | 0.0975 |     - |     - |     408 B |
| Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last | 104.02 ns | 2.963 ns | 8.455 ns | 101.19 ns | 0.1166 |     - |     - |     488 B |
| Z_13_tile_for_downtown_San_Francisco                         |  11.35 ns | 0.293 ns | 0.536 ns |  11.15 ns | 0.0095 |     - |     - |      40 B |

## License

This library is licensed under the MIT License.