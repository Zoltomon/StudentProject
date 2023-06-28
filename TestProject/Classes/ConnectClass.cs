using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Classes
{
    class ConnectClass
    {
        public static TestDataBaseContext connectDB { get; set; } = new TestDataBaseContext();
    }
}
