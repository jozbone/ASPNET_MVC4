using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using eManager.Domain;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDepartmentDataSource _db;

        public HomeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var sw = new Stopwatch();
            sw.Start();
            
            var allDepartments = _db.Departments.ToListAsync();
            var number = SlowOperationAsync();
            await Task.WhenAll(allDepartments, number);

            sw.Stop();

            var timeTaken = sw.ElapsedMilliseconds;
            return View(allDepartments.Result);
            // you can also explicitly specify it like this:
            // return View("Index");
        }

        private async Task<IEnumerable<Department>> GetAllDepartments()
        {
            //var task = SlowOperationAsync();
            //            Console.WriteLine("Slow operation result is: {0}", task.Result);
            //            Console.WriteLine("Slow operation test completed on {0}", Thread.CurrentThread.ManagedThreadId);

            var departmentTask = await _db.Departments.ToListAsync();
//            task.Wait();
            return departmentTask;

            // tells MVC runtime to render a "conventional view"
        }

        private static async Task<int> SlowOperationAsync()
        {
            //Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(2000);

            //Console.WriteLine("Slow operation completed on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}