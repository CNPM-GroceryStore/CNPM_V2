using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GroceryStore
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tb_sdt chứa kí tự là chữ
            if (Regex.IsMatch(tb_sdt.Text, "[a-zA-Z]"))
            {
                errorRegister.SetError(tb_sdt, "Số điện thoại không được chứa kí tự là chữ");
            }
            else if (tb_sdt.Text.Length < 10 || tb_sdt.Text.Length > 10)
            {
                errorRegister.SetError(tb_sdt, "Số điện thoại không đúng định dạng");
            }
            else
            {
                errorRegister.SetError(tb_sdt, "");
            }
        }

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidEmail(tb_email.Text))
            {
                errorRegister.SetError(tb_email, "Địa chỉ email không hợp lệ.");
            }
            else
            {
                errorRegister.SetError(tb_email, "");
            }
        }



        //hàm validate email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_name.Text))
            {
                errorRegister.SetError(tb_name, "Họ tên không được bỏ trống.");

            }
            if (tb_name.Text.Any(char.IsDigit))
            {
                errorRegister.SetError(tb_name, "Họ tên không được chứa kí tự số.");
            }
            else
            {
                errorRegister.SetError(tb_name, "");
            }
        }

        private void tb_address_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_address.Text))
            {
                errorRegister.SetError(tb_address, "Địa chỉ không được bỏ trống.");

            }
            else
            {
                errorRegister.SetError(tb_address, "");
            }
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tb_password.Text))
            {
                errorRegister.SetError(tb_password, "Mật khẩu không được bỏ trống.");
            }

            if (tb_password.Text.Length < 8)
            {
                errorRegister.SetError(tb_password, "Mật khẩu phải dài hơn 8 kí tự.");
            }
            else
            {
                errorRegister.SetError(tb_password, "");
            }
        }

        private void tb_confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_confirmPassword.Text))
            {
                errorRegister.SetError(tb_confirmPassword, "Nhập lại mật khẩu không được bỏ trống.");

            }

            if (tb_confirmPassword.Text.Trim() != tb_password.Text.Trim())
            {
                errorRegister.SetError(tb_confirmPassword, "Nhập lại mật khẩu không khớp.");
            }
            else
            {
                errorRegister.SetError(tb_confirmPassword, "");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (errorRegister.GetError(tb_sdt) != "" || errorRegister.GetError(tb_email) != "" || errorRegister.GetError(tb_name) != "" ||
                errorRegister.GetError(tb_password) != "" || errorRegister.GetError(tb_confirmPassword) != "")
            {
                lb_error.Text = "Vui lòng kiểm tra lại thông tin.";
            }
            else
            {
                if (Connect())
                {
                    MessageBox.Show("Đăng kí thành công");
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                else
                {
                    lb_error.Text = "Đăng kí thất bại, vui lòng kiểm tra lại thông tin.";
                }

            }
        }


        //Check Account: if exist in DB, notice error, else notice successfully login
        private Boolean Connect()
        {
            DTO_User user = new DTO_User(tb_sdt.Text, tb_email.Text, tb_name.Text, tb_address.Text, tb_password.Text);
            BUS_User bUS = new BUS_User();
            if (!bUS.checkAccount(user))
            {
                bUS.createAccount(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
