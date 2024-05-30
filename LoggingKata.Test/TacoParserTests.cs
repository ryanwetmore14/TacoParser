using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {

            var tacoParser = new TacoParser();


            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");


            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]

        public void ShouldParseLatitude(string line, double expected)
        {

            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }



    }
}
