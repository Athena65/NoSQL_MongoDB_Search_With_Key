using Microsoft.AspNetCore.Mvc;
using NewMongoDBProjectAnd_SearchUsers.Models;
using NewMongoDBProjectAnd_SearchUsers.Services;
using System;
using System.Threading.Tasks;

namespace NewMongoDBProjectAnd_SearchUsers.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllAsync());

            }catch(Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);

            }


        }
        [HttpGet]
        public async Task<IActionResult> GetWithFirstNameKey([FromQuery] string key)
        {
            try
            {
                var customer = await _customerService.GetAllWithFirstNameKey(key);
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(customer);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWithLastNameKey([FromQuery] string key)
        {
            try
            {
                var customer = await _customerService.GetAllWithFirstNameKey(key);
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(customer);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id); 
                if (customer == null)
                     return NotFound();  

                return Ok(customer);
                

            }catch(Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message= ex.Message;   
                return BadRequest(response);

            }
            
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var Created_Customer = await _customerService.CreateAsync(customer);
                return Ok(Created_Customer.FirstName +" Created");    

            }catch(Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return Unauthorized(response);
            }

            
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateCustomer(string id, Customer customer)
        {
            try
            {
                if (customer == null)
                    return NotFound();

              await _customerService.UpdateAsync(id, customer);
              return Ok(customer.Id +" Updated");

            }catch(Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("{id:length(24)}")]

        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            

            if (customer == null)
                return NotFound();

            await _customerService.DeleteAsync(customer.Id);
            return Ok("Deleted");
        }




    }
}
