using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MMonitorLib.Entities;

namespace CentralServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MMonitorService" in both code and config file together.
    public class MMonitorService : IMMonitorService
    {
        public bool AddNewSource(TheSource source)
        {
            throw new NotImplementedException();
        }

        public bool BanUser(string id)
        {
            throw new NotImplementedException();
        }

        public bool CreateRule(PageParsingRule rule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TheSource> GetAllSources()
        {
            throw new NotImplementedException();
        }

        public int GetNumOfSourcesInQueue()
        {
            throw new NotImplementedException();
        }

        public PageParsingRule GetRule(int id)
        {
            throw new NotImplementedException();
        }

        public TheSource GetSourceByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TheSource> GetSourcesByTitleSample(string title, int max = 10)
        {
            throw new NotImplementedException();
        }

        public TheSource GetSource(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRule(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSource(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRule(PageParsingRule rule)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSource(TheSource theSource)
        {
            throw new NotImplementedException();
        }
    }
}
