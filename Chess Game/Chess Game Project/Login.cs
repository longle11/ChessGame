using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using Chess_Game_Project.classes_handle;

namespace Chess_Game_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            errorHideLabel.Hide();
            btnLogin.Enabled = true;
            showFormAgain = this;   //gán form hiện tại cho 1 form
            txtPassword.PasswordChar = '*';

        }

        public Timer timer = null;
        public string apiUrlLogin = "https://chessmates.onrender.com/api/v1/auth/login";
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        public int countLogin = 2;
        public int timeStart = 1;
        public int timeFinish = 60;
        public static Login showFormAgain;
        public classes.infoUser user = null;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeStart == timeFinish)
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
                btnLogin.Enabled = true;
                timer.Stop();
                errorHideLabel.Text = "";
                errorHideLabel.Hide();
                countLogin = 2;
            }
            timeStart++;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ username và password");
                return;
            }
            var data = new
            {
                userName = txtUserName.Text.Trim(),
                password = txtPassword.Text.Trim()
            };
            btnLogin.Enabled = false;
            // Gửi yêu cầu POST đến apiUrl với dữ liệu jsonData
            try
            {
                JToken tkData = await manageApi.callApiUsingMethodPost(data, apiUrlLogin);
                if (tkData != null)
                {
                    btnLogin.Enabled = true;
                    // Chuyển đổi sang đối tượng JSON
                    user = JsonConvert.DeserializeObject<classes.infoUser>(tkData.ToString());
                    if (string.Equals(user.statusActive, "online"))
                    {
                        MessageBox.Show("Tài khoản này hiện đang được sử dụng", "notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLogin.Enabled = true;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        errorHideLabel.Text = "";
                        errorHideLabel.Hide();
                        //cập nhật trạng thái thành hoạt động
                        string apiUser = apiGetUser + user.id;
                        var data1 = new
                        {
                            userName = user.userName,
                            gmail = user.gmail,
                            linkAvatar = user.linkAvatar,
                            statusActive = "online",
                        };
                        user.statusActive = "online";
                        await manageApi.callApiUsingMethodPut(data1, apiUser);
                        this.Hide();


                        //tạo ra giao diện chính
                        LobbyInterface inter = new LobbyInterface(user);
                        inter.Show();
                    }
                }
                else
                {
                    if (countLogin == 0)
                    {
                        btnLogin.Enabled = true;
                        txtPassword.Enabled = false;
                        txtUserName.Enabled = false;
                        btnLogin.Enabled = false;
                        errorHideLabel.Text = "Vui lòng chờ 3 phút để thực hiện lại thao tác này";
                        timer = new Timer();
                        timer.Interval = 1000;
                        timer.Start();
                        timer.Tick += Timer_Tick;
                        return;
                    }
                    btnLogin.Enabled = true;
                    errorHideLabel.Show();
                    errorHideLabel.ForeColor = Color.Red;
                    errorHideLabel.Text = $"Sai tài khoản hoặc mật khẩu, bạn còn {countLogin} lần để đăng nhập";
                    countLogin--;
                }
            }
            catch (Exception ex)
            {
                btnLogin.Enabled = true;
                string apiUser = apiGetUser + user.id;
                var data1 = new
                {
                    userName = user.userName,
                    gmail = user.gmail,
                    linkAvatar = user.linkAvatar,
                    statusActive = "offline",
                };
                user.statusActive = "offline";
                await manageApi.callApiUsingMethodPut(data1, apiUser);
            }
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            RegisterInterface rgForm = new RegisterInterface();
            rgForm.Show();

            //ẩn form hiện tại
            Hide();
        }
        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            //click vào quên mật khẩu thì hiện form xác thực tài khoản
            AuthInterface auth = new AuthInterface();
            auth.Show();

            //ẩn form login đi 
            this.Hide();
        }
        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

            ptbContainAvt.BackgroundImage = System.Drawing.Image.FromFile("Resources\\loginAvt.jpg");
            ptbContainAvt.BackgroundImageLayout = ImageLayout.Stretch;
            pnlContent.BringToFront();
            // Thiết lập kích thước form
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = (int)(screenWidth * 0.8);
            int formHeight = (int)(screenHeight * 0.9);
            this.Size = new Size(formWidth, formHeight);

            // Đặt vị trí của form để nằm chính giữa màn hình
            int left = (screenWidth - formWidth) / 2;
            int top = (screenHeight - formHeight) / 2;
            this.Location = new Point(left, top);
            ptbContainAvt.Size = this.Size;

            // Đưa Panel vào chính giữa màn hình
            pnlContent.Location = new Point((this.Width - pnlContent.Width) / 2,
                                        (this.Height - pnlContent.Height) / 2);
            this.TransparencyKey = Color.Empty;
        }
    }
}
