using Microsoft.AspNetCore.Mvc;
using MiniErp.Api.Dtos;
using MiniErp.Api.Services;

namespace MiniErp.Api.Controllers;

[ApiController]
[Route("api/customers")]
[Produces("application/json")]
public class CustomersController(ICustomerService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CustomerResponse>>> GetAll(CancellationToken ct)
    {
        var customers = await service.GetAllAsync(ct);
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerResponse>> GetById(int id, CancellationToken ct)
    {
        var customer = await service.GetByIdAsync(id, ct);
        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponse>> Create(CreateCustomerRequest request, CancellationToken ct)
    {
        try
        {
            var customer = await service.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        catch (DuplicateDocumentException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CustomerResponse>> Update(int id, UpdateCustomerRequest request, CancellationToken ct)
    {

        var customer = await service.UpdateAsync(id, request, ct);

        if(customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var customer = await service.DeleteAsync(id, ct);

        if (customer is false)
        {
            return NotFound();
        }

        return NoContent();
    }
}
