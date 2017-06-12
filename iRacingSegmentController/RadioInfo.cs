using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class RadioInfo
        {
            public List<Radios> Radios { get; set; }
            public int SelectedRadioNum { get; set; }
        }

        public class Radios
        {
            public int RadioNum { get; set; }
            public int HopCount { get; set; }
            public int NumFrequencies { get; set; }
            public int TunedToFrequencyNum { get; set; }
            public int ScanningIsOn { get; set; }
            public List<Frequencies> Frequencies { get; set; }
        }

        public class Frequencies
        {
            public int FrequencyNum { get; set; }
            public string FrequencyName { get; set; }
            public int Priority { get; set; }
            public int CarIdx { get; set; }
            public int EntryIdx { get; set; }
            public int ClubID { get; set; }
            public int CanScan { get; set; }
            public int CanSquawk { get; set; }
            public int Muted { get; set; }
            public int IsMutable { get; set; }
            public int IsDeletable { get; set; }
        }
    }
}