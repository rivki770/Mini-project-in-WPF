using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        string name;
        Host relatedHost;

        public string Name { get => name; set => name = value; }
        public Host RelatedHost { get => relatedHost; set => relatedHost = value; }
    }
}
