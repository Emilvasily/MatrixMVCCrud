using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatrixMVCCrud.Models.EntityFramework;

namespace MatrixMVCCrud.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }
        public List<Employees_General_Data> employees_General_Data { get; set; }

    }
}