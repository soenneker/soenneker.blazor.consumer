using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Consumer.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ConsumerTests : HostedUnitTest
{

    public ConsumerTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
