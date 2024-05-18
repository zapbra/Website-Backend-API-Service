
namespace WebApplication1.classes
{
    public class FileLogger
    {

        public bool WriteToFile(string message)
        {
            string logFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "logs");

            string date = DateTime.Now.ToString("MMMM d, yyyy");
            string dateYearMonth = DateTime.Now.ToString("MM_yyyy");
            string filePath = dateYearMonth + "_log.txt";

            try
            {
                // create directory /logs if not exists
                if (!Directory.Exists(logFolderPath))
                {
                    Directory.CreateDirectory(logFolderPath);
                }

                // append to monthly log file
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(logFolderPath, filePath), true))
                {

                    outputFile.WriteLine($"Date: {date}, {message}");
                    outputFile.Flush();
                    Console.WriteLine("Wrote to file");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
                Console.WriteLine(e.GetType());
                return false;
            }
            return true;
        }


    }
}
