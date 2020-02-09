using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdCliente.Text);
            string nombre = txtNombre.Text;
            string direccion =  txtDireccion.Text;
            string telefono = txtTelefono.Text;
            
            using (BaseEjemploEntitiesConect contexto = new BaseEjemploEntitiesConect()) {
                clientes c = new clientes
                {
                    idCliente = id,
                    nombreCliente = nombre,
                    direccion = direccion,
                    telefono = telefono 

                };
                contexto.clientes.Add(c);
                contexto.SaveChanges();
                cargar();
            }

        }

        private void llenar()
        {
            this.txtIdCliente.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombre.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            this.txtDireccion.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            this.txtTelefono.Text = grid.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void cargar() {
            BaseEjemploEntitiesConect contexto = new BaseEjemploEntitiesConect();
            grid.DataSource = contexto.clientes.ToList();
        }

        private void grid_Click(object sender, EventArgs e)
        {
            llenar(); 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(this.txtIdCliente.Text);
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            using (BaseEjemploEntitiesConect contexto = new BaseEjemploEntitiesConect()) {
                clientes c = contexto.clientes.FirstOrDefault(x => x.idCliente == id);
                c.nombreCliente = nombre;
                c.direccion = direccion;
                c.telefono = telefono;
                contexto.SaveChanges();
                cargar();
            
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(this.txtIdCliente.Text);

            using (BaseEjemploEntitiesConect contexto = new BaseEjemploEntitiesConect())
            {
                clientes c = contexto.clientes.FirstOrDefault(x => x.idCliente == id);
                
                contexto.clientes.Remove(c);
                contexto.SaveChanges();
                cargar();

            }
        }
    }
}
