using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        ArrayList info = new ArrayList { };

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string password = textBox3.Text;
            string password2 = textBox4.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("账号不可为空");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("用户名不可为空");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不可为空");
                return;
            }
            else if (info.Contains(id))
            {
                MessageBox.Show("账号已经存在");
                return;
            }
            else if (password != password2)
            {
                MessageBox.Show("两次密码输入不一致");
                return;
            }
            else
            {
                info.Add(id);
                info.Add(name);
                info.Add(password);
                MessageBox.Show("注册成功！");
            }
        }
    }
}
