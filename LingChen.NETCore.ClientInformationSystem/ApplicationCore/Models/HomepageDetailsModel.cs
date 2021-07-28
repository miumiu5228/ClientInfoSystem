using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class HomepageDetailsModel
    {
        public List<EmployeeResponseModel> Employees { get; set; }
        public List<ClientResponseModel> Clients { get; set; }
    }
}
