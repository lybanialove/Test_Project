using System;

namespace WpfApp1.Database.Entity
{
    public class Employee 
    {
        public Guid id { get; set; }
        public string fio { get; set; }
        public Employee(string firstName, string lastName)
        {
            fio = $"{firstName} {lastName}";
            id = new Guid();
        }
        public Employee()
        {

        }
    }
}
