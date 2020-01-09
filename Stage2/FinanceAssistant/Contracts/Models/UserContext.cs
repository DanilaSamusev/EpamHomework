using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Contracts.Models
{
    class UserContext : IPrincipal
    {
        public IIdentity Identity => throw new NotImplementedException();

        public UserContext()
        {
            //Iden
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
