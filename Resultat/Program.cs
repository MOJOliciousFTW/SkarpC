using Microsoft.Extensions.Configuration;

public class Program
{
    public static async Task Main()
    {
        var oppsett = new ConfigurationBuilder()
            .AddJsonFile("oppsett.json")
            .Build();

        var openAiTeneste = new OpenAiTeneste(oppsett["Nøkkel"] ?? "");

        while (true)
        {
            Console.Write("> ");
            string brukerUtsegn = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(brukerUtsegn))
            {
                break;
            }

            string svar = await openAiTeneste.HentSvarFråKunstigIntelligensEtterKvart(brukerUtsegn);
            Console.WriteLine(svar);
        }
    }
}