using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using VidlyApp.Dtos;
using VidlyApp.Models;

namespace VidlyApp.Controllers.Api
{
	public class CustomersController : ApiController
    {
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}
		// GET /api/customers
		public IEnumerable<CustomerDto> GetCustomer()
		{
			return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
		}

		//Get /ap/customers/id

		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}

		//POST  /api/customer
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
				//throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;
			return Created(new Uri(Request.RequestUri + "/" + customer.Id ), customerDto);
		}

		// PUT /api/customer/1
		[HttpPut]
		public void UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
			if(customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			Mapper.Map(customerDto, customerInDb);
			_context.SaveChanges();
		}

		//Delete  /api/customer/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

		}
    }
}
