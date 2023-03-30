using RazorPlusServices.Models;
using static RazorPlusServices.Pages.SuppliersModel;

namespace RazorPlusServices.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly NorthwindContext _dbContext;

        public SupplierService(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SupplierViewModel> GetSuppliers(string sortColumn, string sortOrder)
        {
            var query = _dbContext.Suppliers.AsQueryable();

            if (sortColumn == "Name")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.CompanyName);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.CompanyName);

            if (sortColumn == "Country")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Country);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Country);

            if (sortColumn == "City")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.City);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.City);

            var suppliers = query.Select(s => new SupplierViewModel
            {
                Id = s.SupplierId,
                Name = s.CompanyName,
                City = s.City,
                Country = s.Country
            }).ToList();

            return suppliers;
        }
    }
}
