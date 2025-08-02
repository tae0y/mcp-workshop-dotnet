using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// 원숭이 데이터 관리를 위한 static helper 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys = new List<Monkey>
    {
        new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Latitude = -8.783195, Longitude = 34.508523 },
        new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Latitude = 12.769013, Longitude = -85.602364 },
        new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg", Latitude = 1.957709, Longitude = 37.297204 },
        new Monkey { Name = "Squirrel Monkey", Location = "Central & South America", Population = 11000, Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg", Latitude = -8.783195, Longitude = -55.491477 },
        new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 19000, Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg", Latitude = -14.235004, Longitude = -51.92528 },
        new Monkey { Name = "Howler Monkey", Location = "South America", Population = 8000, Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg", Latitude = -8.783195, Longitude = -55.491477 },
        new Monkey { Name = "Japanese Macaque", Location = "Japan", Population = 1000, Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg", Latitude = 36.204824, Longitude = 138.252924 },
        new Monkey { Name = "Mandrill", Location = "Southern Cameroon, Gabon, and Congo", Population = 17000, Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg", Latitude = 7.369722, Longitude = 12.354722 },
        new Monkey { Name = "Proboscis Monkey", Location = "Borneo", Population = 15000, Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg", Latitude = 0.961883, Longitude = 114.55485 },
        new Monkey { Name = "Sebastian", Location = "Seattle", Population = 1, Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg", Latitude = 47.606209, Longitude = -122.332071 },
        new Monkey { Name = "Henry", Location = "Phoenix", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg", Latitude = 33.448377, Longitude = -112.074037 },
        new Monkey { Name = "Red-shanked douc", Location = "Vietnam", Population = 1300, Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg", Latitude = 16.111648, Longitude = 108.262122 },
        new Monkey { Name = "Mooch", Location = "Seattle", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG", Latitude = 47.608013, Longitude = -122.335167 }
    };
    private static int randomPickCount = 0;
    private static readonly object lockObj = new();

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task InitializeAsync()
    {
    if (monkeys != null && monkeys.Count > 0) return;
        using var httpClient = new HttpClient();
        // MCP Monkey 서버의 엔드포인트 주소 (실제 주소로 교체 필요)
        var url = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/main/monkeydata.json";
        try
        {
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Monkey data server returned {(int)response.StatusCode} ({response.ReasonPhrase}).");
                Console.ResetColor();
                monkeys = new List<Monkey>();
                return;
            }
            var json = await response.Content.ReadAsStringAsync();
            monkeys = JsonSerializer.Deserialize<List<Monkey>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Monkey>();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] Failed to fetch monkey data: {ex.Message}");
            Console.ResetColor();
            monkeys = new List<Monkey>();
        }
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        if (monkeys == null) throw new InvalidOperationException("MonkeyHelper is not initialized. Call InitializeAsync() first.");
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (monkeys == null) throw new InvalidOperationException("MonkeyHelper is not initialized. Call InitializeAsync() first.");
        return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이를 반환하고, 호출 횟수를 추적합니다.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        if (monkeys == null) throw new InvalidOperationException("MonkeyHelper is not initialized. Call InitializeAsync() first.");
        lock (lockObj)
        {
            randomPickCount++;
        }
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// 랜덤 원숭이 선택 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount()
    {
        lock (lockObj)
        {
            return randomPickCount;
        }
    }
}
