using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Customer entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private ICustomerLogic customerLogic;

    public CustomerController(ICustomerLogic customerLogic)
    {
        this.customerLogic = customerLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> ReadAllAsync()
    {
        try
        {
            var result = await customerLogic.ReadAllAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> ReadAsync(int id)
    {
        try
        {
            var result = await customerLogic.ReadAsync(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] Customer value)
    {
        try
        {
            await customerLogic.CreateAsync(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] Customer value)
    {
        try
        {
            await customerLogic.UpdateAsync(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await customerLogic.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCustomersByName/{firstName}/{lastName}")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByNameAsync(string firstName, string lastName)
    {
        try
        {
            var result = await customerLogic.GetCustomersByNameAsync(firstName, lastName);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
