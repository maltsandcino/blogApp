namespace BlogForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageButton = new System.Windows.Forms.Button();
            this.captionLabel = new System.Windows.Forms.Label();
            this.imageText = new System.Windows.Forms.TextBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.mainText = new System.Windows.Forms.RichTextBox();
            this.markup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(574, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(123, 28);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(622, 20);
            this.title.TabIndex = 2;
            this.title.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Blog Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Short Description";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(124, 65);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(622, 51);
            this.description.TabIndex = 5;
            this.description.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(15, 318);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 69);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // imageButton
            // 
            this.imageButton.Location = new System.Drawing.Point(15, 388);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(100, 23);
            this.imageButton.TabIndex = 8;
            this.imageButton.Text = "Select Image";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Location = new System.Drawing.Point(121, 393);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(75, 13);
            this.captionLabel.TabIndex = 10;
            this.captionLabel.Text = "Image Caption";
            // 
            // imageText
            // 
            this.imageText.Location = new System.Drawing.Point(202, 390);
            this.imageText.Name = "imageText";
            this.imageText.Size = new System.Drawing.Size(189, 20);
            this.imageText.TabIndex = 11;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Location = new System.Drawing.Point(12, 136);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(54, 13);
            this.mainLabel.TabIndex = 12;
            this.mainLabel.Text = "Main Text";
            this.mainLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // mainText
            // 
            this.mainText.Location = new System.Drawing.Point(124, 133);
            this.mainText.Name = "mainText";
            this.mainText.Size = new System.Drawing.Size(622, 204);
            this.mainText.TabIndex = 13;
            this.mainText.Text = "";
            // 
            // markup
            // 
            this.markup.Location = new System.Drawing.Point(12, 164);
            this.markup.Name = "markup";
            this.markup.Size = new System.Drawing.Size(63, 20);
            this.markup.TabIndex = 14;
            this.markup.Text = "Markup";
            this.markup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.markup.UseVisualStyleBackColor = true;
            this.markup.Click += new System.EventHandler(this.markup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.markup);
            this.Controls.Add(this.mainText);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.imageText);
            this.Controls.Add(this.captionLabel);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "New Blog Entry";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.TextBox imageText;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.RichTextBox mainText;
        private System.Windows.Forms.Button markup;
    }
}

