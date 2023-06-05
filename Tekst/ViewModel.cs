﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Tekst
{
    public class TxtViewModel
    {
        public ObservableCollection<Info> txt { get; set; }
        private string jsonFile = "text.txt";
        public ICommand AddTxtCommand { get; set; }
        public TxtViewModel()
        {
            txt = new ObservableCollection<Info>();
            LoadText();
            AddTxtCommand = new Re
                ((p) =>
                {
                    var TxtAdd = p as ct;
                    string NameOfTxt = TxtAdd.tb1.Text;
                    string UserTxt = TxtAdd.tb2.Text;
                    if (!string.IsNullOrEmpty(NameOfTxt) && !string.IsNullOrEmpty(UserTxt))
                    {
                        AddTxt(NameOfTxt, UserTxt);
                        TxtAdd.tb1.Text = NameOfTxt;
                        TxtAdd.tb2.Text = UserTxt;
                    }
                    MessageBox.Show("Текст добавлен в заметки!");
                });
        }
        private void SaveTxt()
        {
            var json = JsonConvert.SerializeObject(txt);
            File.AppendAllText(jsonFile, json);
        }
        public string LoadText()
        {
            if (File.Exists(jsonFile))
            {
                string a = File.ReadAllText(jsonFile);
                var charsToRemove = new string[] { "@", ",", ".", ";", "'", "NameTxt", "NoteTxt", "{", "}", "(", ")", ":", "]", "[", "\"", "\"" };
                foreach (var c in charsToRemove)
                {
                    a = a.Replace(c, string.Empty);
                }
                return a;
            }
            else { return null; }
        }
        public void AddTxt(string txtTitle, string txtUser)
        {
            txt.Add(new Info(txtTitle, txtUser));
            SaveTxt();
        }
    }
}
