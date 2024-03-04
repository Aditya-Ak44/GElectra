
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using GElectra.Data;

namespace GElectra.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;
        private readonly string connectionString;
        public AdminController()
        {
            _adminService = new AdminService();
        }

        // GET: Admin
       

        // GET: Admin/Details/5
       

        // GET: Admin/Create
        public ActionResult DisplayCustomer()
        {
            var customers = _adminService.OnGetAsync();

            return View();
        }

       
    }
}