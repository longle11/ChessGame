using Chess_Game_Project.classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_Game_Project.classes_handle;
using System.Net.Sockets;

namespace Chess_Game_Project
{
    public partial class InfoUserInterface : Form
    {
        private string preUserame;
        private string preEmail;
        private infoUser user;
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string directoryImagePath;
        private string pathImage;
        private string preLinkAvatar;
        private bool checkModify;
        private TcpClient client = null;

        private bool isUpdate = false;

        public InfoUserInterface()
        {
            InitializeComponent();
        }
        private void InfoUserInterface_Load(object sender, EventArgs e)
        {
            txtDefeats.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtID.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtWins.ReadOnly = true;

            handleLoadInterface.loadInterFace(this, null, pnlContent);
        }
        public InfoUserInterface(infoUser user, bool checkModify, TcpClient client) : this()
        {
            try
            {
                this.client = client;
                //đếm số trận thắng và số trận thua
                int numberOfWins = 0, numberOfLosses = 0;
                foreach (match item in user.matches)
                {
                    if (string.Equals(item.status, "finished"))
                    {
                        foreach (matchPlayer player in item.players)
                        {
                            if (string.Equals(player.user, user.id))
                            {
                                if (string.Equals(player.resultMatch.ToLower(), "win"))
                                    numberOfWins++;
                                else
                                    numberOfLosses++;
                            }
                        }
                    }
                }

                directoryImagePath = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
                this.checkModify = checkModify;
                if (checkModify)
                {
                    btnChangeImage.Enabled = false;
                    btnSaveInfo.Enabled = false;
                }
                else
                {
                    btnChangeImage.Visible = false;
                    btnSaveInfo.Visible = false;
                    btnEditInfo.Visible = false;
                }
                this.user = user;

                //hiển thị hình ảnh lên giao diện
                ptboxAvatar.Image = Image.FromFile($"{directoryImagePath}\\" + user.linkAvatar);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

                txtDefeats.Text = numberOfLosses.ToString();
                txtWins.Text = numberOfWins.ToString();
                txtUsername.Text = user.userName;
                txtEmail.Text = user.gmail;
                txtID.Text = user.id;
                //lưu lại thông tin trước đó
                preLinkAvatar = user.linkAvatar;
                preEmail = user.gmail;
                preUserame = user.userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtEmail.ReadOnly = false;

            btnEditInfo.Enabled = false;
            btnChangeImage.Enabled = true;
            btnSaveInfo.Enabled = true;
        }
        private void addImageIntoPath(string directoryPath, string fileImage)
        {
            using (FileStream stream = new FileStream(Path.Combine(directoryPath, fileImage), FileMode.OpenOrCreate))
            {
                byte[] imageData = File.ReadAllBytes(pathImage);

                stream.Write(imageData, 0, imageData.Length);
            }
        }
        private async void btnSaveInfo_Click(object sender, EventArgs e)
        {
            btnEditInfo.Enabled = true;
            btnSaveInfo.Enabled = false;
            btnChangeImage.Enabled = false;
            string apiPath = apiGetUser + user.id;
            //đưa user lên api để kiểm tra API có tồn tại hay không

            var data = new
            {
                userName = txtUsername.Text,
                gmail = txtEmail.Text,
                linkAvatar = user.linkAvatar,
                statusActive = "online"
            };
            if (string.Equals(user.linkAvatar, preLinkAvatar) && string.Equals(user.userName, txtUsername.Text))
            {
                isUpdate = false;
            }
            else
            {
                JToken tkData = await manageApi.callApiUsingMethodPut(data, apiPath);
                if (tkData != null)
                {
                    //lấy dữ liệu thành công
                    MessageBox.Show("Lưu thông tin thành công");
                    //them hinh anh vao trong kho luu tru va tien hanh xoa anh cu khoi kho luu tru

                    if (!File.Exists(Path.Combine(directoryImagePath, user.linkAvatar)))
                        if (user.linkAvatar != preLinkAvatar)
                            //khong tinh truong hop anh mac dinh va xoa hinh anh cu khoi kho luu tru
                            addImageIntoPath(directoryImagePath, user.linkAvatar);

                    //cập nhật lại thông tin
                    user.userName = txtUsername.Text;
                    user.gmail = txtEmail.Text;

                    isUpdate = true;
                }
                else
                {
                    MessageBox.Show("Tên này đã tồn tại, vui lòng nhập tên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //cap nhat user ve lai gia tri ban dau
                    txtUsername.Text = preUserame;
                    txtEmail.Text = preEmail;

                    ptboxAvatar.Image = Image.FromFile($"{directoryImagePath}\\" + preLinkAvatar);
                    ptboxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;


                    user.linkAvatar = preLinkAvatar;

                    txtEmail.ReadOnly = true;
                    txtUsername.ReadOnly = true;
                }
            }

            btnEditInfo.Enabled = true;
            btnChangeImage.Enabled = false;
            btnSaveInfo.Enabled = false;

        }
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName == "") return;
                string[] paths = openFileDialog.FileName.Split('\\');
                user.linkAvatar = paths[paths.Length - 1];

                ptboxAvatar.Image = Image.FromFile(openFileDialog.FileName);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                pathImage = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ảnh không hợp lệ, vui lòng chọn lại ảnh khác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (client != null && isUpdate)
            {
                //gui thong diep cap nhat thong tin cua user
                string message = (int)manageChooseCases.setting.updateInfo + "*" + preUserame + "+" + user.userName + "+" + user.id + "+" + user.linkAvatar + "+" + user.gmail;
                handleChat.sendData(client, message);
            }
            this.Close();
            LobbyInterface.showInter.Show();
        }
    }
}
