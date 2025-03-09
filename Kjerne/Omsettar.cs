using System.Text.RegularExpressions;

public class Omsettar
{
    private static readonly Dictionary<string, string> NøkkelordKopling = new()
    {
        { "bruk", "using" },
        { "ope", "public" },
        { "lukka", "protected" },
        { "låst", "private" },
        { "gruppe", "class" },
        { "tom", "void" },
        { "dersom", "if" },
        { "elles", "else" },
        { "for kvar", "foreach" },
        { "i", "in" },
        { "medan", "while" },
        { "gjør", "do" },
        { "returner", "return" },
        { "sann", "true" },
        { "usann", "false" },
        { "statisk", "static" },
        { "prøv", "try" },
        { "fang", "catch" },
        { "Unntak", "Exception"},
        { "Konsoll", "Console" },
        { "Skriv", "Write" },
        { "SkrivLinje", "WriteLine" },
        { "Les", "Read" },
        { "LesLinje", "ReadLine" },
        { "variabel", "var"},
        { "heltall", "int" },
        { "tekst", "string" },
        { "LeggTil", "Add" },
        { "konstant", "const" },
        { "Hovedfunksjon", "Main" },
        { "etter kvart", "async" },
        { "avvent", "await" },
        { "avbryt", "break" },
        { "Oppgave", "Task" },
        { "ErTom", "IsNullOrEmpty" },
    };

    public static string OmsetSkarpCTilCSharp(string skarpCKode)
    {
        string omsetKode = skarpCKode;

        foreach (var par in NøkkelordKopling)
        {
            omsetKode = Regex.Replace(omsetKode, @"\b" + par.Key + @"\b", par.Value);
        }

        return omsetKode;
    }

    public static string OmsetCSharpTilSkarpC(string cSharpKode)
    {
        string skarpCKode = cSharpKode;

        foreach (var par in NøkkelordKopling)
        {
            skarpCKode = Regex.Replace(skarpCKode, @"\b" + par.Value + @"\b", par.Key);
        }

        return skarpCKode;
    } 
}
