using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLinq
{
    class AddressBook
    {
        DataTable dataTable = new DataTable();
        /// <summary>
        /// DataTable created for storing contact information
        /// </summary>
        public void CreateAddressBook()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));
            //Some pre existing contacts added
            dataTable.Rows.Add("Sheldon", "Cooper", "Street 4", "Casper", "Texas", "525252", "9876778434", "cooper@yahoo.com");
            dataTable.Rows.Add("Siddhi", "Seth", "Gopal Vihar", "Jabalpur", "Madhya Pradesh", "856985", "7458658925", "siddhiseth@gmail.com");
            dataTable.Rows.Add("Priyanka", "Chopra", "Street 5", "NewYork", "NewYork", "520147", "5201118267", "priyanka@gmail.com");
            dataTable.Rows.Add("Kareena", "Kapoor", "Bandra", "Mumbai", "Maharashtra", "852412", "7458965896", "kareena@yahoo.com");
            dataTable.Rows.Add("Aditya", "Singh", "NavyNagar", "Vizag", "Andra Pradesh", "842563", "7849876734", "aditya@rediffmail.com");
            dataTable.Rows.Add("John", "Parker", "Broadway", "NewYork", "NewYork", "10028", "4256387459", "parker@gmail.com");
            dataTable.Rows.Add("Bugs", "Bunny", "GrandmaHome", "Tristate Area", "NewYork", "100001", "8987224534", "Bugs@gmail.com");
            dataTable.Rows.Add("Captain", "Hook", "Sea Waters", "Island", "California", "452652", "6767986886", "hook@gmail.com");
            dataTable.Rows.Add("Monica", "Gellar", "Richwood", "Manhattan", "NewYork", "652369", "9874523555", "monicagellar@yahoo.com");
        }
        /// <summary>
        /// Insert Contacts in a the addressBook
        /// </summary>
        /// <param name="contact"></param>
        public void InsertContacts(Contact contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Contact inserted successfully");
        }
        /// <summary>
        /// Display address book data table
        /// </summary>
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
        /// <summary>
        /// Delete contact from table
        /// </summary>
        /// <param name="name"></param>
        public void DeleteContact(string name)
        {
            var deleteRow = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
        }
        /// <summary>
        /// Retrieve contacts of a particular city
        /// </summary>
        /// <param name="city"></param>
        public void RetrieveContactsByCity(string city)
        {
            var cityResults = dataTable.AsEnumerable().Where(x => x.Field<string>("City") == city);
            foreach (DataRow row in cityResults)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves contact of a particular state
        /// </summary>
        /// <param name="state"></param>
        public void RetrieveContactsByState(string state)
        {
            var stateResults = dataTable.AsEnumerable().Where(x => x.Field<string>("State") == state);
            foreach (DataRow row in stateResults)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Displays count of contacts city and state wise
        /// </summary>
        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into grp
                                      select new
                                      {
                                          City = grp.Key.City,
                                          State = grp.Key.State,
                                          Count = grp.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "\t" + row.State + "\t" + row.Count);
            }
        }
        /// <summary>
        /// Retrieves Contacts alphabetically in a city
        /// </summary>
        /// <param name="city"></param>
        public void SortContactsAlphabeticalyForACity(string city)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("city") == city).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (DataRow row in records)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}