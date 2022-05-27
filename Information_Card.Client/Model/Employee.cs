using Information_Card.Client.Model.Base;
using System;

namespace Information_Card.Client.Model
{
    public sealed class Employee : BaseModel
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public string PathPhoto { get; set; }
        public string Job { get; set; }

        public bool isValid()
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Surname) || Salary <= 0 ||
                String.IsNullOrEmpty(Status) || String.IsNullOrEmpty(PhoneNumber) || String.IsNullOrEmpty(PathPhoto)
              || String.IsNullOrEmpty(Job))
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
