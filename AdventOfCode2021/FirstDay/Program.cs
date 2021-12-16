// See https://aka.ms/new-console-template for more information

Console.WriteLine("First Day - Sonar Sweep - Part One");
Console.WriteLine("Load Measurements");
var convertedMeasurements = MeasurementConversion(File.ReadAllLines("SonarMeasurement.txt"));
Console.WriteLine($"Number of increases {CalculateNumberOfDepthMeasurementIncrease(convertedMeasurements)}");
Console.WriteLine("First Day - Sonar Sweep - Part Two");
var slidingWindowsMeasurements = CalculateSlidingWindowsMeasurements(convertedMeasurements);
Console.WriteLine($"Number of increases {CalculateNumberOfDepthMeasurementIncrease(slidingWindowsMeasurements)}");
Console.WriteLine("Press <Escape> to quit");
while (Console.ReadKey().Key != ConsoleKey.Escape) {
}

static int[] MeasurementConversion(string[] measurements) {
    var convertedMeasurements = Array.ConvertAll(measurements, s => int.TryParse(s, out var measurement)
                                                     ? measurement
                                                     : 0);
    return convertedMeasurements;
}

static int CalculateNumberOfDepthMeasurementIncrease(int[] measurements) {
    var numberOfIncrease = 0;
    for (var i = 0; i < measurements.Length - 1; i++) {
        if (Math.Sign(measurements[i + 1] - measurements[i]) > 0) {
            numberOfIncrease += 1;
        }
    }

    return numberOfIncrease;
}

static int[] CalculateSlidingWindowsMeasurements(int[] measurements) {
    var slidingWindowsMeasurements = new int[measurements.Length];
    for (var i = 0; i < measurements.Length - 2; i++) {
        slidingWindowsMeasurements[i] = measurements.ToList().GetRange(i, 3).Sum();
    }

    return slidingWindowsMeasurements;
}
