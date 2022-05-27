using Information_Card.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Information_Card.Core.Entities
{
    public class Employee: EntityBase
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }
        public string PathPhoto { get; set; }
        public string Job { get; set; }
    }
}
