using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkForce.Models;
using System.Data.Entity.Infrastructure;
using WorkForce.ViewModels.Employees;

namespace WorkForce.Controllers
{
    public class EmployeesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employees
        public ActionResult Index()
        {

            var employees = db.Employees.Include(e => e.Department);
            var training = db.Employees.Include(t => t.Training);

            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            
            if (employee == null)
            {
                return HttpNotFound();
            }
            FindComputer(employee.EmployeeId);
            PopulateTrainingList();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var listDepts = PopulateDepartmentsDropDownList();
            ViewBag.DepartmentId = listDepts; 
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNewEmployee newEmployee)
        {
            var employee = new Employee
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                StartDate = newEmployee.StartDate,
                Department = db.Departments.Find(newEmployee.DepartmentId)
            };

            try
            {
                if (ModelState.IsValid)
                {

                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                ModelState.AddModelError("", "Unable to save changes.");
            }
            PopulateDepartmentsDropDownList(employee.Department);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            PopulateTrainingList();
            PopulateDepartmentsDropDownList(employee.Department);
            FindComputer(employee.EmployeeId);

            var details = new EditEmployee
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                DepartmentId = employee.Department.DepartmentId,
                Training = employee.Training,
                ComputerId = employee.Computer.ComputerId
            };
            return View(details);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmployee employee)
        {
            if (ModelState.IsValid)
            {
                var emp = db.Employees.Find(employee.EmployeeId);
                emp.EmployeeId = employee.EmployeeId;
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Department = db.Departments.Find(employee.DepartmentId);
                emp.ComputerId = db.Computers.Find(employee.ComputerId);

                if (employee.NewTrainingId > 0)
                {
                    db.Trainings.Find(employee.NewTrainingId).Employees.Add(emp);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit",new {id = employee.EmployeeId });
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PopulateTrainingList(object selectedTraining = null)
        {
            var trainingQuery = from d in db.Trainings
                                orderby d.Name
                                select d;
            var items = new SelectList(trainingQuery, "TrainingId", "Name", selectedTraining);
            ViewBag.Training = items;
        }

        private SelectList PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in db.Departments
                                   orderby d.DepartmentName
                                   select d;
            return new SelectList(departmentsQuery, "DepartmentId", "DepartmentName", selectedDepartment);
        }
        private void FindComputer(int id)
        {
            //List<Computers> myComputer = new List<Computers>();
            var allComputers = db.Computers.ToList();
            
            foreach (var item in allComputers)
            {
                if (item.EmployeeId == id)
                {
                    ViewBag.Computer = item;
                }
               
            }
            //ViewBag.Computer = myComputer;
        }
    }
}
