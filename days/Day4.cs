namespace AoC2024.days;

public class Day4 : Day
{
    private string[] _inputArray;
    public Day4(string inputFilePath) : base(inputFilePath)
    {
        _inputArray = Input.Split('\n');
    }

    public int Part1()
    {
        for(int i = 0; i < _inputArray.Length; i++)
        {
            for (int j = 0; j < _inputArray[i].Length; j++)
            {
                var moves = calculateMoves(i, j);
                if (_inputArray[i][j] != 'X') { continue; }
                
            }
        }
        return default;
    }

    public int Part2()
    {
        return default;
    }

    private int isEndIndex (int i)
    {
        if (i == 0)
        {
            return 1; // if first Index return 1
        }
        if (i == _inputArray.Length - 1)
        {
            return -1; // if last index return 2
        }
        return 0; // if false return 0
    }

    private int isEndIndex (int i, int j)
    {
        if (j == 0)
        {
            return 1; // if first Index return 1
        }
        if (j == _inputArray[i].Length - 1)
        {
            return -1; // if last index return 2
        }
        return 0; // if false return 0
    }

    private List<(int, int)> calculateMoves(
        int rowIndex,
        int columnIndex
        )
    {
        List<(int, int)> moves = new();

        var isRowEnd = isEndIndex(rowIndex);
        switch (isRowEnd)
        {
            case 1:
                moves.Add((rowIndex+1, columnIndex)); // bottom middle
                break;
            case -1:
                moves.Add((rowIndex-1, columnIndex)); // top middle
                break;
            default:
                moves.AddRange(
                    (rowIndex+1, columnIndex), // bottom middle
                    (rowIndex-1, columnIndex) // top middle
                );
                break;
        }

        var isColumnEnd = isEndIndex(rowIndex, columnIndex);
        switch (isColumnEnd)
        {
            case 1:
                moves.Add((rowIndex, columnIndex+1)); // middle right
                break;
            case -1:
                moves.Add((rowIndex, columnIndex-1)); // middle left
                break;
            default:
                moves.AddRange(
                    (rowIndex, columnIndex+1), // middle right
                    (rowIndex, columnIndex-1) // middle left
                ); 
                break;
        }

        if (isRowEnd == 1 && isColumnEnd == 1) // grid top left
        {
            moves.Add((rowIndex+1, columnIndex+1)); // bottom right 
            return moves;
        }
        if (isRowEnd == 1 && isColumnEnd == -1) // grid top right
        {
            moves.Add((rowIndex+1, columnIndex-1)); // bottom left
            return moves;
        }
        if (isRowEnd == -1 && isColumnEnd == 1) // grid bottom left
        {
            moves.Add((rowIndex-1, columnIndex+1)); // top right 
            return moves;
        }
        if (isRowEnd == -1 && isColumnEnd == -1) // grid bottom right
        {
            moves.Add((rowIndex-1, columnIndex-1)); // top left
            return moves;
        }
        if (isRowEnd == 1 && isColumnEnd == 0) // non-edge of top row
        {
            moves.AddRange(
                (rowIndex+1, columnIndex+1), // bottom right 
                (rowIndex+1, columnIndex-1) // bottom left
            );
            return moves;
        }
        if (isRowEnd == -1 && isColumnEnd == 0) // non-edge of bottom row
        {
            moves.AddRange(
                (rowIndex-1, columnIndex+1), // top right
                (rowIndex-1, columnIndex-1) // top left
            );
            return moves;
        }
        if (isRowEnd == 0 && isColumnEnd == 1) // non-edge of leftmost column
        {
            moves.AddRange(
                (rowIndex+1, columnIndex+1), // bottom right 
                (rowIndex-1, columnIndex+1) // top right
            );
            return moves;
        }
        if (isRowEnd == 0 && isColumnEnd == -1) // non-edge of rightmost column
        {
            moves.AddRange(
                (rowIndex+1, columnIndex-1), // bottom left
                (rowIndex-1, columnIndex-1) // top left
            );
            return moves;
        }

        moves.AddRange(
            (rowIndex+1, columnIndex+1), // bottom right 
            (rowIndex+1, columnIndex-1), // bottom left
            (rowIndex-1, columnIndex+1), // top right
            (rowIndex-1, columnIndex-1) // top left
        );
        return moves;
    }
}
