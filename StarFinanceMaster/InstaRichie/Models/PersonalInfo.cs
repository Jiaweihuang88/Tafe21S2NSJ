using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace StartFinance.Models
{
    public class PersonalInfo
    {
        [PrimaryKey, AutoIncrement]
        public int User_ID { get; set; }

        [Unique]
        public string Full_Name { get; set; }

        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Contact { get; set; }
    }
}
