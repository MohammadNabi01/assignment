namespace ConsoleApp.Models.Entities;

internal class UserEntity
{   
	public int Id { get; set; }
	public string FIrstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;

	public ICollection<CaseEntity> Cases { get; set; } = new List<CaseEntity>();
}
