namespace MiniErp.Api.Services;

public class DuplicateDocumentException(string document)
    : Exception($"A customer with document '{document}' already exists.");
