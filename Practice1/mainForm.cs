using Practice1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;


namespace Practice1
{
    public partial class mainForm : Form
    {
        private BindingList<Worker> workersBindingList = new BindingList<Worker>();

        public ApplicationContext1 db;
        public mainForm()
        {
            InitializeComponent();

            db = new ApplicationContext1();
            List<Worker> workers = db.Workers.ToList();

            dataGridView1.DataSource = workersBindingList;

            LoadData();
        }

        public List<Worker> FilterData(string searchText)
        {
            using (var context = new ApplicationContext1())
            {
                return context.Workers.Where(e => e.invNumber.Contains(searchText) || e.adress.Contains(searchText)).ToList();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text;
            List<Worker> filteredData = FilterData(searchText);

            workersBindingList.Clear();
            foreach (var worker in filteredData)
            {
                workersBindingList.Add(worker);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = workersBindingList;

            dataGridView1.Refresh();
        }





        public void LoadData()
        {
            workersBindingList.Clear();

            using (var context = new ApplicationContext1())
            {
                List<Worker> workers = db.Workers.ToList();

                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("id", "ID");
                dataGridView1.Columns.Add("fcs", "ФИО");
                dataGridView1.Columns.Add("invNumber", "Инвентарный номер");
                dataGridView1.Columns.Add("equip", "Оборудование");
                dataGridView1.Columns.Add("cost", "Цена");
                dataGridView1.Columns.Add("adress", "Адрес");


                foreach (var worker in workers)
                {
                    workersBindingList.Add(worker);
                }
            }
        }


        private void pictureRefreshGrid_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                using (var context = new ApplicationContext1())
                {
                    var entity = context.Workers.Find(id);

                    if (entity != null)
                    {
                        context.Workers.Remove(entity);
                        context.SaveChanges();
                    }
                }

                // Обновление источника данных dataGridView1
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = workersBindingList;
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxCost.Text, out int cost))
            {
                using (var dbContext = new ApplicationContext1())
                {
                    var data = new Worker { fcs = textBoxFcs.Text, invNumber = textBoxInvNumber.Text, equip = textBoxEquip.Text, cost = cost, adress = textBoxAdress.Text  };
                    dbContext.Workers.Add(data);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Введите корректное числовое значение для стоимости.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                using (var context = new ApplicationContext1())
                {
                    var entity = context.Workers.Find(id);

                    if (entity != null)
                    {
                        context.Workers.Remove(entity);
                        context.SaveChanges();
                    }
                }

                // Удаление строки из workersBindingList
                var workerToRemove = workersBindingList.FirstOrDefault(w => w.id == id);
                if (workerToRemove != null)
                {
                    workersBindingList.Remove(workerToRemove);
                }
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var modifiedRow = dataGridView1.Rows[e.RowIndex];
                var entityId = (int)modifiedRow.Cells["id"].Value;

                using (var context = new ApplicationContext1())
                {
                    var entity = context.Workers.Find(entityId);
                    if (entity != null)
                    {
                        entity.fcs = Convert.ToString(modifiedRow.Cells["fcs"].Value);
                        entity.invNumber = Convert.ToString(modifiedRow.Cells["invNumber"].Value);
                        entity.equip = Convert.ToString(modifiedRow.Cells["equip"].Value);
                        entity.cost = Convert.ToInt32(modifiedRow.Cells["cost"].Value);
                        entity.adress = Convert.ToString(modifiedRow.Cells["adress"].Value);

                        context.SaveChanges();
                    }
                }
            }
        }

    }
}
