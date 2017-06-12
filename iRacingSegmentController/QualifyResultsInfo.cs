using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class QualifyResultsInfo
        {
            public List<Results> Results { get; set; }
        }

        public class Results
        {
            public string Position { get; set; }
            public string ClassPosition { get; set; }
            public string CarIdx { get; set; }
            public string FastestLap { get; set; }
            public string FastestTime { get; set; }
        }
    }
}