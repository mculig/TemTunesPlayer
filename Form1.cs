using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemTunesPlayer
{
    public partial class temTunesPlayer : Form
    {

        delegate void playingStartedDelegate(object sender, EventArgs e);
        delegate void playingStoppedDelegate(object sender, EventArgs e);

        private static readonly String scoreRetrievalURL = @"https://www.temtunes.org/api/music/score/";

        private MusicScore score = null;

        private MusicPlayer player = new MusicPlayer();

        private readonly int SCORE_START_DELAY_MILIS = 3000;

        private bool looping = false;

        public temTunesPlayer()
        {
            InitializeComponent();

            player.playingStarted += HandlePlayingStarted;
            player.playingStopped += HandlePlayingStopped;

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(score != null)
            {
                updateStatus("Playing in 3 seconds");
                player.PlayScore(score, SCORE_START_DELAY_MILIS, looping); 
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            player.StopPlaying();
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {
            this.looping = !this.looping;
            if (looping)
            {
                labelLooping.Text = "Looping ON";
                labelLooping.ForeColor = Color.Green;
            }
            else
            {
                labelLooping.Text = "Looping OFF";
                labelLooping.ForeColor = Color.Red;
            }
        }

        private void buttonDownloadScore_Click(object sender, EventArgs e)
        {
            if(scoreIdTextBox.TextLength == 24)
            {
                using(WebClient client = new WebClient())
                {
                    try
                    {
                        updateStatus("Downloading");
                        String scoreJSON = Encoding.UTF8.GetString(Encoding.Default.GetBytes(client.DownloadString(scoreRetrievalURL + scoreIdTextBox.Text)));
                        score = JsonConvert.DeserializeObject<MusicScore>(scoreJSON);
                        labelScoreName.Text = score.scoreName;
                        labelAuthor.Text = score.authorFullUsername;
                        labelBPM.Text = score.bpm + "BPM";
                        updateStatus("Download complete");
                    }
                    catch(Exception)
                    {
                        score = null;
                        updateStatusError("Download failed");
                    }
                }
            }
        }

        private void HandlePlayingStarted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new playingStartedDelegate(HandlePlayingStarted), new object[] { sender, e });
            }
            else
            {
                updateStatus("Playing");
            }
        }

        private void HandlePlayingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new playingStoppedDelegate(HandlePlayingStopped), new object[] { sender, e });
            }
            else
            {
                updateStatus("Stopped");
            }
        }

        private void updateStatus(String status)
        {
            labelStatus.Text = status;
            labelStatus.ForeColor = Color.White;
        }

        private void updateStatusError(String status)
        {
            labelStatus.Text = status;
            labelStatus.ForeColor = Color.Red;
        }
    }
}
