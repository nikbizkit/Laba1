using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Eto.Drawing;
using Eto.Forms;

namespace Lab_4
{
    public class MainForm : Form
    {
        public MainForm()
        {
            ClientSize = new Size(400, 400);
            Title = "Lab 4";

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

                bool isFinded = false;

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                foreach (var word in wordList)
                {
                    if (word.Contains(expectedSubstring))
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
                    new TableRow(listBox, timeFindLabel)
                }
            };
            
            Content = layout;
        }
    }
}