namespace P06_Sneaking
{
    using System;

    public class Sneaking
    {
        static char[][] room;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            room = new char[rows][];

            AddPlayers(rows);

            var moves = Console.ReadLine().ToCharArray();

            var samPosition = SamPosition();

            Moves(moves, samPosition);
        }

        private static void Moves(char[] moves, int[] samPosition)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                EnemyMoves();

                var getEnemy = GetEnemy(samPosition);

                if (IsSamDied(samPosition, getEnemy)) return;

                SamMove(samPosition, moves, i);

                room[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }

                if (IsNikoladzeKilled(getEnemy, samPosition)) return;
            }
        }

        private static void SamMove(int[] samPosition, char[] moves, int i)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static bool IsNikoladzeKilled(int[] getEnemy, int[] samPosition)
        {
            if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                room[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                NikoladzeDied();
                return true;
            }

            return false;
        }

        private static void NikoladzeDied()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }

            return;
        }

        private static bool IsSamDied(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';

                SamDied(samPosition);

                return true;
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';

                SamDied(samPosition);
            }

            return false;
        }

        private static void SamDied(int[] samPosition)
        {
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static int[] GetEnemy(int[] samPosition)
        {
            int[] getEnemy = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }

            return getEnemy;
        }

        private static void EnemyMoves()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static int[] SamPosition()
        {
            int[] samPosition = new int[2];

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                        break;
                    }
                }
            }

            return samPosition;
        }

        private static void AddPlayers(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}