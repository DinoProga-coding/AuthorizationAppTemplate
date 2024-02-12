using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlApp
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            string query = $"SELECT login, password FROM data WHERE login = '{login}' AND password = '{password}'";
            SqlCommand command = new SqlCommand(query, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Вы вошли в аккаунт");
                ContentForm1 form1 = new ContentForm1();
                this.Hide();
                form1.Visible = true;
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegistrationForm form2 = new RegistrationForm();
            form2.Visible = true;
            this.Hide();
        }
    }
}
