using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Blazor.Consumer.Tests;

[Collection("Collection")]
public class ConsumerTests : FixturedUnitTest
{
    public ConsumerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }
}
