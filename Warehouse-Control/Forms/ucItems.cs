using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Util;
using Warehouse_Control.Connection;
using Warehouse_Control.Models;
using System.Data.Entity;
using System.IO;

namespace Warehouse_Control.Forms
{
    public partial class ucItems : UserControl
    {
        private int id;

        public ucItems()
        {
            InitializeComponent();
            enable_textbox(false);
            btnCancel.Visible   = false;
            btnSave.Visible     = false;
            btnNew.Visible      = true;
            btnSearch.Visible   = true;
            btnSaveEdit.Visible = false;
            btnDelete.Visible   = false;
            btnEdit.Visible     = false;
            btnImport.Visible   = true;
            btnExport.Visible   = true;
        }

        public void enable_textbox(Boolean enable)
        {
            tbName.Enabled = enable;
            tbDescription.Enabled = enable;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            enable_textbox(true);
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnNew.Visible = false;
            btnSearch.Visible = false;
            btnImport.Visible = false;
            btnExport.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            enable_textbox(false);
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
            btnEdit.Visible = false;
            btnSaveEdit.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!check_fields())
            {
                return;
            }

            var db = new ConnectionDB();
            var item = new Items
            {
                key = tbName.Text,
                description = tbDescription.Text,
            };
            db.Items.Add(item);
            db.SaveChanges();
            clear_fields();

            MessageBox.Show("Registro realizado con éxito", "Operador", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
            btnEdit.Visible = true;
            btnSaveEdit.Visible = true;
            enable_textbox(false);
            fill_dgv("");
        }


        #region Funciones
        private bool check_fields()
        {
            var validator = new tbValidators();
            return validator.requieredTextValidator(tbName);
        }

        private void clear_fields()
        {
            tbDescription.Text = "";
            tbName.Text = "";
        }

        private void fill_dgv(string searchValue)
        {
            dgvItems.Rows.Clear(); //limpiamos el data grid

            var db = new ConnectionDB();
            List<Items> data;

            if (!string.IsNullOrEmpty(searchValue))
            {
                data = db.Items.Where(x => x.key.Contains(searchValue) || x.description.Contains(searchValue)).ToList();
            }
            else
            {
                data = db.Items.ToList();
            }

            foreach (var item in data)
            {
                dgvItems.Rows.Add(item.id, item.key, item.description);
            }
        }
        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            fill_dgv(tbSearch.Text);
        }

        private void DgvItems_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0)
            {
                return;
            }

            var db = new ConnectionDB();
            var index = dgvItems.CurrentRow.Index;
            id = Convert.ToInt16(dgvItems.Rows[index].Cells[0].Value.ToString());

            var item = db.Items.Where(x => x.id == id).FirstOrDefault();

            tbName.Text = item.key;
            tbDescription.Text = item.description;

            btnDelete.Visible = true;
            btnEdit.Visible = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            enable_textbox(true);
            btnSearch.Visible = false;
            btnDelete.Visible = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;
            btnSaveEdit.Visible = true;
            btnEdit.Visible = false;
            btnEdit.Visible = false;
            btnSaveEdit.Visible = false;
        }

        private void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!check_fields()) {
                return;
            }
            var db = new ConnectionDB();
            var item = db.Items.Where( x=> x.id == id).FirstOrDefault();

            item.key = tbName.Text;
            item.description = tbDescription.Text;

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Registro actualizado con éxito", "Articulo",MessageBoxButtons.OK,MessageBoxIcon.Information);

            clear_fields();
            enable_textbox(false);
            btnSearch.Visible = true;
            btnDelete.Visible = false;
            btnNew.Visible = true;
            btnCancel.Visible = false;
            btnSaveEdit.Visible = false;
            btnEdit.Visible = true;
            btnSaveEdit.Visible = true;
            fill_dgv("");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Estas segudo que desea eliminar este registro?", "Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes) {
                var db = new ConnectionDB();
                var item = db.Items.Where(x => x.id == id).FirstOrDefault();
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();

                MessageBox.Show("Registro eliminado con éxito", "Articulo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                clear_fields();
                enable_textbox(false);
                btnSearch.Visible = true;
                btnDelete.Visible = false;
                btnNew.Visible = true;
                btnCancel.Visible = false;
                btnSaveEdit.Visible = false;
                btnEdit.Visible = false;
                fill_dgv("");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            var db = new ConnectionDB();
            var ofd = new OpenFileDialog{
                Filter = "CSV Files (*.csv)|*.csv",
                Title  = "Open file"
            };

            bool first = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(ofd.FileName))
                    return;

                try
                {
                    using (var reader = new StreamReader(ofd.FileName))
                    {

                        while (!reader.EndOfStream)
                        {

                            var line = reader.ReadLine();
                            var item = line.Split(',');
                            var items = new Items();

                            if (Convert.ToString(item[0]) == "Nombre")
                            {
                                continue;
                            }

                            items.key = Convert.ToString(item[0]);
                            items.description = Convert.ToString(item[1]);

                            db.Items.Add(items);
                            db.SaveChanges();
                        }
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error al abrir el archivo", "Articulos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

            MessageBox.Show("Proceso terminado", "Articulos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fill_dgv("");

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog
            {
                Title = "Guardar como",
                Filter = "CSV Files (*.csv)|*.csv"
            };
            saveFile.ShowDialog();
            if (string.IsNullOrEmpty(saveFile.FileName))
            {
                MessageBox.Show("Nombre no válido", "Articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            File.AppendAllText(saveFile.FileName,"Nombre,Descripción");
            MessageBox.Show("Proceso terminado", "Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
