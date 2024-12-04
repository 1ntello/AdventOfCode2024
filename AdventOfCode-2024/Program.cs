using AdventOfCode_2024;

Console.WriteLine("Advent of Code 2024 Challenges");

Console.WriteLine("Enter challenge number");
var challengeNumber = Console.ReadLine();

try
{
    int challengeNo = int.Parse(challengeNumber!);
    Console.WriteLine($"Running challenge {challengeNumber}");
    ChallengeRunner.RunChallenge(challengeNo);
    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadKey();
}