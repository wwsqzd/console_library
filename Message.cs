public static class Message
{
    public static void Print(string message)
    {
        System.Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine(message);
        System.Console.ResetColor();
    }
}