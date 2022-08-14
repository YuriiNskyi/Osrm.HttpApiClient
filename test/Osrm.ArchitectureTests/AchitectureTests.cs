using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Syntax.Elements.Types.Classes;
using ArchUnitNET.Loader;
using ArchUnitNET.NUnit;
using NUnit.Framework;
using Osrm.HttpApiClient;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Osrm.ArchitectureTests
{
    [TestFixture]
    public class AchitectureTests
    {
        // TIP: load your architecture once at the start to maximize performance of your tests
        private static readonly Architecture Architecture 
            = new ArchLoader()
                .LoadAssemblies(
                    typeof(OsrmHttpApiClient).Assembly,
                    typeof(Geometry).Assembly,
                    typeof(CommonRequest).Assembly,
                    typeof(CommonResponse).Assembly)
                .Build();

        private readonly IObjectProvider<IType> OsrmHttpApiClient 
            = Types().That().ResideInAssembly("Osrm.HttpApiClient").And().ResideInNamespace("Osrm.HttpApiClient").As("HTTP API Client Assembly");

        private readonly IObjectProvider<IType> CommonModels
            = Types().That().ResideInAssembly("Osrm.HttpApiClient.Models.Common").And().ResideInNamespace("Osrm.HttpApiClient.Models.Common").As("Common models");

        private readonly IObjectProvider<IType> RequestsModel
            = Types().That().ResideInAssembly("Osrm.HttpApiClient.Models.Requests").And().ResideInNamespace("Osrm.HttpApiClient.Models.Requests").As("Requests models");

        private readonly IObjectProvider<IType> ResponsesModels
            = Types().That().ResideInAssembly("Osrm.HttpApiClient.Models.Responses").And().ResideInNamespace("Osrm.HttpApiClient.Models.Responses").As("Responses models");

        [Test]
        public void Dependency_direction_is_correct()
        {
            Types().That().Are(CommonModels).Should().NotDependOnAny(Types().That().Are(OsrmHttpApiClient))
                .And(Types().That().Are(CommonModels).Should().NotDependOnAny(Types().That().Are(RequestsModel)))
                .And(Types().That().Are(CommonModels).Should().NotDependOnAny(Types().That().Are(ResponsesModels)))
                .And(Types().That().Are(RequestsModel).Should().NotDependOnAny(Types().That().Are(OsrmHttpApiClient)))
                .And(Types().That().Are(RequestsModel).Should().NotDependOnAny(Types().That().Are(ResponsesModels)))
                .And(Types().That().Are(ResponsesModels).Should().NotDependOnAny(Types().That().Are(OsrmHttpApiClient)))
                .And(Types().That().Are(ResponsesModels).Should().NotDependOnAny(Types().That().Are(RequestsModel)))
                .Check(Architecture);
        }

        [Test]
        public void Naming_conventions_for_requests_are_correct()
        {
            Classes().That().AreAssignableTo(typeof(IOsrmRequest)).Should().HaveNameContaining("Request")
                .And(Classes().That().Are(RequestsModel).And().HaveNameContaining("Request").Should().ResideInNamespace("Osrm.HttpApiClient.Models.Requests"))
                .Check(Architecture);
        }

        [Test]
        public void Naming_conventions_for_responses_are_correct()
        {
            Classes().That().AreAssignableTo(typeof(IOsrmResponse)).Should().HaveNameContaining("Response")
                .And(Classes().That().Are(ResponsesModels).And().HaveNameContaining("Response").Should().ResideInNamespace("Osrm.HttpApiClient.Models.Responses"))
                .Check(Architecture);
        }

        [Test]
        public void Extensions_in_all_assemblies_are_correct()
        {
            static ClassesShouldConjunction ExtensionsAreInternalAndResideInNamespace(IObjectProvider<ICanBeAnalyzed> insideAssembly)
                => Classes().That().Are(insideAssembly).And().HaveNameContaining("Extensions").Should().BeInternal().AndShould().ResideInNamespace("(*).Extensions");

            ExtensionsAreInternalAndResideInNamespace(CommonModels)
                .And(ExtensionsAreInternalAndResideInNamespace(RequestsModel))
                .And(ExtensionsAreInternalAndResideInNamespace(ResponsesModels))
                .And(ExtensionsAreInternalAndResideInNamespace(OsrmHttpApiClient))
                .Check(Architecture);
        }

        [Test]
        public void Free_of_cycles()
        {
            ArchUnitNET.Fluent.Slices.SliceRuleDefinition.Slices().Matching("Osrm.HttpApiClient.(*)").Should()
                    .BeFreeOfCycles()
                    .Check(Architecture);
        }
    }
}
