using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var data=context.Employees.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees model)
        {
            if (ModelState.IsValid)
            {
                var data = new Employees
                {
                    Name = model.Name,
                    Salary = model.Salary,
                };
                context.Employees.Add(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var emp=context.Employees.SingleOrDefault(x => x.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(x => x.Id == id);
            var result = new Employees()
            {
                Name = emp.Name,
                Salary = emp.Salary,
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employees model)
        {

           
                var data = new Employees
                {
                    Id= model.Id,
                    Name = model.Name,
                    Salary = model.Salary,
                };
                context.Employees.Update(data);
                context.SaveChanges();
                return RedirectToAction("Index");
         
            
        }
    }
}
