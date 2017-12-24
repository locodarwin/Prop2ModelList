using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;

namespace Prop2ModelList
{
    public partial class Form1 : Form
    {

        private readonly BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Process;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            Status("Ready to begin.");
            Status("To start, use the 'Browse' button to select a propdump file.");
            Status("Then click 'Go!' to begin processing the file.");

        }


        private void butGo_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
            butGo.Enabled = false;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a file.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Propdump File|*.txt";     // filer by txt
            openFileDialog1.Title = "Select a propdump v5 file";

            // Open dialog and allow user to choose file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // When chosen, put filename in the textbox  
                textFileIn.Text = openFileDialog1.FileName;
            }
        }



        private void Process(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bgWorker = (BackgroundWorker)sender;

            List<string> aModelsIn = new List<string>();
            List<string> aModelsOut = new List<string>();

            string sInFile = textFileIn.Text;
            string line, sOutFile;

            // Check to make sure file exists, bail if not
            if (!File.Exists(sInFile))
            {
                bgWorker.ReportProgress(0, "Input file does not exist! Try again.");
                return;
            }

            // Make sure the propdump is real, and is version 5
            string linetest = File.ReadLines(sInFile).First();
            if (linetest.Contains("propdump version 5") == false)
            {
                bgWorker.ReportProgress(0, "Input file is not a valid propdump v5! Try again.");
                return;
            }



            bgWorker.ReportProgress(0, "Processing...");

            // Begin processing
            bgWorker.ReportProgress(0, "Reading file: " + sInFile);

            // Iteration
            int iCount = 0;
            System.IO.StreamReader infile = new System.IO.StreamReader(sInFile);

            while ((line = infile.ReadLine()) != null)
            {
                iCount++;
                
                // Ignore the first line, it's the header
                if (iCount == 1)
                {
                    continue;
                }

                // break the line into an array split by " " (space)
                string[] piece = line.Split(' ');
                int len = Convert.ToInt32(piece[9]);
                if (len == 0)
                {
                    continue;
                }
                try
                {
                    string chop = piece[13].Substring(0, len);
                    aModelsIn.Add(chop);
                }
                catch { }
                
                //Console.WriteLine(chop);
                

            }
            infile.Close();


            // Make the array elements unique
            aModelsOut = aModelsIn.Distinct().ToList();
            aModelsOut.Sort();

            // Open the output file for writing
            sOutFile = Path.GetDirectoryName(sInFile) + "\\model_list.txt";
            System.IO.StreamWriter outfile = new System.IO.StreamWriter(sOutFile, true);
            bgWorker.ReportProgress(0, "Writing output file: " + sOutFile);
            foreach (string x in aModelsOut)
            {
                outfile.WriteLine(x);
            }
            outfile.Close();
         
        }

        /*

            359971 1167343043 -800 0 200 0 0 0 0 7 0 99 0 floor01create name gz1wat1, texture water1_top mask=semitrans10,solid no,move 0 0.1 0.5 time=2 smooth sync

            The 0st part (358257) is the citizen number of the owner of the object.
            The 1nd part (1167343043) is the timestamp that contains the date when the object had been created.
            The 2rd part (-800) is the X position of the object.
            The 3th part (0) is the Y position of the object.
            The 4th part (200) is the Z position of the object.
            The 5th part (0) is the YAW orientation of the object.
            The 6th part (0) is the Tilt orientation of the object.
            The 7th part (0) is the Roll orientation of the object.
            The 8th part (0) is the type of the object. (0: Object. 1: Camera. 2: Zone. 3: Particle Emitter. 4: Mover.).
            The 9th part (7) is the length of the model name (floor01).
            The 10th part (0) is the length of the description.
            The 11th part (99) is the length of the action (create name gz1wat1 [...]).
            The 12th part (0) is the length of the object data (for object types other than 0).
            The 13th part (all that remains) contains object information in the length described above.

        */






        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Status(e.UserState.ToString());
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butGo.Enabled = true;
            Status("Completed.");
        }



        public void Status(string sMessage, bool bAddNewLine = true)
        {
            richStatus.AppendText(sMessage);
            if (bAddNewLine != false)
            {
                richStatus.AppendText(Environment.NewLine);
                richStatus.ScrollToCaret();
            }
        }

    }
}
