using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Car entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CarController : ControllerBase
{
    private ICarLogic carLogic;

    public CarController(ICarLogic carLogic)
    {
        this.carLogic = carLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> ReadAllAsync()
    {
        try
        {
            var result = await carLogic.ReadAllAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> ReadAsync(int id)
    {
        try
        {
            var result = await carLogic.ReadAsync(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] Car value)
    {
        try
        {
            await carLogic.CreateAsync(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] Car value)
    {
        try
        {
            await carLogic.UpdateAsync(value);

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
            await carLogic.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsFromYear/{year}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCarsFromYearAsync(int year)
    {
        try
        {
            var result = await carLogic.GetCarsFromYearAsync(year);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsByMake/{make}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCarsByMakeAsync(string make)
    {
        try
        {
            var result = await carLogic.GetCarsByMakeAsync(make);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetMostExpensive/{count}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetMostExpensiveAsync(int count)
    {
        try
        {
            var result = await carLogic.GetMostExpensiveAsync(count);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetNotMaintained")]
    public async Task<ActionResult<IEnumerable<Car>>> GetNotMaintainedAsync()
    {
        try
        {
            var result = await carLogic.GetNotMaintainedAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
