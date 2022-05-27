using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Information_Catd.Infrastructure.Data
{
    public interface IFileDataAccess
    {
        Task<IEnumerable<T>> LoadData<T>(string pathFile);
        Task<List<T>> SaveItem<T>(string pathFile, List<T> items);
    }
}
