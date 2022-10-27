// See https://aka.ms/new-console-template for more information

Console.WriteLine("Day 4 - Giant Squid - Part One");
Console.WriteLine("Load BingoGame!");
var puzzleInput = File.ReadAllLines("PuzzleInput.txt");
var drawnNumbers = BingoDrawnNumber(puzzleInput);

var transposedMatrix = TransposeMatrix(bdMatrix);
var convertedMatrixRowsToIntegerArray = ConvertBinaryRowsToInteger(transposedMatrix);
var gammaRate = Convert.ToInt32(CalculateGammarateBinaryRepresentation(convertedMatrixRowsToIntegerArray), 2);
var epsilonRate = Convert.ToInt32(CalculateEpsilonrateBinaryRepresentation(convertedMatrixRowsToIntegerArray), 2);
Console.WriteLine($"Gammarate: {gammaRate}");
Console.WriteLine($"Epsilonrate: {epsilonRate}");
Console.WriteLine($"Power Consumption: {gammaRate * epsilonRate}");

Console.WriteLine("Day 3 - Binary Diagnostic -  Part Two");

var oxygenGeneratorRate = Convert.ToInt32(CalculateOxygenGeneratorRating(binaryDiagnostic), 2);
var co2ScrubberRate = Convert.ToInt32(CalculateCO2ScrubberRating(binaryDiagnostic), 2);

Console.WriteLine($"OxygenGeneratorrate: {oxygenGeneratorRate}");
Console.WriteLine($"CO2ScrubberRate: {co2ScrubberRate}");
Console.WriteLine($"life support rating: {oxygenGeneratorRate * co2ScrubberRate}");

Console.WriteLine("Press <Escape> to quit");
while (Console.ReadKey().Key != ConsoleKey.Escape) {
}

static string[] BingoDrawnNumber(string[] puzzleinput) {
    return puzzleinput[0].Split(',');
}