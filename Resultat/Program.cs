class Program
{
    static async Task Main()
    {
        const string apiNøkkel = "api-nøkkel-her";
        var openAiTeneste = new OpenAiTeneste(apiNøkkel);

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