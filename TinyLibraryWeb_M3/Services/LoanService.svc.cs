using System;
using FeeCalcLibrary;
using TinyLibraryWeb_M3.Models;
using System.Linq;

namespace TinyLibraryWeb_M3.Services
{
    public class LoanService : ILoanService
    {
        // This method is calculating a late fee using the external library function
        public decimal FeeCalcLibrary(int daysLate) =>
            FeeCalc.ComputeLateFee(daysLate);

        // This method is processing a list of items for checkout
        public bool Checkout(LoanItemDTO[] items)
       {
            // Iterating through each item provided in the array
            foreach (var dto in items ?? Enumerable.Empty<LoanItemDTO>())
           {
                // Retrieving the full item details from the repository
                var it = ItemRepository.Get(dto.Id);
               if (it == null || it.IsBorrowed) continue;

                // Updating the item's status and loan details
               it.IsBorrowed = true;
               it.BorrowedBy = dto.User;
               it.DueDate    = dto.DueDate;
               ItemRepository.Update(it); // Saving the updated item details back to the repository
            }
            return true;
       
        }
    }
}
