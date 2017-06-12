using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class SessionInfo
        {
            public List<Session> Sessions { get; set; }
        }

        public class Session
        {
            public int SessionNum { get; set; }
            public string SessionTime { get; set; }
            public string SessionNumLapsToAvg { get; set; }
            public string SessionTrackRubberState { get; set; }
            public int ResultsLapsComplete { get; set; }
            public string SessionLaps { get; set; }
            public string SessionType { get; set; }
            public List<Positions> ResultsPositions { get; set; }
            public List<ResultsFastestLap> ResultsFastestLap { get; set; }
            public string ResultsAverageLapTime { get; set; }
            public string ResultsNumCautionFlags { get; set; }
            public string ResultsNumCautionLaps { get; set; }
            public string ResultsNumLeadChanges { get; set; }
            public string ResultsOfficial { get; set; }
        }

        public class Positions
        {
            public Positions()
            {
                CarIdx = -1;  // pace car is always CarIdx 0, -1 will never be used by iracing
            }
            public int Position { get; set; }
            public int ClassPosition { get; set; }
            public int CarIdx { get; set; }
            public int Lap { get; set; }
            public decimal Time { get; set; }
            public decimal FastestLap { get; set; }
            public decimal FastestTime { get; set; }
            public decimal LastTime { get; set; }
            public int LapsLed { get; set; }
            public int LapsComplete { get; set; }
            public decimal LapsDriven { get; set; }
            public int Incidents { get; set; }
            public int ReasonOutId { get; set; }
            public string ReasonOutStr { get; set; }
        }

        public class ResultsFastestLap
        {
            public int CarIdx { get; set; }
            public string FastestLap { get; set; }
            public string FastestTime { get; set; }
        }
    }
}