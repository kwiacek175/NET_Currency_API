using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Runtime.ConstrainedExecution;

namespace WindowsFormsApp1
{
    public partial class CurrencyAPI : Form
    {
        private Bank context;

        public CurrencyAPI()
        {
            InitializeComponent();
            context = new Bank();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string json = await downloadData();
            Currency cur = JsonConvert.DeserializeObject<Currency>(json);
            if (cur.table == "C")
               label4.Text = cur.currency + "\nKurs kupna: " + cur.rates[0].bid.ToString() + " PLN  " + "\nKurs sprzedaży: " + cur.rates[0].ask.ToString() + " PLN";
            else
                label4.Text = cur.currency + "\nKurs średni: " + cur.rates[0].mid.ToString() + " PLN";
            listBox1.Items.Add(cur);


            //var counter = 0;
            //foreach (var item in cur.rates)
            //{
            //    context.CurrencyBoard.Add(new Currency() { table = cur.table, currency = cur.currency, code = cur.code, rates = cur.rates });
            //    context.SaveChanges();
            //    counter++;
            //    var rates = context.CurrencyBoard.ToList();
            //    foreach (var rate in rates)
            //        listBox1.Items.Add(rate);
            //}

            //var curen = (from s in context.CurrencyBoard select s).ToList<Currency>();
            //foreach (var st in curen)
            //{
            //    Console.WriteLine("ID: {0}, Currency: {1}, Rate: {2}", st.table, st.currency, st.code);
            //    var remove = context.CurrencyBoard.First(x => x.ID == st.ID);
            //    context.CurrencyBoard.Remove(remove);
            //    context.SaveChanges();
            //}


        }

        private async Task<string> downloadData()
        {
            string code = textBox1.Text;
            string table = textBox2.Text;
            HttpClient client = new HttpClient();
            string call = "http://api.nbp.pl/api/exchangerates/rates/" + table + "/" + code + "/?format=json";
            string json = await client.GetStringAsync(call);
            return json;
        }
    }
}
