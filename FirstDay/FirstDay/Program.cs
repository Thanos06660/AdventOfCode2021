// See https://aka.ms/new-console-template for more information

Console.WriteLine("First Day");
Console.WriteLine($"Number of increases {CalculateNumberOfDepthMeasurementIncrease(File.ReadAllLines("SonarMeasurement.txt"))}");
Console.ReadKey();

static int CalculateNumberOfDepthMeasurementIncrease(string[] Measurements) {
    var numberOfIncrease = 0;
    for (var i = 0; i < Measurements.Length - 1; i++) {
        int firstMeasurement;
        int secondMeasurement;
        int.TryParse(Measurements[i + 1], out secondMeasurement);
        int.TryParse(Measurements[i], out firstMeasurement);
        if (Math.Sign(secondMeasurement - firstMeasurement) > 0) {
            numberOfIncrease += 1;
        }
    }

    return numberOfIncrease;
}

;