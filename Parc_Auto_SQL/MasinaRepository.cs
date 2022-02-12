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

        public void add(Masina masina)
        {
            string sql = "insert into masina(marca,pret) values(@marca,@pret)";
            db.SaveData(sql, new { masina.Marca, masina.Pret }, connectionString);
        }

        public void deleteById(int id)
        {
            string sql = "delete from masina where id=@id";
            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateMarcaById(int id, string marca)
        {
            string sql = "update masina set marca=@marca where id=@id";
            db.SaveData(sql, new { marca, id }, connectionString);
        }

        public void updatePretById(int id, double pret)
        {
            string sql = "update masina set pret=@pret where id=@id";
            db.SaveData(sql, new { pret, id }, connectionString);
        }

        public Masina getMasinaById(int id)
        {
            string sql = "select * from masina where id=@id";
            return db.LoadData<Masina, dynamic>(sql, new { id }, connectionString)[0];
        }

    }
}
