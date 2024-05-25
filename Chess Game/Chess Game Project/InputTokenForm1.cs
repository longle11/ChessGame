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
    public partial class InputTokenForm1 : Form
    {
        private string userName;
        private string gmail;
        private string apiInputToken = "https://chessmates.onrender.com/api/v1/auth/getToken/";
        private string apiAuthAccount = "https://chessmates.onrender.com/api/v1/auth/forgotPassword";
        public InputTokenForm1()
        {
            InitializeComponent();
        }
        public InputTokenForm1(string userName, string gmail) : this()
        {
            this.userName = userName;
            this.gmail = gmail;
            btnSendTokenAgain.Enabled = false;
        }
        private async void btnSendTokenAgain_Click(object sender, EventArgs e)
        {
            var data = new
            {
                userName,
                gmail
            };
            JToken dtToken = await manageApi.callApiUsingMethodPost(data, apiAuthAccount);
            if(dtToken != null)
            {
                btnSendTokenAgain.Enabled = false;
                MessageBox.Show("Vui lòng kiểm tra email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }else
            {
                btnSendTokenAgain.Enabled = true;
                MessageBox.Show("Gửi thất bại, vui lòng thực hiện lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void InputTokenForm1_Load(object sender, EventArgs e)
        {
            handleLoadInterface.loadInterFace(this, null, pnlContent);
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAuth.Text.Trim())) return;
            string api = apiInputToken + txtAuth.Text.Trim();
            JToken tkData = await manageApi.callApiUsingMethodPost(new {}, api);
            if(tkData != null)
            {
                this.Close();
                MessageBox.Show("Xác nhận thành công, vui lòng thực hiện bước tiếp theo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                ChangePasswordInterface pw = new ChangePasswordInterface();
                pw.Show();
            }
            else
            {
                MessageBox.Show("Mã đã hết hạn, vui lòng thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnSendTokenAgain.Enabled = true;
                txtAuth.Clear();
            }
        }
    }
}
