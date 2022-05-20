using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Configuration
{
    public class ProjectConfiguration
    {
        public Mongo Mongo { get; set; }
    }

    public class Mongo 
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BooksCollectionName { get; set; }
    }
}
