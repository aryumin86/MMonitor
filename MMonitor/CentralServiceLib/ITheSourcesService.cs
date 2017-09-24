using MMonitorLib.Entities;
using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralServiceLib
{
    [ServiceContract]
    public interface ITheSourcesService
    {
        [OperationContract]
        bool AddNewTheSource(TheSource source);

        [OperationContract]
        IEnumerable<TheSource> GetAllTheSources();

        [OperationContract]
        TheSource GetSourceByUrl(string url);

        [OperationContract]
        IEnumerable<TheSource> GetSourcesByTitleSample(string title, int max = 10);

        [OperationContract]
        TheSource GetTheSource(int id);

        [OperationContract]
        bool UpdateTheSource(TheSource theSource);

        [OperationContract]
        bool RemoveTheSource(int id);

        /// <summary>
        /// How many sources are in queue to identify encoding, language, title etc.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetNumOfSourcesInQueue();
    }
}
