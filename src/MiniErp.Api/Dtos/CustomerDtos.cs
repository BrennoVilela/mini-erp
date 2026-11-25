using System.ComponentModel.DataAnnotations;
using MiniErp.Api.Domain;

namespace MiniErp.Api.Dtos;

public record CreateCustomerRequest(
    [Required, StringLength(150)] string Name,
    [Required, StringLength(20)] string Document,
    [Required, EmailAddress, StringLength(200)] string Email,
    [StringLength(20)] string? Phone);

public record UpdateCustomerRequest(
    [Required, StringLength(150)] string Name,
    [Required, EmailAddress, StringLength(200)] string Email,
    [StringLength(20)] string? Phone,
    bool IsActive);

public record CustomerResponse(
    int Id,
    string Name,
    string Document,
    string Email,
    string? Phone,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt)
{
    public static CustomerResponse FromEntity(Customer customer) => new CustomerResponse(
        customer.Id,
        customer.Name,
        customer.Document,
        customer.Email,
        customer.Phone,
        customer.IsActive,
        customer.CreatedAt,
        customer.UpdatedAt);
}
