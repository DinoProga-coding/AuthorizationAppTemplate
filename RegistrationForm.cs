using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlApp
{
    public partial class RegistrationForm : Form
    {
        DataBase database = new DataBase();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if(loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                string query = $"SELECT login, password FROM data WHERE login = '{login}' AND password = '{password}'";
                SqlCommand command = new SqlCommand(query, database.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Такой аккаунт уже существует");
                }
                else
                {
                    MessageBox.Show("Аккаунт зарегистрирован");
                    string query2 = $"INSERT INTO data(login, password) VALUES('{login}','{password}')";
                    SqlCommand command2 = new SqlCommand(query2, database.GetConnection());
                    database.OpenConnection();
                    if(command2.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Успешно");
                    }
                    else
                    {
                        Console.WriteLine("ошибка");
                    }
                    database.CloseConnection();
                    Thread.Sleep(1000);
                    Form1 form = new Form1();
                    this.Hide();
                    form.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Visible = true;
        }
    }
}
