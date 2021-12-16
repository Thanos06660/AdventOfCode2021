// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
Console.WriteLine("Day 3 - Binary Diagnostic - Part One");
Console.WriteLine("Load SubmarineCourse!");
var binaryDiagnostic = File.ReadAllLines("DiagnosticReport.txt");
var bdMatrix = binaryDiagnostic.Select(s => s.ToCharArray()).ToArray();
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

static string CalculateOxygenGeneratorRating(string[] binaryDiagnostic) {
    var counter = 0;
    var tempDiagnostics = binaryDiagnostic;
    var bdMatrix = tempDiagnostics.Select(s => s.ToCharArray()).ToArray();
    var transposedMatrix = TransposeMatrix(bdMatrix);
    var transposedMatrixSecondDimensionLength = transposedMatrix.GetLength(1);
    var convertedMatrixRowsToIntegerArray = ConvertBinaryRowsToInteger(transposedMatrix);
    var mostCommonBit = GetMostCommonBit2(SparseBitcount(convertedMatrixRowsToIntegerArray[counter]), transposedMatrixSecondDimensionLength);

    while (tempDiagnostics.Length > 1) {
        tempDiagnostics = tempDiagnostics.Where(td => td[counter].Equals(mostCommonBit)).ToArray();
        bdMatrix = tempDiagnostics.Select(s => s.ToCharArray()).ToArray();
        transposedMatrix = TransposeMatrix(bdMatrix);
        transposedMatrixSecondDimensionLength = transposedMatrix.GetLength(1);
        convertedMatrixRowsToIntegerArray = ConvertBinaryRowsToInteger(transposedMatrix);
        counter++;
        mostCommonBit = GetMostCommonBit2(SparseBitcount(convertedMatrixRowsToIntegerArray[counter]), transposedMatrixSecondDimensionLength);
    }

    return tempDiagnostics[0];
}

static string CalculateCO2ScrubberRating(string[] binaryDiagnostic) {
    var counter = 0;
    var tempDiagnostics = binaryDiagnostic;
    var bdMatrix = tempDiagnostics.Select(s => s.ToCharArray()).ToArray();
    var transposedMatrix = TransposeMatrix(bdMatrix);
    var transposedMatrixSecondDimensionLength = transposedMatrix.GetLength(1);
    var convertedMatrixRowsToIntegerArray = ConvertBinaryRowsToInteger(transposedMatrix);
    var leastCommonBit = GetLeastCommonBit2(SparseBitcount(convertedMatrixRowsToIntegerArray[counter]), transposedMatrixSecondDimensionLength);

    while (tempDiagnostics.Length > 1) {
        tempDiagnostics = tempDiagnostics.Where(td => td[counter].Equals(leastCommonBit)).ToArray();
        bdMatrix = tempDiagnostics.Select(s => s.ToCharArray()).ToArray();
        transposedMatrix = TransposeMatrix(bdMatrix);
        transposedMatrixSecondDimensionLength = transposedMatrix.GetLength(1);
        convertedMatrixRowsToIntegerArray = ConvertBinaryRowsToInteger(transposedMatrix);
        counter++;
        leastCommonBit = GetLeastCommonBit2(SparseBitcount(convertedMatrixRowsToIntegerArray[counter]), transposedMatrixSecondDimensionLength);
    }

    return tempDiagnostics[0];
}

static string CalculateGammarateBinaryRepresentation(BigInteger[] bigIntegerArray) {
    var gammaRateinBinaryPresentation = new char[bigIntegerArray.Length];
    for (var i = 0; i < bigIntegerArray.Length; i++) {
        gammaRateinBinaryPresentation[i] = GetMostCommonBit(SparseBitcount(bigIntegerArray[i]));
    }

    return new string(gammaRateinBinaryPresentation);
}

static string CalculateEpsilonrateBinaryRepresentation(BigInteger[] bigIntegerArray) {
    var epsilonRateinBinaryPresentation = new char[bigIntegerArray.Length];
    for (var i = 0; i < bigIntegerArray.Length; i++) {
        epsilonRateinBinaryPresentation[i] = GetLeastCommonBit(SparseBitcount(bigIntegerArray[i]));
    }

    return new string(epsilonRateinBinaryPresentation);
}

static int SparseBitcount(BigInteger n) {
    var count = 0;
    while (n != 0) {
        count++;
        n &= n - 1;
    }

    return count;
}

static char GetMostCommonBit(int numberOfSetBits) {
    return numberOfSetBits >= 500
        ? '1'
        : '0';
}

static char GetLeastCommonBit(int numberOfSetBits) {
    return numberOfSetBits >= 500
        ? '0'
        : '1';
}

static char GetMostCommonBit2(int numberOfSetBits, int divider) {
    return numberOfSetBits >= divider / 2
        ? '1'
        : '0';
}

static char GetLeastCommonBit2(int numberOfSetBits, int divider) {
    return numberOfSetBits >= divider / 2
        ? '0'
        : '1';
}

static BigInteger[] ConvertBinaryRowsToInteger(char[,] matrix) {
    var numberOfRows = matrix.GetLength(0);
    var convertedBinaries = new BigInteger[numberOfRows];
    for (var i = 0; i < numberOfRows; i++) {
        var row = matrix.GetRow(i);
        convertedBinaries[i] = BinToDec(new string(row));
    }

    return convertedBinaries;
}

static char[,] TransposeMatrix(char[][] matrix) {
    var m = matrix.Length;
    var n = matrix[0].Length;

    var transposedMatrix = new char[n, m];
    for (var x = 0; x < n; x++) {
        for (var y = 0; y < m; y++) {
            transposedMatrix[x, y] = matrix[y][x];
        }
    }

    return transposedMatrix;
}

static BigInteger BinToDec(string value) {
    // BigInteger can be found in the System.Numerics dll
    BigInteger res = 0;

    // I'm totally skipping error handling here
    foreach (var c in value) {
        res <<= 1;
        res += c == '1'
            ? 1
            : 0;
    }

    return res;
}

public static class ArrayExt {
    public static T[] GetRow<T>(this T[,] array, int row) {
        if (!typeof(T).IsPrimitive) {
            throw new InvalidOperationException("Not supported for managed types.");
        }

        if (array == null) {
            throw new ArgumentNullException("array");
        }

        var cols = array.GetUpperBound(1) + 1;
        var result = new T[cols];

        int size;

        if (typeof(T) == typeof(bool)) {
            size = 1;
        } else if (typeof(T) == typeof(char)) {
            size = 2;
        } else {
            size = Marshal.SizeOf<T>();
        }

        Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

        return result;
    }
}
