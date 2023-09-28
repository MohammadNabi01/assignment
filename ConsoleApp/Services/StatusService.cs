using ConsoleApp.Contexts;
using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services;

internal class StatusService
{
	private readonly DataContext _context =new();

	public async Task CreateStatusTypesAsync()
	{
		if (!await _context.Statuses.AnyAsync())
		{
			string[] _statuses = new string[] { "ej påbörjad", "Pågående", "Avsltuad" };

			foreach(var status in _statuses)
			{
				await _context.AddAsync(new StatusEntity { StatusName = status });
				await _context.SaveChangesAsync();
			}
		}
	}

}
