using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Blazor.Consumer.Tests;

[Collection("Collection")]
public class BaseConsumerTests : FixturedUnitTest
{
    public BaseConsumerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }
}
