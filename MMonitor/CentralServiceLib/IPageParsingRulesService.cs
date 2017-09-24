using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralServiceLib
{
    [ServiceContract]
    public interface IPageParsingRulesService
    {
        [OperationContract]
        PageParsingRule GetRule(int id);

        [OperationContract]
        bool UpdateRule(PageParsingRule rule);

        [OperationContract]
        bool RemoveRule(int id);

        [OperationContract]
        bool CreateRule(PageParsingRule rule);
    }
}
