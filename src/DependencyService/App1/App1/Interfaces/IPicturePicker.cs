using System.IO;
using System.Threading.Tasks;

namespace App1.Interfaces
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}