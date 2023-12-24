using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Rental entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private IRentalLogic rentalLogic;

    public RentalController(IRentalLogic rentalLogic)
    {
        this.rentalLogic = rentalLogic;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Rental>> ReadAll()
    {
        try
        {
            var result = rentalLogic.ReadAll();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Rental> Read(int id)
    {
        try
        {
            var result = rentalLogic.Read(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Rental value)
    {
        try
        {
            rentalLogic.Create(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult Update([FromBody] Rental value)
    {
        try
        {
            rentalLogic.Update(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            rentalLogic.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsByDate/{start}/{end}")]
    public ActionResult<IEnumerable<Car>> GetCarsByDate(DateTime start, DateTime end)
    {
        try
        {
            var result = rentalLogic.GetCarsByDate(start, end);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCustomersByDate/{date}")]
    public ActionResult<IEnumerable<Customer>> GetCustomersByDate(DateTime date)
    {
        try
        {
            var result = rentalLogic.GetCustomersByDate(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetActiveRentals/{date}")]
    public ActionResult<IEnumerable<Rental>> GetActiveRentals(DateTime date)
    {
        try
        {
            var result = rentalLogic.GetActiveRentals(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}