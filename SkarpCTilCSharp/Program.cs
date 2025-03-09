class Program
{
    static void Main(string[] args)
    {
        string rotmappe = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

        if (!Directory.Exists(rotmappe))
        {
            Console.WriteLine($"Feil: Mappa '{rotmappe}' finnes ikkje.");
            return;
        }

        // Leit fram alle .sc filer
        string[] filer = Directory.GetFiles(rotmappe, "*.sc", SearchOption.AllDirectories);
        if (filer.Length == 0)
        {
            Console.WriteLine($"Inga .sc filer funne i '{rotmappe}'.");
            return;
        }

        foreach (string fil in filer)
        {
            string målBane = Path.ChangeExtension(fil, ".cs");

            try
            {
                string startKode = File.ReadAllText(fil);
                string omsettKode = Omsettar.OmsetSkarpCTilCSharp(startKode);
                File.WriteAllText(målBane, omsettKode);

                Console.WriteLine($"Omsett '{fil}' → '{målBane}'");
            }
            catch (Exception unntak)
            {
                Console.WriteLine($"Omsetting feila '{fil}': {unntak.Message}");
            }
        }
    }
}
