using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;
using PPPKDZ2.Models;
using System.Data;

namespace PPPKDZ2.DAO
{
    class DbHandler
    {
        private static string       cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase  db = new SqlDatabase(cs);

        public static List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();

            using (IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, nameof(GetAllStudents)))
            {
                while (dr.Read())
                {
                    studentList.Add(new Student
                    {
                        IDStudent   = (int)dr[nameof(Student.IDStudent)],
                        Ime         = dr[nameof(Student.Ime)].ToString(),
                        Prezime     = dr[nameof(Student.Prezime)].ToString(),
                        JMBAG       = dr[nameof(Student.JMBAG)].ToString(),
                        Email       = dr[nameof(Student.Email)].ToString()
                    });
                }
            }
            return studentList;
        }

        public static Student SelectStudent(int idStudent)
        {
            DataSet ds = db.ExecuteDataSet(nameof(SelectStudent), idStudent);
            DataRow dr = ds?.Tables[0]?.Rows[0];

            if (dr != null)
            {
                return new Student
                {
                    IDStudent   = (int)dr[nameof(Student.IDStudent)], 
                    Ime         = dr[nameof(Student.Ime)].ToString(),
                    Prezime     = dr[nameof(Student.Prezime)].ToString(),
                    JMBAG       = dr[nameof(Student.JMBAG)].ToString(),
                    Email       = dr[nameof(Student.Email)].ToString()
                };
            }
            return null;
        }

        public static int InsertStudent(Student dummy)
        {
            return db.ExecuteNonQuery(nameof(InsertStudent), dummy.Ime, dummy.Prezime, dummy.JMBAG, dummy.Email);
        }

        public static int UpdateStudent(int idStudent, Student dummy)
        {
            return db.ExecuteNonQuery(nameof(UpdateStudent), idStudent, dummy.Ime, dummy.Prezime, dummy.JMBAG, dummy.Email);
        }

        public static int DeleteStudent(int idStudent)
        {
            return db.ExecuteNonQuery(nameof(DeleteStudent), idStudent);
        }
    }
}
