using Microsoft.EntityFrameworkCore;
using MiniErp.Api.Data;
using MiniErp.Api.Domain;
using MiniErp.Api.Dtos;

namespace MiniErp.Api.Services;

public class CustomerService(AppDbContext db) : ICustomerService
{
   public async Task<IReadOnlyList<CustomerResponse>> GetAllAsync(CancellationToken ct)
   {
       return await db.Customers
           .AsNoTracking()
           .OrderBy(c => c.Name)
           .Select(c => CustomerResponse.FromEntity(c))
           .ToListAsync(ct);
   }

   public async Task<CustomerResponse?> GetByIdAsync(int id, CancellationToken ct)
    {
        var customer = await db.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, ct);

        return customer is null ? null : CustomerResponse.FromEntity(customer);
    }

    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request, CancellationToken ct)
    {
        var document = new string(request.Document.Where(char.IsDigit).ToArray());

        var existingDocument = await db.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Document == document, ct);

        if (existingDocument is not null)
        {
            throw new DuplicateDocumentException(document);
        }

        var customer = new Customer
        {
            Name = request.Name,
            Document = document,
            Email = request.Email,
            Phone = request.Phone
        };

        db.Customers.Add(customer);
        await db.SaveChangesAsync(ct);

        return CustomerResponse.FromEntity(customer);
    }

    public async Task<CustomerResponse?> UpdateAsync(int id, UpdateCustomerRequest request, CancellationToken ct)
    {
        var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id, ct);

        if (customer is null)
        {
            return null;
        }

        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Phone = request.Phone;
        customer.IsActive = request.IsActive;
        customer.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync(ct);

        return CustomerResponse.FromEntity(customer);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id, ct);

        if (customer is null)
        {
            return false;
        }

        db.Customers.Remove(customer);
        await db.SaveChangesAsync(ct);

        return true;
    }
}
