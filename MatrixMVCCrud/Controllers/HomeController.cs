using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MatrixMVCCrud.Models;
using MatrixMVCCrud.Models.EntityFramework;
using MatrixMVCCrud.Models.ViewModel;

namespace MatrixMVCCrud.Controllers
{

    public class HomeController : Controller
    {
        MatrixMVCCrudDBEntities matrixMVCCrudDBEntities = new MatrixMVCCrudDBEntities();

        public ActionResult Index()
        {
            var employeesList = matrixMVCCrudDBEntities.Employees.ToList();
            return View(employeesList);         
        }

        public ActionResult DeleteEmployee(int id)
        {
            var custModel = matrixMVCCrudDBEntities.Employees.Find(id);
            matrixMVCCrudDBEntities.Employees.Remove(custModel);
            matrixMVCCrudDBEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult NewEmployee()
        {
            var generalDAtaList = matrixMVCCrudDBEntities.Employees_General_Data.Include(m => m.Employees_General_Type).ToList();   //include eto kak join ()
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                employee = new Employee(),
                employees_General_Data = generalDAtaList
            };

            return View("EmployeeForm", employeeViewModel );
        }

        public ActionResult SaveEmployee (Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var generalDAtaList = matrixMVCCrudDBEntities.Employees_General_Data.Include(m => m.Employees_General_Type).ToList();   //include eto kak join ()
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    employee = employee,
                    employees_General_Data = generalDAtaList
                };
                return View("EmployeeForm", employeeViewModel);
            }

            if (employee.ID == 0)
            {
                matrixMVCCrudDBEntities.Employees.Add(employee);
            }
            else
            {
                matrixMVCCrudDBEntities.Entry(employee).State = EntityState.Modified;
            }

            matrixMVCCrudDBEntities.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult EditEmployee (int id)
        {
            var employeeModel = matrixMVCCrudDBEntities.Employees.Find(id);
            var generalDAtaList = matrixMVCCrudDBEntities.Employees_General_Data.Include(m => m.Employees_General_Type).ToList();   //include eto kak join ()
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                employee = employeeModel,
                employees_General_Data = generalDAtaList
            };
            return View("EmployeeForm", employeeViewModel);
        }

    }
}


//Kod nije iznachalno pokazivayetsa kak otobrajatsa doljni danniye

//List<CustomerModel> listCustomer = new List<CustomerModel>();

//CustomerModel customerModel1 = new CustomerModel("Izzet", "Mamayev", 24, 1, "Xirdalan", new DateTime(1994, 12, 21));
//CustomerModel customerModel2 = new CustomerModel("Jonni", "Hesenov", 24, 1, "Xirdalan", new DateTime(1994, 12, 21));
//CustomerModel customerModel3 = new CustomerModel("Rozmarin", "Ceferov", 24, 1, "Xirdalan", new DateTime(1994, 12, 21));
//CustomerModel customerModel4 = new CustomerModel("Debi", "Dobroyev", 24, 1, "Xirdalan", new DateTime(1994, 12, 21));

//listCustomer.Add(customerModel1);
//listCustomer.Add(customerModel2);
//listCustomer.Add(customerModel3);
//listCustomer.Add(customerModel4);


////ViewData["customerModelList"] = listCustomer;

//return View(listCustomer);