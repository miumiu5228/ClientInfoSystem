
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaitonCore.Entites
{
    public class Interactions
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmpId { get; set; }
        public Char IntType { get; set; }
        public DateTime IntDate { get; set; }
        public string Remarks { get; set; }

        public Clients Clients { get; set; }
        public Employees Employees { get; set; }
    }
}
