using CrudEmpleados.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudEmpleados
{
    public partial class UpdateEmplForm : Form
    {
        public UpdateEmplForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEmplForm_Load(object sender, EventArgs e)
        {
            cmbEmpleado.DataSource = new EmplModel().EmplGet();
            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "IdEmpleado";

            cmbEmpresa.DataSource = new EmprModel().GetEmpr();
            cmbEmpresa.DisplayMember = "empr_nombre";
            cmbEmpresa.ValueMember = "empr_id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
           var IdEmpleado =Convert.ToInt32(cmbEmpleado.SelectedValue);
           var IdEmpresa =Convert.ToInt32( cmbEmpresa.SelectedValue);
            //empresa nombre direccion telefono id empleado
            new EmplModel().EmplUpdate(new EmplModel(){IdEmpresa=IdEmpresa,Nombre=txtNombre.Text,Direccion = txtDireccion.Text , Telefono = Convert.ToInt32(txtTelefono.Text) ,IdEmpleado = IdEmpleado });
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Todos los campos son necesarios");
            }
        }
    }
}
