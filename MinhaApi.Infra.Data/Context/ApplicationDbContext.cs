using System;
using MinhaApi.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi.Infra.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Person> People { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
