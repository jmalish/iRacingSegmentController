using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
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
    }
}