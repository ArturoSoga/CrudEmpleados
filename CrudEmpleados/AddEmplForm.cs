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
    public partial class AddEmplForm : Form
    {
        public AddEmplForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEmplForm_Load(object sender, EventArgs e)
        {
            cmbEmpresa.DataSource = new EmprModel().GetEmpr();
            cmbEmpresa.DisplayMember = "empr_nombre";
            cmbEmpresa.ValueMember = "empr_id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            int idEmpresa =Convert.ToInt32(cmbEmpresa.SelectedValue);
            new EmplModel().EmplInsert(new EmplModel() {Nombre= txtNombre.Text ,Telefono = Convert.ToInt64(txtTelefono.Text) ,Direccion=txtDireccion.Text, IdEmpresa = idEmpresa });
            this.Close();
        }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Todos los campos son necesarios");
            }
}
    }
}
