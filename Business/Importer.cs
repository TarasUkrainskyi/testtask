using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestTask.Helpers;
using TestTask.Services;

namespace TestTask.Business
{
    public class Importer
    {
        private PatternsService _patternsService;
        private List<StringBuilder> _contents;

        public Importer()
        {
            _patternsService = new PatternsService();
            _contents = new List<StringBuilder>();
        }

        public bool IsImported { get { return _contents.Any(); } }

        public void ImportProcess(string file)
        {
            try
            {
                string[] lines = ReadFile(file);

                if (lines == null)
                    return;

                _contents = SplitFileContentsIntoCharacterImages(lines);

                _patternsService.UpdatePatterns(_contents);

                MessageBox.Show("Import data from a file has been successfully completed", "Info");
            }
            catch
            {
                MessageBox.Show("Import data from a file was completed with an error", "Error");
            }            
        }

        public string[] ReadFile(string file)
        {
            try
            {
                string text = File.ReadAllText(file);
                int length = text.Length;

                string[] lines = text.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries
                );

                if (!ValidateFileContents(lines))
                    return null;

                return lines;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public void SaveFile()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "result1.txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(saveFileDialog.FileName, Converter.ConvertToAccountNumbers(_contents));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        bool ValidateFileContents(string[] lines)
        {
            if (lines.Length % 3 != 0)
            {
                MessageBox.Show("The contents of the file are not valid", "Error");

                return false;
            }

            foreach (var line in lines)
            {
                if (line.Length != 27)
                {
                    MessageBox.Show("The contents of the file are not valid", "Error");

                    return false;
                }
            }

            return true;
        }

        List<StringBuilder> SplitFileContentsIntoCharacterImages(string[] rows)
        {
            List<StringBuilder> characterImages = new List<StringBuilder>();
            int j = 0;

            foreach (var row in rows)
            {
                var columns = row.Split(3).Select(s => new StringBuilder(s)).ToList();

                if (!characterImages.Any() || j % 3 == 0)
                {
                    characterImages.AddRange(columns);
                    j++;
                    continue;
                }

                for (int i = 0; i < columns.Count; i++)
                {
                    characterImages[i + ((int)(j / 3)) * 9].Append(Environment.NewLine + columns[i]);
                }

                j++;
            }

            return characterImages;
        }
        
        public void ShowConvertedValues()
        {
            foreach (var value in Converter.ConvertToAccountNumbers(_contents))
            {
                Console.WriteLine("\n" + value);
            }
        }
    }
}
