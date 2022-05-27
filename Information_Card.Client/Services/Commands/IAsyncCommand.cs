using System.Threading.Tasks;
using System.Windows.Input;

namespace Information_Card.Client.Services.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
