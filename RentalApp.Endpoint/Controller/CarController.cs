using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Car entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private ICarLogic carLogic;

    public CarController(ICarLogic carLogic)
    {
        this.carLogic = carLogic;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> ReadAll()
    {
        try
        {
            var result = carLogic.ReadAll();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> Read(int id)
    {
        try
        {
            var result = carLogic.Read(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Car value)
    {
        try
        {
            carLogic.Create(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult Update([FromBody] Car value)
    {
        try
        {
            carLogic.Update(value);

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
            carLogic.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsFromYear/{year}")]
    public ActionResult<IEnumerable<Car>> GetCarsFromYear(int year)
    {
        try
        {
            var result = carLogic.GetCarsFromYear(year);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCarsByMake/{make}")]
    public ActionResult<IEnumerable<Car>> GetCarsByMake(string make)
    {
        try
        {
            var result = carLogic.GetCarsByMake(make);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetMostExpensive/{count}")]
    public ActionResult<IEnumerable<Car>> GetMostExpensive(int count)
    {
        try
        {
            var result = carLogic.GetMostExpensive(count);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetNotMaintained")]
    public ActionResult<IEnumerable<Car>> GetNotMaintained()
    {
        try
        {
            var result = carLogic.GetNotMaintained();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
