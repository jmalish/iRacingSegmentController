using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace iRacingSegmentController
{
    public partial class Form1 : Form
    {
        #region Variables
        private bool isClosing = false;  // is the program closing?
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;  // sdk wrapper, used to connect to live iRacing API
        private bool isYellowOut = false;  // is the yellow flag out?
        private string currentFlag = "";  // current flag
        private List<Driver> driversInSession; // list of all drivers in server
        private List<Positions> currentPositions;
        #endregion

        #region Form Stuff
        public Form1()  // this is run when the program is first started, it's essentially the same as form load for the primary form
        {
            InitializeComponent();  // do magic stuff

            #region DataGridView Setup
            dgvDriverList.RowHeadersVisible = false;  // hide left margin

            dgvDriverList.ColumnCount = 4; // set number of columns

            // set column names
            dgvDriverList.Columns[0].Name = "Pos.";
            dgvDriverList.Columns[1].Name = "Car #";
            dgvDriverList.Columns[2].Name = "Name";
            dgvDriverList.Columns[3].Name = "Lap";

            // set column widths
            dgvDriverList.Columns[0].Width = 50;
            dgvDriverList.Columns[1].Width = 56;
            dgvDriverList.Columns[3].Width = 50;
            #endregion

            #region wrapper stuff
            try
            {
                wrapper = new iRacingSdkWrapper.SdkWrapper();  // create wrapper instance

                wrapper.TelemetryUpdated += OnTelemetryUpdated;  // listen to telemetry events
                wrapper.SessionInfoUpdated += OnSessionInfoUpdated;  // listen to session events

                wrapper.Start();  // start wrapper
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                //WriteToLogFile("wrapper stuff", exc.Message.ToString());
            }
            #endregion
        }
        #endregion  

        #region SDK Wrapper Stuff
        // Do things when Telemetry updates (supposed to be 60 times per second)
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)
        {
            if (wrapper.IsConnected)
            {
                lblIsConnected.Text = "Connected: True";
            }

            //Console.WriteLine("Telemetry Updated");

            #region Flag stuff
            string newFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split(' ')[0];  // get the actual current flag according to the session, splits because it normally shows two states

            lblCurrentFlag.Text = "Current Flag: " + currentFlag;
            #endregion
        }

        // Do things when session info updates
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs sessionArgs)
        {
            //Console.WriteLine("Session Info Updated");
            if (sessionArgs.SessionInfo.IsValidYaml)  // check if yaml is valid
            {
                // TODO: Fix this since it's deprecated, I doubt this will cause me issue, but better safe than sorry
                Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);  // create a deserializer
                var input = new StringReader(sessionArgs.SessionInfo.Yaml);  // read the yaml
                var sessionInfo = deserializer.Deserialize<SDKReturn>(input);  // deserialize the yaml

                #region Drivers Info
                if ((driversInSession == null) || (driversInSession.Count != sessionInfo.DriverInfo.Drivers.Count)) // if driver list is empty, or one of the lists is longer than the other
                {
                    driversInSession = sessionInfo.DriverInfo.Drivers; // set local driver list equal to drivers in the server
                }
                #endregion


                #region Race Session Info
                foreach (var session in sessionInfo.SessionInfo.Sessions)  // look through all the sessions (normally they're Practice, Qualifying, and Race)
                {
                    if (session.SessionType == "Race") // find the race part session (ignore qual and practice parts of the active server, if they exist)
                    {
                        var raceSession = session; // the session we're dealing with is the race session, just using this to shorten the variable to less than 50 characters
                        var lapsComplete = Convert.ToInt32(raceSession.ResultsLapsComplete); // get the laps complete, this is helpful for when someone in top 10 is not on lead lap

                        lblCurrentLap.Text = "Current Lap: " + lapsComplete;  // update current lap label


                        if (currentPositions != null)  // make sure currentPositions list is not null, otherwise program crashes
                        {
                            
                        }

                        currentPositions = raceSession.ResultsPositions; // update positions to equal live results

                        dgvDriverList.Rows.Clear();  // clear list so we don't have a bunch of duplicates
                        foreach (Positions p in currentPositions)  // for each position in current positions
                        {
                            dgvDriverList.Rows.Add(p.Position, p.CarIdx, "", p.LapsComplete); // add position to datagridview
                        }

                        Console.WriteLine("Current positions updated");


                        //TODO: see below
                        // Get everyone's current lap to set a baseline, this should happen at start of race, so long as it happens before segment end we're good
                        // when session args updates, see who's lap counter incremented by 1, meaning they just crossed the line

                        // Alternative, keep checking car who Postion: 9 (actually p10 due to 0 index)'s lap
                        // if p10 = current lap (lapscomplete), segment ends
                        // this doesn't work if not all of top 10 is on lead lap so I'll need to check to make sure all of top 10 is on lead lap
                        // if not, need to throw caution when last car on lead lap crosses the line


                        // if p10 is on lead lap, throw caution when p10 crosses line
                        // else throw caution when last car on lead lap crosses line
                    }
                }
                #endregion
            }
        }
        #endregion


        #region Classes for YAML Parsing
        public class SDKReturn
        {
            public SessionInfo SessionInfo { get; set; }
            public DriverInfo DriverInfo { get; set; }
            public RadioInfo RadioInfo { get; set; }
            public WeekendInfo WeekendInfo { get; set; }
        }

        public class SessionInfo
        {
            public List<Session> Sessions { get; set; }
        }

        public class WeekendInfo
        {
            public string TrackDisplayName { get; set; }
        }

        public class Session
        {
            public string ResultsLapsComplete { get; set; }
            public string SessionLaps { get; set; }
            public string SessionType { get; set; }
            public List<Positions> ResultsPositions { get; set; }
        }

        public class Positions
        {
            public string Position { get; set; }
            public string ClassPosition { get; set; }
            public string CarIdx { get; set; }
            public string Lap { get; set; }
            public string Time { get; set; }
            public string FastestLap { get; set; }
            public string FastestTime { get; set; }
            public string LastTime { get; set; }
            public string LapsLed { get; set; }
            public string LapsComplete { get; set; }
            public string LapsDriven { get; set; }
            public string Incidents { get; set; }
            public string ReasonOutId { get; set; }
            public string ReasonOutStr { get; set; }
        }


        public class DriverInfo
        {
            public List<Driver> Drivers { get; set; }
        }

        public class Driver // probably don't need every item, can delete stuff later if I really need to
        {
            public string CarIdx { get; set; }
            public string UserName { get; set; }
            public string AbbrevName { get; set; }
            public string Initials { get; set; }
            public string UserID { get; set; }
            public string TeamID { get; set; }
            public string TeamName { get; set; }
            public string CarNumber { get; set; }
            public string CarNumberRaw { get; set; }
            public string CarPath { get; set; }
            public string CarClassID { get; set; }
            public string CarID { get; set; }
            public string CarIsPaceCar { get; set; }
            public string CarIsAI { get; set; }
            public string CarScreenName { get; set; }
            public string CarScreenNameShort { get; set; }
            public string CarClassShortName { get; set; }
            public string CarClassRelSpeed { get; set; }
            public string CarClassLicenseLevel { get; set; }
            public string CarClassMaxFuelPct { get; set; }
            public string CarClassWeightPenalty { get; set; }
            public string CarClassColor { get; set; }
            public string IRating { get; set; }
            public string LicLevel { get; set; }
            public string LicSubLevel { get; set; }
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




        public class RadioInfo
        {
            public List<Radios> Radios { get; set; }
        }

        public class Radios
        {
            public List<Frequencies> Frequencies { get; set; }
        }

        public class Frequencies
        {
            public string FrequencyName { get; set; }
            public string CanSquawk { get; set; }
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  // when close button is clicked, stop wrapper and close the rest of the program 
        {
            isClosing = true;  // let everything else know program is closing
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free

            Application.Exit();  // close program
        }
    }
}