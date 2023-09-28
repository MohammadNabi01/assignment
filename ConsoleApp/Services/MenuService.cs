using ConsoleApp.Models.Entities;

namespace ConsoleApp.Services;

internal class MenuService
{
	private readonly UserService _userService = new();
	private readonly CaseService _caseService  = new();


	public async Task<UserEntity> CreateUserAsync()
	{
		var _entity = new UserEntity();
		Console.Clear();
		Console.WriteLine("################### Ny Handläggare ###################");
		Console.Write("Ange förnamn:");
		_entity.FIrstName = Console.ReadLine() ?? "";
		Console.Write("Ange efternamn:");
		_entity.LastName = Console.ReadLine() ?? "";
		Console.Write("Ange e-postadress:");
		_entity.Email = Console.ReadLine() ?? "";

		return await _userService.CreateAsync(_entity);
	}

	public async Task MainMenu(int userID)
	{
		Console.Clear();
		Console.WriteLine("################### Huvudmenyn ###################");
		Console.WriteLine("1. Visa Alla aktiva ärednden");
		Console.WriteLine("2. Visa Alla handlägare");
		Console.WriteLine("3. Skapa ett nytt ärende");
		Console.Write("Välj ett av ovanstående alternativ: ");
		var option = Console.ReadLine();
		 
		switch (option)
		{
			case "1":
				await ActiveCasesAsync();

				break;

			case "2":
				await HandlersAsync();
				break;

			case "3":
				await NewCasesAsync(userID);
				break;

			default:
				Console.Clear();
				Console.WriteLine("Inget giltigt val angavs. ");
				break;
		}
	}
	private async Task ActiveCasesAsync()
	{
		Console.Clear();
		Console.WriteLine("################### Aktive Ärenden ###################");
		foreach(var _case in await _caseService.GetAllActiveAsync())
		{
			Console.WriteLine($"Ärendenummer: {_case.Id}");
			Console.WriteLine($"Skapad: {_case.Created}");
			Console.WriteLine($"Modifierad at: {_case.Modified}");
			Console.WriteLine($"Status : {_case.Status.StatusName}");
			Console.WriteLine("");
		}
	}

	private async Task HandlersAsync()
	{
		Console.Clear();
		Console.WriteLine("################### Handläggare ###################");
		foreach (var _user in await _userService.GetAllAsync())
		{
			Console.WriteLine($"Handläggare-ID: {_user.Id}");
			Console.WriteLine($"Namn: {_user.FIrstName} {_user.LastName}");
			Console.WriteLine($"E-postadress: {_user.Email}");
			Console.WriteLine("");
		}
	}
	
	private async Task NewCasesAsync(int userId)
	{
		var _entity = new CaseEntity { UserId = userId };
		Console.Clear();
		Console.WriteLine("################### Nytt Ärende ###################");
		Console.Write("Ange kundens namn: ");
		_entity.CustomerName = Console.ReadLine() ?? "";
		Console.Write("Ange kundens e-postadress: ");
		_entity.CustomerEmail = Console.ReadLine() ?? "";
		Console.Write("Beskriv ärendet: ");
		_entity.Description = Console.ReadLine() ?? "";

		await _caseService.CreateAsync(_entity);
		await ActiveCasesAsync();

	}
}
