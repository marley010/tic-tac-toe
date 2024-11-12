using System;
using System.Linq;

string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
bool isPlayer1Turn = true;
int numTurns = 0;

while (CheckVictory() == null && numTurns < 9)
{
    PrintGrid();

    if (isPlayer1Turn)
        Console.WriteLine("Player 1 turn!");
    else
        Console.WriteLine("Player 2 turn!");

    string choice = Console.ReadLine();

    if (grid.Contains(choice) && choice != "X" && choice != "0")
    {
        int gridIndex = Convert.ToInt32(choice) - 1;

        if (isPlayer1Turn)
            grid[gridIndex] = "X";
        else
            grid[gridIndex] = "0";

        // Wissel van beurt en verhoog de zet-teller
        isPlayer1Turn = !isPlayer1Turn;
        numTurns++;
    }
    else
    {
        Console.WriteLine("Invalid choice. Try again.");
    }
}

PrintGrid(); // Laat het eindrooster zien

string winner = CheckVictory();
if (winner == "X")
    Console.WriteLine("Player 1 wins!");
else if (winner == "0")
    Console.WriteLine("Player 2 wins!");
else
    Console.WriteLine("Tie!");

string CheckVictory()
{
    // Controleer rijen, kolommen en diagonalen voor een winnaar
    if (grid[0] == grid[1] && grid[1] == grid[2]) return grid[0];
    if (grid[3] == grid[4] && grid[4] == grid[5]) return grid[3];
    if (grid[6] == grid[7] && grid[7] == grid[8]) return grid[6];

    if (grid[0] == grid[3] && grid[3] == grid[6]) return grid[0];
    if (grid[1] == grid[4] && grid[4] == grid[7]) return grid[1];
    if (grid[2] == grid[5] && grid[5] == grid[8]) return grid[2];

    if (grid[0] == grid[4] && grid[4] == grid[8]) return grid[0];
    if (grid[6] == grid[4] && grid[4] == grid[2]) return grid[6];

    // Geen winnaar
    return null;
}

void PrintGrid()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(grid[i * 3 + j] + "|");
        }
        Console.WriteLine();
        Console.WriteLine("------");
    }
}