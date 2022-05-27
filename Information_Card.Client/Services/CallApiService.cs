using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Information_Card.Client.Model.Base;
using System;

namespace Information_Card.Client.Services
{
    public class CallApiService<TEntity> : ICallApiService<TEntity>
          where TEntity : BaseModel
    {
        RestClient client = new RestClient("https://localhost:44357");
  
        
        public async Task<ObservableCollection<TEntity>> GetAllAsync(string url)
        {
            try
            {
                var request = new RestRequest(url);
                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    ObservableCollection<TEntity> items = JsonConvert.DeserializeObject<ObservableCollection<TEntity>>(rawResponse);
                    return items;
                }
                else
                {
                    MessageBox.Show("Error server");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server");
                return null;
            }
        }

        public async Task PutAsync(string url,TEntity item)
        {
            try
            {
                var request = new RestRequest(url, Method.Put);
                request.AddJsonBody(item);
                request.RequestFormat = RestSharp.DataFormat.Json;
                var response = await client.PutAsync(request);
                MessageBox.Show("Изменения сохранено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server");
            }
        }

        public async Task PostAsync(string url,TEntity item)
        {
            try
            {
                var request = new RestRequest(url, Method.Post);
                request.AddJsonBody(item);
                request.RequestFormat = RestSharp.DataFormat.Json;
                var response = await client.PostAsync(request);
                MessageBox.Show("Сохранено");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error server");
            }
        }

        public async Task DeleteAsync(string url,TEntity item)
        {
            try
            {
                var request = new RestRequest(url, Method.Delete);
                request.AddJsonBody(item);
                request.RequestFormat = RestSharp.DataFormat.Json;
                var response = await client.DeleteAsync(request);
                MessageBox.Show("Удалено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server");
            }
        }
    }
}
