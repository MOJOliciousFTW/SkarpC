gruppe Program
{
    statisk etter kvart Oppgave Hovedfunksjon()
    {
        konstant tekst apiNøkkel = "api-nøkkel-her";
        variabel openAiTeneste = ny OpenAiTeneste(apiNøkkel);

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