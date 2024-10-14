using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Blazor.Consumer.Tests;

[Collection("Collection")]
public class ConsumerTests : FixturedUnitTest
{
    public ConsumerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }
}
