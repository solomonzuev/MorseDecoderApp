namespace MorseDecoder;

public class BitDecoder
{
    private const char DOT = '.';
    private const char DASH = '-';
    private const char SPACE_BETWEEN_SYMBOLS = ' ';
    private const string SPACE_BETWEEN_WORDS = "   ";

    private string _bits;
    private string _morseCode = string.Empty;
    private char _currentBit;

    private int _timeUnit;
    private int _numberOfBits;

    public BitDecoder(string bits)
    {
        _bits = PrepareForDecoding(bits);
        _timeUnit = CalculateTimeUnit();
    }

    private string PrepareForDecoding(string bits)
    {
        string preparedBits = bits.Trim('0');
        preparedBits += '0';

        return preparedBits;
    }

    private int CalculateTimeUnit()
    {
        int timeUnit = int.MaxValue;
        int timePart = 0;

        char lastBit = _bits[0];

        foreach (var bit in _bits)
        {
            if (bit != lastBit)
            {
                if (timePart < timeUnit)
                {
                    timeUnit = timePart;
                }

                timePart = 0;
                lastBit = bit;
            }

            timePart++;
        }

        if (timeUnit < 1)
        {
            throw new ArgumentException($"Failed to get a unit of time for {_bits}");
        }

        return timeUnit;
    }

    public string DecodeToMorse()
    {
        ResetFields();

        foreach (var bit in _bits)
        {
            if (_currentBit != bit)
            {
                ConvertCurrentNumberOfBitsToMorse();
                
                _numberOfBits = 0;
                _currentBit = bit;
            }

            _numberOfBits++;
        }

        return _morseCode;
    }

    private void ResetFields()
    {
        _morseCode = string.Empty;
        _currentBit = _bits[0];
        _numberOfBits = 0;
    }

    private void ConvertCurrentNumberOfBitsToMorse()
    {
        if (IsMorseDot())
        {
            _morseCode += DOT;
        }
        else if (IsMorseDash())
        {
            _morseCode += DASH;
        }
        else if (IsSpaceBetweenSymbols())
        {
            _morseCode += SPACE_BETWEEN_SYMBOLS;
        }
        else if (IsSpaceBetweenWords())
        {
            _morseCode += SPACE_BETWEEN_WORDS;
        }
    }

    private bool IsMorseDot() => _currentBit =='1' && GetTimeUnitLong() == 1;
    private bool IsMorseDash() => _currentBit == '1' && GetTimeUnitLong() == 3;
    private bool IsSpaceBetweenSymbols() => _currentBit =='0' && GetTimeUnitLong() == 3;
    private bool IsSpaceBetweenWords() => _currentBit == '0' && GetTimeUnitLong() == 7;

    private int GetTimeUnitLong() => _numberOfBits / _timeUnit;
}
