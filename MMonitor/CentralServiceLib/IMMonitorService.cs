using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMMonitorService" in both code and config file together.
    [ServiceContract]
    public interface IMMonitorService
    {
        [OperationContract]
        bool BanUser(string id);

        [OperationContract]
        bool RemoveUser(string id);

        [OperationContract]
        bool AddNewSource(TheSource source);

        [OperationContract]
        IEnumerable<TheSource> GetAllSources();

        [OperationContract]
        TheSource GetSourceByUrl(string url);

        [OperationContract]
        IEnumerable<TheSource> GetSourcesByTitleSample(string title, int max = 10);

        [OperationContract]
        TheSource GetSource(int id);

        [OperationContract]
        bool UpdateSource(TheSource theSource);

        [OperationContract]
        bool RemoveSource(int id);

        /// <summary>
        /// How many sources are in queue to identify encoding, language, title etc.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetNumOfSourcesInQueue();

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
