using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IUsersService" in both code and config file together.
    public class IUsersService : IIUsersService
    {
        public bool BanUser(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
