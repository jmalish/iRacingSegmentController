using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class SplitTimeInfo
        {
            public List<Sectors> Sectors { get; set; }
        }

        public class Sectors
        {
            public int SectorNum { get; set; }
            public string SectorStartPct { get; set; }
        }
    }
}