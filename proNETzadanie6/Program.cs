using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj ścieżkę do pliku źródłowego:");
        string? sourceFilePath = Console.ReadLine();

        Console.WriteLine("Podaj ścieżkę do pliku docelowego:");
        string? destinationFilePath = Console.ReadLine();

        try
        {
            if (sourceFilePath != null && destinationFilePath != null)
            {
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;

                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }

                    Console.WriteLine("Plik został pomyślnie skopiowany.");
                }
            }
            else
            {
                Console.WriteLine("Ścieżki plików nie mogą być puste.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik źródłowy nie istnieje.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }
    }
}
