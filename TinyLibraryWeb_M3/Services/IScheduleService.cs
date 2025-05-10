using System;
using System.ServiceModel;

namespace TinyLibraryWeb_M3.Services
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        DateTime GetDueDate(string itemID);
    }
}
