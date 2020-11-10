using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp1
{
    class AddressModel
    {
        DataTable dataTable = new DataTable();

        public void CreateAddressBook()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(int));
            dataTable.Columns.Add("Email", typeof(string));
        }
        public void ContactDetails()
        {
            dataTable.Rows.Add("Toshani", "Yadav", "Lotus", "Noida", "UP", "201310", "12345687","toshi@hmail.com");
            dataTable.Rows.Add("Kaminee", "Uikey", "abcd", "Seoni", "MP", "455668", "154256", "ksmiskj@gmail.com");
            dataTable.Rows.Add("Rakhi", "saraf", "qwert", "Sitamarhi", "Bihar", "26273898", "2782863", "ksjjklaL@gmail.com");
            dataTable.Rows.Add("Sameer", "Chaudhary", "ahdff", "Bhopal", "MP", "6254443332", "3897487", "sameerfaltu@gmail.com");
        }
        public void DisplayAddressBook()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Edits the existing contact in datatable
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email)
        {
            var recordedData = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName).FirstOrDefault();
            if (recordedData != null)
            {
                recordedData.SetField("LastName", lastName);
                recordedData.SetField("Address", address);
                recordedData.SetField("City", city);
                recordedData.SetField("State", state);
                recordedData.SetField("ZipCode", zipcode);
                recordedData.SetField("EmailID", email);
                recordedData.SetField("State", state);
                Console.WriteLine("Contact edited successfully");
            }
            else
            {
                Console.WriteLine("No Contact Found");
            }
        }
        public void DeleteContact(string name)
        {
            var deleteRow = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
        }
    }
}