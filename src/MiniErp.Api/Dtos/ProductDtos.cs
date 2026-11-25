using System.ComponentModel.DataAnnotations;
using MiniErp.Api.Domain;

namespace MiniErp.Api.Dtos;

public record CreateProductRequest(
    [Required, StringLength(150)] string Name,
    [Required, StringLength(50)] string Sku,
    [StringLength(1000)] string? Description,
    [Range(0.01, 1_000_000)] decimal Price,
    [Range(0, int.MaxValue)] int StockQuantity);

public record UpdateProductRequest(
    [Required, StringLength(150)] string Name,
    [StringLength(1000)] string? Description,
    [Range(0.01, 1_000_000)] decimal Price,
    [Range(0, int.MaxValue)] int StockQuantity,
    bool IsActive);

public record ProductResponse(
    int Id,
    string Name,
    string Sku,
    string? Description,
    decimal Price,
    int StockQuantity,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt)
{
    public static ProductResponse FromEntity(Product product) => new ProductResponse(
        product.Id,
        product.Name,
        product.Sku,
        product.Description,
        product.Price,
        product.StockQuantity,
        product.IsActive,
        product.CreatedAt,
        product.UpdatedAt);
}
