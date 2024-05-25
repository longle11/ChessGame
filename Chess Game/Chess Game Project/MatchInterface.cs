using Chess_Game_Project.classes;
using Chess_Game_Project.classes_handle;
using Chess_Game_Project.ContainUserControls;
using Chess_Game_Project.CryptoGraphy;
using chessgames.backPieces;
using chessgames.whitePieces;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Chess_Game_Project
{
    public partial class MatchInterface : Form
    {
        #region pieces
        //khai báo các quân cờ đen
        private BlackPawn blackPawn = new BlackPawn();
        private BlackRock1 blackRock1 = new BlackRock1();
        private BlackRock2 blackRock2 = new BlackRock2();
        private BlackKnight1 blackKnight1 = new BlackKnight1();
        private BlackKnight2 blackKnight2 = new BlackKnight2();
        private BlackBiShop1 blackBiShop1 = new BlackBiShop1();
        private BlackBiShop2 blackBiShop2 = new BlackBiShop2();
        private BlackQueen blackQueen = new BlackQueen();
        private BlackKing blackKing = new BlackKing();
        //khai báo các quân cờ trắng
        private WhitePawn whitePawn = new WhitePawn();
        private WhiteKnight1 whiteKnight1 = new WhiteKnight1();
        private WhiteKnight2 whiteKnight2 = new WhiteKnight2();
        private WhiteBiShop1 whiteBiShop1 = new WhiteBiShop1();
        private WhiteBiShop2 whiteBiShop2 = new WhiteBiShop2();
        private WhiteKing whiteKing = new WhiteKing();
        private WhiteQueen whiteQueen = new WhiteQueen();
        private WhiteRock1 whiteRock1 = new WhiteRock1();
        private WhiteRock2 whiteRock2 = new WhiteRock2();
        #endregion

        #region boolsChess
        private bool whiteTurn;
        private bool blackTurn;
        private bool gameOver = false;
        private bool castlingBlackRock1 = true;
        private bool castlingBlackRock2 = true;
        private bool castlingBlackKing = true;
        private bool castlingWhiteRock1 = true;
        private bool castlingWhiteRock2 = true;
        private bool checkEnable = false;
        private bool castlingWhiteKing = true;
        private bool isCreated;
        private bool canNotMove = false; // ngăn không cho đối phương di chuyển khi user chọn thành công quân cờ mới
        private bool isChoose = true; //trường này khi quân tốt di chuyển tới cuối bàn cờ thì nếu chọn quân mới rồi mới được quyền đánh
        private bool setUpTimer = false;
        private bool setUpTimerThread = false;
        #endregion

        #region integers
        private int beforeMove_X;
        private int beforeMove_Y;
        private int getChangMove_X;
        private int getChangMove_Y;
        private int move;
        private int portConnect = 8080;
        private int playerMoved = 0;
        private int castlingPiece = 0;
        private int changePieceValue = 0;
        private int piece = -1;
        private int countTime = 60;
        private int setUpTime = 60;
        private int iconNumbers = 29;
        private int betPoint = 0;
        private int currentScore = 0;
        private int currentDifPlayerScore = 0;
        #endregion

        #region info user
        private string matchId;
        private string ipConnectRoom;
        private string parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
        private string myIp;
        private string difIp;
        private int port = 1000;
        #endregion

        #region apiPath
        private string apiResultMatch = "https://chessmates.onrender.com/api/v1/matches/edit/resultMatch/";
        private string apiUpdateScore = "https://chessmates.onrender.com/api/v1/users/updatePoint/";
        private string apiGetUserId = "https://chessmates.onrender.com/api/v1/users/";
        private string apiDeleteRoom = "https://chessmates.onrender.com/api/v1/matches/delete/";
        #endregion

        #region variable
        private ChessBoard chessboard = new ChessBoard();
        private userControlClick[,] tableBackground;
        private int[,] WhiteStaleArray = new int[8, 8];
        private int[,] BlackStaleArray = new int[8, 8];
        private Thread serverRcvData = null;
        private Thread clientRcvData = null;
        private Thread threadWaiting = null;
        private Stream stream = null;
        private TcpClient client = null;
        private TcpListener server = null;
        private List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>();
        private List<System.Windows.Forms.Button> buttonListIcons = new List<System.Windows.Forms.Button>();
        private infoUser difPlayer = null;
        private infoUser currentPlayer = null;
        private System.Windows.Forms.Button oldButton = new System.Windows.Forms.Button()
        {
            Height = 0,
            Width = 0
        };
        private button btn = new button();
        private UdpClient clientUDP = null;
        private Thread rcvDataUDPThread = null;
        private IPEndPoint ipEndPoint = null;
        private System.Windows.Forms.Timer timer = null;
        public static int posY = 0;
        public static MatchInterface showInter = null;
        public TcpClient currentTcpClient = null;
        #endregion


        private void MatchInterface_Load(object sender, EventArgs e)
        {
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
            // Đưa System.Windows.Forms.Panel vào chính giữa màn hình
            pnlContent.Location = new Point((this.Width - pnlContent.Width) / 2,
                                        (this.Height - pnlContent.Height) / 2);
            pnlContent.BackColor = Color.Transparent;
            pnlContent.Parent = this;
            this.TransparencyKey = Color.Empty;
            pnlContent.BringToFront();

            listChat.Parent = pnlChatClientFrame;
            pnlContainsIcon.Parent = pnlChatClientFrame;
            pnlContainsIcon.BringToFront();

            if (isCreated)
                MessageBox.Show("Bạn là quân cờ trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show("Bạn là quân cờ đen", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void displayAnncount(bool whiteTurn, bool blackTurn)
        {
            if (whiteTurn && !blackTurn) //quân trắng được di chuyển trước
                txtTurnUser.BackColor = Color.White;
            else
                txtTurnUser.BackColor = Color.Black;
        }
        private void addTextBoxIntoPanelHorizontal(System.Windows.Forms.Panel pnl)
        {
            for (int i = 0; i < 8; i++)
            {
                int posX = i == 0 ? 0 : i * 50;
                int posY = pnl.Height / 2 - 15 / 2;
                System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox()
                {
                    Size = new Size(50, 15),
                    Location = new Point(posX, posY),
                };
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                tb.Font = new Font(tb.Font, FontStyle.Bold);
                tb.Text = Convert.ToString((char)('a' + i));
                tb.BackColor = Color.DarkSeaGreen;
                tb.ReadOnly = true;
                pnl.Controls.Add(tb);
            }
        }
        private void addTextBoxIntoPanelVertical(System.Windows.Forms.Panel pnl)
        {
            for (int i = 0; i < 8; i++)
            {
                int posX = i == 0 ? 0 : i * 50;
                int posY = pnl.Width / 2 - 15 / 2;
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button()
                {
                    Size = new Size(15, 50),
                    Location = new Point(posY, posX),
                };
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.DarkSeaGreen;
                btn.Text = Convert.ToString(i + 1);
                btn.Enabled = true;
                pnl.Controls.Add(btn);
            }
        }
        public MatchInterface()
        {
            InitializeComponent();

            showInter = this;

            pnlContainsIcon.Hide();
            txtCountTime.ReadOnly = true;
            txtCountTime.Text = countTime.ToString();

            //tạo một ma trận có kích thước 8 * 8
            chessboard.Board = new int[8, 8]
            {
                { 02, 03, 04, 05, 06, 09, 08, 07},
                { 01, 01, 01, 01, 01, 01, 01, 01},
                { 00, 00, 00, 00, 00, 00, 00, 00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 11, 11, 11, 11, 11, 11, 11, 11},
                { 12, 13, 14, 15, 16, 19, 18, 17},
            };

            chessboard.PossibleMoves = new int[8, 8];
            tableBackground = new userControlClick[8, 8];

            CheckForIllegalCrossThreadCalls = false;
            //horizontal
            System.Windows.Forms.Panel pnl = new System.Windows.Forms.Panel()
            {
                Size = new Size(400, 15),
                Location = new Point(80, 3)  //310
            };
            System.Windows.Forms.Panel pnl1 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Width, pnl.Size.Height),
                Location = new Point(pnl.Location.X, pnl.Location.Y + 50 * 8 + 25)
            };
            addTextBoxIntoPanelHorizontal(pnl);
            addTextBoxIntoPanelHorizontal(pnl1);
            pnlContainChessBoard.Controls.Add(pnl);
            pnlContainChessBoard.Controls.Add(pnl1);

            //vertical
            System.Windows.Forms.Panel pnl2 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Height, pnl.Size.Width),
                Location = new Point(60, 20)
            };

            System.Windows.Forms.Panel pnl3 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Height, pnl.Size.Width),
                Location = new Point(pnl2.Location.X + 50 * 8 + 25, pnl2.Location.Y)
            };
            addTextBoxIntoPanelVertical(pnl2);
            addTextBoxIntoPanelVertical(pnl3);
            pnlContainChessBoard.Controls.Add(pnl2);
            pnlContainChessBoard.Controls.Add(pnl3);

            for (int i = 0; i < 8; i++) // tượng trưng cho các dòng
            {
                for (int j = 0; j < 8; j++) //tượng trưng cho các cột
                {
                    tableBackground[i, j] = new userControlClick();
                    tableBackground[i, j].Parent = pnlContainChessBoard;
                    tableBackground[i, j].Location = new Point(j * 50 + 80, i * 50 + 20);
                    tableBackground[i, j].posX = j;
                    tableBackground[i, j].posY = i;
                    tableBackground[i, j].Size = new Size(50, 50);
                    tableBackground[i, j].Click += tableBackground_Click;
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
                    tableBackground[i, j].BackgroundImageLayout = ImageLayout.Center;
                }
            }
        }
        public MatchInterface(string myIp, string difIp, string matchId, string ipConnectRoom, bool isCreated, bool turn, int piece, int betPoint, infoUser difPlayer, infoUser currentPlayer, TcpClient currentTcpClient) : this()
        {
            this.myIp = myIp;
            this.difIp = difIp;
            this.isCreated = isCreated;
            this.matchId = matchId;
            this.betPoint = betPoint;
            this.difPlayer = difPlayer;
            this.currentPlayer = currentPlayer;
            this.ipConnectRoom = ipConnectRoom;
            this.currentTcpClient = currentTcpClient;

            //chủ phòng sẽ là cờ trắng và biến piece = 0
            lbCurrentPlayer.Text = currentPlayer.userName;
            avtCurrentPlayer.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + currentPlayer.linkAvatar);
            avtCurrentPlayer.SizeMode = PictureBoxSizeMode.Zoom;

            if (isCreated) // đây là người tạo phòng cũng tương đương với server
            {
                //đây là lượt mà chủ phòng sẽ được đánh trước
                whiteTurn = turn;
                blackTurn = !turn;
                displayAnncount(whiteTurn, blackTurn);
                clientUDP = new UdpClient(port);
                rcvDataUDPThread = new Thread(new ThreadStart(rcvDataUDP));
                rcvDataUDPThread.Start();

                this.piece = piece;
                server = new TcpListener(IPAddress.Any, portConnect);
                server.Start();
                threadWaiting = new Thread(new ThreadStart(waitingAnotherClient));
                threadWaiting.Start();
            }
            else //đây sẽ là người sẽ tham gia vào phòng chơi
            {
                try
                {
                    //đây là lượt mà người còn lại sẽ được đánh
                    blackTurn = turn;
                    whiteTurn = !turn;
                    displayAnncount(whiteTurn, blackTurn);
                    //người chơi sẽ là cờ đen và biến piece = 1
                    this.piece = piece;
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(ipConnectRoom), portConnect);

                    //tạo ra đối tượng UDP
                    clientUDP = new UdpClient(port);
                    ipEndPoint = new IPEndPoint(IPAddress.Parse(difIp), port);

                    string message = "<<<+" + JsonConvert.SerializeObject(currentPlayer) + "+" + myIp + "+>>>";
                    string encryptData = encryptAndDecryptData.EncryptMessage(message);
                    byte[] sendData = Encoding.UTF8.GetBytes(encryptData);

                    clientUDP.Send(sendData, sendData.Length, ipEndPoint);


                    lbDifPlayer.Text = difPlayer.userName;
                    avtDifPlayer.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + difPlayer.linkAvatar);
                    avtDifPlayer.SizeMode = PictureBoxSizeMode.Zoom;

                    rcvDataUDPThread = new Thread(new ThreadStart(rcvDataUDP));
                    rcvDataUDPThread.Start();

                    clientRcvData = new Thread(new ThreadStart(rcvData));
                    clientRcvData.Start();
                    timer = new System.Windows.Forms.Timer();
                    timer.Tick += Timer_Tick;
                    timer.Interval = 1;
                    setUpTimer = true;
                    setUpTimerThread = true;
                    timer.Start();
                    player.players += 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                    return;
                }
            }
            // hàm kiểm tra ô nào chứa quân cờ
            getPiecesOnBoard();
            // hiển thị danh sách các quân cờ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //hiển thị các quân cờ lên trên giao diện
                    choose(i, j);
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (setUpTimer)
            {
                timer.Interval = 1000;
            }
            txtCountTime.Text = countTime.ToString();
            sendMove(0, 0, 1, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ

            countTime--;
            if (countTime == 0)
            {
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
                displayAnncount(whiteTurn, blackTurn);
                countTime = setUpTime;
                clearMove();
                //thực hiện việc xóa các nút có màu đỏ trong list view nếu có
                for (int i = 0; i < buttonList.Count; i++)
                {
                    if (buttonList[i].BackColor == Color.Red)
                        buttonList[i].BackColor = Color.Transparent;
                }
            }
            if (setUpTimerThread)
            {
                timer.Interval = 1;
                setUpTimerThread = false;
            }
        }
        private void getPiecesOnBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // kiểm tra xem thử các quân cờ nào có thể được quyền di chuyển
                    if (chessboard.Board[i, j] != 0)
                    {
                        if (piece == 0)
                        {
                            if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                        else if (piece == 1)
                        {
                            if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        chessboard.PossibleMoves[i, j] = 0;
                    }
                }
            }
        }
        private System.Drawing.Image choose(int i, int j)
        {
            switch (chessboard.Board[i, j])
            {
                case 00: tableBackground[i, j].BackgroundImage = null; break;
                //Đây là trường hợp của các quân cờ đen
                case 01: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackPawn.png"); break;
                case 02: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackRock.png"); break;
                case 03: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKnight.png"); break;
                case 04: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackBiShop.png"); break;
                case 05: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackQueen.png"); break;
                case 06: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKing.png"); break;
                case 07: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackRock.png"); break;
                case 08: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKnight.png"); break;
                case 09: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackBiShop.png"); break;
                //đây là trường hợp của các quân cờ trắng
                case 11: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhitePawn.png"); break;
                case 12: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteRock.png"); break;
                case 13: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKnight.png"); break;
                case 14: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteBiShop.png"); break;
                case 15: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteQueen.png"); break;
                case 16: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKing.png"); break;
                case 17: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteRock.png"); break;
                case 18: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKnight.png"); break;
                case 19: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteBiShop.png"); break;
            }
            return tableBackground[i, j].BackgroundImage;
        }
        //hàm hiển thị các quân cờ lên bàn cờ
        private void displayPieces(int posY, int posX, int beforeY, int beforeX)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if ((posY == i && posX == j) || ((beforeY == i && beforeX == j)))
                        //hiển thị các quân cờ lên trên giao diện
                        choose(i, j);
            //lưu lại tất cả các nước di chuyển của các quân cờ
            staleArrays();
            //kiểm tra xem quân vua có đang bị chiếu tướng hay không
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //hàm lưu lại vị trí di chuyển của các quân cờ
        private void staleArrays()
        {
            //dùng để lưu mọi nước đi của người chơi
            //đối với các quân cờ đen
            BlackStaleArray = new int[8, 8];
            BlackStaleArray = whitePawn.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteQueen.isStale(chessboard.Board, BlackStaleArray);
            //đối với các quân cờ trắng
            WhiteStaleArray = new int[8, 8];
            WhiteStaleArray = blackPawn.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackQueen.isStale(chessboard.Board, WhiteStaleArray);
        }
        private void tableBackground_Click(object sender, EventArgs e)
        {
            //sự kiện khi click vào 1 quân cờ bất kỳ
            afterClickOnTable((sender as userControlClick).posX, (sender as userControlClick).posY);
        }
        private void afterClickOnTable(int j, int i)
        {
            // khi client chưa tham gia phòng đấu thì không được phép làm gì cả
            if (isCreated && client == null)
            {
                MessageBox.Show("Game chưa bắt đầu, vui lòng đợi người chơi còn lại");
                return;
            }
            else
            {
                if (isChoose)
                {
                    // i tương đương với posY, j tương đương với posX
                    switch (chessboard.PossibleMoves[i, j])
                    {
                        // dùng để lưu lại việc tính toán các đường đi có sẵn của quân cờ
                        // lưu lại vị trí của các quân cờ đã chọn 
                        case 1: //1: tương đương với các quân cờ có thể chọn
                            possibleMovesByPieces(chessboard.Board[i, j], j, i);
                            beforeMove_Y = i;
                            beforeMove_X = j;
                            break;
                        case 2: //2: tương đương với những ô quân cờ có thể di chuyển
                            move = 0;
                            succesfulMove(j, i);
                            break;
                        // khi người dùng hủy việc chọn quân thì vị trí trên bàn cờ sẽ bị xóa
                        case 3: //3: tương đương với quân cờ được chọn
                            clearMove();
                            break;
                        case 4:
                            handleCastling(j, i);
                            break;
                    }
                    //kiểm tra việc chiếu tướng
                    chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn quân cờ thay thế");
                    return;
                }
            }
        }
        private void handleCastling(int posX, int posY)
        {

            if (chessboard.Board[posY, posX] == 2 || chessboard.Board[posY, posX] == 7 || chessboard.Board[posY, posX] == 12 || chessboard.Board[posY, posX] == 17)
            {
                //lưu lại nước di chuyển để gửi cho đối phương
                for (int index = 0; index < 20; index++)
                {
                    if (chessboard.Board[beforeMove_Y, beforeMove_X] == index)
                    {
                        playerMoved = index;
                    }
                }
                //quân đen nhập thành
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == 06)
                {
                    castlingPiece = 1; //quân đen nhập thành
                    //sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
                    if (!gameOver)
                        sendMove(posY, posX, 0, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                    if (posY == 0 && posX == 0 && chessboard.Board[posY, posX] == 02)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[0, 2] = 06;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[0, 3] = 02;
                        chessboard.Board[0, 0] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(0, 2, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(0, 3, 0, 0);
                    }
                    if (posY == 0 && posX == 7 && chessboard.Board[posY, posX] == 07)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[0, 6] = 06;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[0, 5] = 07;
                        chessboard.Board[0, 7] = 00;
                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(0, 6, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(0, 5, 0, 7);
                    }
                }
                //quân trắng nhập thành
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == 16)
                {
                    castlingPiece = 2; //quân trắng nhập thành
                    //sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
                    if (!gameOver)
                        sendMove(posY, posX, 0, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                    if (posY == 7 && posX == 0 && chessboard.Board[posY, posX] == 12)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[7, 2] = 16;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[7, 3] = 12;
                        chessboard.Board[7, 0] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(7, 2, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xercvData
                        displayPieces(7, 3, 7, 0);
                    }
                    if (posY == 7 && posX == 7 && chessboard.Board[posY, posX] == 17)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[7, 6] = 16;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[7, 5] = 17;
                        chessboard.Board[7, 7] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(7, 6, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(7, 5, 7, 7);
                    }
                }


                if (timer != null)
                {
                    //cập nhật lại thời gian
                    setUpTimer = true;
                    timer.Interval = 1;
                    countTime = setUpTime;
                }
                else
                {
                    //cập nhật lại thời gian
                    sendMove(0, 0, 1, setUpTime, 0);
                }
                clearMove();
                everyPossibleMoves();
                //kiểm tra xem có bị chiếu tướng hay không
                checkmateChecker(posY, posX);
                //chuyển lượt người chơi
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
                displayAnncount(whiteTurn, blackTurn);
            }
        }
        //numberOfPiece là số kí hiệu của quân cờ trên bàn cờ và X, Y là vị trí của quân cờ đó trên bàn cờ
        private void possibleMovesByPieces(int numberOfPiece, int posX, int posY)
        {
            //khi chọn vào 1 quân cờ mới thì vị trí của quân cờ cũ sẽ bị clear đi
            clearMove();

            //kiểm tra nếu đang bị chiếu tướng thì không thể nhập thành
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 06)
                    {
                        castlingBlackKing = false;
                    }
                    else if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 16)
                    {
                        castlingWhiteKing = false;
                    }
                }
            }
            switch (numberOfPiece)
            {
                //thuật toán đường di chuyển của quân tốt
                case 1:
                    chessboard.PossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 2:
                    chessboard.PossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 3:
                    chessboard.PossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 4:
                    chessboard.PossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 5:
                    chessboard.PossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 6:
                    chessboard.PossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
                    break;
                case 7:
                    chessboard.PossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 8:
                    chessboard.PossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 9:
                    chessboard.PossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 11:
                    chessboard.PossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 12:
                    chessboard.PossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 13:
                    chessboard.PossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 14:
                    chessboard.PossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 15:
                    chessboard.PossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 16:
                    chessboard.PossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
                    break;
                case 17:
                    chessboard.PossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 18:
                    chessboard.PossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 19:
                    chessboard.PossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
            }
            //những vị trí mà quân cờ được lựa chọn sẽ có giá trị là 3
            chessboard.PossibleMoves[posY, posX] = 3;
            removeMoveThatNotPossible(numberOfPiece, posY, posX);
            //hiển thị các vị trí mà quân cờ có thể di chuyển
            showPossibleMoves();
        }
        //hiển thị ra đường đi chỉ dẫn cho các quân cờ
        private void showPossibleMoves()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.PossibleMoves[i, j] == 2)
                    {
                        tableBackground[i, j].BackColor = Color.Yellow;
                        move++;
                    }
                    if (chessboard.PossibleMoves[i, j] == 4)
                    {
                        tableBackground[i, j].BackColor = Color.Green;
                        move++;
                    }
                    if (chessboard.PossibleMoves[i, j] == 3)
                        tableBackground[i, j].BackColor = Color.Blue;
                }
            }
            //kiểm tra xem quân vua có đang bị chiếu tướng hay không
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //xóa đường đi của các quân cờ trước đó
        private void clearMove()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.Board[i, j] != 0)
                    {
                        if (piece == 0)
                        {
                            if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                        else if (piece == 1)
                        {
                            if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        chessboard.PossibleMoves[i, j] = 0;
                    }
                }
            }
            //thay đổi lại màu của bàn cờ sau khi người dùng hủy việc chọn quân cờ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
                }
            }
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        private void listPieceKilled(int posY, int posX, int beforeMove_Y, int beforeMove_X)
        {
            //loại bỏ trường hợp khi nhập thành
            bool checkCastlingBlackPiece = chessboard.Board[beforeMove_Y, beforeMove_X] == 06 && (chessboard.Board[posY, posX] == 2 || chessboard.Board[posY, posX] == 7);
            bool checkCastlingWhitePiece = chessboard.Board[beforeMove_Y, beforeMove_X] == 16 && (chessboard.Board[posY, posX] == 12 || chessboard.Board[posY, posX] == 17);
            if (checkCastlingBlackPiece) { }
            else if (checkCastlingWhitePiece) { }
            else
            {
                if (choose(posY, posX) != null)
                {
                    //đưa quân cờ bị ăn vào trong System.Windows.Forms.Panel
                    System.Windows.Forms.Button btn1 = null;
                    if (buttonList.Count % 5 == 0)
                    {
                        if (buttonList.Count != 0)
                            oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                        btn1 = btn.createButton(oldButton, pnlContainPieces, choose(posY, posX), chessboard.Board[posY, posX].ToString(), whiteTurn);
                        btn1.Click += Btn1_Click;
                    }
                    else
                    {
                        btn1 = btn.createButton(buttonList[buttonList.Count - 1], pnlContainPieces, choose(posY, posX), chessboard.Board[posY, posX].ToString(), whiteTurn);
                        btn1.Click += Btn1_Click;
                    }
                    btn.numberOfPiece = chessboard.Board[posY, posX];
                    buttonList.Add(btn1);
                }
            }
        }
        //hàm thực hiện việc di chuyển khi người dùng chọn đúng vào nước đi hợp lệ
        private void succesfulMove(int posX, int posY)
        {
            castlingPiece = 0;
            changePieceValue = 0;
            if (timer != null)
            {
                //cập nhật lại thời gian
                setUpTimer = true;
                timer.Interval = 1;
                countTime = setUpTime;
            }
            else
            {
                //cập nhật lại thời gian
                sendMove(0, 0, 1, setUpTime, 0);
            }

            //lưu lại nước di chuyển để gửi cho đối phương
            for (int index = 0; index < 20; index++)
            {
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == index)
                {
                    playerMoved = index;
                }
            }

            bool checkCanMove = false;
            //kiểm tra xem người dùng đã thay thế quân tốt bằng quân khác hay chưa mà đã di chuyển
            if (buttonList.Count != 0)
            {
                for (int index = 0; index < buttonList.Count; index++)
                {
                    if (buttonList[index].BackColor == Color.Red)
                    {
                        checkCanMove = true;
                        break;
                    }
                }
            }

            if (checkCanMove)
            {
                MessageBox.Show("Bạn không thể di đánh khi chưa thay thế quân cờ mới");
                clearMove();
                return;
            }

            //chứa danh sách các quân cờ sau khi bị loại khỏi danh sách
            listPieceKilled(posY, posX, beforeMove_Y, beforeMove_X);

            //dùng cho việc nhập thành và khi quân tốt đến cuối bàn cờ địch thì sẽ được chọn quân mới
            castlingAndPawnPromotionChecker(posY, posX);

            //đây là vị trí cũ nơi mà ta sẽ gửi quân cờ đến vị trí mới
            chessboard.Board[posY, posX] = chessboard.Board[beforeMove_Y, beforeMove_X];

            //thiết lập vị trí cũ quân cờ là 0
            chessboard.Board[beforeMove_Y, beforeMove_X] = 0;
            //vẽ lại bàn cờ
            displayPieces(posY, posX, beforeMove_Y, beforeMove_X);
            clearMove();
            everyPossibleMoves();
            ////kiểm tra xem có bị chiếu tướng hay không
            checkmateChecker(posY, posX);

            ////sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
            if (!gameOver && !canNotMove)
                sendMove(posY, posX, 0, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
            if (!canNotMove)
            {
                //chuyển lượt người chơi
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
                displayAnncount(whiteTurn, blackTurn);
            }

        }
        //hiển thị bị chiếu tướng và kết thúc game
        private async void checkmateChecker(int i, int j)
        {
            if (move == 0)
            {
                //mặc định player1 là người thắng còn player2 là người thua
                var obj = new
                {
                    player1 = currentPlayer.id + '-' + "win",
                    player2 = difPlayer.id + '-' + "lose"
                };
                await manageApi.callApiUsingMethodPut(obj, apiResultMatch + matchId);
                //cập nhật lại điểmm cho người thắng
                await manageApi.callApiUsingMethodPut(new { point = currentPlayer.point + betPoint }, apiUpdateScore + currentPlayer.id);
                //cập nhật lại điểm cho người thua
                await manageApi.callApiUsingMethodPut(new { point = difPlayer.point - betPoint }, apiUpdateScore + difPlayer.id);
                //thực hiện gửi dữ liệu xử lý thoát khỏi phòng
                JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + currentPlayer.id);
                if (tkData != null)
                {
                    infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                    this.currentPlayer = user;
                    //tạo lại giao diện mới
                    MessageBox.Show("Bạn đã thắng");

                    gameOver = true;
                    sendMove(i, j, 0, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                    StopGame();
                    string message = (int)manageChooseCases.setting.finishedRoom + "*" + currentPlayer.userName + "+" + JsonConvert.SerializeObject(currentPlayer) + "+" + matchId;
                    handleChat.sendData(currentTcpClient, message);
                    this.Close();
                    LobbyInterface.showInter.Show();
                }
            }
        }
        //hàm được sử dụng cho việc nhập thành và khi quân tốt đến cuối bàn cờ địch thì sẽ được chọn quân mới
        private void castlingAndPawnPromotionChecker(int i, int j)
        {
            //khi người chơi tiến hành di chuyển quân xe hoặc vua của mình thì sẽ không thể nhập thành nữa
            switch (chessboard.Board[beforeMove_Y, beforeMove_X])
            {
                case 2:
                    castlingBlackRock1 = false;
                    break;
                case 6:
                    castlingBlackKing = false;
                    break;
                case 7:
                    castlingBlackRock2 = false;
                    break;
                case 12:
                    castlingWhiteRock1 = false;
                    break;
                case 16:
                    castlingWhiteKing = false;
                    break;
                case 17:
                    castlingWhiteRock2 = false;
                    break;
            }

            //Xử lý việc chọn quân cờ khi quân tốt ra khỏi bàn cờ vua
            if (chessboard.Board[beforeMove_Y, beforeMove_X] == 11) //kiểm tra xem tốt trắng đã lên cuối hàng hay chưa
            {
                if (i == 0)
                {
                    checkEnable = true;
                    getChangMove_X = j;
                    getChangMove_Y = i;
                    bool checkCanChange = false;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) > 11)
                        {
                            buttonList[index].BackColor = Color.Red;
                            checkCanChange = true;
                        }
                    }
                    if (checkCanChange)
                    {
                        canNotMove = true;
                        isChoose = false;
                        MessageBox.Show("Vui lòng chọn 1 quân trắng để thay thế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        isChoose = true;
                        if (timer != null)
                        {
                            //cập nhật lại thời gian
                            setUpTimer = true;
                            timer.Interval = 1;
                            countTime = setUpTime;
                        }
                        else
                        {
                            //cập nhật lại thời gian
                            sendMove(0, 0, 1, setUpTime, 0);
                        }
                        checkEnable = false;
                    }
                }
            }
            else if (chessboard.Board[beforeMove_Y, beforeMove_X] == 01) //kiểm tra xem tốt đen đã xuống cuối hàng hay chưa
            {
                if (i == 7)
                {
                    checkEnable = true;
                    getChangMove_X = j;
                    getChangMove_Y = i;
                    bool checkCanChange = false;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) < 10 && int.Parse(buttonList[index].Text) > 1)
                        {
                            buttonList[index].BackColor = Color.Red;
                            checkCanChange = true;
                        }
                    }
                    if (checkCanChange)
                    {
                        canNotMove = true;
                        isChoose = false;
                        MessageBox.Show("Vui lòng chọn 1 quân đen để thay thế");
                    }
                    else
                    {
                        isChoose = true;
                        if (timer != null)
                        {
                            //cập nhật lại thời gian
                            setUpTimer = true;
                            timer.Interval = 1;
                            countTime = setUpTime;
                        }
                        else
                        {
                            //cập nhật lại thời gian
                            sendMove(0, 0, 1, setUpTime, 0);
                        }
                        checkEnable = false;
                    }
                }
            }
        }
        //sự kiện người dùng chọn quân cờ mới để thay thế quân tốt
        private void everyPossibleMoves()
        {
            chessboard.AllPossibleMoves = new int[8, 8];
            whiteTurn = !whiteTurn;
            blackTurn = !blackTurn;
            for (int numberOfPiece = 1; numberOfPiece < 20; numberOfPiece++)
            {
                for (int posY = 0; posY < 8; posY++)
                {
                    for (int posX = 0; posX < 8; posX++)
                    {
                        if (chessboard.Board[posY, posX] == numberOfPiece)
                        {
                            switch (numberOfPiece)
                            {
                                case 1:
                                    chessboard.AllPossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 2:
                                    chessboard.AllPossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 3:
                                    chessboard.AllPossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 4:
                                    chessboard.AllPossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 5:
                                    chessboard.AllPossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 6:
                                    chessboard.AllPossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
                                    break;
                                case 7:
                                    chessboard.AllPossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 8:
                                    chessboard.AllPossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 9:
                                    chessboard.AllPossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 11:
                                    chessboard.AllPossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 12:
                                    chessboard.AllPossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 13:
                                    chessboard.AllPossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 14:
                                    chessboard.AllPossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 15:
                                    chessboard.AllPossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 16:
                                    chessboard.AllPossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
                                    break;
                                case 17:
                                    chessboard.AllPossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 18:
                                    chessboard.AllPossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 19:
                                    chessboard.AllPossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                            }
                            removeMoveThatNotPossible2(numberOfPiece, posY, posX);
                        }
                    }
                }
            }
            //đổi lượt lại cho người chơi khác
            whiteTurn = !whiteTurn;
            blackTurn = !blackTurn;
        }
        private void removeMoveThatNotPossible(int numberOfPiece, int posY, int posX)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.PossibleMoves[i, j] == 2)
                    {
                        int selectPiece = chessboard.Board[i, j];
                        // mô phỏng vị trí mới của quân cờ
                        chessboard.Board[i, j] = numberOfPiece;
                        chessboard.Board[posY, posX] = 0;
                        //cập nhật lại các đường đi cho các mảng cũ
                        staleArrays();
                        //2 điều kiện này sẽ kiểm tra trong mảng cũ có chứa quân vua hay không
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn)   //đây là trường hợp dành cho quân trắng
                            chessboard.PossibleMoves[i, j] = 0; //tiến hành xóa đi vị trí có thể đi của quân cờ
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && !whiteTurn)  //đây là trường hợp dành cho quân đen
                            chessboard.PossibleMoves[i, j] = 0;
                        //thiết lập về lại vị trí ban đầu của quân cờ
                        chessboard.Board[i, j] = selectPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;

                        //cập nhật lại các đường đi cho các mảng cũ
                        staleArrays();
                    }
                }
            }
        }
        private void removeMoveThatNotPossible2(int numberOfPiece, int posY, int posX)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.AllPossibleMoves[i, j] == 2)
                    {
                        int lastHitPiece = chessboard.Board[i, j];
                        chessboard.Board[i, j] = numberOfPiece;
                        chessboard.Board[posY, posX] = 0;
                        staleArrays();
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn && !blackTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && blackTurn && !whiteTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 0)
                            move++;
                        chessboard.Board[i, j] = lastHitPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;
                        staleArrays();
                    }
                }
            }
            chessboard.AllPossibleMoves = new int[8, 8];
        }
        //============================================  HÀM NHẬN VÀ GỬI DỮ LIỆU ===========================================================
        // Hàm gửi sự kiện chọn 1 quân cờ thay thế
        private void Btn1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (checkEnable)
            {
                // đây là trường hợp dành cho quân trắng đi trước
                if (int.Parse(btn.Text) == 01 || int.Parse(btn.Text) == 11)
                {
                    MessageBox.Show("Bạn không được chọn quân tốt làm quân thay thế");
                    return;
                }
                if (btn.BackColor == Color.Red)
                {
                    chessboard.Board[getChangMove_Y, getChangMove_X] = int.Parse(btn.Text);
                    changePieceValue = int.Parse(btn.Text);

                    //thực hiện việc xóa các nút có màu đỏ
                    for (int i = 0; i < buttonList.Count; i++)
                    {
                        if (buttonList[i].BackColor == Color.Red)
                            buttonList[i].BackColor = Color.Transparent;
                    }
                    //thay thế quân cờ đã chọn bằng quân tốt
                    if (btn.TabIndex == 1) //tương đương với quân tốt đen
                    {
                        btn.Image = null;
                        btn.BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackPawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "01";
                    }
                    else if (btn.TabIndex == 0) //tương đương với quân tốt trắng
                    {
                        btn.Image = null;
                        btn.BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhitePawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "11";
                    }
                    if (timer != null)
                    {
                        //cập nhật lại thời gian
                        setUpTimer = true;
                        timer.Interval = 1;
                        countTime = setUpTime;
                    }
                    else
                    {
                        //cập nhật lại thời gian
                        sendMove(0, 0, 1, setUpTime, 0);
                    }
                    checkEnable = false;
                    //chuyển lượt người chơi
                    whiteTurn = !whiteTurn;
                    blackTurn = !blackTurn;
                    displayAnncount(whiteTurn, blackTurn);
                    //sau khi đã chọn quân mới
                    isChoose = true;

                    //gửi giá trị trị này tới bàn cờ đối phương
                    sendMove(getChangMove_Y, getChangMove_X, 0, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ

                    canNotMove = false;//cập nhật lại sau khi chọn
                    displayPieces(getChangMove_Y, getChangMove_X, beforeMove_Y, beforeMove_X);
                }
            }
            else
            {
                MessageBox.Show("Bạn không thể thực hiện thao tác này");
                return;
            }
        }
        // hàm nận dữ liệu xử lý trên bàn cờ
        private void rcvData()
        {
            try
            {
                while (true)
                {
                    byte[] buffers = new byte[12];
                    stream = client.GetStream();
                    int length = stream.Read(buffers, 0, buffers.Length);
                    if (length > 0)
                    {
                        //xử lý khi 1 người chơi thoát khỏi phòng 
                        if (buffers[11] == 1) //người chơi này thoát khỏi phòng đấu
                        {
                            MessageBox.Show("Bạn đã thắng, vui lòng bấm thoát để rời phòng");
                            gameOver = true;
                            return;
                        }
                        if (buffers[8] == 0)
                        {
                            //chứa danh sách các quân cờ sau khi bị loại khỏi danh sách
                            listPieceKilled(buffers[3], buffers[4], buffers[1], buffers[2]);
                            //đổi lượt
                            whiteTurn = !whiteTurn;
                            blackTurn = !blackTurn;
                            displayAnncount(whiteTurn, blackTurn);
                            if (buffers[6] == 0)
                            {
                                //thay đổi lại vị trí của người chơi cũ
                                chessboard.Board[buffers[1], buffers[2]] = 0;
                                //cập nhật lại vị trí mới
                                chessboard.Board[buffers[3], buffers[4]] = buffers[0];
                            }
                            //dùng cho việc nhập thành
                            if (buffers[6] == 1) //dành cho nhập thành quân đen
                            {
                                if (buffers[3] == 0 && buffers[4] == 0 && chessboard.Board[buffers[3], buffers[4]] == 02)
                                {
                                    //hoán đổi vị trí của quân vua
                                    chessboard.Board[0, 2] = 06;
                                    chessboard.Board[buffers[1], buffers[2]] = 00;
                                    //hoán đổi vị trí của quân xe
                                    chessboard.Board[0, 3] = 02;
                                    chessboard.Board[0, 0] = 00;

                                    //vẽ lại vị trí của quân vua
                                    displayPieces(0, 2, buffers[1], buffers[2]);
                                    //vẽ lại vị trí của quân xe
                                    displayPieces(0, 3, 0, 0);
                                }
                                if (buffers[3] == 0 && buffers[4] == 7 && chessboard.Board[buffers[3], buffers[4]] == 07)
                                {
                                    //hoán đổi vị trí của quân vua
                                    chessboard.Board[0, 6] = 06;
                                    chessboard.Board[buffers[1], buffers[2]] = 00;
                                    //hoán đổi vị trí của quân xe
                                    chessboard.Board[0, 5] = 07;
                                    chessboard.Board[0, 7] = 00;

                                    //vẽ lại vị trí của quân vua
                                    displayPieces(0, 6, buffers[1], buffers[2]);
                                    //vẽ lại vị trí của quân xe
                                    displayPieces(0, 5, 0, 7);
                                }
                                staleArrays();
                                chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                                continue;
                            }
                            else if (buffers[6] == 2)//dành cho nhập thành quân trắng
                            {
                                if (buffers[3] == 7 && buffers[4] == 0 && chessboard.Board[buffers[3], buffers[4]] == 12)
                                {
                                    //hoán đổi vị trí của quân vua
                                    chessboard.Board[7, 2] = 16;
                                    chessboard.Board[buffers[1], buffers[2]] = 00;
                                    //hoán đổi vị trí của quân xe
                                    chessboard.Board[7, 3] = 12;
                                    chessboard.Board[7, 0] = 00;

                                    //vẽ lại vị trí của quân vua
                                    displayPieces(7, 2, buffers[1], buffers[2]);
                                    //vẽ lại vị trí của quân xe
                                    displayPieces(7, 3, 7, 0);
                                }
                                if (buffers[3] == 7 && buffers[4] == 7 && chessboard.Board[buffers[3], buffers[4]] == 17)
                                {
                                    //hoán đổi vị trí của quân vua
                                    chessboard.Board[7, 6] = 16;
                                    chessboard.Board[buffers[1], buffers[2]] = 00;
                                    //hoán đổi vị trí của quân xe
                                    chessboard.Board[7, 5] = 17;
                                    chessboard.Board[7, 7] = 00;

                                    //vẽ lại vị trí của quân vua
                                    displayPieces(7, 6, buffers[1], buffers[2]);
                                    //vẽ lại vị trí của quân xe
                                    displayPieces(7, 5, 7, 7);

                                }

                                staleArrays();
                                chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                                continue;
                            }

                            //dùng cho việc hoán đổi quân cờ khi quân tốt di chuyển đến cuối bàn cờ
                            if (buffers[7] != 0)
                            {
                                chessboard.Board[buffers[3], buffers[4]] = buffers[7];
                            }

                            displayPieces(buffers[3], buffers[4], buffers[1], buffers[2]);
                            staleArrays();

                            for (int i = 0; i < 8; i++)
                                for (int j = 0; j < 8; j++)
                                    if (i % 2 == 0)
                                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                                        else tableBackground[i, j].BackColor = Color.White;
                                    else
                                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                                    else tableBackground[i, j].BackColor = Color.Brown;
                            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);

                            if (buffers[5] == 0)
                            {
                                MessageBox.Show("Bạn đã thua, vui lòng bấm thoát để rời phòng");
                                gameOver = true;
                            }
                        }
                        else if (buffers[8] == 1)
                        {
                            if (buffers[10] == setUpTime)
                            {
                                countTime = buffers[10] + 1;
                                setUpTimerThread = true;
                                setUpTimer = true;
                            }
                            else
                            {
                                if (buffers[9] - 1 == 0)
                                {
                                    whiteTurn = !whiteTurn;
                                    blackTurn = !blackTurn;
                                    displayAnncount(whiteTurn, blackTurn);
                                    clearMove();
                                }
                                //hiển thị lên giao diện
                                txtCountTime.Text = buffers[9].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void sendMove(int posY, int posX, int mode, int countAgain, int outRoom)
        {
            try
            {
                if (client != null)
                {
                    //ta sẽ gửi 1 mảng byte chứa stt của quân cờ, vị trí hiện tại của quân cờ, vị trí mới mà quân cờ sẽ di chuyển
                    //giá trị để kiểm tra xem quân vua có bị chiếu tướng hay không, giá trị nhập thành và giá trị quân cờ mới sẽ thay khi tốt đến cuối bàn cờ
                    byte[] dataSends = { (byte)playerMoved, (byte)beforeMove_Y, (byte)beforeMove_X, (byte)posY, (byte)posX, (byte)move, (byte)castlingPiece, (byte)changePieceValue, (byte)mode, (byte)countTime, (byte)countAgain, (byte)outRoom };
                    stream = client.GetStream();
                    stream.Write(dataSends, 0, dataSends.Length);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void rcvDataUDP()
        {
            try
            {
                while (true)
                {
                    ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receive_buffer = clientUDP.Receive(ref ipEndPoint);
                    string data = Encoding.UTF8.GetString(receive_buffer);
                    string decryptData = encryptAndDecryptData.DecryptMessage(data);
                    //đây sẽ là nơi mà chủ phòng nhận dữ liệu từ người chơi
                    if (decryptData.Contains("<<<") && decryptData.Contains(">>>"))
                    {
                        string[] lst = decryptData.Split('+');
                        this.difPlayer = JsonConvert.DeserializeObject<infoUser>(lst[1]);
                        lbDifPlayer.Text = difPlayer.userName;
                        difIp = lst[2];
                        avtDifPlayer.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + difPlayer.linkAvatar);
                        avtDifPlayer.SizeMode = PictureBoxSizeMode.Zoom;

                        MessageBox.Show($"{difPlayer.userName} đã tham gia vào phòng chơi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        string[] strs = decryptData.Split(':');
                        if (strs[0].Contains("(1)"))    //đây là chat 
                            handleChat.writeData(null, strs[2], strs[1], 1, strs[0].Substring(0, strs[0].Length - 3), listChat, this, posY, currentPlayer.userName, parentDirectory, null, pnlContainsIcon);
                        else if (strs[0].Contains("(2)")) // đây là gửi icon
                        {
                            string imageData = strs[1];
                            byte[] convertedBytes = Convert.FromBase64String(imageData);
                            // Chuyển đổi mảng byte thành hình ảnh
                            using (MemoryStream stream = new MemoryStream(convertedBytes))
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                handleChat.writeData(image, strs[2], "", 2, strs[0].Substring(0, strs[0].Length - 3), listChat, this, posY, currentPlayer.userName, parentDirectory, null, pnlContainsIcon);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            handleChat.displayListIconsIntoInterface(pnlContainsIcon, 7);
            foreach (System.Windows.Forms.Button btnChat in handleChat.buttonListIcons)
                btnChat.Click += btnSendIcon_click;
        }
        private void btnSendIcon_click(object sender, EventArgs e)
        {
            if (player.players == 2)
            {
                ipEndPoint = new IPEndPoint(IPAddress.Parse(difIp), port);
                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
                string path = btn.Text;
                byte[] imageBytes = File.ReadAllBytes(path);
                string encryptData = encryptAndDecryptData.EncryptMessage(currentPlayer.userName + "(2):" + Convert.ToBase64String(imageBytes) + ":" + currentPlayer.linkAvatar);
                byte[] data = Encoding.UTF8.GetBytes(encryptData);

                clientUDP.Send(data, data.Length, ipEndPoint);

                handleChat.writeData(System.Drawing.Image.FromFile(path), currentPlayer.linkAvatar, "", 2, currentPlayer.userName, listChat, this, posY, currentPlayer.userName, parentDirectory, null, pnlContainsIcon);
            }
            pnlContainsIcon.Hide();
            buttonListIcons.Clear();
        }
        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (player.players == 2)
            {
                if (string.Equals(txtMessage.Text.Trim(), ""))
                    return;
                string data = $"{currentPlayer.userName}(1):" + txtMessage.Text.Trim() + ":" + currentPlayer.linkAvatar;
                if (txtMessage.Text.Trim().Contains(':'))
                {
                    MessageBox.Show("Không được phép nhập kí tự \":\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    string encryptData = encryptAndDecryptData.EncryptMessage(data);
                    ipEndPoint = new IPEndPoint(IPAddress.Parse(difIp), port);
                    byte[] send_buffer = Encoding.UTF8.GetBytes(encryptData);
                    clientUDP.Send(send_buffer, send_buffer.Length, ipEndPoint);
                    handleChat.writeData(null, currentPlayer.linkAvatar, txtMessage.Text.Trim(), 1, currentPlayer.userName, listChat, this, posY, currentPlayer.userName, parentDirectory, null, pnlContainsIcon);
                }

            }
            txtMessage.Clear();
        }
        private void waitingAnotherClient()
        {
            while (true)
            {
                if (player.players == 2)
                {
                    client = server.AcceptTcpClient();
                    serverRcvData = new Thread(new ThreadStart(rcvData));
                    serverRcvData.Start();
                    break;
                }
            }
        }
        //==================================================================================================================================

        //============================================  CÁC SỰ KIỆN KHÁC ===================================================================

        private async void btnOutRoom_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + currentPlayer.id);
                if (tkData != null)
                {
                    infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                    this.currentPlayer = user;


                    //gửi sự kiện tới server 
                    string message = (int)manageChooseCases.setting.finishedRoom + "*" + currentPlayer.userName + "+" + JsonConvert.SerializeObject(currentPlayer) + "+" + matchId;
                    handleChat.sendData(currentTcpClient, message);
                    StopGame();
                    this.Close();
                    LobbyInterface.showInter.Show();
                }
            }
            else
            {
                DialogResult dgResult = MessageBox.Show("Bạn có chắc muốn thoát khỏi phòng", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgResult == DialogResult.Yes)
                {
                    //kiểm tra xem trong phòng có 2 hay 1 người
                    if (player.players == 2)
                    {
                        //mặc định player1 là người thắng còn player2 là người thua
                        var obj = new
                        {
                            player1 = difPlayer.id + '-' + "win",
                            player2 = currentPlayer.id + '-' + "lose"
                        };
                        await manageApi.callApiUsingMethodPut(obj, apiResultMatch + matchId);
                        //cập nhật lại điểmm cho người thắng
                        await manageApi.callApiUsingMethodPut(new { point = difPlayer.point + betPoint }, apiUpdateScore + difPlayer.id);
                        //cập nhật lại điểm cho người thua
                        await manageApi.callApiUsingMethodPut(new { point = currentPlayer.point - betPoint }, apiUpdateScore + currentPlayer.id);
                        //thực hiện gửi dữ liệu xử lý thoát khỏi phòng

                        JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + currentPlayer.id);
                        if (tkData != null)
                        {
                            infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                            this.currentPlayer = user;
                            //tạo lại giao diện mới
                            MessageBox.Show("Bạn đã thua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                            sendMove(0, 0, 0, 0, 1);
                            //gửi sự kiện tới server 
                            string message = (int)manageChooseCases.setting.finishedRoom + "*" + currentPlayer.userName + "+" + JsonConvert.SerializeObject(currentPlayer) + "+" + matchId;
                            handleChat.sendData(currentTcpClient, message);
                        }
                    }
                    else
                    {
                        //nếu phòng chỉ có 1 người thì xóa luôn phòng này
                        await manageApi.callApiUsingDeleteMethod(apiDeleteRoom + matchId);
                        //xoa phong doi voi tat ca nguoi choi dang online
                        string message = (int)manageChooseCases.setting.deleteRoom + "*" + matchId;
                        handleChat.sendData(currentTcpClient, message);
                    }
                    gameOver = true;
                    posY = 0;
                    StopGame();
                    this.Close();
                    LobbyInterface.showInter.Show();
                }
            }
        }
        private void StopGame()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    chessboard.PossibleMoves[i, j] = 0;

            pnlChatClientFrame.Controls.Clear();
            posY = 0;

            //kết thúc timer
            if (timer != null)
                timer.Stop();
            if (threadWaiting != null)
                threadWaiting.Abort();
            //đóng server
            if (server != null)
                server.Stop();
            if (client != null)
                client.Close();
            if (serverRcvData != null)
                serverRcvData.Abort();
            if (clientRcvData != null)
                clientRcvData.Abort();

            if (clientUDP != null)//đóng kết nối UDP
            {
                clientUDP.Close();
            }
            if (rcvDataUDPThread != null)
            {
                rcvDataUDPThread.Abort();
            }  //đóng luồng dữ liệu của việc nhận dữ liệu chat 

            //cập nhật user.players về lại 1
            player.players = 1;
        }
        //==================================================================================================================================
    }
}
