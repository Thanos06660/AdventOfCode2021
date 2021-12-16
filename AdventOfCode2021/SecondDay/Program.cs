// See https://aka.ms/new-console-template for more information

Console.WriteLine("Day 2 - Dive! - Part One");
Console.WriteLine("Load SubmarineCourse!");
var submarineCourse = File.ReadAllLines("SubmarineCourse.txt");
var position = CalculateHorizontalPositionAndDepth(submarineCourse);

Console.WriteLine($"Number of Horizontalmovement {position.Item1}");
Console.WriteLine($"Number of Verticalmovement {position.Item2}");
Console.WriteLine($"Product Of Horizontal and Verticalmovement {position.Item1 * position.Item2}");

Console.WriteLine("Day 2 - Dive! -  Part Two");
var position2 = CalculateHorizontalPositionAndDepth2(submarineCourse);
Console.WriteLine($"Number of Horizontalmovement {position2.Item1}");
Console.WriteLine($"Number of Verticalmovement {position2.Item2}");
Console.WriteLine($"Product Of Horizontal and Verticalmovement {position2.Item1 * position2.Item2}");

Console.WriteLine("Press <Escape> to quit");
while (Console.ReadKey().Key != ConsoleKey.Escape) {
}

static Tuple<int, int> CalculateHorizontalPositionAndDepth(string[] measurements) {
    var position = new Tuple<int, int>(0, 0);
    string[] movement;
    foreach (var m in measurements) {
        movement = m.Split(' ');
        int.TryParse(movement[1], out var intResult);
        switch (movement[0]) {
            case "forward":
                position = new Tuple<int, int>(position.Item1 + intResult, position.Item2);
                break;
            case "up":
                position = new Tuple<int, int>(position.Item1, position.Item2 + -1 * intResult);
                break;
            case "down":
                position = new Tuple<int, int>(position.Item1, position.Item2 + intResult);
                break;
        }
    }

    return position;
}

static Tuple<int, int, int> CalculateHorizontalPositionAndDepth2(string[] measurements) {
    var position = new Tuple<int, int, int>(0, 0, 0);
    string[] movement;
    foreach (var m in measurements) {
        movement = m.Split(' ');
        int.TryParse(movement[1], out var intResult);
        switch (movement[0]) {
            case "forward":
                position = new Tuple<int, int, int>(position.Item1 + intResult, position.Item2, position.Item3);
                position = new Tuple<int, int, int>(position.Item1, position.Item2 + position.Item3 * intResult, position.Item3);
                break;
            case "up":
                position = new Tuple<int, int, int>(position.Item1, position.Item2, position.Item3 + -1 * intResult);
                break;
            case "down":
                position = new Tuple<int, int, int>(position.Item1, position.Item2, position.Item3 + intResult);
                break;
        }
    }

    return position;
}


