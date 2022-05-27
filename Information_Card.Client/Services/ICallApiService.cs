using Information_Card.Client.Model;
using Information_Card.Client.Model.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Information_Card.Client.Services
{
    public interface ICallApiService<TEntity> where TEntity : BaseModel
    {
        Task<ObservableCollection<TEntity>> GetAllAsync(string url);
        Task PutAsync(string url,TEntity itrm);
        Task PostAsync(string url,TEntity itrm);
        Task DeleteAsync(string url,TEntity itrm);
    }
}
