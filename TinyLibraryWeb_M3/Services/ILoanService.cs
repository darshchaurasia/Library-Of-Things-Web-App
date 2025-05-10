using System.ServiceModel;

namespace TinyLibraryWeb_M3.Services
{
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]
        decimal FeeCalcLibrary(int daysLate);

        [OperationContract]
        bool Checkout(LoanItemDTO[] items);
    }
}
