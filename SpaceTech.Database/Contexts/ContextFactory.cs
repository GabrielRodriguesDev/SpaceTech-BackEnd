using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SpaceTech.Database.Contexts;
internal class ContextFactory : IDesignTimeDbContextFactory<SpaceTechContext>
{
    public SpaceTechContext CreateDbContext(string[] args)
    {
        //var connectionString = "Server=db-mysql-1-do-user-13359326-0.b.db.ondigitalocean.com;Port=25060;Database=finansist;Uid=doadmin;Pwd=AVNS_xnwnGd6nNLKVPmBpY0x";
        var connectionString = "Server=localhost;Port=3306;Database=spacetech;Uid=root;Pwd=fx870";

        var optionsBuilder = new DbContextOptionsBuilder<SpaceTechContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).LogTo(Console.Write);
        return new SpaceTechContext(optionsBuilder.Options);
    }
}
