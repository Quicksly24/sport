using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using sportsapi.Model.Wnba;
using System.Net.WebSockets;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Actions;


public class RawApi{

  public void Reader(WebApplication app){

       app.MapGet("/Teams",Teams).WithOpenApi();
       app.MapGet("/Teams/{id}/Players",Teamplayers).WithOpenApi();
       app.MapGet("/Teams/player/{id}", player).WithOpenApi();
       app.MapGet("/Teams/{id}/schedule/{year}", schedule).WithOpenApi();
       app.MapGet("/Teams/play", client).WithOpenApi();

    }

  public async Task<HttpResponse> client(HttpContext ctx)
  {
      ctx.Response.Headers.Location = "/Teams/yeah";
      ctx.Response.StatusCode = 302;

      return ctx.Response;
  }
  public async Task<IResult> schedule(string id,string year)
  {
      string url = $"https://wnba-api.p.rapidapi.com/schedule-team?season={year}&teamId={id}";

      var json = await Response(url);

      var obj = JsonDocument.Parse(json);

      var root = obj.RootElement;

      var doc = root.GetProperty("events");

      var model = JsonSerializer.Deserialize<evt[]>(doc);

      return Results.Ok(model);
  }
    public async Task<IResult> player(string id)
  {

      string url = $"https://wnba-api.p.rapidapi.com/player-overview?playerId={id}";

      var json = await Response(url);

     

      var obj = JsonDocument.Parse(json);

      var root = obj.RootElement;

      var doc = root.GetProperty("player_overview").GetProperty("statistics");

      var model = JsonSerializer.Deserialize<Statistics>(doc);

      return Results.Ok(model);
  }

    public async Task<IResult> Teamplayers(string id)
    {
        string url = $"https://wnba-api.p.rapidapi.com/wnbateamplayers?teamid={id}";

        var json = await Response(url);

        var obj = JsonDocument.Parse(json);

        var root = obj.RootElement;

        var doc = root.GetProperty("team").GetProperty("athletes");

        var model = JsonSerializer.Deserialize<List<Players>>(doc.GetRawText());

        return Results.Ok(model);
    }

    public async Task<IResult> Teams()
    {
        string url = "https://wnba-api.p.rapidapi.com/wnbateamlist?limit=15";
        var json = await Response(url);
        var doc = JsonDocument.Parse(json);

        var root = doc.RootElement;

        var let = root.GetProperty("sports").EnumerateArray().First()
                                   .GetProperty("leagues").EnumerateArray().First()
                                   .GetProperty("teams");
             

        return Results.Ok(let);
    }

    private async Task<string> Response(string url)
    {
        using(var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "apikey");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "domain");

            return await client.GetStringAsync(url);
            
            
        }
    }


}