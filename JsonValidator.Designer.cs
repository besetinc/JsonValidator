namespace JsonValidator
{
    partial class JsonValidator
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonValidator));
            groupBox1 = new System.Windows.Forms.GroupBox();
            inputJson = new System.Windows.Forms.TextBox();
            validateButton = new System.Windows.Forms.Button();
            resetButton = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            output = new System.Windows.Forms.TextBox();
            openFileButton = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            jsonTreeView = new System.Windows.Forms.TreeView();
            loadSchemaButton = new System.Windows.Forms.Button();
            saveFileButton = new System.Windows.Forms.Button();
            formatJsonButton = new System.Windows.Forms.Button();
            minifyJsonButton = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox1.Controls.Add(inputJson);
            groupBox1.Location = new System.Drawing.Point(12, 55);
            groupBox1.Margin = new System.Windows.Forms.Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(420, 270);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Json &input";
            // 
            // inputJson
            // 
            inputJson.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            inputJson.Location = new System.Drawing.Point(12, 25);
            inputJson.Margin = new System.Windows.Forms.Padding(2);
            inputJson.Multiline = true;
            inputJson.Name = "inputJson";
            inputJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            inputJson.Size = new System.Drawing.Size(396, 230);
            inputJson.TabIndex = 0;
            inputJson.WordWrap = false;
            // 
            // validateButton
            // 
            validateButton.Image = (System.Drawing.Image)resources.GetObject("validateButton.Image");
            validateButton.Location = new System.Drawing.Point(398, 12);
            validateButton.Margin = new System.Windows.Forms.Padding(2);
            validateButton.Name = "validateButton";
            validateButton.Size = new System.Drawing.Size(115, 30);
            validateButton.TabIndex = 4;
            validateButton.Text = "&Validate";
            validateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            validateButton.UseVisualStyleBackColor = true;
            validateButton.Click += ValidateButton_Click;
            // 
            // resetButton
            // 
            resetButton.Image = (System.Drawing.Image)resources.GetObject("resetButton.Image");
            resetButton.Location = new System.Drawing.Point(756, 12);
            resetButton.Margin = new System.Windows.Forms.Padding(2);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(115, 30);
            resetButton.TabIndex = 7;
            resetButton.Text = "&Reset";
            resetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += ResetButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox2.Controls.Add(output);
            groupBox2.Location = new System.Drawing.Point(12, 335);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2);
            groupBox2.Size = new System.Drawing.Size(420, 250);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Messages / &Logs";
            // 
            // output
            // 
            output.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            output.Location = new System.Drawing.Point(12, 25);
            output.Margin = new System.Windows.Forms.Padding(2);
            output.Multiline = true;
            output.Name = "output";
            output.ReadOnly = true;
            output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            output.Size = new System.Drawing.Size(396, 210);
            output.TabIndex = 0;
            // 
            // openFileButton
            // 
            openFileButton.Image = (System.Drawing.Image)resources.GetObject("openFileButton.Image");
            openFileButton.Location = new System.Drawing.Point(12, 12);
            openFileButton.Margin = new System.Windows.Forms.Padding(2);
            openFileButton.Name = "openFileButton";
            openFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            openFileButton.Size = new System.Drawing.Size(115, 30);
            openFileButton.TabIndex = 1;
            openFileButton.Text = "&Open file...";
            openFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += OpenFileButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(jsonTreeView);
            groupBox3.Location = new System.Drawing.Point(445, 55);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(425, 530);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Json &Hierarchy Tree";
            // 
            // jsonTreeView
            // 
            jsonTreeView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            jsonTreeView.Location = new System.Drawing.Point(12, 25);
            jsonTreeView.Name = "jsonTreeView";
            jsonTreeView.Size = new System.Drawing.Size(401, 490);
            jsonTreeView.TabIndex = 6;
            // 
            // loadSchemaButton
            // 
            loadSchemaButton.Image = (System.Drawing.Image)resources.GetObject("loadSchemaButton.Image");
            loadSchemaButton.Location = new System.Drawing.Point(253, 12);
            loadSchemaButton.Name = "loadSchemaButton";
            loadSchemaButton.Size = new System.Drawing.Size(140, 30);
            loadSchemaButton.TabIndex = 3;
            loadSchemaButton.Text = "&Load schema...";
            loadSchemaButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            loadSchemaButton.UseVisualStyleBackColor = true;
            loadSchemaButton.Click += loadSchemaButton_Click;
            // 
            // saveFileButton
            // 
            saveFileButton.Image = (System.Drawing.Image)resources.GetObject("saveFileButton.Image");
            saveFileButton.Location = new System.Drawing.Point(132, 12);
            saveFileButton.Name = "saveFileButton";
            saveFileButton.Size = new System.Drawing.Size(115, 30);
            saveFileButton.TabIndex = 2;
            saveFileButton.Text = "&Save file...";
            saveFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            saveFileButton.UseVisualStyleBackColor = true;
            saveFileButton.Click += saveFileButton_Click;
            // 
            // formatJsonButton
            // 
            formatJsonButton.Image = (System.Drawing.Image)resources.GetObject("formatJsonButton.Image");
            formatJsonButton.Location = new System.Drawing.Point(515, 12);
            formatJsonButton.Name = "formatJsonButton";
            formatJsonButton.Size = new System.Drawing.Size(115, 30);
            formatJsonButton.TabIndex = 5;
            formatJsonButton.Text = "&Format";
            formatJsonButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            formatJsonButton.UseVisualStyleBackColor = true;
            formatJsonButton.Click += formatJsonButton_Click;
            // 
            // minifyJsonButton
            // 
            minifyJsonButton.Image = (System.Drawing.Image)resources.GetObject("minifyJsonButton.Image");
            minifyJsonButton.Location = new System.Drawing.Point(636, 12);
            minifyJsonButton.Name = "minifyJsonButton";
            minifyJsonButton.Size = new System.Drawing.Size(115, 30);
            minifyJsonButton.TabIndex = 6;
            minifyJsonButton.Text = "&Minify";
            minifyJsonButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            minifyJsonButton.UseVisualStyleBackColor = true;
            minifyJsonButton.Click += minifyJsonButton_Click;
            // 
            // JsonValidator
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(882, 603);
            Controls.Add(minifyJsonButton);
            Controls.Add(formatJsonButton);
            Controls.Add(saveFileButton);
            Controls.Add(loadSchemaButton);
            Controls.Add(groupBox3);
            Controls.Add(openFileButton);
            Controls.Add(groupBox2);
            Controls.Add(resetButton);
            Controls.Add(validateButton);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(2);
            MinimumSize = new System.Drawing.Size(900, 650);
            Name = "JsonValidator";
            Text = "JSON Validator";
            KeyDown += JsonApp_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox inputJson;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView jsonTreeView;
        private System.Windows.Forms.Button loadSchemaButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button formatJsonButton;
        private System.Windows.Forms.Button minifyJsonButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

