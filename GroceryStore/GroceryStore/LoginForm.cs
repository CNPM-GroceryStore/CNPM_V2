using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GroceryStore
{
    public partial class LoginForm : Form
    {
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
            DTO_Staff staff = new DTO_Staff(tb_sdt.Text, tb_password.Text);
            BUS_Staff bUS_Staff = new BUS_Staff();
            //MessageBox.Show(bUS_Staff.checkAccount(staff).ToString());
            if (bUS_Staff.checkAccountStaff(staff))
            {
                bUS_Staff.loginAccountStaff(staff);
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                HomeForm home = new HomeForm(staff);
                home.Show();
            }
            else { errorLogin.SetError(tb_sdt, "Tài khoản hoặc mật khẩu không đúng"); }

        }

        private void lb_signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void lb_forgetPassword_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            //xử lý sự kiện forgot password
            MessageForm messageForm = new MessageForm(tb_sdt.Text);
            messageForm.Show();
        }
    }
}