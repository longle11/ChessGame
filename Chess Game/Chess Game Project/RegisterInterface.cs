using Chess_Game_Project.classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Chess_Game_Project.classes_handle;

namespace Chess_Game_Project
{
    public partial class RegisterInterface : Form
    {
        public RegisterInterface()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';


            clearError();
            errorUserNameLabel.ForeColor = Color.Red;
            errorPasswordLabel.ForeColor = Color.Red;
            errorEmailLabel.ForeColor = Color.Red;
            errorConfirmPasswordLabel.ForeColor = Color.Red;
        }

        public void clearError()
        {
            errorUserNameLabel.Text = "";
            errorPasswordLabel.Text = "";
            errorEmailLabel.Text = "";
            errorConfirmPasswordLabel.Text = "";
        }
        public string apiUrlRegister = "https://chessmates.onrender.com/api/v1/auth/register";
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(txtConfirmPassword.Text, txtPassword.Text))
                errorConfirmPasswordLabel.Text = "";
            else
            {
                errorConfirmPasswordLabel.ForeColor = Color.Red;
                errorConfirmPasswordLabel.Text = "Mật khẩu không khớp";
            }
        }
        private void displayError(errorRegister errors)
        {
            clearError();
            //Truong hop doi voi userName
            if (string.IsNullOrEmpty(txtConfirmPassword.Text)) errorConfirmPasswordLabel.Text = "Thông tin không được bỏ trống";
            else errorConfirmPasswordLabel.Text = "Mật khẩu không khớp";
            if (errors.userName != null) errorUserNameLabel.Text = errors.userName[0];
            if (errors.gmail != null) errorEmailLabel.Text = errors.gmail[0];
            if(errors.password != null) errorPasswordLabel.Text = errors.password[0];    

        }
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string gmail = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassowrd = txtConfirmPassword.Text.Trim();
                var data = new
                {
                    userName,
                    gmail,
                    password
                };
                string dataJson = JsonConvert.SerializeObject(data);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(apiUrlRegister, new StringContent(dataJson, Encoding.UTF8, "application/json"));

                //thực hiện đăng ký thành công
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    if (string.IsNullOrEmpty(errorConfirmPasswordLabel.Text))
                    {
                        JToken dataToken = JObject.Parse(await response.Content.ReadAsStringAsync())["data"];
                        infoUser user = JsonConvert.DeserializeObject<infoUser>(dataToken.ToString());
                        //đóng form register
                        this.Close();
                        clearError();
                        MessageBox.Show("Đăng ký thành công, vui lòng đăng nhập lại để vào game", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None); ;
                        Login.showFormAgain.Show();
                    }
                }
                else
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    // Phân tích chuỗi JSON
                    JObject jsonData = JObject.Parse(responseData);

                    // Lấy giá trị của thuộc tính "data"
                    JToken dataToken = jsonData["messageErrors"];
                    if (dataToken != null)
                    {
                        JObject dataObject = dataToken.ToObject<JObject>();
                        if (dataObject != null)
                        {
                            errorRegister errors = JsonConvert.DeserializeObject<errorRegister>(dataObject.ToString());
                            //hiển thị lỗi lên trên giao diện
                            displayError(errors);

                            if (string.IsNullOrEmpty(txtConfirmPassword.Text)) errorConfirmPasswordLabel.Text = "Thông tin không được bỏ trống";
                            else
                            {
                                if (string.Equals(txtConfirmPassword.Text, txtPassword.Text))
                                    errorConfirmPasswordLabel.Text = "";
                                else
                                    errorConfirmPasswordLabel.Text = "Mật khẩu không khớp";
                            }
                        }
                    }
                    else
                        errorUserNameLabel.Text = "Username đã tồn tại, vui lòng thay đổi username khác";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng ký, vui lòng thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }

        private void btnComeback_Click(object sender, EventArgs e)
        {
            //đóng form register
            this.Close();
            //mở lại form login
            Login.showFormAgain.Show();
        }

        private void RegisterInterface_Load(object sender, EventArgs e)
        {
            handleLoadInterface.loadInterFace(this, null, pnlContent);
        }
    }
}
