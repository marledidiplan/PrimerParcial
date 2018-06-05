using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parcial1.Entidades;
using Parcial1.BLL;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Parcial1.UI.Consulta;

namespace Parcial1.UI.Consulta
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Grupos, bool>> Filtro = a => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = a => a.GrupoId == id
                    && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 1:
                    Filtro = a => a.Descripcion.Equals(CriteriotextBox.Text)
                     && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2:
                    Filtro=a =>a.Fecha.Equals(CriteriotextBox.Text)
                     && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3:
                    Filtro = a => a.Cantidad.Equals(CriteriotextBox)
                     && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 4: 
                    Filtro = a =>a.Equals(CriteriotextBox.Text)
                     && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 5: 
                    Filtro = a => a.Grupo.Equals(CriteriotextBox.Text)
                    && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                case 6:
                    Filtro = a => a.Integrantes.Equals(CriteriotextBox.Text)
                    && (a.Fecha <= DesdedateTimePicker.Value && a.Fecha <= HastadateTimePicker.Value);
                    break;
                   }
            ConsultadataGridView.DataSource = BLL.GruposBLL.GetList(Filtro);

        }
    }
}
