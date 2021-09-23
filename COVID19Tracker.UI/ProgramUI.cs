﻿using COVID19Tracker.Data;
using COVID19Tracker.Models.DepartmentModel;
using COVID19Tracker.Models.Employee_Models;
using COVID19Tracker.Models.HealthStatus_Models;
using COVID19Tracker.Services.Employee_Services;
using COVID19Tracker.UI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI
{
    public class ProgramUI
    {
        private readonly EmployeeUIServices _employeeUIServices = new EmployeeUIServices();
        private readonly DepartmentUIServices _departmentUIServices = new DepartmentUIServices();
        private readonly HealthStatusUIServices _healthStatusUIServices = new HealthStatusUIServices();
        public async Task Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        await CreateEmployee();
                        break;
                    case "2":
                        IEnumerable<EmployeeListItem> listOfEmployees = await GetAllEmployees();
                        DisplayEmployeeListItems(listOfEmployees);
                        break;
                    case "3":
                        EmployeeDetail employee = await GetEmployeeById();
                        DisplayEmployeeDetail(employee);
                        Console.ReadLine();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    case "5":
                        DeleteEmployee();
                        break;
                    case "6":
                        await CreateHealthStatus();
                        break;
                    case "7":
                        HealthStatusDetail healthStatus = await GetHealthStatusById();
                        DisplayHealthStatusDetail(healthStatus);
                        Console.ReadLine();
                        break;
                    case "8":
                        await CreateDepartment();
                        break;
                    case "9":
                        GetAllDepartments();
                        break;
                    case "10":
                        GetDepartmentById();
                        break;
                    case "11":
                        GetVaccinatedByDepartmentId();
                        break;
                    case "12":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }

                Console.ReadLine();
            }
        }

        private void GetVaccinatedByDepartmentId()
        {
            throw new NotImplementedException();
        }

        private void GetDepartmentById()
        {
            throw new NotImplementedException();
        }

        private void GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        private async Task CreateDepartment()
        {
            DepartmentCreate newDepartment = new DepartmentCreate();
            Console.Clear();

            Console.WriteLine("Please enter a Department Name:");
            newDepartment.DepartmentName = Console.ReadLine();

            Console.WriteLine("Please enter a Department Location:");
            newDepartment.DepartmentLocation = Console.ReadLine();

           await _departmentUIServices.Create<DepartmentCreate>("department/", newDepartment);
        }

        private async Task<HealthStatusDetail> GetHealthStatusById()
        {
            Console.Clear();
            Console.WriteLine("Enter the id of the Health Status you would like to see:");

            int healthStatusId = int.Parse(Console.ReadLine());

            var healthStatus = await _healthStatusUIServices.GetById(healthStatusId);
            if (healthStatus is null)
            {
                Console.WriteLine("No health status exists with that ID");
                return null;
            }

            return healthStatus;
        }

        private async Task CreateHealthStatus()
        {
            HealthStatusCreate newHealthStatus = new HealthStatusCreate();
            Console.Clear();

            Console.WriteLine("Do they have Covid? (y / n):");
            newHealthStatus.HasCovid = GetBoolResponse(Console.ReadLine().ToLower());

            Console.WriteLine("Are you fully vaccinated?");
            newHealthStatus.Vaccinated = GetBoolResponse(Console.ReadLine().ToLower());

            Console.WriteLine("Is the employee hospitalized?");
            newHealthStatus.Hospitalized = GetBoolResponse(Console.ReadLine().ToLower());

            Console.WriteLine("Comorbities:");
            newHealthStatus.Comorbidities = Console.ReadLine();

            Console.WriteLine("When did you start quarantine?");
            newHealthStatus.QuarantinedDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("When were you last tested?");
            newHealthStatus.LastTestedDate = Convert.ToDateTime(Console.ReadLine());

            await _healthStatusUIServices.Create<HealthStatusCreate>("healthstatus/", newHealthStatus);




        }

        private void DisplayHealthStatusDetail(HealthStatusDetail healthStatus)
        {
            Console.WriteLine($"Vaccinated {healthStatus.Vaccinated}\n" +
                              $"Has Covid: {healthStatus.HasCovid}\n" +
                              $"Hospitalized: {healthStatus.Hospitalized}\n" +
                              $"Comorbitities: {healthStatus.Comorbidities}\n" +
                              $"Quarantined Date: {healthStatus.QuarantinedDate}\n" +
                              $"Last Tested Date:{healthStatus.LastTestedDate}");
        }

        private void DisplayEmployeeDetail(EmployeeDetail employee)
        {
            
            Console.WriteLine($"Badge ID: {employee.BadgeId}\n" +
                              $"Name: {employee.FirstName} {employee.LastName}\n" +
                              $"Department Name: {employee.DepartmentName}\n" +
                              $"Vaccinated: {employee.Vaccinated}\n" +
                              $"Current Have Covid {employee.HasCovid}\n" +
                              $"Comorbidities: {employee.Comorbities}");

            Console.ReadLine();
        }

        private void DisplayEmployeeListItems(IEnumerable<EmployeeListItem> listItem)
        {
            foreach (var item in listItem)
            {
                Console.WriteLine($"Badge ID: {item.BadgeId}\n" +
                              $"Name: {item.FirstName} {item.LastName}\n" +
                              $"Department Name: {item.DepartmentName}\n" +
                              $"************************");
            }
        }

        private void DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        private void UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDetail> GetEmployeeById()
        {
            Console.Clear();
            Console.WriteLine("Please enter an Employee Badge ID");

            int employeeId = int.Parse(Console.ReadLine());

            var employee = await _employeeUIServices.GetById(employeeId);
            if (employee is null)
            {
                Console.WriteLine("No Employee exists by that Badge ID.");
                return null;
            }

            return employee;

            Console.ReadLine();

        }

        private async Task<IEnumerable<EmployeeListItem>> GetAllEmployees()
        {

            var listOfEmployees = await _employeeUIServices.GetAll<EmployeeListItem>("employee/");
            if (listOfEmployees is null)
            {
                Console.WriteLine("Sorry, internal error...");
                return null;
            }

            return listOfEmployees;


        }

        private async Task CreateEmployee()
        {
            EmployeeCreate newEmployee = new EmployeeCreate();
            Console.Clear();


            Console.WriteLine("Please enter a Badge ID:");
            newEmployee.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a first name:");
            newEmployee.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter a last name:");
            newEmployee.LastName = Console.ReadLine();

            Console.WriteLine("Please enter a department ID:");
            newEmployee.DepartmentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a Health Status ID:");
            newEmployee.HealthStatusId = int.Parse(Console.ReadLine());

            await _employeeUIServices.Create<EmployeeCreate>("employee/", newEmployee);
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to the COVID19 Tracker Application!"); ;
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. Create an Employee\n" +
                              "2. Get All Employees\n" +
                              "3. Get a specific Employee\n" +
                              "4. Update an Employee\n" +
                              "5. Delete an Employee\n" +
                              "6. Create Health Status\n" +
                              "7. Get a Health Status\n" +
                              "8. Create a Department\n" +
                              "9. Get all departments\n" +
                              "10. Get specific department\n" +
                              "11. Show vaccinated by deparment" +
                              "12. Exit");
        }

        private bool GetBoolResponse(string answer)
        {
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("An invalid response was given, the default designation will be false");
                return false;
            }


        }
    }
}
