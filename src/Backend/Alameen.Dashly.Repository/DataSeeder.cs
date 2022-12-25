using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Alameen.Dashly.Repository
{
    public static class DataSeeder
    {
        public static List<TEntity> ImportSeedData<TEntity>(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(currentDirectory, fileName);

            var result = new List<TEntity>();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }

            return result;
        }

        //public static void SeedWebapps(DashlyContext context)
        //{
        //    if (!context.Webapps.Any())
        //    {
        //        var result = ImportSeedData<WebappData>("Seed\\webapplist.json");
        //    }
        //}
    }
}