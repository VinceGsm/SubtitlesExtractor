using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an option from the following list:");
        Console.WriteLine("\t1 - SRT - One Piece");
        Console.WriteLine("\t2 - SRT - Autre");
        Console.Write("Your option? ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("Type inputDirectory for selecting mkv :");
                string inputDirectory = Console.ReadLine();
                OnePieceAmb3rSrt(inputDirectory);
                break;
            case "2":
                Console.WriteLine("A venir");
                break;
        }
        Console.WriteLine("------------------------\n");
        Console.WriteLine("All done!");
        Console.ReadLine();
    }

    private static void OnePieceAmb3rSrt(string inputDirectory)
    {
        string[] mkvFiles = Directory.GetFiles(inputDirectory, "*.mkv");

        foreach (string mkvFile in mkvFiles)
        {
            // Build the FFmpeg command to extract the subtitles track            
            string ffmpegCommand = $"-i {mkvFile} -map 0:s:0 {inputDirectory}\\{mkvFile.Substring(28, 14)}.srt";

            // Run the FFmpeg command
            ProcessStartInfo psi = new ProcessStartInfo("ffmpeg", ffmpegCommand);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            Process process = Process.Start(psi);
            process.WaitForExit();
        }
    }
}