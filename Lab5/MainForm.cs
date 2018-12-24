using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Eto.Forms;
using Eto.Drawing;

namespace Lab_5
{
    public class MainForm : Form
    {
        public MainForm()
        {
            ClientSize = new Size(400, 400);
            Title = "Lab 5";

            var wordList = new List<string>();

            var timeLabel = new Label();
            
            var openFileButton = new Button { Text = "Open File" };
            openFileButton.Click += delegate
            {
                var openFileDialog = new OpenFileDialog
                {
                    MultiSelect = false,
                    Filters = {"Text|*.txt"}
                };

                var stopWatch = new Stopwatch();

                if (openFileDialog.ShowDialog(this) == DialogResult.Ok)
                {
                    stopWatch.Start();
                    var file = File.ReadAllText(openFileDialog.FileName);
                    foreach (var word in file.Split(' '))
                    {
                        if (!wordList.Contains(word))
                        {
                            wordList.Add(word);
                        }
                    }
                }

                stopWatch.Stop();
                timeLabel.Text = "Time of opening and scanning: " + stopWatch.ElapsedMilliseconds + " ms";
            };
            
            var textBox = new TextBox();
            var listBox = new ListBox();
            var timeFindLabel = new Label();
            var MaxDistLabel = new Label();
            var MaxDistTextBox = new TextBox();

            MaxDistLabel.Text = "Enter max distance between words";
            textBox.PlaceholderText = "Enter word to find";
            
            var findButton = new Button { Text = "Find word" };
            findButton.Click += delegate
            {
                listBox.Items.Clear();

                var expectedSubstring = textBox.Text;
                if (expectedSubstring.Trim(' ') == "")
                {
                    listBox.Items.Add("Empty field");
                    return;
                }

                if (MaxDistTextBox.Text.Trim(' ') == "")
                {
                    listBox.Items.Add("Empty max distance field");
                    return;
                }

                var maxDist = Int32.Parse(MaxDistTextBox.Text);
                var isFinded = false;

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                foreach (var word in wordList)
                {
                    if (DistDamerau(word, expectedSubstring) <= maxDist)
                    {
                        listBox.Items.Add(word);
                        isFinded = true;
                    }
                }

                stopWatch.Stop();
                if (!isFinded)
                {
                    listBox.Items.Add("No matches");
                }

                timeFindLabel.Text = "Time of searching: " + stopWatch.ElapsedMilliseconds + " ms";
            };
            
            var layout = new TableLayout
            {
                Padding = new Padding(10),
                Spacing = new Size(5, 5),
                Rows =
                {
                    new TableRow(openFileButton, timeLabel),
                    new TableRow(textBox, findButton),
                    new TableRow(MaxDistLabel, MaxDistTextBox),
                    new TableRow(listBox, timeFindLabel)
                }
            };
            
            Content = layout;
        }

        private static int Dist(string s1, string s2)
        {
            if (s1 == s2)
            {
                return 0;
            }

            var M = s1.Length + 1;
            var N = s2.Length + 1;
            
            var dist = new int[M, N];

            for (var i = 0; i < M; i++)
            {
                dist[i, 0] = i;
            }
            
            for (var j = 0; j < N; j++)
            {
                dist[0, j] = j;
            }

            for (var i = 1; i < M; i++)
            {
                for (var j = 1; j < N; j++)
                {
                    var diff = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    dist[i, j] = Math.Min(
                        Math.Min(
                            dist[i - 1, j] + 1, 
                            dist[i, j - 1] + 1
                        ),
                        dist[i - 1, j - 1] + diff
                    );
                }
            }

            return dist[M - 1, N - 1];
        }

        private static int DistDamerau(string s1, string s2)
        {
            if (s1 == s2)
            {
                return 0;
            }
            
            var M = s1.Length + 1;
            var N = s2.Length + 1;
            
            var dist = new int[M, N];
            
            for (var i = 0; i < M; i++)
            {
                dist[i, 0] = i;
            }
            
            for (var j = 0; j < N; j++)
            {
                dist[0, j] = j;
            }

            for (var i = 1; i < M; i++)
            {
                for (var j = 1; j < N; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dist[i, j] = dist[i - 1, j - 1];
                    }
                        
                    var diff = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    dist[i, j] = Math.Min(
                        Math.Min(
                            dist[i - 1, j] + 1, 
                            dist[i, j - 1] + 1
                        ),
                        dist[i - 1, j - 1] + diff
                    );
                    
                    if (i > 1 && j > 1 && s1[i - 2] == s2[j - 1] && s1[i - 1] == s2[j - 2])
                    {
                        dist[i, j] = Math.Min(dist[i, j], dist[i - 2, j - 2] + 1);
                    }
                }
            }

            return dist[M - 1, N - 1];
        }
    }
}