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
using Chess_Game_Project.classes;
using Chess_Game_Project.classes_handle;

namespace Chess_Game_Project
{
    public partial class ChangePasswordInterface : Form
    {
        public ChangePasswordInterface()
        {
            InitializeComponent();
            txtConfirmPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';

            clearError();


            errorConfirmPassword.ForeColor = Color.Red;
            errorNewPassword.ForeColor = Color.Green;
        }
        public void clearError()
        {
            errorNewPassword.Text = "";
            errorConfirmPassword.Text = "";
        }
        private void ChangePasswordInterface_Load(object sender, EventArgs e)
        {
            handleLoadInterface.loadInterFace(this, null, pnlContent);
        }
        private string apiResetPassword = "https://chessmates.onrender.com/api/v1/auth/resetPassword";
        private void displayError(errorRegister errors)
        {
            clearError();
            //Truong hop doi voi userName
            if (string.IsNullOrEmpty(txtConfirmPassword.Text)) errorNewPassword.Text = "Thông tin không được bỏ trống";
            else errorConfirmPassword.Text = "Mật khẩu không khớp";
            if (errors.password != null) errorNewPassword.Text = errors.password[0];
        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim())) return;
            var data = new
            {
                password = txtNewPassword.Text.Trim()
            };

            string dataJson = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            // Gửi yêu cầu POST đến apiUrl với dữ liệu jsonData
            HttpResponseMessage response = await client.PostAsync(apiResetPassword, new StringContent(dataJson, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(errorConfirmPassword.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                    Login.showFormAgain.Show();

                    clearError();
                }
            }
            else
            {
                string responseData = await response.Content.ReadAsStringAsync();
                // Phân tích chuỗi JSON
                JObject jsonData = JObject.Parse(responseData);

                // Lấy giá trị của thuộc tính "data"
                JToken dataToken = jsonData["messageErrors"];
                if(dataToken != null)
                {
                    JObject dataObject = dataToken.ToObject<JObject>();
                    errorRegister errors = JsonConvert.DeserializeObject<errorRegister>(dataObject.ToString());
                    //hiển thị lỗi lên trên giao diện
                    if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                        errorConfirmPassword.Text = "";
                    else
                        errorConfirmPassword.Text = "Mật khẩu không khớp";

                    displayError(errors);
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                errorConfirmPassword.Text = "";
            else
                errorConfirmPassword.Text = "Mật khẩu không khớp";
        }


    }
}
