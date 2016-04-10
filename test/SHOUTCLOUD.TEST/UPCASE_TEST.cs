using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SHOUTCLOUD.TEST
{
    public class UPCASE_TEST
    {
        [Fact]
        public async Task Converts_to_uppercase()
        {
            var input = "hello world";

            var output = await SHOUTCLOUD.UPCASE(input);

            output.Should().Be("HELLO WORLD"); // OMG CLOUD
        }
    }
}
