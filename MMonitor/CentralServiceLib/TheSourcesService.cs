using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MMonitorLib.Entities;

namespace CentralServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConductorService" in both code and config file together.
    public class TheSourcesService : ITheSourcesService
    {
        public bool AddNewTheSource(TheSource source)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TheSource> GetAllTheSources()
        {
            throw new NotImplementedException();
        }

        public int GetNumOfSourcesInQueue()
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

        public TheSource GetTheSource(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTheSource(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTheSource(TheSource theSource)
        {
            throw new NotImplementedException();
        }
    }
}
