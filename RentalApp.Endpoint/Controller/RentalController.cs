using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Rental entity API Controller.
/// </summary>
[Route("[controller]")]
[ApiController]
[Authorize]
public class RentalController : ControllerBase
{
    private IRentalLogic rentalLogic;

    public RentalController(IRentalLogic rentalLogic)
    {
        this.rentalLogic = rentalLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rental>>> ReadAllAsync()
    {
        try
        {
            var result = await rentalLogic.ReadAllAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> ReadAsync(int id)
    {
        try
        {
            var result = await rentalLogic.ReadAsync(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] Rental value)
    {
        try
        {
            await rentalLogic.CreateAsync(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] Rental value)
    {
        try
        {
            await rentalLogic.UpdateAsync(value);

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
            await rentalLogic.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsByDate/{start}/{end}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCarsByDateAsync(DateTime start, DateTime end)
    {
        try
        {
            var result = await rentalLogic.GetCarsByDateAsync(start, end);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCustomersByDate/{date}")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByDateAsync(DateTime date)
    {
        try
        {
            var result = await rentalLogic.GetCustomersByDateAsync(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetActiveRentals/{date}")]
    public async Task<ActionResult<IEnumerable<Rental>>> GetActiveRentalsAsync(DateTime date)
    {
        try
        {
            var result = await rentalLogic.GetActiveRentalsAsync(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}