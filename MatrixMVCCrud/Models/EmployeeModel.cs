using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixMVCCrud.Models
{
    public class EmployeeModel
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public DateTime Created_Date { get; set; }

        public EmployeeModel(string name, string surname, int age, byte gender, string address, DateTime created_Date)
        {
            
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Address = address;
            Created_Date = created_Date;
        }

    }
}