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
            var isMullPrefix = Input[i] == 109 // m
                && Input[i+1] == 117 // u 
                && Input[i+2] == 108 // l
                && Input[i+3] == 40; // (
            if (!isMullPrefix) { continue; }

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
