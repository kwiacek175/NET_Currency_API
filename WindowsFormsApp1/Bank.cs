using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Bank : DbContext
    {
        public DbSet<Currency> CurrencyBoard { get; set; }
    } 
}
