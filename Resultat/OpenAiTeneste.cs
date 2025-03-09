using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class OpenAiTeneste
{
    private readonly HttpClient _httpKlient;
    private readonly string _apiNøkkel;
    private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";

    public OpenAiTeneste(string apiNøkkel)
    {
        _httpKlient = new HttpClient();
        _apiNøkkel = apiNøkkel;
        _httpKlient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiNøkkel);
    }

    public async Task<string> HentSvarFråKunstigIntelligensEtterKvart(string leietekst)
    {
        var førespurnadKropp = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = "Du er ein tenestevillig assistent." },
                new { role = "user", content = leietekst }
            }
        };

        var jsonInnhald = new StringContent(JsonSerializer.Serialize(førespurnadKropp), Encoding.UTF8, "application/json");

        var svar = await _httpKlient.PostAsync(_apiUrl, jsonInnhald);
        svar.EnsureSuccessStatusCode();

        var svarInnhald = await svar.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(svarInnhald);
        return json.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Inga svar.";
    }
}

