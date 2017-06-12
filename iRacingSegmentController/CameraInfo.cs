using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class CameraInfo
        {
            public List<Groups> Groups { get; set; }
        }

        public class Groups
        {
            public int GroupNum { get; set; }
            public string GroupName { get; set; }
            public bool IsScenic { get; set; }
            public List<Cameras> Cameras { get; set; }
        }

        public class Cameras
        {
            public int CameraNum { get; set; }
            public string CameraName { get; set; }
        }
    }
}