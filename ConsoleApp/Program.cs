using ConsoleApp.Services;

StatusService statusService = new();
MenuService menuService = new();
UserService userService = new();

// Initialize program 
await statusService.CreateStatusTypesAsync();
var currentUser = await userService.GetAsync(x => x.Email =="hans@domain.com");
if (currentUser == null)
	currentUser = await menuService.CreateUserAsync();


// run program
while (true)
{
	await menuService.MainMenu(currentUser.Id);
	Console.ReadKey();
}
