using AppCore.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmProductos : Form
    {
        public IProductoService PModel { get; set; }

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cmbCategoria.Items.AddRange(Enum.GetValues(typeof(Categoria))
                                              .Cast<object>()
                                              .ToArray()
                                          );
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                ID = PModel.GetLastProductoId() + 1,
                Nombre = txtNombre.Text,
                Descripcion = txtDesc.Text,
                Existencia = (int)nudExist.Value,
                Precio = nudPrice.Value,
                Vencimiento = dtpCaducity.Value,
                Categoria = (Categoria)cmbCategoria.SelectedIndex
            };

            PModel.Create(p);

            Dispose();
        }
    }
}
