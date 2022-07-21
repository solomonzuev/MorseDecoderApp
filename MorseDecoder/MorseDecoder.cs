namespace MorseDecoder;

public class MorseDecoder
{
    private static Dictionary<string, string> morseToSymbol = new()
    {
         [".-"] = "A",
         ["-..."] = "B",
         ["-.-."] = "C",
         ["-.."] = "D",
         ["."] = "E",
         ["..-."] = "F",
         ["--."] = "G",
         ["...."] = "H",
         [".."] = "I",
         [".---"] = "J",
         ["-.-"] = "K",
         [".-.."] = "L",
         ["--"] = "M",
         ["-."] = "N",
         ["---"] = "O",
         [".--."] = "P",
         ["--.-"] = "Q",
         [".-."] = "R",
         ["..."] = "S",
         ["-"] = "T",
         ["..-"] = "U",
         ["...-"] = "V",
         [".--"] = "W",
         ["-..-"] = "X",
         ["-.--"] = "Y",
         ["--.."] = "Z",
         [".----"] = "1",
         ["..---"] = "2",
         ["...--"] = "3",
         ["....-"] = "4",
         ["....."] = "5",
         ["-...."] = "6",
         ["--..."] = "7",
         ["---.."] = "8",
         ["----."] = "9",
         ["-----"] = "0",
         [".-.-.-"] = ".",
         ["--..--"] = ",",
         ["-.-.--"] = "!",
         ["..--.."] = "?",
         [" "] = " ",
         ["...---..."] = "SOS"
    };

    public static string DecodeBits(string bits)
    {
        BitDecoder decoder = new(bits);

        return decoder.DecodeToMorse();
    }

    public static string DecodeMorse(string morseCode)
    {
        string[] wordsInMorse = morseCode.Split("   ", StringSplitOptions.RemoveEmptyEntries);

        var decodedWords = wordsInMorse.Select(DecodeWord);

        return string.Join(' ', decodedWords);
    }

    private static string DecodeWord(string wordInMorse)
    {
        string[] symbolsInMorse = wordInMorse.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return string.Join("", DecodeSymbols(symbolsInMorse));
    }

    private static IEnumerable<string> DecodeSymbols(string[] symbolsInMorse)
    {
        return symbolsInMorse.Select(DecodeSymbol);
    }

    private static string DecodeSymbol(string code)
    {
        return morseToSymbol[code];
    }
}