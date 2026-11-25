namespace MiniErp.Api.Services;

public class DuplicateSkuException(string sku)
    : Exception($"A product with SKU '{sku}' already exists.");
