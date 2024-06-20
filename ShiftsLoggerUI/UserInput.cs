namespace ShiftsLoggerUI;

public class UserInput
{
    public async Task Menu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Shift menu");
            Console.WriteLine("Press '1' to view all shifts");
            Console.WriteLine("Press '2' to add a shift");
            Console.WriteLine("Press '3' to delete a shift");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await ShowShifts();
                    break;

                case "2":
                    await DeleteShift();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    private static async Task ShowShifts()
    {
        var shifts = await ShiftHttp.GetShifts();

        foreach (var shift in shifts)
        {
            Console.WriteLine($"{shift.Id} {shift.FullName}");
        }
    }

    private static async Task DeleteShift()
    {
        await ShowShifts();
        Console.WriteLine("Please insert the number you want to delete");
        var input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input can not be empty please choose a number");
            input = Console.ReadLine();
        }
        await ShiftHttp.DeleteShift(Convert.ToInt32(input));
    }
}