using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak02
{
    public partial class Form1 : Form
    {

        PPPKDZ2MatejLamza ds;
        PPPKDZ2MatejLamzaTableAdapters.StudentTableAdapter taStudent;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            FillStudentList();
        }

        private void Init()
        {
            ds = new PPPKDZ2MatejLamza();
            taStudent = new PPPKDZ2MatejLamzaTableAdapters.StudentTableAdapter();

            taStudent.Fill(ds.Student);
        }

        private void FillStudentList()
        {
            lbStudenti.Items.Clear();
            ds.Student.Rows.Cast<PPPKDZ2MatejLamza.StudentRow>().ToList().ForEach(s => lbStudenti.Items.Add(s));
            if (lbStudenti.Items.Count > 0)
            {
                lbStudenti.SelectedIndex = 0;
            }
        }

        private void ClearAllTextBoxs()
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtJMBAG.Clear();
            txtEmail.Clear();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            PPPKDZ2MatejLamza.StudentRow row = ds.Student.NewStudentRow();

            row.Ime     = txtIme.Text.Trim();
            row.Prezime = txtPrezime.Text.Trim();
            row.JMBAG   = txtJMBAG.Text.Trim();
            row.Email   = txtEmail.Text.Trim();

            ds.Student.Rows.Add(row);
            taStudent.Update(ds.Student);

            FillStudentList();
            ClearAllTextBoxs();
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            PPPKDZ2MatejLamza.StudentRow row = lbStudenti.SelectedItem as PPPKDZ2MatejLamza.StudentRow;
            if (row == null)
            {
                MessageBox.Show("Odaberite studenta kojeg zelite urediti!!");
                return;
            }

            row.Ime     = txtIme.Text;
            row.Prezime = txtPrezime.Text;
            row.JMBAG   = txtJMBAG.Text;
            row.Email   = txtEmail.Text;

            taStudent.Update(ds.Student);
            FillStudentList();
            ClearAllTextBoxs();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            PPPKDZ2MatejLamza.StudentRow row = lbStudenti.SelectedItem as PPPKDZ2MatejLamza.StudentRow;
            if (row == null)
            {
                MessageBox.Show("Odaberite studenta kojeg zelite obrisati!!");
                return;
            }
            

            row.Delete();
            taStudent.Update(ds.Student);
            FillStudentList();
        }
    }
}
