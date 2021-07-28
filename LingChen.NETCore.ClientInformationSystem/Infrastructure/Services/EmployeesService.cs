using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicaitonCore.Entites;

namespace Infrastructure.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IClientsRepository _clientRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IClientsRepository clientRepository)
        {
            _employeesRepository = employeesRepository;
            _clientRepository = clientRepository;
        }
        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model)
        {
            var dbEmployee = await _employeesRepository.GetExistsAsync(e => e.Id == model.Id && e.Name == model.Name);
            if (dbEmployee == true)
            {
                throw new ConflictException("The employee already exists!");
            }

            await _employeesRepository.AddAsync(new Employees
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation

            }); ;

            var employeeResponse = new EmployeeResponseModel
            {
                Id = model.Id,
                Name = model.Name
            };

            return employeeResponse;
        }

        public async Task<string> DeleteEmployee(int id)
        {

            var dbEmployee = await _employeesRepository.GetEmployee(id);


            if (dbEmployee == null)
            {
                throw new ConflictException("The employee is not found!");
            }


            await _employeesRepository.DeleteAsync(dbEmployee);

            

            return "Employee deleted successfully!";
        }

        public async Task<EmployeeResponseModel> EmployeeDetails(int id)
        {
            var dbEmployee = await _employeesRepository.GetEmployee(id);

            if (dbEmployee == null)
            {
                throw new ConflictException("The employee is not found!");
            }

            var employeeResponse = new EmployeeResponseModel
            {
                Id = dbEmployee.Id,
                Name = dbEmployee.Name,
                Designation = dbEmployee.Designation
            };

            return employeeResponse;


        }

        public async Task<HomepageDetailsModel> GetAllEmployeesClients()
        {
            var homepageDetails = new HomepageDetailsModel();

            var employees = await _employeesRepository.ListAllAsync();
            var clients = await _clientRepository.ListAllAsync();

            homepageDetails.Clients = new List<ClientResponseModel>();
            foreach (var c in clients)
            {
                homepageDetails.Clients.Add(
                    new ClientResponseModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Email = c.Email,
                        Phones = c.Phones,
                        Address = c.Address

                    });
            }

            homepageDetails.Employees = new List<EmployeeResponseModel>();
            foreach (var e in employees)
            {
                homepageDetails.Employees.Add(
                    new EmployeeResponseModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Designation = e.Designation

                    });
            }

            return homepageDetails;


        }

        public async Task<EmployeeUpdateModel> GetEmployeeById(int id)
        {
            var dbEmployee = await _employeesRepository.GetByIdAsync(id);

            var employeeUpdate = new EmployeeUpdateModel
            {
                Id = dbEmployee.Id,
                Name = dbEmployee.Name,
                Password = dbEmployee.Password,
                Designation = dbEmployee.Designation
            };

            return employeeUpdate;

        }

        public async Task<EmployeeResponseModel> UpdateEmployee(EmployeeUpdateModel employeeUpdateModel)
        {
            var dbEmployee = await _employeesRepository.GetByIdAsync(employeeUpdateModel.Id);
            if (dbEmployee == null)
            {
                throw new ConflictException("The employee does not exists!");
            }


            dbEmployee.Id = employeeUpdateModel.Id;
            dbEmployee.Name = employeeUpdateModel.Name;
            dbEmployee.Password = employeeUpdateModel.Password;
            dbEmployee.Designation = employeeUpdateModel.Designation;

            await _employeesRepository.UpdateAsync(dbEmployee);

            var employeeResponse = new EmployeeResponseModel
            {
                Id = employeeUpdateModel.Id,
                Name = employeeUpdateModel.Name
            };

            return employeeResponse;
        }


        public async Task<EmployeeResponseModel> RegisterUser(EmployeeRequestModel requestModel)
        {
            // Make sure email does not exists in database User table

            var dbUser = await _employeesRepository.GetByIdAsync(requestModel.Id);

            if (dbUser != null)
            {
                // we already have user with same id
                throw new ConflictException("The account arleady exists");
            }

            // save to database

            var user = new Employees
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                Designation = requestModel.Designation,
                Password = requestModel.Password
               
            };

            // save to database by calling UserRepository Add method
            var createdUser = await _employeesRepository.AddAsync(user);

            var employeeResponse = new EmployeeResponseModel
            {
                Id = createdUser.Id,
                Name = requestModel.Name,
                Designation = requestModel.Designation,
               
            };

            return employeeResponse;
        }



        public async Task<EmployeeLoginResponseModel> Login(int id, string password)
        {
            var dbEmployee = await _employeesRepository.GetByIdAsync(id);
            if (dbEmployee == null)
            {
                throw new NotFoundException("Id does not exists, please register first");
            }

            if (password == dbEmployee.Password)
            {
                // good, correct password

                var employeeLoginResponseModel = new EmployeeLoginResponseModel
                {

                    Id = dbEmployee.Id,
                    Name = dbEmployee.Name,
                    Designation = dbEmployee.Designation
                  
                };

                return employeeLoginResponseModel;
            }

            return null;
        }
    }
}
