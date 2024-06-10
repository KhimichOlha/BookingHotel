using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Context
{
	public class BookingIdentityDbContext : IdentityDbContext<IdentityUser>
	{
		public BookingIdentityDbContext(DbContextOptions<BookingIdentityDbContext>  options): base(options) { }

	}
}
