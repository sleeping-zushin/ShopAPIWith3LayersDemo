using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.User
{
    public class LoginResponseVM
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserVM User { get; set; }
    }
}
