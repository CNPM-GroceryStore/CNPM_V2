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
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace GroceryStore
{
    public partial class MessageForm : Form
    {
        private string _message;
        private string OTP;

        //String connectionString = "Data Source=DESKTOP-RTQDFRG\\SQLEXPRESS;Initial Catalog=CuaHangTienLoi;Integrated Security=True";
        String connectionString = "Data Source=MSI;Initial Catalog=CuaHangTienLoi;Integrated Security=True";

        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(string Message) : this()
        {
            _message = Message;
            lb_sdt.Text = _message;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            //random mã otp
            Random rnd = new Random();
            OTP = rnd.Next(100000, 999999).ToString();

            //// replace with your twilio account sid and auth token
            // Replace with your Twilio Account SID and Auth Token
            const string accountSid = "ACf1413a57860e90c3bcddfde1b2c89d68";
            const string authToken = "66eb17623c4f438e8fb3fced93dc62b8";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your OTP is " + OTP,
                from: new Twilio.Types.PhoneNumber("+15855728524"),
                to: new Twilio.Types.PhoneNumber(convertNumber(lb_sdt.Text))
            );

        }

        private string convertNumber(string number)
        {
            MessageBox.Show(number);
            string internationalNumber = "+84" + number.Substring(1);
            return internationalNumber;
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            if (tb_sdt.Text.Equals(OTP))
            {
                Connect();
            }
            else
            {
                MessageBox.Show("Sai OTP, vui lòng nhập lại.");
            }
        }

        //hàm kết nối database thực hiện lệnh insert
        private void Connect()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SoDienThoai", Sdt);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@HoTen", Name);
                    command.Parameters.AddWithValue("@DiaChi", Address);
                    command.Parameters.AddWithValue("@MatKhau", Password);

                    //Thêm parameter để trả về kết quả
                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    connection.Open();
                    command.ExecuteNonQuery();

                    //Kiểm tra kết quả trả về từ stored procedure
                    int result = (int)returnValue.Value;
                    if (result == 0)
                    {
                        this.Hide();
                        MessageBox.Show("Đăng kí thành công, vui lòng đăng nhập");
                        this.Hide();
                        //registerForm.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí thất bại, vui lòng đăng kí lại");
                        this.Hide();
                    }
                }
            }
        }
    }
}
