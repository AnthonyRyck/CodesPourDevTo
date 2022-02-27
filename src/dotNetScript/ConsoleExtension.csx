public static class ConsoleExtension
{
	public static void Info(string message)
	{
		ForegroundColor = ConsoleColor.White;
		Console.WriteLine(message);
	}

	public static void Result(string message)
	{
		ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(message);
	}

    public static void Title(string titre)
    {
        ForegroundColor = ConsoleColor.White;
		Console.WriteLine("######## " + titre + " ########");
    }

	public static void Pause()
	{
		Info(">Appuyer sur une touche pour continuer.");
		Console.ReadKey();
	}

	public static void Espace()
	{
		Info(string.Empty);
	}
}