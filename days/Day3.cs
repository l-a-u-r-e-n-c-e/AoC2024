namespace AoC2024.days;

public class Day3 : Day
{
    public Day3(string inputFilePath) : base(inputFilePath)
    {
    }

    public int Part1()
    {
        var result = 0;
        for(int i = 0; i < Input.Length; i++)
        {
            if (!isMulPrefix(i)) { continue; }

            var multiplicandLastIndex = getLastIndex(i, 4, ',');
            if (multiplicandLastIndex == 0) { continue; }
            var multiplicand = i+4 == multiplicandLastIndex 
                ? Input[i+4] - '0' 
                : int.Parse(Input[(i+4)..(multiplicandLastIndex+1)]);
            
            var multiplierLastIndex = getLastIndex(multiplicandLastIndex, 2, ')');
            if (multiplierLastIndex == 0) { continue; }
            var multiplier = multiplicandLastIndex+2 == multiplierLastIndex 
                ? Input[multiplicandLastIndex+2] - '0' 
                : int.Parse(Input[(multiplicandLastIndex+2)..(multiplierLastIndex+1)]);

            result += multiplicand * multiplier;
        }

        return result;
    }

    public int Part2()
    {
        var result = 0;
        var enabled = true;

        for(int i = 0; i < Input.Length; i++)
        {
            enabled = isDo(i) ? true : enabled;
            enabled = isDont(i) ? false : enabled;
            if (!enabled) { continue; }

            if (!isMulPrefix(i)) { continue; }

            var multiplicandLastIndex = getLastIndex(i, 4, ',');
            if (multiplicandLastIndex == 0) { continue; }
            var multiplicand = i+4 == multiplicandLastIndex 
                ? Input[i+4] - '0' 
                : int.Parse(Input[(i+4)..(multiplicandLastIndex+1)]);
            
            var multiplierLastIndex = getLastIndex(multiplicandLastIndex, 2, ')');
            if (multiplierLastIndex == 0) { continue; }
            var multiplier = multiplicandLastIndex+2 == multiplierLastIndex 
                ? Input[multiplicandLastIndex+2] - '0' 
                : int.Parse(Input[(multiplicandLastIndex+2)..(multiplierLastIndex+1)]);

            result += multiplicand * multiplier;
        }
        return result;
    }
    
    private bool isDo(int i)
    {
        return Input[i] == 'd'
        && Input[i+1] == 'o'
        && Input[i+2] == '('
        && Input[i+3] == ')';
    }

    private bool isDont(int i)
    {
        return Input[i] == 'd'
        && Input[i+1] == 'o'
        && Input[i+2] == 'n'
        && Input[i+3] == '\''
        && Input[i+4] == 't'
        && Input[i+5] == '('
        && Input[i+6] == ')';
    }

    private bool isMulPrefix(int i)
    {
        return Input[i] == 'm'
            && Input[i+1] == 'u'
            && Input[i+2] == 'l'
            && Input[i+3] == '(';
    }

    private int getLastIndex(int i, int offset, char validTerminator)
    {
        char terminator = new();
        var isNumber = Input[i+offset] >= 48 && Input[i+offset] <= 57;
        while(isNumber)
        {
            offset++;
            isNumber = Input[i+offset] >= 48 && Input[i+offset] <= 57;
            terminator = Input[i+offset];
        }

        if (terminator != validTerminator) { return 0; }
        return i+offset-1;
    }
}
