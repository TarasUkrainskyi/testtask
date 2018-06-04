using System;
using System.Windows.Forms;
using TestTask.Business;
using TestTask.Helpers;

namespace TestTask
{
    public class ManagerTest2
    {
        private IdentityPizza _identityPizza;
        public ManagerTest2()
        {
            _identityPizza = new IdentityPizza();
        }

        public void OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.SetValidateSettings("Text|*.json", 1000000);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _identityPizza.ImportProcess(ofd.FileName);
            }
        }

        public void ShowValues()
        {
            _identityPizza.ShowValues();
            Console.ReadLine();
        }

        public void SaveValues()
        {
            _identityPizza.SaveFile();
        }

        public bool IsImported()
        {
            return _identityPizza.IsImported;
        }
    }
}
