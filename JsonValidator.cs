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
        }
        private JSchema? loadedSchema;

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Open JSON File";
                ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        inputJson.Text = File.ReadAllText(ofd.FileName);

                        output.Clear();
                        jsonTreeView.Nodes.Clear();
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Failed to open file: " + ex.Message);
                    }
                }
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
            if (!string.IsNullOrWhiteSpace(inputJson.Text))
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
                JToken jsonToken = JsonHandler.Validate(inputJson);
                ShowMessage("JSON syntax is valid.");

                // Build JSON hierarchy
                TreeNode rootNode = jsonTreeView.Nodes.Add("JSON");

                PopulateTreeView(jsonToken, rootNode);

                rootNode.ExpandAll();

                if (loadedSchema != null)
                {
                    IList<string> validationErrors;

                    bool isValid = JsonHandler.ValidateSchema(jsonToken, loadedSchema, out validationErrors);

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
        private void LoadSchemaButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select JSON Schema";
                dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string schemaJson = File.ReadAllText(dialog.FileName);

                        loadedSchema = JsonHandler.ParseSchema(schemaJson);

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
        private void SaveFileButton_Click(object sender, EventArgs e)
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
        private void FormatJsonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputJson.Text))
                {
                    ShowMessage("Please enter or load JSON data first.");
                    return;
                }

                inputJson.Text = JsonHandler.Format(inputJson.Text);
                ShowMessage("JSON formatted successfully.");
            }
            catch (JsonReaderException ex)
            {
                ShowMessage("JSON syntax is NOT valid.");
                ShowMessage(ex.Message);
            }
        }
        private void MinifyJsonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputJson.Text))
                {
                    ShowMessage("Please enter or load JSON data first.");
                    return;
                }

                inputJson.Text = JsonHandler.Minify(inputJson.Text);
                ShowMessage("JSON minified successfully.");
            }
            catch (JsonReaderException ex)
            {
                ShowMessage("JSON syntax is NOT valid.");
                ShowMessage(ex.Message);
            }
        }
    }
}
