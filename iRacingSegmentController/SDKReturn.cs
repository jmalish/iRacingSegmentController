using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class SDKReturn
        {
            public SessionInfo SessionInfo { get; set; }
            public DriverInfo DriverInfo { get; set; }
            public RadioInfo RadioInfo { get; set; }
            public WeekendInfo WeekendInfo { get; set; }
            public QualifyResultsInfo QualifyResultsInfo { get; set; }
            public CameraInfo CameraInfo { get; set; }
            public SplitTimeInfo SplitTimeInfo { get; set; }
        }
    }
}