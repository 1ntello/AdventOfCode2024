using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    // models
    public class Item
    {
        public string Icon { get; set; }
        public Item()
        {
            Icon = ".";
        }
    }

    public class Passed : Item 
    {
        public Passed()
        {
            Icon = "X";
        }
    }
    public class Obstacle : Item 
    {
        public Obstacle()
        {
            Icon = "#";
        }
    }
    public class Guard : Item 
    {
        public Guard(Direction direction)
        {
            Direction = direction;
            Icon = "^";
        }

        public void MoveDirectionRight()
        {
            switch (Direction)
            {
                case Direction.Up: Direction = Direction.Right; break;
                case Direction.Down: Direction = Direction.Left; break;
                case Direction.Left: Direction = Direction.Up; break;
                case Direction.Right: Direction = Direction.Down; break;
            }
        }
        public void UpdateIcon()
        {
            switch (Direction)
            {
                case Direction.Up:Icon = "^";break;
                case Direction.Down: Icon = "v"; break;
                case Direction.Left: Icon = "<"; break;
                case Direction.Right: Icon = ">"; break;
            }
        }
        public  Direction Direction { get; set; }
       
    }
    public class Challenge6 : IChallenge
    {
        public Guard guard { get; set; }

        int xBoundary { get; set; }
        int yBoundary { get; set; }
        public string ChallengePart1(string[] input)
        {
            var board = GetBoardFilled(input);
            PrintBoard(board);


            bool offBoard = false;
            Point StartingPosition = board.Where(x => x.Value.GetType() == typeof(Guard)).Single().Key;
            Direction direction = (board.Where(x => x.Value.GetType() == typeof(Guard)).Single().Value as Guard).Direction;
            guard = new Guard(direction);

            board[StartingPosition] = guard; // so we can keep track

            var currentPosition = StartingPosition;
            while (!offBoard)
            {
                // move
                var nextPoint = GetNextPoint(currentPosition);
                if (nextPoint.X >= xBoundary || nextPoint.Y >= yBoundary)
                    break;
                else
                {
                    MoveOnBoard(board, currentPosition, nextPoint);

                    if(board[nextPoint].GetType() != typeof(Obstacle))
                        currentPosition = nextPoint;
                    //PrintBoard(board);
                }
            }

            // +1 to compensate for current position
            return (board.Where(x => x.Value.GetType() == typeof(Passed)).Count() + 1).ToString();

        }

        public string ChallengePart2(string[] input)
        {
            //we keep track of passed points, 
            //if all points are passed twice its a loop
            // we just place an obstacle at every location. 

            var oldBoard = GetBoardFilled(input);
            var pointsToLoopThrough = oldBoard.Where(x => x.Value.GetType() != typeof(Guard) && x.Value.GetType() != typeof(Obstacle)).Select(x => x.Key).ToList();
            var PointsThatWork = new List<Point>();
            int pointCounter = 0;
            Point StartingPosition = oldBoard.Where(x => x.Value.GetType() == typeof(Guard)).Single().Key;
            Direction direction = (oldBoard.Single(x => x.Value.GetType() == typeof(Guard)).Value as Guard).Direction;
            foreach (var p in pointsToLoopThrough)
            {
                Console.WriteLine($"Testing point {pointCounter}");
                var board = new Dictionary<Point, Item>();

                foreach (var item in oldBoard)
                {
                    board.Add(item.Key, item.Value);
                }

                bool offBoard = false;
                guard = new Guard(direction);
                board[p] = new Obstacle();

                Dictionary<Point, int> pointsHit = new Dictionary<Point, int>();
                var currentPosition = StartingPosition;

                while (!offBoard)
                {
                    // move
                    var nextPoint = GetNextPoint(currentPosition);
                    if (nextPoint.X >= xBoundary || nextPoint.Y >= yBoundary || nextPoint.X < 0 || nextPoint.Y < 0)
                    {
                        Console.WriteLine($"{pointCounter}: {p.X},{p.Y} goes out of bounds");
                        offBoard = true;
                        break;
                    }
                    else if (pointsHit.Count > 0 && pointsHit.All(x => x.Value > 1) || pointsHit.Any(x => x.Value > 100))
                    {
                        Console.WriteLine($"{pointCounter}: {p.X},{p.Y} works");
                        offBoard = true;
                        PointsThatWork.Add(p);
                        break;
                    }
                    else
                    {
                        MoveOnBoard(board, currentPosition, nextPoint);

                        if (board[nextPoint].GetType() != typeof(Obstacle))
                        {
                            if (pointsHit.ContainsKey(currentPosition))
                                pointsHit[currentPosition]++;
                            else
                                pointsHit.Add(currentPosition, 1);
                            currentPosition = nextPoint;
                        }
                    }
                }
                pointCounter++;
            }
            return PointsThatWork.Count.ToString();
        }

        private Point GetNextPoint(Point current)
        {
            Point newPoint = current; 
            switch (guard.Direction)
            {
                case Direction.Up: newPoint.Y--; break;
                case Direction.Down: newPoint.Y++; break;
                case Direction.Left: newPoint.X--; break;
                case Direction.Right: newPoint.X++; break;
            }
            return newPoint;
        }
        private void MoveOnBoard(Dictionary<Point, Item> board, Point currentPoint, Point newPoint)
        {
            //Console.WriteLine($"Moving from {currentPoint.X}, {currentPoint.Y} to {newPoint.X}, {newPoint.Y}");
            if (board.ContainsKey(newPoint))
            {
                if (board[newPoint].GetType() == typeof(Obstacle))
                {
                    //Console.WriteLine($"Turning right");
                    // turn right 
                    guard.MoveDirectionRight();
                    guard.UpdateIcon();
                }
                else
                {
                    //Console.WriteLine($"moving forward");
                    board[newPoint] = board[currentPoint];
                    //board[currentPoint] = new Passed();
                }
            }
        }
        private void PrintBoard(Dictionary<Point, Item> board)
        {
            for (int i = 0; i < yBoundary; i++)
            {
                for (int j = 0; j < xBoundary; j++)
                {
                    Console.Write(board[new Point(j, i)].Icon);
                }
                Console.WriteLine();
            }
        }
        private Dictionary<Point, Item> GetBoardFilled(string[] input)
        {
            Dictionary<Point, Item> boardFilled = new Dictionary<Point, Item>();
            xBoundary = input[0].Length;
            yBoundary = input.Length;

            for (int i = 0; i < yBoundary; i++)
            {
                for (int j = 0; j < xBoundary; j++)
                {
                    Item item = new Item();
                    if (input[i].ElementAt(j) == '#')
                        item = new Obstacle();
                    else if (input[i].ElementAt(j) == '<')
                        item = new Guard(Direction.Left);
                    else if (input[i].ElementAt(j) == '>')
                        item = new Guard(Direction.Right);
                    else if (input[i].ElementAt(j) == '^')
                        item = new Guard(Direction.Up);
                    else if (input[i].ElementAt(j) == 'v')
                        item = new Guard(Direction.Down);

                    boardFilled[new Point(j, i)] = item; 
                }
            }

            return boardFilled;
        }
    }

    
}
