﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TopSchool.Infra.Data;
public class DataMigrationFactory : IDesignTimeDbContextFactory<DataContext>
{
    /// <summary>
    /// Classe para uso exclusivo do EF Migrations
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public DataContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        //string dBConnectionString = "Data Source=DESKTOP-QPKH2J6\\DOFARIDATABASE;Initial Catalog=DbUdemyDDDCore;User ID=sa;Password=Dfr@123;Connection Timeout=60;Persist Security Info=True";

        string dBConnectionString = "Data Source=DbTopSchool.db";

        optionsBuilder.UseSqlite(dBConnectionString);

        return new DataContext(optionsBuilder.Options);
    }

}