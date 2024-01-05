using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Logic;
using RentalApp.Model;

namespace RentalApp.Endpoint.Controller;

/// <summary>
/// Maintenance entity API Controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MaintenanceController : ControllerBase
{
    private IMaintenanceLogic maintenanceLogic;

    public MaintenanceController(IMaintenanceLogic maintenanceLogic)
    {
        this.maintenanceLogic = maintenanceLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maintenance>>> ReadAllAsync()
    {
        try
        {
            var result = await maintenanceLogic.ReadAllAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Maintenance>> ReadAsync(int id)
    {
        try
        {
            var result = await maintenanceLogic.ReadAsync(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] Maintenance value)
    {
        try
        {
            await maintenanceLogic.CreateAsync(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] Maintenance value)
    {
        try
        {
            await maintenanceLogic.UpdateAsync(value);

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
            await maintenanceLogic.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetByDate/{date}")]
    public async Task<ActionResult<IEnumerable<Maintenance>>> GetByDateAsync(DateTime date)
    {
        try
        {
            var result = await maintenanceLogic.GetByDateAsync(date);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetUsingKeyword/{keyword}")]
    public async Task<ActionResult<IEnumerable<Maintenance>>> GetUsingKeywordAsync(string keyword)
    {
        try
        {
            var result = await maintenanceLogic.GetUsingKeywordAsync(keyword);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
