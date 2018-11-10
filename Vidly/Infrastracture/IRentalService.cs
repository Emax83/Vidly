using System.Collections.Generic;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Infrastracture
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetRentals();
        Rental GetRental(int id);
        bool AddNewRental(NewRentalViewModel newRental);
        bool EndRental(int id);
    }
}
