using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Information_Catd.Infrastructure.Data
{
    public class FileDataAccess : IFileDataAccess
    {
        public FileDataAccess()
        {

        }

        public async Task<IEnumerable<T>> LoadData<T>(string pathFile)
        {
            try
            {
                var result = await File.ReadAllTextAsync(pathFile);
                var models = JsonConvert.DeserializeObject<IEnumerable<T>>(result);
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> SaveItem<T>(string pathFile, List<T> items)
        {
            try
            {
                var json = JsonConvert.SerializeObject(items);
                await File.WriteAllTextAsync(pathFile, json);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
