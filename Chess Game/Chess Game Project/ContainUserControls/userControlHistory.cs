using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlHistory : UserControl
    {
        public userControlHistory()
        {
            InitializeComponent();
        }
        public DataGridView dtGridView
        {
            get
            {
                return dtGridViewHistory;
            }
        }
        public void copyDataIntoGridListHistories(DataGridView dtgrv)
        {
            dtGridViewHistory.Rows.Clear();
            dtGridViewHistory.Columns.Clear();
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtGridViewHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtGridViewHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridViewHistory.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            //xóa đi dòng cuối cùng trong dataGridView
            dtGridViewHistory.AllowUserToAddRows = false;
            dtGridViewHistory.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dtGridViewHistory.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridViewHistory.Columns)
                column.Resizable = DataGridViewTriState.False;
            foreach (DataGridViewRow row in dtGridViewHistory.Rows)
                row.Resizable = DataGridViewTriState.False;
            foreach (DataGridViewColumn column in dtgrv.Columns)
                dtGridViewHistory.Columns.Add(column.Clone() as DataGridViewColumn);

            foreach (DataGridViewRow row in dtgrv.Rows)
            {
                int rowIndex = dtGridViewHistory.Rows.Add(row.Clone() as DataGridViewRow);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dtGridViewHistory.Rows[rowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }

            dtGridViewHistory.ReadOnly = true;
            dtGridViewHistory.RowTemplate.Height = 45;
        }
        public event EventHandler<EventArgs> btnCloseHistory_click;
        private void btnCloseHistory_Click(object sender, EventArgs e)
        {
            btnCloseHistory_click?.Invoke(this, e);
        }
        public void changeUserName(DataGridView currentDgv, string username, string preUsername)
        {
            foreach (DataGridViewRow row in currentDgv.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng header
                if (!row.IsNewRow)
                {
                    // Lấy giá trị trong một cột của dòng hiện tại
                    string value1 = row.Cells["userName1"].Value.ToString();
                    if (string.Equals(value1, preUsername))
                    {
                        row.Cells["userName1"].Value = username;
                    }
                    string value2 = row.Cells["userName2"].Value.ToString();
                    if (string.Equals(value2, preUsername))
                    {
                        row.Cells["userName2"].Value = username;
                    }
                }
            }
        }
        public void changeUserNameIntoDataHistory(string username, string preUsername)
        {
            changeUserName(dtGridView, username, preUsername);
        }
        public event EventHandler<EventArgs> btnLoadListHistory_click;
        private void btnLoadListHistory_Click(object sender, EventArgs e)
        {
            btnLoadListHistory_click?.Invoke(this, e);
        }
    }
}
