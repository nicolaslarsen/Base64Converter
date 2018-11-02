using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Base64Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string outputFilename;
        // Processes aren't actually used right now
        private Dictionary<string, Process> CleanUpPdfs;

        // Variable to determine if the output file should be cleaned up when program exits
        private bool CleanUp;

        public MainWindow()
        {
            InitializeComponent();
            ResetFiles();
            CleanUpPdfs = new Dictionary<string, Process>();
        }

        private void ResetFiles()
        {
            outputFilename = Converter.CreateFilename();
            CleanUp = true;
            OutputResetButton.Visibility = Visibility.Hidden;
        }

        private void OutputSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileChooser = new SaveFileDialog
            {
                DefaultExt      = "pdf",
                AddExtension    = true
            };

            if (fileChooser.ShowDialog() == true)
            {
                outputFilename = fileChooser.FileName;
                CleanUp = false;
                OutputResetButton.Visibility = Visibility.Visible;
            }
        }

        private void OutputResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetFiles();
        }

        private void FileSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();

            if (fileChooser.ShowDialog() == true)
            {
                B64box.Text = File.ReadAllText(fileChooser.FileName);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBoxResult.Yes;

            if (File.Exists(outputFilename)) {
                msgResult = MessageBox.Show(
                    "Output file already exists, do you wish to overwrite?",
                    "File exists",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
            }

            if (msgResult == MessageBoxResult.Yes && !string.IsNullOrWhiteSpace(B64box.Text)){
                try
                {
                    File.WriteAllBytes(outputFilename, Converter.Base64Decode(B64box.Text));
                    Process proc = Process.Start(outputFilename);
                    if (CleanUp)
                    {
                        CleanUpPdfs.Add(outputFilename, proc);
                    }

                    ResetFiles();
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "Invalid base64 string",
                        "Invalid text",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );
                }
            }
        }

        private void Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            foreach (KeyValuePair<string, Process> entry in CleanUpPdfs)
            {
                string filename = entry.Key;
                Process proc = entry.Value;

                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException)
                    {
                        MessageBoxResult msgResult = MessageBox.Show(
                                    "It looks like you still have a pdf open.\n" +
                                    "The program can not exit until you close it:\n\n" +
                                    filename + "\n\n" +
                                    "if you want to keep this pdf, you should " +
                                    "save the file in another location\n\n",
                                    "Could not clean up",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
    }
}
