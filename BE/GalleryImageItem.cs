using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GalleryImageItem
    {
        int _Id;
        string _Url;
        int _HostingUnitId;

        public int Id { get => _Id; set => _Id = value; }
        public string Url { get => _Url; set => _Url = value; }
        public int HostingUnitId { get => _HostingUnitId; set => _HostingUnitId = value; }
    }
}
