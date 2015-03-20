using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patientensystem
{
    public partial class Patientenstudie : Form
    {
        private IWriteController arztWriter;
        private IWriteController patientWriter;

        private IReadController arztReader;
        private IReadController patientReader;

        public Patientenstudie()
        {
            InitializeComponent();

            // Arzt (ArztWriter.cs) und Patient (PatientWriter.cs) Writer initialisieren
            arztWriter = new ArztWriter();
            patientWriter = new PatientWriter();

            // Arzt (ArztReader.cs) und Patient (PatinetReader.cs) Reader initialisieren
            arztReader = new ArztReader();
            patientReader = new PatientReader();
        }

        private void cmd_add_p_Click(object sender, EventArgs e)
        {
            // neue Daten in Patienten-Datenbank eintragen (Neuer Patient)
            string text = txt_patient.Text;
            bool result = patientWriter.writePData(new PData(text));

            if (result)
            {
                txt_patient.Text = "";
            }
        }

        private void cmd_show_p_Click(object sender, EventArgs e)
        {
            IList<PData> result = patientReader.readPData();

            // Alle PData der Patienten-Datenbank anzeigen
            string resultText = "";
            foreach (PData pdata in result)
            {
                resultText += pdata.befund + System.Environment.NewLine;
            }

            // Ausgabe Patient
            lbl_ausgabe_p.Text = resultText;
        }

        private void cmd_add_a_Click(object sender, EventArgs e)
        {
            // neue Daten in Arzt-Datenbank eintragen (neuer Befund)
            string text = txt_befund.Text;
            bool result = arztWriter.writePData(new PData(text));
            
            if (result)
            {
                txt_befund.Text = "";
            }
        }

        private void cmd_show_a_Click(object sender, EventArgs e)
        {
            IList<PData> result = arztReader.readPData();

            //Alle Daten der Arzt-Datenbank anzeigen
            string resultText = "";
            foreach (PData pdata in result)
            {
                resultText += pdata.befund + System.Environment.NewLine;
            }

            // Ausgabe Arztbefund
            lbl_ausgabe_a.Text = resultText;
        }
    }
}
