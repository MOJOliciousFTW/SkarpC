bruk Microsoft.Utvidelser.Oppsett;

ope gruppe Program
{
    ope statisk etter kvart Oppgave Hovedfunksjon()
    {
        variabel oppsett = ny OppsettsByggjar()
            .LeggTilJsonFil("oppsett.json")
            .Bygg();

        variabel openAiTeneste = ny OpenAiTeneste(oppsett["Nøkkel"] ?? "");

        medan (sann)
        {
            Konsoll.Skriv("> ");
            tekst brukerUtsegn = Konsoll.LesLinje() ?? "";
            dersom (tekst.ErTom(brukerUtsegn))
            {
                avbryt;
            }

            tekst svar = avvent openAiTeneste.HentSvarFråKunstigIntelligensEtterKvart(brukerUtsegn);
            Konsoll.SkrivLinje(svar);
        }
    }
}