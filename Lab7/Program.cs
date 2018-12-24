using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department(1, "Бухгалтерия"),
                new Department(2, "Маркетинговый отдел"),
                new Department(3, "Финансовый отдел"),
                new Department(4, "Отдел управления поставками"),
                new Department(5, "Отдел технической поддержки"),
                new Department(6, "Отдел разработки программного обеспечения"),
                new Department(7, "Отдел тестирования")
            };
            
            var employees = new List<Employee>
            {
                new Employee(1, "Кочетков", 6),
                new Employee(2, "Белкина", 6),
                new Employee(3, "Дехтеров", 7),
                new Employee(4, "Крюков", 5),
                new Employee(5, "Хрюков", 1),
                new Employee(6, "Канюков", 3),
                new Employee(7, "Бадышев", 1),
                new Employee(8, "Антонова", 1),
                new Employee(9, "Симонов", 4),
                new Employee(10, "Сифонов", 3),
                new Employee(11, "Котов", 7),
                new Employee(12, "Датов", 5),
                new Employee(13, "Аверин", 2),
                new Employee(14, "Агатов", 2)
            };

            Console.WriteLine("Выведите список всех сотрудников и отделов, отсортированный по отделам");
            
            var list1 = 
                from employee in employees
                join department in departments on employee.DepartmentID equals department.ID
                orderby department.Name
                select new
                {
                    employee.Surname,
                    DepartmentName = department.Name
                };

            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Выведите список всех сотрудников, у которых фамилия начинается с буквы «А»");

            var list2 =
                from employee in employees
                where employee.Surname[0] == 'А'
                select employee;

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.WriteLine("Выведите список всех отделов и количество сотрудников в каждом отделе");

            var list3 =
                from department in departments
                join employee in employees on department.ID equals employee.DepartmentID into employeesOnDepartment
                select new
                {
                    DepartmentID = department.ID,
                    DepartmentName = department.Name,
                    CountOfEmployees = employeesOnDepartment.Count()
                };
                
                
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.WriteLine("Выведите список отделов, в которых у всех сотрудников фамилия начинается с буквы «А»");
            
            var list4 =
                from department in departments
                join employee in employees on department.ID equals employee.DepartmentID into employeesOnDepartment
                where employeesOnDepartment.All(employee => employee.Surname[0] == 'А')
                select department;
                
            foreach (var item in list4)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.WriteLine("Выведите список отделов, " +
                              "в которых хотя бы у одного сотрудника фамилия начинается с буквы «А»");

           
            var list5 =
                from department in departments
                join employee in employees on department.ID equals employee.DepartmentID into employeesOnDepartment
                where employeesOnDepartment.Any(employee => employee.Surname[0] == 'А')
                select department;
                
            foreach (var item in list5)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            
            var departmentEmployees = new List<DepartmentEmployees>
            {
                new DepartmentEmployees(5, 3),
                new DepartmentEmployees(5, 1),
                new DepartmentEmployees(5, 3),
                new DepartmentEmployees(7, 5),
                new DepartmentEmployees(3, 2),
                new DepartmentEmployees(6, 7),
                new DepartmentEmployees(6, 7),
                new DepartmentEmployees(6, 7),
                new DepartmentEmployees(7, 5),
                new DepartmentEmployees(7, 2),
                new DepartmentEmployees(5, 1),
                new DepartmentEmployees(4, 6),
                new DepartmentEmployees(4, 5),
                new DepartmentEmployees(1, 4),
                new DepartmentEmployees(2, 3),
                new DepartmentEmployees(3, 3),
                new DepartmentEmployees(11, 2),
                new DepartmentEmployees(14, 5),
                new DepartmentEmployees(12, 4),
                new DepartmentEmployees(4, 7),
                new DepartmentEmployees(3, 5),
                new DepartmentEmployees(9, 2),
                new DepartmentEmployees(9, 4),
                new DepartmentEmployees(10, 6),
                new DepartmentEmployees(12, 4),
                new DepartmentEmployees(7, 2),
                new DepartmentEmployees(1, 1),
                new DepartmentEmployees(2, 1),
                new DepartmentEmployees(12, 5)
            };
            
            Console.WriteLine("Выведите список всех отделов и список сотрудников в каждом отделе");

            var list6 =
                from departmentEmployee in departmentEmployees
                group departmentEmployees by departmentEmployee.DepartmentID into deps
                select new
                {
                    Department = departments.Single(dep => dep.ID == deps.Key),
                    Employees = string.Join(", ", employees.FindAll(employee => employee.DepartmentID == deps.Key))
                };
                
            foreach (var item in list6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Выведите список всех отделов и количество сотрудников в каждом отделе");

            var list7 =
                from departmentEmployee in departmentEmployees
                group departmentEmployees by departmentEmployee.DepartmentID into deps
                select new
                {
                    Department = departments.Single(dep => dep.ID == deps.Key),
                    EmployeesCount = employees.FindAll(employee => employee.DepartmentID == deps.Key).Count
                };
                
            foreach (var item in list7)
            {
                Console.WriteLine(item);
            }
        }
    }
}