using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Author
{
    public partial class Form1 : Form
    {
        public Dictionary<string, string> kostenko = new Dictionary<string, string>() { { "страшні","слова" }, { "зненацька", "причаїлись" }, { "все", "повторялось" }, { "завжди", "неповторність" }, { "безсмертний", "дотик"}};
        public Dictionary<string, string> shevchenko = new Dictionary<string, string>() { { "поховайте", "мене" },{ "як", "умру" },{"на" ,"могилі" }, { "вкраїні", "милій"}, { "степу", "широкого"}, { "лани","широкополі" },{ "волю", "окропіте" } };
        public Dictionary<string, string> franko = new Dictionary<string, string> { { "дика", "площина" }, { "гранітною", "скалою"},{ "чоло", "життя"},{ "гадь", "обвили"}, { "додолу", "ся" },{ "кам’яне", "чоло" },{ "гук", "кривавий" } };
        public Dictionary<string, string> ukrainka = new Dictionary<string, string> { { "сумнім", "перелозі" }, { "гетьте", "думи" }, { "молодії", "літа"} ,{ "лиха", "співати" }, { "барвисті", "квітки" },{"ясну", "владарку" },{ "зірку", "провідну" } };
        public double kost = 0;
        public double shev = 0;
        public double fran = 0;
        public double ukra = 0;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "This is writed:";
            kost = 0;
            shev = 0;
            fran = 0;
            ukra = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            string[] mass = fileText.Split(' ','.',',','!','?','-',':');
            for (int i = 0; i < mass.Length; i++)
            {
                if (kostenko.ContainsKey(mass[i]) && kostenko.ContainsValue(mass[i + 1]) && kostenko[mass[i]]==mass[i+1])
                    kost++;
                if (shevchenko.ContainsKey(mass[i]) && shevchenko.ContainsValue(mass[i + 1]) && shevchenko[mass[i]] == mass[i + 1])
                    shev++;
                if (franko.ContainsKey(mass[i]) && franko.ContainsValue(mass[i + 1]) && franko[mass[i]] == mass[i + 1])
                    fran++;
                if (ukrainka.ContainsKey(mass[i]) && ukrainka.ContainsValue(mass[i + 1]) && ukrainka[mass[i]] == mass[i + 1])
                    ukra++;
            }
            double author = Math.Max(Math.Max(kost, shev), Math.Max(fran, ukra));
            if(author == kost)
            {
                label1.Text+=" Lina Kostenko";
            }
            if (author == shev)
            {
                label1.Text += " Taras Shevchenko";
            }
            if (author == fran)
            {
                label1.Text += " Ivan Franko";
            }
            if (author == ukra)
            {
                label1.Text += " Lesya Ukrainka";
            }
            double chance = Math.Round(author/(kost+shev+fran+ukra)*100);
            label1.Text +="\n With chance: "+chance.ToString()+"%";
        }
    }
}
