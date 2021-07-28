using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUser
    {
        [StringLength(4)]
        int UserId { get; }
        bool IsAuthenticated { get; }
        string FullName { get; }
     
    }
}
