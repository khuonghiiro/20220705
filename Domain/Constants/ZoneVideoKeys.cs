using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public class ZoneVideoKeys
    {
        public const string ALL_ZONES = "zonevideo";
        public const string DETAIL = "zonevideo:id{0}";
        public const string VIDEO_LASTEST = "videoinzone:zoneall";
        public const string VIDEO_HOT = "videoinzoneorderbyview:zoneall";
        public const string VIDEO_IN_ZONE = "videoinzone:zone{0}";
    }
}
