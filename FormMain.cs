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
            // Simple input validation - Presence Check
            if (tbxAlbumEntry.Text == "")
            {
                lblAlbumProgress.Text = "Album Progress : [ERR - NO URL PROVIDED]";
                return;
            }

            // Update GUI labels
            lblAlbumProgress.Text = "Album Progress : [FETCHING ALBUM PAGE DATA]";

            // Get the album page
            HttpResponseMessage albumPageResponse = await httpCli.GetAsync(tbxAlbumEntry.Text);
            string albumPageContent = await albumPageResponse.Content.ReadAsStringAsync();

            // Get creator page URL
            string[] splitURL = tbxAlbumEntry.Text.Split('/');
            string creatorPageURL = splitURL[0] + "//" + splitURL[2];

            // Get the track list pattern string from the regex_patterns.json file and match the HTML against it
            string pattern = regexPatternsDict["track_list_pattern"];
            MatchCollection Matches = Regex.Matches(albumPageContent, pattern);

            // Set up GUI elements
            pgbAlbumProgress.Maximum = Matches.Count;
            pgbAlbumProgress.Value = 0;
            lblAlbumProgress.Text = $"Album Progress : 0 / {Matches.Count}";
            lblCurrentTrack.Text = "Current Track : ";

            // Itterate over each of the matches
            int tracksDownloaded = 0;
            foreach (Match relativeTrackURLMatch in Matches)
            {
                // Create full track page URL from the relative track page URL
                string trackPageURL = creatorPageURL + relativeTrackURLMatch.Value;

                // Get track name from URL
                string[] splitTrackURL = trackPageURL.Split('/');
                string trackName = splitTrackURL[splitTrackURL.Length - 1];

                // Update the current track label
                lblCurrentTrack.Text = "Current Track : " + trackName;

                // Download the track
                await DownloadTrack(trackPageURL, trackName);

                // Update statistics
                tracksDownloaded++;

                // Update GUI elements
                pgbAlbumProgress.Value++;
                lblAlbumProgress.Text = $"Album Progress : {tracksDownloaded} / {Matches.Count}";
            }
            // Reset GUI elements
            lblAlbumProgress.Text = "Album Progress : Done!";
            lblCurrentTrack.Text = "Current Track N/A:";
        }

        private async void btnDownloadTrack_Click(object sender, EventArgs e)
        {
            // Simple input validation - Presence Check
            if (tbxTrackEntry.Text == "")
            {
                lblCurrentTrack.Text = "Current Track : [ERR - NO URL PROVIDED]";
                return;
            }

            // Get track name from URL
            string[] splitURL = tbxTrackEntry.Text.Split('/');
            string trackName = splitURL[splitURL.Length - 1];

            // Update and setup GUI elements
            lblAlbumProgress.Text = "Album Progress : N/A";
            lblCurrentTrack.Text = "Current Track : " + trackName;
            pgbAlbumProgress.Value = 0;
            pgbAlbumProgress.Maximum = 1;

            // Download the track
            await DownloadTrack(tbxTrackEntry.Text, trackName);

            // Update + reset GUI elements
            pgbAlbumProgress.Value++;
            lblCurrentTrack.Text = "Current Track : Done!";
        }

        /// <summary>
        /// Downloads a track from bandcamp when given a track page url and the track's name
        /// </summary>
        /// <param name="trackPageURL">The URL pointing to the page of a track. E.G. https://overkillsoundtracks.bandcamp.com/track/hard-time </param>
        /// <param name="trackName">The name of the track, this is the name it will be saved on disc as </param>
        /// <returns></returns>
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
