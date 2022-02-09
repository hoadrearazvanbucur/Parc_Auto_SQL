using DataAcces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class MasinaRepository
    {
        private readonly string connectionString;
        private Data_Acces db;

        public MasinaRepository()
        {
            db = new Data_Acces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"D:\1_PROGRAMARE\C#\Baza_De_Date\Parc_Auto_SQL\Parc_Auto_SQL").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Masina> getAll()
        {
            string sql = "select * from masina";
            return db.LoadData<Masina,dynamic>(sql,new { },connectionString);
        }

    }
}
