namespace MorseDecoder.Tests
{
    public class MorseDecoderTests
    {
        [Theory]
        [InlineData("A", ".-")]
        [InlineData("B", "-...")]
        [InlineData("C", "-.-.")]
        [InlineData("D", "-..")]
        [InlineData("E", ".")]
        [InlineData("F", "..-.")]
        [InlineData("H", "....")]
        [InlineData("Z", "--..")]
        [InlineData(".", ".-.-.-")]
        [InlineData(",", "--..--")]
        [InlineData("!", "-.-.--")]
        [InlineData("?", "..--..")]
        [InlineData("", "")]
        public void DecodeMorse_ShouldReturnOneSymbol(string expected, string morseCode)
        {
            string actual = MorseDecoder.DecodeMorse(morseCode);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Decode_SpecialCase_ShouldReturnSOS()
        {
            string actual = MorseDecoder.DecodeMorse("...---...");

            Assert.Equal("SOS", actual);
        }

        [Theory]
        [InlineData("APPLE", ".- .--. .--. .-.. .")]
        [InlineData("BACK", "-... .- -.-. -.-")]
        [InlineData("CREM", "-.-. .-. . --")]
        [InlineData("DOG", "-.. --- --.")]
        public void DecodeMorse_ShouldReturnOneWord(string expected, string morseCode)
        {
            string actual = MorseDecoder.DecodeMorse(morseCode);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("APPLE IS GOOD.", ".- .--. .--. .-.. .   .. ...   --. --- --- -.. .-.-.-")]
        [InlineData("BACK AND PACK", "-... .- -.-. -.-   .- -. -..   .--. .- -.-. -.-")]
        [InlineData("MY CREM", "-- -.--   -.-. .-. . --")]
        [InlineData("HI, MARY!", ".... .. --..--   -- .- .-. -.-- -.-.--")]
        public void DecodeMorse_ShouldReturnText(string expected, string morseCode)
        {
            string actual = MorseDecoder.DecodeMorse(morseCode);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(".-", "0110011111100")]
        [InlineData("-- .", "001111110011111100000011")]
        [InlineData(".. -.   --", "11001100000011111100110000000000000011111100111111")]
        [InlineData(".... . -.--   .--- ..- -.. .", "1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")]
        public void DecodeBits_TwoTimeUnit_ShouldReturnCorrectMorseCode(string expected, string bits)
        {
            string actual = MorseDecoder.DecodeBits(bits);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(".-", "111000111111111000")]
        [InlineData(".-", "00111000111111111000")]
        [InlineData(".-", "111000111111111")]
        [InlineData("-- .", "011101110001")]
        [InlineData(".. -.   --", "1010001110100000001110111")]
        [InlineData(".... .. --..--   -- .- .-. -.-- -.-.--", "111100001111000011110000111100000000000011110000111100000000000011111111111100001111111111110000111100001111000011111111111100001111111111110000000000000000000000000000111111111111000011111111111100000000000011110000111111111111000000000000111100001111111111110000111100000000000011111111111100001111000011111111111100001111111111110000000000001111111111110000111100001111111111110000111100001111111111110000111111111111")]
        public void DecodeBits_DifferentTimeUnit_ShouldReturnCorrectMorseCode(string expected, string bits)
        {
            string actual = MorseDecoder.DecodeBits(bits);

            Assert.Equal(expected, actual);
        }
    }
}