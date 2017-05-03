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
        private bool closing = false;
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;  // create sdk wrapper, used to connect to iRacing
        private bool isYellowOut = false;
        private string currentFlag = "";
        private List<Driver> driversInSession;

        private string driverCurrentLap = "0";
        #endregion


        public Form1()
        {
            InitializeComponent();

            #region wrapper stuff
            try
            {
                Console.WriteLine("Starting wrapper.");

                wrapper = new iRacingSdkWrapper.SdkWrapper();  // create wrapper instance

                wrapper.TelemetryUpdated += OnTelemetryUpdated;  // listen to telemetry events
                wrapper.SessionInfoUpdated += OnSessionInfoUpdated;  // listen to session events

                wrapper.Start();  // start wrapper
            }
            catch (Exception exc)
            {
                //WriteToLogFile("wrapper stuff", exc.Message.ToString());
            }


            #endregion
        }

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
                Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);  // create a deserializer
                var input = new StringReader(sessionArgs.SessionInfo.Yaml);  // read the yaml
                var sessionInfo = deserializer.Deserialize<SDKReturn>(input);  // deserialize the yaml

                #region Drivers Info
                if ((driversInSession == null) || (driversInSession.Count != sessionInfo.DriverInfo.Drivers.Count))
                {
                    driversInSession = sessionInfo.DriverInfo.Drivers; // get all drivers in session
                
                    lstDriverList.Items.Clear();
                    foreach (Driver d in driversInSession)
                    {
                        lstDriverList.Items.Add($"{d.CarNumber} \t {d.UserName}");
                    }
                }
                #endregion


                #region Race Session Info
                foreach (var session in sessionInfo.SessionInfo.Sessions)  // look through all the sessions (normally they're Practice, Qualifying, and Race)
                {
                    if (session.SessionType == "Race") // find the race part session (ignore qual and practice parts of the active server, if they exist)
                    {
                        var racesession = session;  // the session we're dealing with is the race session, just using this to shorten the variable to less than 50 characters
                        int lapscomplete = Convert.ToInt32(racesession.ResultsLapsComplete);  // get the laps complete, this is helpful for when someone in top 10 is not on lead lap
                    

                        string newDriverLap = session.ResultsPositions[0].LapsComplete;

                        if (newDriverLap != driverCurrentLap)
                        {
                            string driverOneName = sessionInfo.DriverInfo.Drivers[1].UserName;

                            lblDriverInfo.Text = driverOneName + " is on lap " + newDriverLap;
                            driverCurrentLap = newDriverLap;
                        }
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
            public List<ResultsPositions> ResultsPositions { get; set; }
        }

        public class ResultsPositions
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free TODO: make a joke about debris cautions here

            Application.Exit();
        } // when close button is clicked, stop wrapper and close the rest of the program 
    }
}