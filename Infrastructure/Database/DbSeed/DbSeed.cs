using Domain.Models.Student;
using Domain.Models.Teacher;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DbSeed
{
	public class DbSeed
	{
		public static void SeedStudents(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasData(
				new Student { Id = Guid.NewGuid(), FirstName = "Elsa", LastName = "Andersson", DateOfBirth = new DateOnly(2006, 5, 12), Address = "Kungsgatan 123, Göteborg", PhoneNumber = "+46 70 123 45 67", Email = "elsa.andersson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Oscar", LastName = "Bergqvist", DateOfBirth = new DateOnly(2005, 8, 21), Address = "Avenyn 456, Göteborg", PhoneNumber = "+46 72 345 67 89", Email = "oscar.bergqvist@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Hanna", LastName = "Carlsson", DateOfBirth = new DateOnly(2007, 11, 3), Address = "Vasagatan 789, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "hanna.carlsson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Alexander", LastName = "Dahlström", DateOfBirth = new DateOnly(2007, 2, 15), Address = "Haga Nygata 101, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "alexander.dahlstrom@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Emma", LastName = "Ekström", DateOfBirth = new DateOnly(2006, 4, 28), Address = "Linnégatan 202, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "emma.ekstrom@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Liam", LastName = "Forsberg", DateOfBirth = new DateOnly(2005, 7, 8), Address = "Kungsportsavenyn 303, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "liam.forsberg@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Ella", LastName = "Gustavsson", DateOfBirth = new DateOnly(2007, 10, 19), Address = "Första Långgatan 404, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "ella.gustavsson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Oliver", LastName = "Hedlund", DateOfBirth = new DateOnly(2005, 1, 31), Address = "Andra Långgatan 505, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "oliver.hedlund@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Maja", LastName = "Isaksson", DateOfBirth = new DateOnly(2006, 3, 14), Address = "Västra Hamngatan 606, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "maja.isaksson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "William", LastName = "Johansson", DateOfBirth = new DateOnly(2005, 6, 25), Address = "Storgatan 707, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "william.johansson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Karlsson", DateOfBirth = new DateOnly(2007, 9, 5), Address = "Östra Hamngatan 808, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "alice.karlsson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Noah", LastName = "Lindgren", DateOfBirth = new DateOnly(2005, 12, 16), Address = "Nordenskiöldsgatan 909, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "noah.lindgren@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Astrid", LastName = "Svensson", DateOfBirth = new DateOnly(2006, 2, 27), Address = "Lisebergsgatan 1111, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "astrid.svensson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Erik", LastName = "Toresson", DateOfBirth = new DateOnly(2005, 5, 9), Address = "Fiskebäcksgatan 1212, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "erik.toresson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Amanda", LastName = "Vikström", DateOfBirth = new DateOnly(2007, 8, 20), Address = "Karl Johansgatan 1313, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "amanda.vikstrom@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Gustav", LastName = "Werner", DateOfBirth = new DateOnly(2006, 11, 1), Address = "Magasinsgatan 1414, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "gustav.werner@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Sofia", LastName = "Åberg", DateOfBirth = new DateOnly(2005, 1, 15), Address = "Södra Hamngatan 1515, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "sofia.aberg@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Filip", LastName = "Öberg", DateOfBirth = new DateOnly(2007, 4, 28), Address = "Götgatan 1616, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "filip.oberg@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Viktoria", LastName = "Pettersson", DateOfBirth = new DateOnly(2005, 7, 8), Address = "Ekelundsgatan 1717, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "viktoria.pettersson@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Axel", LastName = "Sjöberg", DateOfBirth = new DateOnly(2006, 10, 19), Address = "Färjenäsgatan 1818, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "axel.sjoberg@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Isabelle", LastName = "Holm", DateOfBirth = new DateOnly(2005, 12, 31), Address = "Trädgårdsgatan 1919, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "isabelle.holm@schoolsync.com" },
				new Student { Id = Guid.NewGuid(), FirstName = "Marcus", LastName = "Lundqvist", DateOfBirth = new DateOnly(2007, 2, 14), Address = "Mölndalsvägen 2020, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "marcus.lundqvist@schoolsync.com" }
			);

		}

		public static void SeedTeachers(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Teacher>().HasData(
				new Teacher { Id = Guid.NewGuid(), FirstName = "Karin", LastName = "Lind", DateOfBirth = new DateOnly(1980, 6, 15), Address = "Skolgatan 1, Göteborg", PhoneNumber = "+46 70 123 45 67", Email = "karin.lind@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Anders", LastName = "Svensson", DateOfBirth = new DateOnly(1975, 9, 21), Address = "Lärargatan 2, Göteborg", PhoneNumber = "+46 72 345 67 89", Email = "anders.svensson@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Camilla", LastName = "Eriksson", DateOfBirth = new DateOnly(1982, 11, 3), Address = "Undervisningsvägen 3, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "camilla.eriksson@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Mats", LastName = "Andersson", DateOfBirth = new DateOnly(1978, 2, 15), Address = "Lärarvägen 4, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "mats.andersson@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Anna", LastName = "Hedström", DateOfBirth = new DateOnly(1985, 4, 28), Address = "Pedagogvägen 5, Göteborg", PhoneNumber = "+46 72 123 45 67", Email = "anna.hedstrom@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Erik", LastName = "Berg", DateOfBirth = new DateOnly(1973, 7, 8), Address = "Lärarstråket 6, Göteborg", PhoneNumber = "+46 70 345 67 89", Email = "erik.berg@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Sara", LastName = "Johansson", DateOfBirth = new DateOnly(1987, 10, 19), Address = "Utvecklingsgatan 7, Göteborg", PhoneNumber = "+46 73 567 89 01", Email = "sara.johansson@schoolsync.com" },
				new Teacher { Id = Guid.NewGuid(), FirstName = "Johan", LastName = "Lund", DateOfBirth = new DateOnly(1979, 1, 31), Address = "Lärarvägen 8, Göteborg", PhoneNumber = "+46 76 789 01 23", Email = "johan.lund@schoolsync.com" }
			);
		}
		public static void SeedUsers(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User { Id = Guid.NewGuid(), Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!") }
				);
		}

	}
}
