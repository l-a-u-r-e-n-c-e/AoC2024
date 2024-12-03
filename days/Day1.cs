namespace AoC2024.days;

public class Day1 : Day
{
    public Day1(string inputFilePath) : base(inputFilePath)
    {

    private (List<int>, List<int>) processInput(string input)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        var inputAsArray = Input.Replace("\n", "   ").Split("   ");

        for(int i = 0; i < inputAsArray.Length; i += 2)
        {
            var left = int.Parse(inputAsArray[i]);
            var right = int.Parse(inputAsArray[i+1]);
            leftList.Add(left);
            rightList.Add(right);
        }

        leftList.Sort();
        rightList.Sort();
        return (leftList, rightList);
    }
}
