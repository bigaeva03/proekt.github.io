using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test_DataBase
{

    // перечисления
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {

        DataBase database = new DataBase();// подключение класса

        int selectedRow; // для работы с dataGridView1

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns(); // метод (колонки для таблицы)
            RefreshDataGrid(dataGridView1); // метож (вывод данных в таблицу)
        }

        private void CreateColumns() // колонки для таблицы
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("type_of", "Тип товара");
            dataGridView1.Columns.Add("count_of", "Количество");
            dataGridView1.Columns.Add("postavka", "Поставщик");
            dataGridView1.Columns.Add("price", "Цена");
            dataGridView1.Columns.Add("IsNew", String.Empty); //пустая строка
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetInt32 (4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw) //вывод данных в таблицу
        {
            dgw.Rows.Clear();
            string queryString = $"select * from test_db";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
                
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)// при нажатии на запись она будет отображаться в поле "Запись"
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_type.Text = row.Cells[1].Value.ToString();
                textBox_count.Text = row.Cells[2].Value.ToString();
                textBox_postav.Text = row.Cells[3].Value.ToString();
                textBox_price.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)// обновление таблицы
        {
            RefreshDataGrid(dataGridView1); //вывод данных в таблицу
            ClearFields();// очищение текстоксов
        }

        private void Change()// метод изменения данных
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var type = textBox_type.Text;
            var count = textBox_count.Text;
            var postav = textBox_postav.Text;
            int price;
            if (DialogResult.Yes == MessageBox.Show("Вы хотите изменить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)// не пустая ли строка
                {
                    if (int.TryParse(textBox_price.Text, out price))// проверка цены
                    {
                        dataGridView1.Rows[selectedRowIndex].SetValues(id, type, count, postav, price);
                        dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("Цена должна иметь числовой формат!");
                    }
                }
            }
            else if (DialogResult == DialogResult.No)
            {

            }
        }

        private void deleteRow()// метод удаления
        {
            if (DialogResult.Yes == MessageBox.Show("Вы хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows[index].Visible = false;
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
            }
            else if (DialogResult == DialogResult.No)
            {

            }
        }

        private void Update() // метод сохраниния
        {
            database.openConnection();
            if (DialogResult.Yes == MessageBox.Show("Вы хотите сохранить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            { 
                for (int index = 0; index < dataGridView1.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                    if (rowState == RowState.Existed)
                        continue;

                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from test_db where id = {id}";

                        var command = new SqlCommand(deleteQuery, database.getConnection());
                        command.ExecuteNonQuery();
                    }

                    // является ли Update (метод сохранения) Change (методу изменения)
                    if (rowState == RowState.Modified)
                    {
                        var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        var type = dataGridView1.Rows[index].Cells[1].Value.ToString();
                        var count = dataGridView1.Rows[index].Cells[2].Value.ToString();
                        var postavka = dataGridView1.Rows[index].Cells[3].Value.ToString();
                        var price = dataGridView1.Rows[index].Cells[4].Value.ToString();

                        var changeQuery = $"update test_db set type_of = '{type}', count_of = '{count}', postavka = '{postavka}', price = '{price}' where id = '{id}'";

                        var command = new SqlCommand(changeQuery, database.getConnection());
                        command.ExecuteNonQuery();
                    }
                }
            }
            else if (DialogResult == DialogResult.No)
            {

            }

                database.closeConnection();
        }

        private void Search()// метод поиска
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(searchtextBox.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void ClearFields()// очищение текстоксов
        {
                textBox_id.Text = "";
                textBox_type.Text = "";
                textBox_count.Text = "";
                textBox_postav.Text = "";
                textBox_price.Text = "";
        }
              

        private void btnDelete_Click(object sender, EventArgs e)// кнопка удалить
        {
            deleteRow();// метод удаления
            ClearFields();// очищение текстоксов
        }

        private void btnUpdate_Click(object sender, EventArgs e)// кнопка сохранить
        {
            Update();// метод сохраниния
        }

        private void btnNew_Click(object sender, EventArgs e)// кнопка добавить новую запись
        {
            Add_Form addfrm = new Add_Form();
            addfrm.Show();
        }
                
        private void btnChange_Click(object sender, EventArgs e)// кнопка изменить
        {
            Change();// метод изменения данных
            ClearFields();// очищение текстоксов
        }
         
        private void btnClear_Click(object sender, EventArgs e)// кнопка очистить
        {
            ClearFields();// очищение текстоксов
        }

        private void searchButton_Click(object sender, EventArgs e) // кнопка найти
        {
            Search();// метод поиска
        }


             



        /*Кнопка Вычислить сумму
         private void calculateButton_Click(object sender, EventArgs e) // кнопка вычислить 
        {
            double x = Convert.ToInt32(tBPriceReception.Text) * Convert.ToInt32(tBCount.Text);
            tBSum.Text = x.ToString();
        }
        */

        /*// кнопка добавления в навигаторе
         private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) 
        {
            dTPReception.Value = DateTime.Now; // нажав кнопку "Добавить" в поле дата будет стоять значение даты,
                                               // в которую добаляют новую запись приёма 
        }
       */



    }
}
