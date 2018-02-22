using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using Zadatak03.Model;

namespace Zadatak03.Helper
{
    class XmlHelper
    { 
        private static string cs         = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const  string FILE_PATH  = "Studenti.xml";
        private const  string SQL_SELECT = "SELECT * FROM Student";

        private static XmlWriter CreateWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            return XmlWriter.Create(FILE_PATH);
        }

        private static XmlDocument LoadDocument()
        {
            XmlDocument xmlDOM = new XmlDocument();
            xmlDOM.Load(FILE_PATH);
            return xmlDOM;
        }

        public static void CreateXML()
        {
            XmlWriter xmlWriter = CreateWriter();

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("studenti");

            foreach (DataRow row in GetStudents().Rows)
            {
                xmlWriter.WriteStartElement("student");
                xmlWriter.WriteAttributeString("id", row[nameof(Student.IDStudent)].ToString());

                xmlWriter.WriteStartElement("ime");
                xmlWriter.WriteString(row[nameof(Student.Ime)].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("prezime");
                xmlWriter.WriteString(row[nameof(Student.Prezime)].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("jmbag");
                xmlWriter.WriteString(row[nameof(Student.JMBAG)].ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("e-mail");
                xmlWriter.WriteString(row[nameof(Student.Email)].ToString());
                xmlWriter.WriteEndElement();

                //Zatvarajuci element od elementa student
                xmlWriter.WriteEndElement();
            }
            //Zatvarajuci element od studenti
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        private static DataTable GetStudents()
        {
            SqlDataAdapter da       = new SqlDataAdapter(SQL_SELECT, new SqlConnection(cs));
            DataTable tblStudents   = new DataTable(nameof(Student));

            da.Fill(tblStudents);
            return tblStudents;
        }

        private static void FillXmlWithStudents()
        {
            XmlDocument xmlDOM = LoadDocument();
        }
    }
}
