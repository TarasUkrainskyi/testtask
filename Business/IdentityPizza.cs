using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TestTask.Helpers;
using TestTask.Models;

namespace TestTask.Business
{
    public class IdentityPizza
    {
        Dictionary<List<string>, int> _pizzas;

        public IdentityPizza()
        {
            _pizzas = new Dictionary<List<string>, int>();
        }

        public void ImportProcess(string file)
        {
            try
            {
                string json = ReadFile(file);
                List<Pizza> pizzas = new JavaScriptSerializer().Deserialize<List<Pizza>>(json);
                GetNumberOfOrders(pizzas);

                MessageBox.Show("Import data from a file has been successfully completed", "Info");
            }
            catch
            {
                MessageBox.Show("Import data from a file was completed with an error", "Error");
            }
        }

        public string ReadFile(string file)
        {
            try
            {
                return File.ReadAllText(file);
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
                saveFileDialog.FileName = "result2.txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.Default))
                    {
                        int i = 0;
                        var orderUnique = _pizzas.OrderByDescending(item => item.Value).Take(10);

                        foreach (var v in orderUnique)
                        {
                            i++;
                            sw.WriteLine("\nPizza #" + i + ". Orders " + v.Value + "pcs.");
                            sw.WriteLine("Toppings:");
                            v.Key.ForEach(topping =>
                            {
                                sw.WriteLine(topping);
                            });
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowValues()
        {
            int i = 0;
            var orderUnique = _pizzas.OrderByDescending(item => item.Value).Take(10);

            foreach (var v in orderUnique)
            {
                i++;
                Console.WriteLine("\nPizza #" + i + ". Orders " + v.Value + "pcs.");
                Console.WriteLine("Toppings:");
                v.Key.ForEach(topping => 
                {
                    Console.WriteLine(topping);
                });
            }
        }

        public void GetNumberOfOrders(List<Pizza> pizzas)
        {
            var toppings = pizzas.Select(p => p.toppings);

            foreach (var topping in toppings)
            {
                if (!_pizzas.Keys.Any(item => IEnumerableHelper.ScrambledEquals(item, topping)))
                {
                    var count = toppings.Count(item => IEnumerableHelper.ScrambledEquals(item, topping));
                    _pizzas.Add(topping, count);
                }
            }
        }

        public bool IsImported { get { return _pizzas.Any(); } }
    }
}
