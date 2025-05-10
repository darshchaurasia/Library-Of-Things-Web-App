using System.ServiceModel;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3.Services
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        Item[] ItemSearch(string keyword);
    }
}
