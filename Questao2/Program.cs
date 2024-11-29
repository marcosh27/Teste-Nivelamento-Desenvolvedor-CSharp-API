using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Questao2;
using JsonSerializer = System.Text.Json.JsonSerializer;

public class Program
{

    static async Task Main(string[] args)
    {
        string teamName2 = "";
        int year2 = 0;
        Console.Write("Informe o nome do time: ");
        string teamName1 = Console.ReadLine();
        Console.Write("Informe o ano para pesquisa: ");
        int year1 = int.Parse(Console.ReadLine());
        Console.Write("Deseja informar outro time? [S/N]: ");
        char newTeam = char.Parse(Console.ReadLine());
        if (newTeam == 'S' || newTeam == 's')
        {
            Console.Write("Informe o nome do segundo time: ");
            teamName2 = Console.ReadLine();
            Console.Write("Informe o ano para pesquisa: ");
            year2 = int.Parse(Console.ReadLine());
            
            await getTotalScoredGoals(teamName1, year1);
            await getTotalScoredGoals(teamName2, year2);
        }
        else await getTotalScoredGoals(teamName1, year1);

        static async Task getTotalScoredGoals(string team, int year)
        {
            string baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";
            string Message = "";
            
            Dictionary<string, string> queryParams1 = new Dictionary<string, string>
                {
                    { "team1", team },
                    { "year", year.ToString() }
                };

                string url = QueryHelpers.AddQueryString(baseUrl, queryParams1);
                HttpClient client = new HttpClient();

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        var responseData = JsonSerializer.Deserialize<FootballMatches>(responseJson);
                        int totalGoals = 0;
                        for (int i = 1; i <= responseData.total_pages; i++)
                        {
                            HttpResponseMessage responsePage = await client.GetAsync(url + "&page=" + i);
                            if (responsePage.IsSuccessStatusCode)
                            {
                                var responsePageJson = await responsePage.Content.ReadAsStringAsync();
                                var responsePageData = JsonSerializer.Deserialize<FootballMatches>(responsePageJson);
                                for (int j = 0; j < responsePageData.data.Count; j++)
                                {
                                    totalGoals += int.Parse(responsePageData.data[j].team1goals);
                                }
                            }
                        }

                        Message = $"Team {team} scored {totalGoals} in {year}.";
                        
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"Erro na requisição: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro inesperado: {ex.Message}");
                }

            Console.WriteLine(Message);
        }
    }
}