using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JsonValidator
{
    public partial class JsonValidator : Form
    {
        public JsonValidator()
        {
            InitializeComponent();
            toolTip1.SetToolTip(openFileButton, "Open a JSON file (Ctrl + O)");
            toolTip1.SetToolTip(saveFileButton, "Save JSON to a file (Ctrl + S)");
            toolTip1.SetToolTip(validateButton, "Validate JSON (Ctrl + Shift + V)");
            toolTip1.SetToolTip(resetButton, "Reset application (Ctrl + Shift + R)");
            toolTip1.SetToolTip(loadSchemaButton, "Load JSON schema (Ctrl + L)");
            toolTip1.SetToolTip(formatJsonButton, "Format JSON (Ctrl + Shift + F)");
            toolTip1.SetToolTip(minifyJsonButton, "Minify JSON (Ctrl + Shift + M)");
        }
        private JSchema? loadedSchema;
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenJsonFile();
        }
        private void OpenJsonFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*|JSON files (*.json)|*.json"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(ofd.FileName);
                var myJson = sr.ReadToEnd();
                inputJson.Text = myJson;

                output.Clear();
                jsonTreeView.Nodes.Clear();
            }
        }
        private void ShowMessage(string outputStr)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(outputStr);
                output.Text = output.Text + outputStr + Environment.NewLine;
                output.SelectionStart = output.TextLength;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            output.Text = string.Empty;
            inputJson.Text = string.Empty;
            jsonTreeView.Nodes.Clear();
            loadedSchema = null;
        }
        private void ValidateButton_Click(object sender, EventArgs e)
        {
            if (inputJson.Text != "")
            {
                ValidateJson(inputJson.Text);
            }
            else
            {
                ShowMessage("There is no .json file to validate. Please provide the file.");
            }
        }
        private void ValidateJson(string inputJson)
        {
            output.Clear();
            jsonTreeView.Nodes.Clear();

            try
            {
                // Check JSON syntax
                JToken jsonToken = JToken.Parse(inputJson);

                ShowMessage("JSON syntax is valid.");

                // Build JSON hierarchy
                TreeNode rootNode = jsonTreeView.Nodes.Add("JSON");

                PopulateTreeView(jsonToken, rootNode);

                rootNode.ExpandAll();

                if (loadedSchema != null)
                {
                    IList<string> validationErrors;

                    bool isValid = jsonToken.IsValid(loadedSchema, out validationErrors);

                    if (isValid)
                    {
                        ShowMessage("JSON is valid against the loaded schema.");
                    }
                    else
                    {
                        ShowMessage("JSON is NOT valid against the loaded schema.");

                        foreach (string error in validationErrors)
                        {
                            ShowMessage(error);
                        }
                    }
                }
            }
            catch (JsonReaderException e)
            {
                jsonTreeView.Nodes.Clear();

                ShowMessage("JSON syntax is NOT valid.");
                ShowMessage("Found a problem: " + e.Message);
            }
            catch (Exception e)
            {
                ShowMessage("Found a problem: " + e.Message);
            }
        }
        private void PopulateTreeView(JToken token, TreeNode parentNode)
        {
            if (token is JObject jsonObject)
            {
                parentNode.Text += " {}";
                parentNode.ForeColor = Color.ForestGreen;
                foreach (JProperty property in jsonObject.Properties())
                {
                    TreeNode propertyNode = parentNode.Nodes.Add(property.Name);
                    PopulateTreeView(property.Value, propertyNode);
                }
            }
            else if (token is JArray jsonArray)
            {
                parentNode.Text += $" [{jsonArray.Count}]";
                parentNode.ForeColor = Color.RoyalBlue;
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    TreeNode arrayNode = parentNode.Nodes.Add($"[{i}]");
                    PopulateTreeView(jsonArray[i], arrayNode);
                }
            }
            else
            {
                parentNode.Text += ": " + token.ToString(Formatting.None);
            }
        }
        private void loadSchemaButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select JSON Schema";
                dialog.Filter = "All files (*.*)|*.*|JSON files (*.json)|*.json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string schemaJson = File.ReadAllText(dialog.FileName);

                        JSchema schema = JSchema.Parse(schemaJson);
                        loadedSchema = schema;

                        ShowMessage("Schema loaded successfully: " +
                                    Path.GetFileName(dialog.FileName));
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Failed to load schema: " + ex.Message);
                    }
                }
            }
        }
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save JSON File";
                dialog.Filter = "JSON files (*.json)|*.json";
                dialog.DefaultExt = "json";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = Path.ChangeExtension(dialog.FileName, ".json");

                        File.WriteAllText(filePath, inputJson.Text);

                        ShowMessage("File saved successfully: " +
                                    Path.GetFileName(filePath));
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Failed to save file: " + ex.Message);
                    }
                }
            }
        }
        private void formatJsonButton_Click(object sender, EventArgs e)
        {
            try
            {
                JToken jsonToken = JToken.Parse(inputJson.Text);

                inputJson.Text = jsonToken.ToString(Formatting.Indented);

                ShowMessage("JSON formatted successfully.");
            }
            catch (JsonReaderException ex)
            {
                ShowMessage("JSON syntax is NOT valid.");
                ShowMessage(ex.Message);
            }
        }

        private void minifyJsonButton_Click(object sender, EventArgs e)
        {
            try
            {
                JToken jsonToken = JToken.Parse(inputJson.Text);

                inputJson.Text = jsonToken.ToString(Formatting.None);

                ShowMessage("JSON minified successfully.");
            }
            catch (JsonReaderException ex)
            {
                ShowMessage("JSON syntax is NOT valid.");
                ShowMessage(ex.Message);
            }
        }
        private void JsonApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                openFileButton.PerformClick();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                saveFileButton.PerformClick();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.V)
            {
                validateButton.PerformClick();
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.R)
            {
                resetButton.PerformClick();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {
                loadSchemaButton.PerformClick();
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.F)
            {
                formatJsonButton.PerformClick();
            }
            else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.M)
            {
                minifyJsonButton.PerformClick();
            }
            else
            {
                return;
            }

            e.SuppressKeyPress = true;
            e.Handled = true;
        }
    }
}

