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
    public partial class Add_Form : Form
    {
        DataBase database = new DataBase();

        public Add_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;// открытие окна по центру экрана
        }

        private void button1_Click(object sender, EventArgs e)// кнопка сохранить
        {
            database.openConnection();

            var type = textBox_type2.Text;
            var count = textBox_count2.Text;
            var postav = textBox_postav2.Text;
            int price;

            if (DialogResult.Yes == MessageBox.Show("Вы хотите сохранить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (int.TryParse(textBox_price2.Text, out price))// проверка поля
                {
                    var addQuery = $"insert into test_db (type_of, count_of, postavka, price) values('{type}', '{count}', '{postav}', '{price}')";

                    var command = new SqlCommand(addQuery, database.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись создана успешно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Запись должна иметь числовой формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (DialogResult == DialogResult.No)
            {

            }

            database.closeConnection();
        }
    }
}
