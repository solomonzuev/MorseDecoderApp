namespace MorseDecoder.Tests
{
    public class BitDecoderTests
    {
        BitDecoder decoder;

        [Theory]
        [InlineData(".-", "111000111111111000")]
        [InlineData(".--", "111000111111111000111111111")]
        public void Decode_TimeUnitThree_ShouldReturnMorseCode(string expected, string bits)
        {
            decoder = new(bits);

            string actual = decoder.DecodeToMorse();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(".-", "0011001111110")]
        [InlineData(".--", "110011111100111111")]
        [InlineData(".. --   .-.", "101000111011100000001011101")]
        public void Decode_DifferentTimeUnit_ShouldReturnMorseCode(string expected, string bits)
        {
            decoder = new(bits);

            string actual = decoder.DecodeToMorse();

            Assert.Equal(expected, actual);
        }
    }
}
