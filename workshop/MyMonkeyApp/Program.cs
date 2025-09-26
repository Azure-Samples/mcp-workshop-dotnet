
using System;
using System.Threading.Tasks;

class Program
{
	private static readonly string[] AsciiArts = new[]
	{
		@"  w  c( .. )o   ("")",
		@"   (..) (..) (..) (..)",
		@"   (o.o) (o.o) (o.o) (o.o)",
		@"   ( : ) ( : ) ( : ) ( : )",
		@"   ("""") ("""") ("""") ("""")",
		@"   (o.o)   (o.o)   (o.o)",
		@"   ( : )   ( : )   ( : )"
	};

	static async Task Main(string[] args)
	{
		await MonkeyHelper.GetMonkeysAsync();
		while (true)
		{
			Console.Clear();
			ShowRandomAsciiArt();
			Console.WriteLine("============================");
			Console.WriteLine(" Monkey Console App");
			Console.WriteLine("============================");
			Console.WriteLine("1. 모든 원숭이 나열");
			Console.WriteLine("2. 이름으로 특정 원숭이의 세부 정보 가져오기");
			Console.WriteLine("3. 무작위 원숭이 가져오기");
			Console.WriteLine("4. 앱 종료");
			Console.Write("메뉴를 선택하세요: ");
			var input = Console.ReadLine();
			Console.WriteLine();
			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					Console.WriteLine("앱을 종료합니다.");
					return;
				default:
					Console.WriteLine("잘못된 입력입니다. 엔터를 눌러 계속하세요.");
					Console.ReadLine();
					break;
			}
		}
	}

	static void ShowRandomAsciiArt()
	{
		var rand = new Random();
		var art = AsciiArts[rand.Next(AsciiArts.Length)];
		Console.WriteLine(art);
		Console.WriteLine();
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("이름           | 서식지         | 개체수");
		Console.WriteLine("--------------------------------------");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"{m.Name,-14}| {m.Location,-13}| {m.Population}");
		}
		Console.WriteLine();
		Console.WriteLine("엔터를 눌러 계속하세요.");
		Console.ReadLine();
	}

	static void GetMonkeyByName()
	{
		Console.Write("원숭이 이름을 입력하세요: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey == null)
		{
			Console.WriteLine("해당 이름의 원숭이가 없습니다.");
		}
		else
		{
			Console.WriteLine($"이름: {monkey.Name}");
			Console.WriteLine($"서식지: {monkey.Location}");
			Console.WriteLine($"개체수: {monkey.Population}");
			if (!string.IsNullOrWhiteSpace(monkey.AsciiArt))
			{
				Console.WriteLine("\n[ASCII Art]");
				Console.WriteLine(monkey.AsciiArt);
			}
		}
		Console.WriteLine();
		Console.WriteLine("엔터를 눌러 계속하세요.");
		Console.ReadLine();
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		Console.WriteLine($"이름: {monkey.Name}");
		Console.WriteLine($"서식지: {monkey.Location}");
		Console.WriteLine($"개체수: {monkey.Population}");
		Console.WriteLine($"무작위 선택 횟수: {MonkeyHelper.GetAccessCount(monkey.Name)}");
		if (!string.IsNullOrWhiteSpace(monkey.AsciiArt))
		{
			Console.WriteLine("\n[ASCII Art]");
			Console.WriteLine(monkey.AsciiArt);
		}
		Console.WriteLine();
		Console.WriteLine("엔터를 눌러 계속하세요.");
		Console.ReadLine();
	}
}
