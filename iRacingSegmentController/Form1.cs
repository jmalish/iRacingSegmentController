using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private List<Driver> driversInSession = new List<Driver>(); // list of all drivers in server
        private List<Positions> currentPositions = new List<Positions>();  // Stores a list of the current standings
        private int currentLapRace;  // what lap the race is on;
        private int segment1EndLap = 999999;
        private int segment2EndLap = 999999;  // these store what laps the segments end
        private bool isSegment1Ended, isSegment2Ended;  // these tell us if the segments are over yet, so we don't send the command twice
        private bool isPitsClosed = false;  // whether pits are closed or not
        private List<Positions> segment1Top10 = new List<Positions>();
        private List<Positions> segment2Top10 = new List<Positions>();
        private List<Positions> carsOnLeadLap = new List<Positions>();
        #endregion


        #region Form Stuff
        public Form1()  // this is run when the program is first started, it's essentially the same as form load for the primary form
        {
            TopMost = true;

            InitializeComponent();  // do magic stuff

            InitializeSegmentTop10s();

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


            dgvSeg1Results.RowHeadersVisible = false;  // hide left margin

            dgvSeg1Results.ColumnCount = 4; // set number of columns

            // set column names
            dgvSeg1Results.Columns[0].Name = "Pos.";
            dgvSeg1Results.Columns[1].Name = "Car #";
            dgvSeg1Results.Columns[2].Name = "Name";
            dgvSeg1Results.Columns[3].Name = "Lap";

            // set column widths
            dgvSeg1Results.Columns[0].Width = 50;
            dgvSeg1Results.Columns[1].Width = 56;
            dgvSeg1Results.Columns[3].Width = 50;
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
                Console.WriteLine(exc.Message);
                //WriteToLogFile("wrapper stuff", exc.Message.ToString());
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: delete this if nothing is put here
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  // when close button is clicked, stop wrapper and close the rest of the program 
        {
            isClosing = true;  // let everything else know program is closing
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free

            Application.Exit();  // close program
        }

        private void nudSegmentEnd1_ValueChanged(object sender, EventArgs e)  // when user changes value for segment 1
        {
            nudSegmentEnd1.Value = (int)Math.Round(nudSegmentEnd1.Value);  // round value to the nearest whole number
            segment1EndLap = (int)nudSegmentEnd1.Value - 1;  // store value, subtract one to make up for 0 index
        }

        private void nudSegmentEnd2_ValueChanged(object sender, EventArgs e)  // when user changes value for segment 2
        {
            nudSegmentEnd2.Value = (int)Math.Round(nudSegmentEnd2.Value);  // round value to the nearest whole number
            segment2EndLap = (int)nudSegmentEnd2.Value - 1;  // store value
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

            lblCurrentFlag.Text = "Current Flag: " + newFlag;
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

                        currentLapRace = raceSession.ResultsLapsComplete; // get the laps complete, this is helpful for when someone in top 10 is not on lead lap

                        lblCurrentLap.Text = $"Current Lap: {currentLapRace + 1}";  // update current lap label


                        if ((currentLapRace >= segment1EndLap - 5 || currentLapRace >= segment2EndLap - 5) && !isPitsClosed)  // if 5 laps from segment end
                        {
                            // TODO: make the 5 lap part set by user, reenable this
                            // ClosePits(); // close pits
                        }

                        currentPositions = raceSession.ResultsPositions; // update positions to equal live results

                        if (currentPositions != null) // make sure currentPositions list is not null, otherwise program will crash
                        {
                            dgvDriverList.Rows.Clear(); // clear dvg so we don't have a bunch of duplicates
                            foreach (Positions p in currentPositions) // for each position in current positions
                            {
                                dgvDriverList.Rows.Add(p.Position, p.CarIdx, driversInSession[p.CarIdx].UserName,
                                    p.LapsComplete + 1); // add position to datagridview
                            }

                            // find how many cars are on lead lap
                            // I have it looking for current lap, and current lap - 1 to make up for when the leader crosses the line
                            IEnumerable<Positions> carsOnLeadLapQuery =
                                from position in currentPositions
                                where position.LapsComplete == currentLapRace || position.LapsComplete == currentLapRace - 1
                                select position;

                            lblCarsOnLead.Text = $"Cars on Lead Lap: {carsOnLeadLapQuery.Count()} of {currentPositions.Count}";

                            carsOnLeadLap = carsOnLeadLapQuery.ToList();  // convert cars on lead query lap to list

                            Console.WriteLine(isSegment1Ended);

                            if (!isSegment1Ended)  // if segment 1 is not ended
                            {
                                if (currentLapRace >= segment1EndLap + 1 && segment1Top10[9].CarIdx == -1)
                                {  // if we're on the lap of a segment end, start checking if we should throw caution
                                    CheckForSegmentEnd();
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }
        #endregion


        #region Functions

        private void InitializeSegmentTop10s()
        {
            for (int i = 0; i < 10; i++)
            {
                segment1Top10.Add(new Positions());
                segment2Top10.Add(new Positions());
            }
        }

        private void CheckForSegmentEnd()
        {
            #region P10 on lead lap
            if (carsOnLeadLap.Count() > 9)  // if there are more than 9 cars on the lead lap, we know p10 is on lead lap
            {
                for (int i = 0; i < 10; i++)
                {
                    if (segment1Top10[i].CarIdx == -1)
                    {
                        if (currentPositions[i].LapsComplete == currentLapRace)
                        {
                            segment1Top10[i] = currentPositions[i];
                            UpdateDataGridView(1);
                        }
                    }
                }

                // check if the car at index 9 (p10 on track) is on the lead lap, that means he's crossed the line
                if (segment1Top10[9].CarIdx != -1)
                {
                    if (!isYellowOut)  // make sure yellow isn't out
                    {
                        ThrowCaution();  // throw caution
                    }
                }  // TODO: Add segment 2
            }
            #endregion
            #region P10 not on lead lap
            else  // if there are less than 10 cars on the lead lap
            {
                for (int i = 0; i < carsOnLeadLap.Count; i++)
                {
                    if (segment1Top10[i].CarIdx == -1)
                    {
                        if (currentPositions[i].LapsComplete == currentLapRace)
                        {
                            segment1Top10[i] = currentPositions[i];
                            UpdateDataGridView(1);
                        }
                    }
                }

                // check if the last car on the lead lap has completed his lap
                if (segment1Top10[carsOnLeadLap.Count - 1].CarIdx != -1)
                {
                    for (int i = carsOnLeadLap.Count + 1; i < 9; i++)  // get all the positions between last car on lead lap + 1 and p10.
                    {
                        segment1Top10[i] = currentPositions[i];
                        UpdateDataGridView(1);
                    }

                    if (!isYellowOut)  // make sure yellow isn't out
                    {
                        isSegment1Ended = true;
                        nudSegmentEnd1.Enabled = false;
                        ThrowCaution();  // throw caution
                    }
                }  // TODO: Add segment 2
            }
            #endregion
        }

        private void UpdateDataGridView(int _segment)
        {
            if (_segment == 1)
            {
                dgvSeg1Results.Rows.Clear();
                for (int i = 0; i < 10; i++)
                {
                    if (segment1Top10[i].CarIdx != -1)
                    {
                        dgvSeg1Results.Rows.Add(segment1Top10[i].Position, segment1Top10[i].CarIdx, driversInSession[segment1Top10[i].CarIdx].UserName,
                            segment1Top10[i].ReasonOutStr); // add position to datagridview
                    }
                }
            }
        }

        private void ClosePits()
        {
            if (isPitsClosed)
            {
                Console.WriteLine("Pits are closed!");
                isPitsClosed = true;
            }
            else
            {
                Console.WriteLine("Pits already closed");
            }
        }

        private void ThrowCaution()
        {
            /* TODO: figure out caution section, using SendKeys might be a horribly bad decision, will need to test
             *
             * Problem with SendKeys is that it sends the text to whatever window is open
             * in a perfect world the user only ever has iracing as the active window when running this
             * but if someone is adminning while swapping between other programs, this might cause issues
             * 
             * It might be best to just use the built in macros, as that's mostly guaranteed to work, it's what was used in the caution clock program
             * being able to run this thing without making the user figure out how to set up macros would be amazing though.
            */
            
            //wrapper.Chat.Activate(); // open chat
            //SendKeys.Send("test");  // send text command to throw caution
            //SendKeys.Send("{ENTER}");  // tell iracing to send the text command, throwing the caution

            Console.WriteLine("Throw caution here!");
            //isYellowOut = true;
            //isPitsClosed = false;

            // TODO: need to "open" pits again
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
            public int ResultsLapsComplete { get; set; }
            public string SessionLaps { get; set; }
            public string SessionType { get; set; }
            public List<Positions> ResultsPositions { get; set; }
        }

        public class Positions
        {
            public Positions()
            {
                CarIdx = -1;  // pace car is always CarIdx 0, -1 will never be used by iracing
            }
            public int Position { get; set; }
            public string ClassPosition { get; set; }
            public int CarIdx { get; set; }
            public int Lap { get; set; }
            public string Time { get; set; }
            public string FastestLap { get; set; }
            public string FastestTime { get; set; }
            public string LastTime { get; set; }
            public int LapsLed { get; set; }
            public int LapsComplete { get; set; }
            public decimal LapsDriven { get; set; }
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
            public int CarNumber { get; set; }
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


        private void btnGoToP10_Click(object sender, EventArgs e)
        {
            wrapper.Camera.SwitchToPosition(10);
        }

        private void dgvDriverList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            wrapper.Camera.SwitchToCar(driversInSession[currentPositions[e.RowIndex].CarIdx].CarNumber);  // TODO: make this work so it jumps to the driver, not the position
        }

        private void btnSetToNextLap_Click(object sender, EventArgs e)  // debug thing, TODO: delete before release
        {
            nudSegmentEnd1.Value = (currentLapRace + 2);  // round value to the nearest whole number
            // segment1EndLap = (int)nudSegmentEnd1.Value - 1;  // store value, subtract one to make up for 0 index
        }
    }
}