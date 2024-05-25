using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlLists : UserControl
    {
        public event EventHandler<EventArgs> btnCloseList_click;
        public event DataGridViewCellEventHandler dtAllUsers_cellContentClick;
        public event DataGridViewCellEventHandler dtListFriends_cellContentClick;
        public event DataGridViewCellEventHandler dtAcceptFriend_cellContentClick;
        public event EventHandler<EventArgs> btnFindUser_click;
        public event EventHandler<EventArgs> btnLoadListAllUsers_click;
        public event EventHandler<EventArgs> btnLoadListFriends_click;
        public event EventHandler<EventArgs> btnLoadListAcceptFriends_click;
        public string username
        {
            get { return txtFindUser.Text; }
        }
        public DataGridView getDtGridViewAllUsers()
        {
            return dtAllUsers;
        }
        public userControlLists()
        {
            InitializeComponent();
        }
        public void selectTabControl(int index)
        {
            tbControls.SelectedIndex = index;
        }
        public void copyData(DataGridView dtgrv, DataGridView currentDtgrv)
        {
            currentDtgrv.Rows.Clear();
            currentDtgrv.Columns.Clear();
            currentDtgrv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            currentDtgrv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            currentDtgrv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            currentDtgrv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            foreach (DataGridViewColumn column in currentDtgrv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //xóa đi dòng cuối cùng trong dataGridView
            currentDtgrv.AllowUserToAddRows = false;
            currentDtgrv.RowHeadersVisible = false;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in currentDtgrv.Columns)
                column.Resizable = DataGridViewTriState.False;
            foreach (DataGridViewRow row in currentDtgrv.Rows)
                row.Resizable = DataGridViewTriState.False;
            foreach (DataGridViewColumn column in dtgrv.Columns)
                currentDtgrv.Columns.Add(column.Clone() as DataGridViewColumn);

            foreach (DataGridViewRow row in dtgrv.Rows)
            {
                int rowIndex = currentDtgrv.Rows.Add(row.Clone() as DataGridViewRow);
                foreach (DataGridViewCell cell in row.Cells)
                    currentDtgrv.Rows[rowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
            }
            currentDtgrv.ReadOnly = true;
        }
        public void copyDataIntoGridAllUsers(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtAllUsers);
            }
            catch (Exception ex)
            {
            }
        }
        public void copyDataIntoGridListFriends(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtListFriends);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi copyDataIntoGridAllUsers: " + ex.Message);
            }
        }
        public void copyDataIntoGridAcceptFriends(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtAcceptFriend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi copyDataIntoGridAllUsers: " + ex.Message);
            }
        }
        public void hideBtnMakeFriend(string userName)
        {
            for (int row = 0; row < dtAllUsers.Rows.Count; row++)
            {
                for (int col = 0; col < dtAllUsers.Rows.Count; col++)
                {
                    DataGridViewCell cell = dtAllUsers.Rows[row].Cells["userName"];
                    if (cell.Value.ToString() == userName)
                    {
                        DataGridViewCell cellMakeFriend = dtAllUsers.Rows[row].Cells[3];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                        return;
                    }
                }
            }
        }
        public void showBtnMakeFriend(string userName)
        {
            for (int row = 0; row < dtAllUsers.Rows.Count; row++)
            {
                for (int col = 0; col < dtAllUsers.Rows.Count; col++)
                {
                    DataGridViewCell cell = dtAllUsers.Rows[row].Cells["userName"];
                    if (string.Equals(cell.Value.ToString(), userName))
                    {
                        //lay ra cot ket ban
                        DataGridViewCell cellMakeFriend = dtAllUsers.Rows[row].Cells[3];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                        return;
                    }
                }
            }
        }
        private void btnCloseList_Click(object sender, EventArgs e)
        {
            btnCloseList_click?.Invoke(this, e);
        }
        private void dtAllUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtAllUsers_cellContentClick?.Invoke(sender, e);
        }
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            btnFindUser_click?.Invoke(this, e);
        }
        private void dtListFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtListFriends_cellContentClick?.Invoke(sender, e);
        }
        private void dtAcceptFriend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtAcceptFriend_cellContentClick?.Invoke(sender, e);
        }
        private void btnLoadListAllUsers_Click(object sender, EventArgs e)
        {
            btnLoadListAllUsers_click?.Invoke(this, e);
        }
        private void btnLoadListFriends_Click(object sender, EventArgs e)
        {
            btnLoadListFriends_click?.Invoke(this, e);
        }
        private void btnLoadListAcceptFriends_Click(object sender, EventArgs e)
        {
            btnLoadListAcceptFriends_click?.Invoke(this, e);
        }
        public void changeUserName(DataGridView currentDgv, string username, string preUsername)
        {
            foreach (DataGridViewRow row in currentDgv.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng header
                if (!row.IsNewRow)
                {
                    // Lấy giá trị trong một cột của dòng hiện tại
                    string value = row.Cells["userName"].Value.ToString();
                    if (string.Equals(value, preUsername))
                    {
                        row.Cells["userName"].Value = username; 
                    }

                }
            }
        }
        public void changeUserNameIntoDataAllUser(string username, string preUsername)
        {
            changeUserName(dtAllUsers, username, preUsername);
        }
        public void changeUserNameIntoDataListFriends(string username, string preUsername)
        {
            changeUserName(dtListFriends, username, preUsername);
        }
        public void changeUserNameIntoDataAcceptFriend(string username, string preUsername)
        {
            changeUserName(dtAcceptFriend, username, preUsername);
        }
        public void changeTextInButtonChat(string difUserName, bool isRead)
        {
            foreach (DataGridViewRow row in dtListFriends.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Lấy giá trị trong một cột của dòng hiện tại
                    string value = row.Cells["userName"].Value.ToString();
                    if (string.Equals(value, difUserName))
                    {
                        DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                        if (!isRead) buttonCell.Value = "Nhắn tin (*)";
                        else buttonCell.Value = "Nhắn tin";
                        row.Cells[4] = buttonCell;
                    }

                }
            }
        }
        public bool checkReadMessageIntoChat()
        {
            foreach (DataGridViewRow row in dtListFriends.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (string.Equals(row.Cells[4].Value.ToString(), "Nhắn tin (*)"))
                        return false;
                }
            }
            return true;
        }
        public void changeTextStatusActiveOffline(string username)
        {
            foreach (DataGridViewRow row in dtListFriends.Rows)
            {
                if (!row.IsNewRow)
                {
                    string value = row.Cells["userName"].Value.ToString();
                    if(string.Equals(value, username))
                    {
                        row.Cells["statusActive"].Value = "offline";
                        DataGridViewCell cellMakeFriend = row.Cells[4];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                    }
                }
            }
        }
        public void changeTextStatusActiveOnline(string username)
        {
            foreach (DataGridViewRow row in dtListFriends.Rows)
            {
                if (!row.IsNewRow)
                {
                    string value = row.Cells["userName"].Value.ToString();
                    if (string.Equals(value, username))
                    {
                        row.Cells["statusActive"].Value = "online";
                        DataGridViewCell cellMakeFriend = row.Cells[4];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                    }
                }
            }
        }
        public bool checkExistsUsernameIntoDataListFriends(string username)
        {
            foreach (DataGridViewRow row in dtListFriends.Rows)
                if (!row.IsNewRow)
                {
                    string value = row.Cells["userName"].Value.ToString();
                    if (string.Equals(value, username))
                        return true;
                }
            return false;
        }
    }
}
