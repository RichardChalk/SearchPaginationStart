using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPlusServices.Models;
using RazorPlusServices.Services;

namespace RazorPlusServices.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public SuppliersModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public class SupplierViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
            public string City { get; set; }

        }
        public List<SupplierViewModel> Suppliers { get; set; }

        public void OnGet(string sortColumn, string sortOrder)
        {
            Suppliers = _supplierService.GetSuppliers(sortColumn, sortOrder);
        }
    }
}
