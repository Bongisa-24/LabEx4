using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class Logic
    {
        Data data = new Data();

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string email { get; set; }

        public void GenerateEmail()
        {
            email = name + "@student.uj.ac.za";
        }
        public string writeData()
        {
            return data.InsertData(name, surname, gender, email);
        }
        public string UpdateData()
        {
            return data.UpdateData(id, name, surname, gender, email);
        }
        public string DeleteData()
        {
            return data.DeleteData(id);
        }



        public DataTable Read()
        {
            return data.ReadData();

        }


    }


}
