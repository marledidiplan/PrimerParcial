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
using System.Data.Entity;
using System.Linq.Expressions;

namespace Parcial1.UI.Registro
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        
        public Grupos LlenaClase()
        {
            Grupos grupos = new Grupos();
            grupos.GrupoId = Convert.ToInt32(IdGruposnumericUpDown.Value);
            grupos.Fecha = FechadateTimePicker.Value;
            grupos.Descripcion = DescripciontextBox.Text;
            grupos.Cantidad = Convert.ToInt32(CantidadtextBox.Text);
            grupos.Grupo = Convert.ToInt32(GrupostextBox.Text);
            return grupos;


        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Grupos grupos = LlenaClase();
            bool paso = false;
            if(!Validar())
            {
                if (IdGruposnumericUpDown.Value == 0)
                    paso = BLL.GruposBLL.Guardar(grupos);
                else
                    paso = BLL.GruposBLL.Modificar(LlenaClase());
                if (paso)
                    MessageBox.Show("Guardado", "EXITO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se Guardo", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                 
        }
        public bool Validar()
        {

            bool Errores = false;
            
            if(String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "Descripcion Vacia");
                Errores = true;

            }
            if(CantidadtextBox.Text== String.Empty)
            {
                errorProvider.SetError(CantidadtextBox, "Cantidad Vacia");
                Errores = true;
            }
            if(IntegrantestextBox.Text==String.Empty)
            {
                errorProvider.SetError(IntegrantestextBox, "Integrantes Vacio");
                Errores = true;
            }
            if(GrupostextBox.Text==string.Empty)
            {
                errorProvider.SetError(GrupostextBox, "Grupo vacio");
                Errores = true;

            }
            return Errores;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdGruposnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            DescripciontextBox.Clear();
            CantidadtextBox.Clear();
            IntegrantestextBox.Clear();
            GrupostextBox.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdGruposnumericUpDown.Value);

            if (BLL.GruposBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se elimino", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdGruposnumericUpDown.Value);
            Grupos grupos = BLL.GruposBLL.Buscar(id);
            if(grupos!=null)
            {
                DescripciontextBox.Text = grupos.Descripcion;
                FechadateTimePicker.Value = grupos.Fecha;
                CantidadtextBox.Text = grupos.Cantidad.ToString();
                IntegrantestextBox.Text = grupos.Integrantes.ToString();
                GrupostextBox.Text = grupos.Grupo.ToString();

            }


            
        }
        public void CalcularIntegrantes()
        {

            

        }
    }
}
