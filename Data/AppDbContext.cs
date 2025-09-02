using ChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchApi.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<DepartamentModel> Departaments { get; set; }
    public DbSet<MemberModel> Members { get; set; }
}