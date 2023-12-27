using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Maintenance entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MaintenanceController : ControllerBase
{
    private IMaintenanceLogic maintenanceLogic;

    public MaintenanceController(IMaintenanceLogic maintenanceLogic)
    {
        this.maintenanceLogic = maintenanceLogic;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Maintenance>> ReadAll()
    {
        try
        {
            var result = maintenanceLogic.ReadAll();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Maintenance> Read(int id)
    {
        try
        {
            var result = maintenanceLogic.Read(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Maintenance value)
    {
        try
        {
            maintenanceLogic.Create(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult Update([FromBody] Maintenance value)
    {
        try
        {
            maintenanceLogic.Update(value);

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
            maintenanceLogic.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetByDate/{date}")]
    public ActionResult<IEnumerable<Maintenance>> GetByDate(DateTime date)
    {
        try
        {
            var result = maintenanceLogic.GetByDate(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetUsingKeyword/{keyword}")]
    public ActionResult<IEnumerable<Maintenance>> GetUsingKeyword(string keyword)
    {
        try
        {
            var result = maintenanceLogic.GetUsingKeyword(keyword);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
