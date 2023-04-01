﻿using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GroceryStore
{
    public partial class LoginForm : Form
    {
        String connectionString = "Data Source=DESKTOP-RTQDFRG\\SQLEXPRESS;Initial Catalog=CuaHangTienLoi;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();

            // Đặt kiểu phẳng của button thành Popup
            btn_login.FlatStyle = FlatStyle.Flat;

            // Đặt bán kính của góc bo thành 80
            btn_login.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_login.Width, btn_login.Height, 12, 12));
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);


        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            if (tb_password.Text.Length < 8)
            {
                errorLogin.SetError(tb_password, "Mật khẩu phải có ít nhất 8 kí tự");
            }
            else if (tb_password.Text.Equals(""))
            {
                errorLogin.SetError(tb_password, "Mật khẩu không được bỏ trống");
            }
            else
            {
                errorLogin.SetError(tb_password, "");
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tb_sdt chứa kí tự là chữ
            if (Regex.IsMatch(tb_sdt.Text, "[a-zA-Z]"))
            {
                errorLogin.SetError(tb_sdt, "Số điện thoại không được chứa kí tự là chữ");
            }
            else if (tb_sdt.Text.Length < 10 || tb_sdt.Text.Length > 10)
            {
                errorLogin.SetError(tb_sdt, "Số điện thoại không đúng định dạng");
            }
            else
            {
                errorLogin.SetError(tb_sdt, "");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DTO_User user = new DTO_User(tb_sdt.Text, tb_password.Text);
            BUS_User bUS_User = new BUS_User();
            //MessageBox.Show(bUS_User.checkAccount(user).ToString());
            if (bUS_User.checkAccount(user))
            {
                bUS_User.loginAccount(user);
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                HomeForm home = new HomeForm(user);
                home.Show();
            }
            else { errorLogin.SetError(tb_sdt, "Tài khoản không tồn tại"); }

        }

        private void lb_forgetPassword_Click(object sender, EventArgs e)
        {
            //xử lý sự kiện forgot password


        }

        private void lb_signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}