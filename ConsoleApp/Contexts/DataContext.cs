﻿using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts;

internal class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nabig\Desktop\Test\Test\ConsoleApp\Contexts\local-sql-db.mdf;Integrated Security=True;Connect Timeout=30");
	}

	public DbSet<StatusEntity> Statuses { get; set; }
	public DbSet<UserEntity> Users { get; set; }

	public DbSet<CaseEntity> Cases { get; set; }
	public DbSet<CommentEntity> Comments { get; set; }
}
