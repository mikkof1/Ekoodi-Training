using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactsApi.Models;
using System.Xml.Serialization;
using System.IO;

namespace ContactsApi.Services
{
    public class ContatsHandler
    {
        static List<Contact> _contactsList = new List<Contact>();
        static int _id = 10;
        readonly string _filePath = HttpContext.Current.Server.MapPath("~/App_Data") + "\\data.xml";

        bool testList = false;

        public ContatsHandler()
        {
            ReadListXml();

            bool testIsRunning = testList && _id == 10;
            if (testIsRunning) _contactsList = TestContactsList();
        }

        public List<Contact> GetList()
        {
            return _contactsList;
        }

        public int AddNewContact(Contact newContact)
        {
            _id++;
            newContact.id = _id;
            _contactsList.Add(newContact);
            SaveDataXml();
            return _id;
        }

        public bool EditContact(Contact contact)
        {
            if (contact.id < 1)
            {
                return false;
            }

            int index = _contactsList.FindIndex(c => c.id == contact.id);
            _contactsList[index] = contact;
            SaveDataXml();
            return true;
        }

        public bool DeleteContact(Contact contact)
        {
            if (contact.id < 1)
            {
                return false;
            }

            int index = _contactsList.FindIndex(c => c.id == contact.id);
            _contactsList.RemoveAt(index);
            SaveDataXml();
            return true;
        }

        private void ReadListXml()
        {
            StreamReader reader = new StreamReader(_filePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            _contactsList = (List<Contact>)serializer.Deserialize(reader);
            reader.Close();
        }

        private void SaveDataXml()
        {
            FileStream writer = new FileStream(_filePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            serializer.Serialize(writer, _contactsList);
            writer.Flush();
            writer.Close();
        }

        private List<Contact> TestContactsList()
        {
            List<Contact> contactsList = new List<Contact>();

            Contact con1 = new Contact();
            con1.id = 1;
            con1.firstName = "Aku";
            con1.lastName = "Ankka";
            con1.phone = "456-789789";
            con1.adress = "Paratiisitie 13";
            con1.city = "Ankkalinna";
            contactsList.Add(con1);

            Contact con2 = new Contact();
            con2.id = 2;
            con2.firstName = "Teppo";
            con2.lastName = "Tulppu";
            con2.phone = "456-123123";
            con2.adress = "Paratiisitie 14";
            con2.city = "Ankkalinna";
            contactsList.Add(con2);

            Contact con3 = new Contact();
            con3.id = 3;
            con3.firstName = "Bruce";
            con3.lastName = "Wayne";
            con3.phone = "555-666 123";
            con3.adress = "Wayne Manor";
            con3.city = "Gotham City";
            contactsList.Add(con3);

            return contactsList;
        }
    }
}