using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{

    internal class Currency
    {
        public int ID { set; get; }
        public string table { get; set; }       // typ tabeli 
        public string currency { get; set; }    // nazwa waluty 
        public string code { get; set; }        // kod walutowy
        public List<Rate> rates { get; set; }   // lista kursów poszczególnych walut w tabeli 

        public override string ToString()
        {
            ID++;
           if (table == "C")
               return $"({ID}) {currency} -- {code} -- Kurs sprzedaży: {rates[0].ask} PLN -- Kurs kupna: {rates[0].bid} PLN -- data publikacji: {rates[0].effectiveDate}";
           else
               return $"({ID}) {currency}  -- {code} -- Kurs średni: {rates[0].mid} PLN -- data publikacji: {rates[0].effectiveDate}";
        }
    }
    public class Rate
    {
        public int rateID { get; set; }
        public float mid { get; set; } // kurs średni {tabela A i tabela B}
        public float bid { get; set; } // kurs kupna {tabela C}
        public float ask { get; set; } // kurs sprzedaży {tabela C}
        public string effectiveDate { get; set; }  // data publikacji 
    }
}
