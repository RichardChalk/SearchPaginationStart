using RazorPlusServices.Models;
using static RazorPlusServices.Pages.SuppliersModel;

namespace RazorPlusServices.Services
{
    public interface ISupplierService
    {
        List<SupplierViewModel> GetSuppliers(string sortColumn, string sortOrder);
    }
}
