namespace MorseDecoder;

public class MorseDecoder
{
    private static Dictionary<char, string> symbolToMorse = new()
    {
        ['A'] = ".-",
        ['B'] = "-...",
        ['C'] = "-.-.",
        ['D'] = "-..",
        ['E'] = ".",
        ['F'] = "..-.",
        ['G'] = "--.",
        ['H'] = "....",
        ['I'] = "..",
        ['J'] = ".---",
        ['K'] = "-.-",
        ['L'] = ".-..",
        ['M'] = "--",
        ['N'] = "-.",
        ['O'] = "---",
        ['P'] = ".--.",
        ['Q'] = "--.-",
        ['R'] = ".-.",
        ['S'] = "...",
        ['T'] = "-",
        ['U'] = "..-",
        ['V'] = "...-",
        ['W'] = ".--",
        ['X'] = "-..-",
        ['Y'] = "-.--",
        ['Z'] = "--..",
        ['1'] = ".----",
        ['2'] = "..---",
        ['3'] = "...--",
        ['4'] = "....-",
        ['5'] = ".....",
        ['6'] = "-....",
        ['7'] = "--...",
        ['8'] = "---..",
        ['9'] = "----.",
        ['0'] = "-----",
        ['.'] = ".-.-.-",
        [','] = "--..--",
        ['!'] = "-.-.--",
        ['?'] = "..--..",
        [' '] = " ",
        [' '] = " ",
    };

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
        bits = bits.Trim('0');
        bits += '0';

        string morseCode = string.Empty;

        int timeUnit = 2;
        char currentUnit = '0';
        int unitNumber = 0;
        int zeros = 0;
        int ones = 0;

        foreach (var bit in bits)
        {
            if (bit == currentUnit)
            {
                unitNumber++;
            }
            else
            {
                if (unitNumber / timeUnit == 1)
                {
                    if (currentUnit == '0')
                    {

                    }
                }
            }
        }

        foreach (var bit in bits)
        {
            if (bit == '0')
            {
                if (ones > 0)
                {
                    switch (ones / timeUnit)
                    {
                        case 1:
                            morseCode += '.';
                            break;
                        case 3:
                            morseCode += '-';
                            break;
                    }

                    ones = 0;
                }
                
                zeros++;
            }
            else if (bit == '1')
            {
                if (zeros > 0)
                {
                    switch (zeros / timeUnit)
                    {
                        case 3:
                            morseCode += ' ';
                            break;
                        case 7:
                            morseCode += "   ";
                            break;
                    }

                    zeros = 0;
                }
                
                ones++;
            }
        }
        return morseCode;
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

    public static string Encode(string text)
    {
        text = text.ToUpper();

        return string.Join(' ', EverySymbolToMorseCode(text));
    }

    private static IEnumerable<string> EverySymbolToMorseCode(string text) 
        => text.Select(s => symbolToMorse[s]);
}