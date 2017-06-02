using System;
using System.Collections.Generic;
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
        private List<Positions> segment1Top10 = new List<Positions>();  // contains top 10 of segment 1
        private List<Positions> segment2Top10 = new List<Positions>();  // contains top 10 of segment 2
        private List<Positions> carsOnLeadLap = new List<Positions>();  // contains all cars on lead lap
        private bool isAdmin = false;  // if user is admin or not
        #endregion


        #region Form Stuff
        public Form1()  // this is run when the program is first started, it's essentially the same as form load for the primary form
        {
            TopMost = true;  // TODO: delete before release

            InitializeComponent();  // do magic stuff

            InitializeSegmentTop10S();

            #region Set Defaults
            nudClosePitsMacro.Value = Properties.Settings.Default.ClosePitsMacro;
            nudThrowCautionMacro.Value = Properties.Settings.Default.ThrowCautionMacro;
            nudClosePits.Value = Properties.Settings.Default.ClosePitsLap;
            #endregion


            #region Data Grid Views setup
            #region dgvDriverList
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

            #region dgvSeg1Results
            dgvSeg1Results.RowHeadersVisible = false;  // hide left margin
            dgvSeg1Results.ColumnCount = 3; // set number of columns

            // set column names
            dgvSeg1Results.Columns[0].Name = "Pos.";
            dgvSeg1Results.Columns[1].Name = "Car #";
            dgvSeg1Results.Columns[2].Name = "Name";

            // set column widths
            dgvSeg1Results.Columns[0].Width = 50;
            dgvSeg1Results.Columns[1].Width = 56;
            #endregion

            #region dgvSeg2Results
            dgvSeg2Results.RowHeadersVisible = false;  // hide left margin
            dgvSeg2Results.ColumnCount = 3; // set number of columns

            // set column names
            dgvSeg2Results.Columns[0].Name = "Pos.";
            dgvSeg2Results.Columns[1].Name = "Car #";
            dgvSeg2Results.Columns[2].Name = "Name";

            // set column widths
            dgvSeg2Results.Columns[0].Width = 50;
            dgvSeg2Results.Columns[1].Width = 56;
            #endregion
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

        private void nudClosePitsMacro_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClosePitsMacro = (int)nudClosePitsMacro.Value;
            Properties.Settings.Default.Save();
        }

        private void nudThrowCautionMacro_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThrowCautionMacro = (int)nudThrowCautionMacro.Value;
            Properties.Settings.Default.Save();
        }

        private void nudClosePits_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClosePitsLap = (int)nudClosePits.Value;
            Properties.Settings.Default.Save();
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

        private void btnGoToP10_Click(object sender, EventArgs e)
        {
            wrapper.Camera.SwitchToPosition(10);
        }

        private void dgvDriverList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            wrapper.Camera.SwitchToCar(driversInSession[currentPositions[e.RowIndex].CarIdx].CarNumber);
        }

        private void btnSetToNextLap_Click(object sender, EventArgs e)  // debug thing, TODO: delete before release
        {
            if (!isSegment1Ended)
            {
                nudSegmentEnd1.Value = (currentLapRace + 1);  // round value to the nearest whole number
            }

            nudSegmentEnd2.Value = (currentLapRace + 2);  // round value to the nearest whole number
        }
        #endregion  


        #region SDK Wrapper Stuff
        // Do things when Telemetry updates (supposed to be 60 times per second)
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)
        {
            if (isClosing) return;  // if program is closing, just return so we don't waste time doing this stuff

            if (wrapper.IsConnected)
            {
                lblIsConnected.Text = "Connected: True";
            }

            #region Flag stuff
            string newFlag =
                telemArgs.TelemetryInfo.SessionFlags.Value.ToString()
                    .Split(' ')[
                        0]; // get the actual current flag according to the session, splits because it normally shows two states

            if (currentFlag != newFlag) // if this is true, the flag state has changed
            {
                if (newFlag.Contains("Caution"))
                {
                    currentFlag = "Caution";
                    isYellowOut = true;
                }
                else if (newFlag.Contains("Green"))
                {
                    currentFlag = "Green";
                    isYellowOut = false;
                }

                lblCurrentFlag.Text = "Current Flag: " + newFlag;
            }
            #endregion
        }

        // Do things when session info updates (seems to be whenever a car crosses the line)
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs sessionArgs)
        {
            if (isClosing) return;  // if program is closing, just return so we don't waste time doing this stuff
            if (!sessionArgs.SessionInfo.IsValidYaml) return;  // if the yaml isn't valid, no reason to bother with the rest


            // TODO: Fix this since it's deprecated, I doubt this will cause me issue, but better safe than sorry
            Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);  // create a deserializer
            var input = new StringReader(sessionArgs.SessionInfo.Yaml);  // read the yaml
            var sessionInfo = deserializer.Deserialize<SDKReturn>(input);  // deserialize the yaml

            #region Radios
            lblIsAdmin.Text = $"User is Admin: {isAdmin}"; // update label

            foreach (Frequencies r in sessionInfo.RadioInfo.Radios[0].Frequencies)
            {
                if (r.FrequencyName == "@ADMIN")
                    isAdmin = true;  // if user has the ADMIN radio channel, we can safely assume they're an admin in the session
            }
            #endregion


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

                    lblCurrentLap.Text = $"Current Lap: {currentLapRace + 1} of {raceSession.SessionLaps}";  // update current lap label

                    #region close pits
                    if (isPitsClosed)  // make sure pits are open
                    {
                        if (!isSegment1Ended)  // check if segment 1 is ended
                        { // if not, we're in segment 1
                            if (currentLapRace >= segment1EndLap - Properties.Settings.Default.ClosePitsLap) // if it's 5 laps or less away from segment 1
                            {
                                ClosePits();  // close pits
                            }
                        }
                        else
                        {  // otherwise we're in segment 2
                            if (currentLapRace >= segment2EndLap - Properties.Settings.Default.ClosePitsLap) // 5 laps or less
                            {
                                ClosePits(); // close pits
                            }
                        }
                    }
                    #endregion

                    currentPositions = raceSession.ResultsPositions; // update positions to equal live results

                    if (currentPositions != null) // make sure currentPositions list is not null, otherwise program will crash
                    {
                        dgvDriverList.Rows.Clear(); // clear dvg so we don't have a bunch of duplicates
                        foreach (Positions p in currentPositions) // for each position in current positions
                        {
                            dgvDriverList.Rows.Add(p.Position, p.CarIdx, driversInSession[p.CarIdx].UserName,
                                p.LapsComplete + 1); // add position to datagridview
                        }


                        IEnumerable<Positions> carsOnLeadLapQuery =
                            from position in currentPositions
                            where position.Lap == 0
                            select position;

                        lblCarsOnLead.Text = $"Cars on Lead Lap: {carsOnLeadLap.Count()} of {currentPositions.Count}";

                        carsOnLeadLap = carsOnLeadLapQuery.ToList();  // convert cars on lead query lap to list

                        if (!isSegment1Ended || (isSegment1Ended && !isSegment2Ended))  // if segment 1 is not ended
                        {
                            if (currentLapRace >= segment1EndLap + 1 && segment1Top10[9].CarIdx == -1 || currentLapRace >= segment2EndLap + 1 && segment2Top10[9].CarIdx == -1)
                            {  // if we're on the lap of a segment end, start checking if we should throw caution
                                if (!isYellowOut) // make sure yellow hasn't come out
                                {
                                    CheckForSegmentEnd(false);
                                }
                                else // if it has
                                {
                                    CheckForSegmentEnd(true);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #endregion


        #region Functions
        private void InitializeSegmentTop10S()
        {
            for (int i = 0; i < 10; i++)
            {
                segment1Top10.Add(new Positions());
                segment2Top10.Add(new Positions());
            }
        }

        private void CheckForSegmentEnd(bool _isYellowOut)
        {
            if (!_isYellowOut)  // caution is not out
            {
                #region P10 on lead lap

                if (carsOnLeadLap.Count() > 9
                ) // if there are more than 9 cars on the lead lap, we know p10 is on lead lap
                {
                    if (!isSegment1Ended) // seg 1
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
                            if (!isYellowOut) // make sure yellow isn't out
                            {
                                ThrowCaution(); // throw caution
                            }
                        }
                    }
                    else // seg 2
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (segment2Top10[i].CarIdx == -1)
                            {
                                if (currentPositions[i].LapsComplete == currentLapRace)
                                {
                                    segment2Top10[i] = currentPositions[i];
                                    UpdateDataGridView(2);
                                }
                            }
                        }

                        // check if the car at index 9 (p10 on track) is on the lead lap, that means he's crossed the line
                        if (segment2Top10[9].CarIdx != -1)
                        {
                            if (!isYellowOut) // make sure yellow isn't out
                            {
                                ThrowCaution(); // throw caution
                            }
                        }
                    }
                }

                #endregion

                #region P10 not on lead lap

                else // if there are less than 10 cars on the lead lap
                {
                    if (!isSegment1Ended)
                    {
                        for (int i = 0; i < carsOnLeadLap.Count + 1; i++)
                        {
                            if (segment1Top10[i].CarIdx == -1)
                            {
                                if (currentPositions[i].LapsComplete == currentLapRace)
                                {
                                    if (segment1Top10[i].CarIdx == -1)
                                    {
                                        segment1Top10[i] = currentPositions[i];
                                        UpdateDataGridView(1);
                                    }
                                }
                            }
                        }

                        // check if the last car on the lead lap has completed his lap
                        if (segment1Top10[carsOnLeadLap.Count - 1].CarIdx != -1)
                        {
                            // if he has, get positions x through 10, where x = cars on lead lap + 1
                            for (int i = carsOnLeadLap.Count;
                                i < 10;
                                i++) // get all the positions between last car on lead lap + 1 and p10.
                            {
                                segment1Top10[i] = currentPositions[i];
                                UpdateDataGridView(1);
                            }

                            if (!isYellowOut) // make sure yellow isn't out
                            {
                                ThrowCaution(); // throw caution
                            }
                        }
                    }
                    else // else segment1ended is false, so we're looking at segment 2 results
                    {
                        for (int i = 0; i < carsOnLeadLap.Count + 1; i++)
                        {
                            if (segment2Top10[i].CarIdx == -1)
                            {
                                if (currentPositions[i].LapsComplete == currentLapRace)
                                {
                                    if (segment2Top10[i].CarIdx == -1)
                                    {
                                        segment2Top10[i] = currentPositions[i];
                                        UpdateDataGridView(2);
                                    }
                                }
                            }
                        }

                        // check if the last car on the lead lap has completed his lap
                        if (segment2Top10[carsOnLeadLap.Count - 1].CarIdx != -1)
                        {
                            // if he has, get positions x through 10, where x = cars on lead lap + 1
                            for (int i = carsOnLeadLap.Count;
                                i < 10;
                                i++) // get all the positions between last car on lead lap + 1 and p10.
                            {
                                segment2Top10[i] = currentPositions[i];
                                UpdateDataGridView(2);
                            }

                            if (!isYellowOut) // make sure yellow isn't out
                            {
                                ThrowCaution(); // throw caution
                            }
                        }
                    }
                }

                #endregion
            }
            else  // caution is out
            {
                if (!isSegment1Ended) // we're in seg 1
                {
                    for (var i = 0; i < 10; i++)
                    {
                        if (segment1Top10[i].CarIdx == -1)
                        {
                            segment1Top10[i] = currentPositions[i];
                            UpdateDataGridView(1);
                        }
                    }
                }
                else  // we're in seg 2
                {
                    for (var i = 0; i < 10; i++)
                    {
                        if (segment2Top10[i].CarIdx == -1)
                        {
                            segment2Top10[i] = currentPositions[i];
                            UpdateDataGridView(2);
                        }
                    }
                }
            }
        }

        private void UpdateDataGridView(int _segment)  // update data grid views to show results
        {
            if (_segment == 1)  // if we're in seg 1
            {
                dgvSeg1Results.Rows.Clear(); // clear the dgv so it doesn't show duplicates
                for (int i = 0; i < 10; i++)
                {
                    if (segment1Top10[i].CarIdx != -1)  // make sure we only show filled slots
                    {
                        dgvSeg1Results.Rows.Add(segment1Top10[i].Position, segment1Top10[i].CarIdx, driversInSession[segment1Top10[i].CarIdx].UserName); // add position to datagridview
                    }
                }
            }
            else
            {
                dgvSeg2Results.Rows.Clear();
                for (int i = 0; i < 10; i++)
                {
                    if (segment2Top10[i].CarIdx != -1)
                    {
                        dgvSeg2Results.Rows.Add(segment2Top10[i].Position, segment2Top10[i].CarIdx, driversInSession[segment2Top10[i].CarIdx].UserName); // add position to datagridview
                    }
                }
            }
        }

        private void ClosePits()
        {
            if (!isPitsClosed) // make sure pits are not closed
            {
                wrapper.Chat.SendMacro(Properties.Settings.Default.ClosePitsMacro - 1);
                isPitsClosed = true;
            }
        }

        private void ThrowCaution()
        {
            if (segment1Top10[9].CarIdx != -1)  // if all segment 1 slots are filled
            {
                isSegment1Ended = true; // tell program seg 1 is ended
                nudSegmentEnd1.Enabled = false;  // disable nud so it can't be edited
            }
            else if (segment2Top10[9].CarIdx != -1)
            {
                isSegment2Ended = true;
                nudSegmentEnd2.Enabled = false;
            }

            wrapper.Chat.SendMacro(Properties.Settings.Default.ThrowCautionMacro - 1);

            isPitsClosed = false;  // open pits
        }
        #endregion
    }
}