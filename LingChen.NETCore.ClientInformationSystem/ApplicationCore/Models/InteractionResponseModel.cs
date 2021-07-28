using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InteractionResponseModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public Char IntType { get; set; }
        public DateTime IntDate { get; set; }
        public string Remarks { get; set; }
        public List<EmployeeResponseModel> Employees { get; set; }
        public List<ClientResponseModel> Clients { get; set; }
       

    }
}
