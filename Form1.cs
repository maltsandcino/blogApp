using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;



namespace BlogForm
{
    public partial class Form1 : Form
    {
        // Declaring environment variable paths
        private string imagePath;
        private string blogPath;
        private string repoPath;
        public Form1()
        {
            InitializeComponent();
            // Setting pictureBox settings
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Setting Environment Variables
            foreach (var line in File.ReadAllLines(".env"))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                var parts = line.Split(new[] { '=' }, 2);
                if (parts.Length == 2)
                {
                    Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
                }
            }


            this.imagePath = Environment.GetEnvironmentVariable("IMAGE_PATH");
            this.blogPath = Environment.GetEnvironmentVariable("BLOG_PATH");
            this.repoPath = Environment.GetEnvironmentVariable("REPO_PATH");
        }

        public class BlogContentItem
        {
            public string Type { get; set; }
            public string Text { get; set; }
            public string Src { get; set; }
            public string Alt { get; set; }
            public string Caption { get; set; }
            public int? Level { get; set; }
        }

        public class BlogEntry
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Date { get; set; }
            public List<Dictionary<string, object>> Content { get; set; }
            public string Preview { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Do you want to save?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

            if (result == DialogResult.Yes)
            {
                // Save Image if one exists and we have a title.
                if (pictureBox1.Image != null && title.Text != "")
                {
                    string fileName = title.Text + ".jpg";
                    string imagePath = Path.Combine(this.imagePath, fileName);
                    Console.WriteLine($"{imagePath}");
                    pictureBox1.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                // Save Blog Post.
                // We want to save: Description, Title, Date, Image Name
                // Image name will be based on the title
                string title_val = title.Text;
                string description_val = description.Text;
                string image_cap = imageText.Text;
                string date_val = DateTime.Now.ToString("d MMMM yyyy");
                string image_name = title_val + ".jpg";
                string blogContent = mainText.Text;

                // Process the blog content by spliting the entry's data up for JSON serialization

                var splitContent = blogContent.Split(new[] { "$section" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(splitContent);
                var jsonEntries = new List<Dictionary<string, object>>();

                // Handle convert these JSON strings into actual JSON we want to use in the post.
                foreach (var section in splitContent)
                {
                    var entry = new Dictionary<string, object>();

                    if (section.Contains("$paragraph"))
                    {
                        entry["type"] = "paragraph";
                        entry["text"] = ExtractValue(section, "$text");
                    }
                    else if (section.Contains("$image"))
                    {
                        entry["type"] = "image";
                        entry["src"] = $"/{title_val}.jpg";
                        entry["alt"] = ExtractValue(section, "$alt");
                        entry["caption"] = image_cap;
                    }
                    else if (section.Contains("$heading"))
                    {
                        entry["type"] = "heading";
                        entry["level"] = 2;
                        entry["text"] = ExtractValue(section, "$text");
                    }
                    else if (section.Contains("$quote"))
                    {
                        entry["type"] = "quote";
                        entry["text"] = ExtractValue(section, "$text");
                    }

                    jsonEntries.Add(entry);
                }

                // Convert
                string json = JsonConvert.SerializeObject(jsonEntries, Formatting.Indented);

                // Helper function to extract values
                string ExtractValue(string section, string marker)
                {
                    int index = section.IndexOf(marker);
                    if (index == -1) return "";

                    // Move past the marker itself
                    index += marker.Length;

                    // Trim and return the rest of the string
                    return section.Substring(index).Trim();
                }


                // This is the current existing data in the blog file:
                string currentBlog = File.ReadAllText(this.blogPath);
                int start = currentBlog.IndexOf("[");
                int end = currentBlog.LastIndexOf("]");

                if (start == -1 || end == -1 || end <= start)
                    throw new InvalidOperationException("Could not locate JSON array brackets.");

                string jsonArray = currentBlog.Substring(start, end - start + 1).Trim();
                var entries = JsonConvert.DeserializeObject<List<BlogEntry>>(jsonArray);
                // This is 1 indexed
                int id_val = entries.Count + 1;

                // Place all the new entry data together in one chunk
                var newJson = new BlogEntry
                {
                    Id = id_val,
                    Title = title_val,
                    Date = date_val,
                    Content = jsonEntries,
                    Preview = description_val
                };
                // Add the new entry into the existing entries and serialize
                entries.Add(newJson);
                string updatedJson = JsonConvert.SerializeObject(entries, Formatting.Indented);

                // Write to source file: 
                string finalOutput = $"const entries = {updatedJson};\n\nexport default entries;";
                File.WriteAllText(this.blogPath, finalOutput);

                // Empty fields
                description.Text = "";
                imageText.Text = "";
                mainText.Text = "";
                title.Text = "";
                pictureBox1.Image = null;

                // Display Message

                MessageBox.Show(
                 $"Data submitted and saved for {title_val}",
                 "Submission Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

                // Push changes

                RunGitCommand($"git add *.jpg *.js");
                RunGitCommand("git commit -m \"Add blog assets\"");
                RunGitCommand("git push");


            }
            else
            {
                MessageBox.Show(
                 $"Could not save data for {title.Text}",
                 "Submission Not Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            title.Text = "";
            mainText.Text = "";
            description.Text = "";
            captionLabel.Text = "";
            pictureBox1.Image = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void markup_Click(object sender, EventArgs e)
        {
            Form2 markupForm = new Form2();
            markupForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the image in a PictureBox named pictureBox1
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

   
        void RunGitCommand(string command)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {command}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WorkingDirectory = this.repoPath
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine("Output:\n" + output);
                if (!string.IsNullOrWhiteSpace(error))
                    Console.WriteLine("Error:\n" + error);
            }
}
}
