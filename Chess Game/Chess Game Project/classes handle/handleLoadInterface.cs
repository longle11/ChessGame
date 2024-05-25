using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.classes_handle
{
    internal class handleLoadInterface
    {
        public static void loadInterFace(Form form, Panel pnlCoverPage, Panel pnlContent)
        {
            // Thiết lập kích thước form
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = (int)(screenWidth * 0.8);
            int formHeight = (int)(screenHeight * 0.9);
            form.Size = new Size(formWidth, formHeight);

            // Đặt vị trí của form để nằm chính giữa màn hình
            int left = (screenWidth - formWidth) / 2;
            int top = (screenHeight - formHeight) / 2;
            form.Location = new Point(left, top);

            if (pnlCoverPage != null)
            {
                pnlCoverPage.Size = form.Size;
                // Đưa Panel vào chính giữa màn hình
                pnlContent.Location = new Point((pnlCoverPage.Width - pnlContent.Width) / 2,
                                            (pnlCoverPage.Height - pnlContent.Height) / 2);
                form.TransparencyKey = Color.Empty;
            }
            else
            {
                // Đưa Panel vào chính giữa màn hình
                pnlContent.Location = new Point((form.Width - pnlContent.Width) / 2,
                                            (form.Height - pnlContent.Height) / 2);
            }
        }
    }
}
