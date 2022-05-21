using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class Employee
    {
        public Employee()
        {
        }

        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string SeriaPasport { get; set; }
        public string NumberPasport { get; set; }
        public string EmployeeInn { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public int? OrganizationId { get; set; }
        public int? PositionId { get; set; }
        public int? UserId { get; set; }
        public int? EducationId { get; set; }

    }
}
