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
    public ActionResult<IEnumerable<Customer>> ReadAll()
    {
        try
        {
            var result = customerLogic.ReadAll();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> Read(int id)
    {
        try
        {
            var result = customerLogic.Read(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Customer value)
    {
        try
        {
            customerLogic.Create(value);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult Update([FromBody] Customer value)
    {
        try
        {
            customerLogic.Update(value);

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
            customerLogic.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCustomersByName/{firstName}/{lastName}")]
    public ActionResult<IEnumerable<Customer>> GetCustomersByName(string firstName, string lastName)
    {
        try
        {
            var result = customerLogic.GetCustomersByName(firstName, lastName);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
