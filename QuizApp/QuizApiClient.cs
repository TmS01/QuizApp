using QuizApp.Integration;
using QuizApp.Models;
using System.Net;
using System.Net.Http.Json;

namespace QuizApp;

public class QuizApiClient
{
    private HttpClient _httpClient;

    public QuizApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://opentdb.com/");
    }

    // min enkla metod så andra klasser kan skapa klienten med QuizApiClient.Create()
    public static QuizApiClient Create()
    {
        return new QuizApiClient();
    }

    public async Task<List<QuizQuestion>> GetQuizQuestionsAsync()
    {
        // Standard till 10 frågor
        return await GetQuizQuestionsAsync(2);
    }

    //  metod som tar antal frågor som parameter
    public async Task<List<QuizQuestion>> GetQuizQuestionsAsync(int amount)
    {
        // min nya inställning med angivet antal
        string url = $"api.php?amount={amount}&category=15&difficulty=easy";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Kunde inte hämta frågor från API.");
        }

        var quizResult = await response.Content.ReadFromJsonAsync<OpenTriviaQuizResponse>();

        if (quizResult == null || quizResult.ResponseCode != 0)
        {
            throw new Exception("Fel från API.");
        }

        var questions = new List<QuizQuestion>();

        foreach (var item in quizResult.Results)
        {
            var incorrectAnswers = new List<string>();

            foreach (var answer in item.IncorrectAnswers)
            {
                incorrectAnswers.Add(CleanText(answer));
            }

            var question = new QuizQuestion(
                CleanText(item.Category),
                CleanText(item.Type),
                CleanText(item.Difficulty),
                CleanText(item.Question),
                CleanText(item.CorrectAnswer),
                incorrectAnswers
            );

            questions.Add(question);
        }

        return questions;
    }

    private string CleanText(string text)
    {
        return System.Net.WebUtility.HtmlDecode(text);
    }
}
