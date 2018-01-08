using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}


		public ActionResult Index()
		{
			var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
			return View(customers);
		}


		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
			if (customer == null) return HttpNotFound();

			return View(customer);
		}

		public ActionResult New()
		{
			var membershiptypes = _context.MembershipTypes.ToList();

			var viewmodel = new CustomerFormView
			{
				MembershipTypes = membershiptypes,
				Customer = new Customer()
			};
			ViewBag.Title = "Add Customer";
			return View("CustomerForm",viewmodel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormView
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}
			if(customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.IsSuscribedToNewsLetter = customer.IsSuscribedToNewsLetter;
				customerInDb.BirthDate = customer.BirthDate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
			}

			_context.SaveChanges();
			return RedirectToAction("Index","Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormView
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			ViewBag.Title = "Edit Customer";
			return View("CustomerForm", viewModel);
		}
	}
}