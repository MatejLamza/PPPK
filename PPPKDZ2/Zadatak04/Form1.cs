using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak04
{
    public partial class Form1 : Form
    {

        PPPKDZ2MatejLamzaEntities db = new PPPKDZ2MatejLamzaEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new PPPKDZ2MatejLamzaEntities())
            {
                GetAllStudents(db);
            }
        }

        private  void GetAllStudents(PPPKDZ2MatejLamzaEntities db)
        {
            db.GetAllStudents().ToList().ForEach(s => lbStudenti.Items.Add(s).ToString());
        }

        private void ShowAllStudents()
        {
            lbStudenti.Items.Clear();

            foreach (var item in db.GetAllStudents())
            {
                lbStudenti.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.InsertStudent(
                txtIme.Text,
                txtPrezime.Text,
                txtJMBAG.Text,
                txtEmail.Text
                );

            ShowAllStudents();
            lbStudenti.SelectedIndex = lbStudenti.Items.Count - 1;
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            db.UpdateStudent(
                 int.Parse((lbStudenti.SelectedItem as GetAllStudents_Result).IDStudent.ToString()),
                 txtIme.Text,
                 txtPrezime.Text,
                 txtJMBAG.Text,
                 txtEmail.Text);

            ShowAllStudents();
            lbStudenti.SelectedIndex = lbStudenti.Items.Count - 1;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            db.DeleteStudent(int.Parse((lbStudenti.SelectedItem as GetAllStudents_Result).IDStudent.ToString()));
            ShowAllStudents();
            lbStudenti.SelectedIndex = lbStudenti.Items.Count - 1;
        }
    }
}
