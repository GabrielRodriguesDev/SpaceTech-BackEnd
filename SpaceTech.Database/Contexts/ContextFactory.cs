using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SpaceTech.Database.Contexts;
internal class ContextFactory : IDesignTimeDbContextFactory<SpaceTechContext>
{
    public SpaceTechContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=db-mysql-nyc1-57105-do-user-14090616-0.b.db.ondigitalocean.com;Port=25060;Database=spacetech;Uid=doadmin;Pwd=AVNS_leyc64f502bfoY24y7K";
        //var connectionString = "Server=localhost;Port=3306;Database=spacetech;Uid=root;Pwd=fx870";

        var optionsBuilder = new DbContextOptionsBuilder<SpaceTechContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).LogTo(Console.Write);
        return new SpaceTechContext(optionsBuilder.Options);
    }
}
