using System.Windows.Forms;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        public class WeekendInfo
        {
            public string TrackName { get; set; }
            public string TrackID { get; set; }
            public string TrackLength { get; set; }
            public string TrackDisplayName { get; set; }
            public string TrackDisplayShortName { get; set; }
            public string TrackConfigName { get; set; }
            public string TrackCity { get; set; }
            public string TrackCountry { get; set; }
            public string TrackAltitude { get; set; }
            public string TrackLatitude { get; set; }
            public string TrackLongitude { get; set; }
            public string TrackNorthOffset { get; set; }
            public string TrackNumTurns { get; set; }
            public string TrackPitSpeedLimit { get; set; }
            public string TrackType { get; set; }
            public string TrackWeatherType { get; set; }
            public string TrackSkies { get; set; }
            public string TrackSurfaceTemp { get; set; }
            public string TrackAirTemp { get; set; }
            public string TrackAirPressure { get; set; }
            public string TrackWindVel { get; set; }
            public string TrackWindDir { get; set; }
            public string TrackRelativeHumidity { get; set; }
            public string TrackFogLevel { get; set; }
            public string TrackCleanup { get; set; }
            public string TrackDynamicTrack { get; set; }
            public string SeriesID { get; set; }
            public string SeasonID { get; set; }
            public string SessionID { get; set; }
            public string SubSessionID { get; set; }
            public string LeagueID { get; set; }
            public string Official { get; set; }
            public string RaceWeek { get; set; }
            public string EventType { get; set; }
            public string Category { get; set; }
            public string SimMode { get; set; }
            public string TeamRacing { get; set; }
            public string MinDrivers { get; set; }
            public string MaxDrivers { get; set; }
            public string DCRuleSet { get; set; }
            public string QualifierMustStartRace { get; set; }
            public string NumCarClasses { get; set; }
            public string NumCarTypes { get; set; }
            public WeekendOptions WeekendOptions { get; set; }
            public TelemetryOptions TelemetryOptions { get; set; }
        }

        public class WeekendOptions
        {
            public string NumStarters { get; set; }
            public string StartingGrid { get; set; }
            public string QualifyScoring { get; set; }
            public string CourseCautions { get; set; }
            public string StandingStart { get; set; }
            public string Restarts { get; set; }
            public string WeatherType { get; set; }
            public string Skies { get; set; }
            public string WindDirection { get; set; }
            public string WindSpeed { get; set; }
            public string WeatherTemp { get; set; }
            public string RelativeHumidity { get; set; }
            public string FogLevel { get; set; }
            public string TimeOfDay { get; set; }
            public string Unofficial { get; set; }
            public string CommercialMode { get; set; }
            public string NightMode { get; set; }
            public string IsFixedSetup { get; set; }
            public string StrictLapsChecking { get; set; }
            public string HasOpenRegistration { get; set; }
            public string HardcoreLevel { get; set; }
            public string IncidentLimit { get; set; }
        }

        public class TelemetryOptions
        {
            public string TelemetryDiskFile { get; set; }
        }
    }
}