using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeesService
    {
        Task<EmployeeResponseModel> RegisterUser(EmployeeRequestModel requestModel);
        Task<EmployeeLoginResponseModel> Login(int id, string password);
        Task<EmployeeUpdateModel> GetEmployeeById(int id);
        Task<HomepageDetailsModel> GetAllEmployeesClients();
        Task<EmployeeResponseModel> EmployeeDetails(int id);
        Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model);
        Task<EmployeeResponseModel> UpdateEmployee(EmployeeUpdateModel employeeUpdateModel);
        Task<string> DeleteEmployee(int id);
    }
}
