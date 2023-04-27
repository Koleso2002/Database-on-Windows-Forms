using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Enter : Form
    {
        private Form1 form1;
        public Enter(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ControlBox = false;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Text = "Введите пароль администратора";
            textBox1.MouseClick += TextBox1_MouseClick;
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Roles.Role = RoleType.USER;
            MessageBox.Show("Вы вошли как Пользователь!");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == Roles.Password)
            {
                Roles.Role = RoleType.ADMIN;
                MessageBox.Show("Вы вошли как Администратор!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!!!");
            }
        }
    }
}
