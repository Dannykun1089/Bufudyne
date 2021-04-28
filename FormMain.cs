using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Bufudyne
{
    public partial class frmMain : Form
    {
        // HTTP client used by the program
        HttpClient httpCli = new HttpClient();

        // Dictionary for storing base64-encoded regex patterns
        Dictionary<string, string> regexPatternsDict;

        public frmMain()
        {
            InitializeComponent();

            // Deserialize the json encoded file into a C# dict
            string regexPatternsJSON = File.ReadAllText("./regex_patterns.json");
            regexPatternsDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(regexPatternsJSON);
        }

        private async void btnDownloadAlbum_Click(object sender, EventArgs e)
        {
            // Update GUI labels
            lblAlbumProgress.Text = "Album Progress : [FETCHING ALBUM PAGE DATA]";

            // Get the album page
            HttpResponseMessage albumPageResponse = await httpCli.GetAsync(tbxAlbumEntry.Text);
            string albumPageContent = await albumPageResponse.Content.ReadAsStringAsync();

            // Get creator page URL
            string[] splitURL = tbxAlbumEntry.Text.Split(Convert.ToChar("/"));
            string creatorPageURL = splitURL[0] + "//" + splitURL[2];

            // Get the track list pattern string from the regex_patterns.json file and match the HTML against it
            string pattern = regexPatternsDict["track_list_pattern"];
            MatchCollection Matches = Regex.Matches(albumPageContent, pattern);

            // Set up GUI elements
            pgbAlbumProgress.Maximum = Matches.Count;
            pgbAlbumProgress.Value = 0;
            int tracksDownloaded = 0;
            lblAlbumProgress.Text = string.Format("Album Progress : 0 / {0}", Matches.Count);
            lblCurrentTrack.Text = "Current Track : ";

            // Itterate over each of the matches
            foreach (Match relativeTrackURLMatch in Matches)
            {
                // Attatch the creator page url and relative track url to create the track page url
                string trackPageURL = creatorPageURL + relativeTrackURLMatch.Value;

                // Get track name from URL
                string[] splitTrackURL = trackPageURL.Split(Convert.ToChar("/"));
                string trackName = splitTrackURL[splitTrackURL.Length - 1];

                // Update the current track label
                lblCurrentTrack.Text = "Current Track : " + trackName;

                // Download track
                await DownloadTrack(trackPageURL, trackName);

                // Update GUI elements
                pgbAlbumProgress.Value += 1;
                tracksDownloaded += 1;
                lblAlbumProgress.Text = String.Format("Album Progress : {0} / {1}", Convert.ToString(tracksDownloaded), Convert.ToString(Matches.Count));
            }
            // Reset GUI elements
            lblAlbumProgress.Text = "Album Progress : Done!";
            lblCurrentTrack.Text = "Current Track N/A:";
        }

        private async void btnDownloadTrack_Click(object sender, EventArgs e)
        {
            // Get track name from URL
            string[] splitURL = tbxTrackEntry.Text.Split(Convert.ToChar("/"));
            string trackName = splitURL[splitURL.Length - 1];

            // Update and setup GUI elements
            lblCurrentTrack.Text = "Current Track : " + trackName;
            pgbAlbumProgress.Value = 0;
            pgbAlbumProgress.Maximum = 1;

            // Download the track
            await DownloadTrack(tbxTrackEntry.Text, trackName);

            //Update GUI elements
            pgbAlbumProgress.Value += 1;
            lblCurrentTrack.Text = "Current Track : ";
        }

        public async Task DownloadTrack(string trackPageURL, string trackName)
        {
            // Get the track page
            HttpResponseMessage trackPageResponse = await httpCli.GetAsync(trackPageURL);
            string trackPageContent = await trackPageResponse.Content.ReadAsStringAsync();

            // Get the audio track pattern string from the regex_patterns.json file and match the HTML against it
            string pattern = regexPatternsDict["audio_url_pattern"];
            Match regexMatch = Regex.Match(trackPageContent, pattern);

            // Get the audio bytes
            HttpResponseMessage audioResponse = await httpCli.GetAsync(regexMatch.Value);
            byte[] audioBytes = await audioResponse.Content.ReadAsByteArrayAsync();

            // Write to file
            File.WriteAllBytes(trackName + ".mp3", audioBytes);
        }
    }
}
