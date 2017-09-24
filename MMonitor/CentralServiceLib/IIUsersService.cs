using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralServiceLib
{
    [ServiceContract]
    public interface IIUsersService
    {
        [OperationContract]
        bool BanUser(string id);

        [OperationContract]
        bool RemoveUser(string id);

        //[OperationContract]
        //bool UpdateUser(Microsoft.AspNet.Identity user);
    }
}
