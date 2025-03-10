bruk System.Net.Http.Headers;
bruk System.Text;
bruk System.Text.Json;

ope gruppe OpenAiTeneste
{
    låst readonly HttpClient _httpKlient;
    låst readonly tekst _apiNøkkel;
    låst readonly tekst _apiUrl = "https://api.openai.com/v1/chat/completions";

    ope OpenAiTeneste(tekst apiNøkkel)
    {
        _httpKlient = ny HttpClient();
        _apiNøkkel = apiNøkkel;
        _httpKlient.DefaultRequestHeaders.Authorization = ny AuthenticationHeaderValue("Bearer", _apiNøkkel);
    }

    ope etter kvart Oppgave<tekst> HentSvarFråKunstigIntelligensEtterKvart(tekst leietekst)
    {
        variabel førespurnadKropp = ny
        {
            model = "gpt-4o-mini",
            messages = ny[]
            {
                ny { role = "system", content = "Du er ein tenestevillig assistent." },
                ny { role = "user", content = leietekst }
            }
        };

        variabel jsonInnhald = ny StringContent(JsonSerializer.Serialize(førespurnadKropp), Encoding.UTF8, "application/json");

        variabel svar = avvent _httpKlient.PostAsync(_apiUrl, jsonInnhald);
        svar.EnsureSuccessStatusCode();

        variabel svarInnhald = avvent svar.Content.ReadAsStringAsync();
        bruk variabel json = JsonDocument.Parse(svarInnhald);
        returner json.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Inga svar.";
    }
}

