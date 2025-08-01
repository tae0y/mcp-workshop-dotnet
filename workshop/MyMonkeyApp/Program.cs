
using MyMonkeyApp;

namespace MyMonkeyApp;

class Program
{        private static readonly string[] AsciiArts = new[]
        {
            @"  __,""=,__
	 ( o o )
	 /  V  \
	/(  _  )\
	  ^^ ^^",
            @"   w  c( .. )o   (  -  )o   (  .. )o
		(   )     (   )     (   )
		 ""       ""       """,
            @"   (o.o)
	  <(   )>
		"" """,
            @"   (""`-""-._
		`    .  `-._
		 .  `     .`-._
		  `-._    `    `-._
			  `-._.  `    `-._
					`-._.  `   `-._
						  `-._.  `-._
								`-._."
        };

        private static void ShowRandomAsciiArt()
        {
            var random = new Random();
            var art = AsciiArts[random.Next(AsciiArts.Length)];
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 16);
            Console.WriteLine(art);
            Console.ResetColor();
        }

        private static async Task Main()
        {
            while (true)
            {
                Console.Clear();
                ShowRandomAsciiArt();
                Console.WriteLine("============================");
                Console.WriteLine("🐒 MyMonkeyApp 메뉴");
                Console.WriteLine("============================");
                Console.WriteLine("1. 모든 원숭이 나열");
                Console.WriteLine("2. 이름으로 특정 원숭이의 세부 정보 가져오기");
                Console.WriteLine("3. 무작위 원숭이 가져오기");
                Console.WriteLine("0. 앱 종료");
                Console.Write("메뉴를 선택하세요: ");

                var input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        await ListAllMonkeys();
                        break;
                    case "2":
                        await GetMonkeyByName();
                        break;
                    case "3":
                        await GetRandomMonkey();
                        break;
                    case "0":
                        Console.WriteLine("앱을 종료합니다. 안녕히 가세요!");
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                        break;
                }
                Console.WriteLine(Environment.NewLine + "아무 키나 누르면 메뉴로 돌아갑니다...");
                Console.ReadKey();
            }
        }

        private static async Task ListAllMonkeys()
        {
            var monkeys = await MonkeyHelper.GetMonkeysAsync();
            if (monkeys.Count == 0)
            {
                Console.WriteLine("원숭이 데이터가 없습니다.");
                return;
            }
            Console.WriteLine($"총 {monkeys.Count}종의 원숭이:");
            foreach (var m in monkeys)
            {
                Console.WriteLine($"- {m.Name} ({m.Location}, 개체수: {m.Population})");
            }
        }

        private static async Task GetMonkeyByName()
        {
            Console.Write("원숭이 이름을 입력하세요: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("이름을 입력해야 합니다.");
                return;
            }
            var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name);
            if (monkey is null)
            {
                Console.WriteLine($"'{name}' 이름의 원숭이를 찾을 수 없습니다.");
                return;
            }
            PrintMonkeyDetails(monkey);
        }

        private static async Task GetRandomMonkey()
        {
            var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
            if (monkey is null)
            {
                Console.WriteLine("원숭이 데이터가 없습니다.");
                return;
            }
            PrintMonkeyDetails(monkey);
            var count = MonkeyHelper.GetRandomAccessCount(monkey.Name);
            Console.WriteLine($"이 원숭이는 무작위로 {count}번 선택되었습니다.");
        }

        private static void PrintMonkeyDetails(Monkey m)
        {
            Console.WriteLine($"이름: {m.Name}");
            Console.WriteLine($"서식지: {m.Location}");
            Console.WriteLine($"개체수: {m.Population}");
            Console.WriteLine($"설명: {m.Details}");
            Console.WriteLine($"위치: {m.Latitude}, {m.Longitude}");
            if (!string.IsNullOrWhiteSpace(m.Image))
                Console.WriteLine($"이미지: {m.Image}");
        }
}