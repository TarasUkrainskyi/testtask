using System;
using System.Windows.Forms;
using TestTask.Business;
using TestTask.Helpers;
using TestTask.Services;

namespace TestTask
{
    public class ManagerTest1
    {
        private Importer _importer;
        private PatternsService _patternsService;

        public ManagerTest1()
        {
            _importer = new Importer();
            _patternsService = new PatternsService();
        }

        public void OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.SetValidateSettings("Text|*.txt", 10000);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _importer.ImportProcess(ofd.FileName);
            }
        }

        public void ShowPatterns()
        {
            _patternsService.ShowPatterns();
            Console.ReadLine();
        }

        public void EditPatterns()
        {
            _patternsService.EditPatterns();
            Console.ReadLine();
        }

        public void ShowConvertedValues()
        {
            _importer.ShowConvertedValues();
            Console.ReadLine();
        }

        public void SaveConvertedValues()
        {
            _importer.SaveFile();
        }

        public bool IsImported()
        {
            return _importer.IsImported;
        }
    }
}
