using Information_Card.Core.Entities.Base;
using Information_Card.Core.Repositories.Base;
using Information_Catd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;


namespace Information_Catd.Infrastructure.Repository
{
    public class RepositoryFile<T> : IRepository<T> where T : EntityBase
    {
        private readonly string _pathFile;
        private readonly IFileDataAccess _fileDataAccess;
        public RepositoryFile(IFileDataAccess fileDataAccess, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _fileDataAccess = fileDataAccess;

            _pathFile = hostingEnvironment.ContentRootPath + "\\" + configuration.GetSection("LocationFile:PathFileInformationCard").Value;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var models = (await _fileDataAccess.LoadData<T>(_pathFile))?.ToList();
                if (models == null)
                {
                    models = new List<T>();
                }
                models.Add(entity);
                await _fileDataAccess.SaveItem<T>(_pathFile, models);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteAsync(T entity)
        {
            try
            {
                var models = (await _fileDataAccess.LoadData<T>(_pathFile))?.ToList();
                var model = models.Find(f => f.Id == entity.Id);
                models.Remove(model);
                await _fileDataAccess.SaveItem(_pathFile, models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return (await _fileDataAccess.LoadData<T>(_pathFile))?.ToList();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                var models = (await _fileDataAccess.LoadData<T>(_pathFile))?.ToList();
                var model = models.Find(f => f.Id == entity.Id);
                models.Remove(model);
                models.Add(entity);
                await _fileDataAccess.SaveItem(_pathFile, models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
