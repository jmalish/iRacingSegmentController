using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class Driver // probably don't need every item, can delete stuff later if I really need to
        {
            public int CarIdx { get; set; }
            public string UserName { get; set; }
            public string AbbrevName { get; set; }
            public string Initials { get; set; }
            public int UserID { get; set; }
            public int TeamID { get; set; }
            public string TeamName { get; set; }
            public string CarNumber { get; set; }
            public int CarNumberRaw { get; set; }
            public string CarPath { get; set; }
            public int CarClassID { get; set; }
            public int CarID { get; set; }
            public int CarIsPaceCar { get; set; }
            public int CarIsAI { get; set; }
            public string CarScreenName { get; set; }
            public string CarScreenNameShort { get; set; }
            public string CarClassShortName { get; set; }
            public int CarClassRelSpeed { get; set; }
            public string CarClassLicenseLevel { get; set; }
            public string CarClassMaxFuelPct { get; set; }
            public string CarClassWeightPenalty { get; set; }
            public string CarClassColor { get; set; }
            public int IRating { get; set; }
            public int LicLevel { get; set; }
            public int LicSubLevel { get; set; }
            public string LicString { get; set; }
            public string LicColor { get; set; }
            public string IsSpectator { get; set; }
            public string CarDesignStr { get; set; }
            public string HelmetDesignStr { get; set; }
            public string SuitDesignStr { get; set; }
            public string CarNumberDesignStr { get; set; }
            public string CarSponsor_1 { get; set; }
            public string CarSponsor_2 { get; set; }
            public string ClubName { get; set; }
            public string DivisionName { get; set; }
        }
    }
}