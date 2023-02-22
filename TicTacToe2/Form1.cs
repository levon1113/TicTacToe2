namespace TicTacToe2
{
    public partial class Form1 : Form
    {
        private string[,] board = new string[3, 3]
        {
            {" ", " ", " "},
            {" ", " ", " "},
            {" ", " ", " "}
        };
        private bool playerTurn = true;
        private bool cpuTurn = false;
        private int movesLeft = 9;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterButtonEvents();
            UpdateBoard();
        }

        private void RegisterButtonEvents()
        {
            foreach (var item in this.tableLayoutPanel1.Controls)
            {
                Button btn = item as Button;

                if (btn == null)
                    continue;

                btn.Click += btn_Click;


            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string symbol = board[i, j];
                    Button button = (Button)tableLayoutPanel1.GetControlFromPosition(i,j);
                    button.Text = symbol;
                }
            }
            
        }

        private void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = " ";
                }
            }
            movesLeft = 9;
            playerTurn = true;
            cpuTurn = false;
            UpdateBoard();
        }

        private void btn_Click(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            int col = tableLayoutPanel1.GetColumn(button);
            int row = tableLayoutPanel1.GetRow(button);
            if (playerTurn && board[col,row] == " ")
            {
                board[col, row] = "X";
                playerTurn = false;
                cpuTurn = true;
                UpdateBoard();    
                movesLeft-=1;

                CheckWin();
                if (movesLeft == 0)
                {
                    MessageBox.Show("Draw");
                    ResetGame();
                }
                CpuMove();
            }
        }

        
        private void CpuMove()
        {
            if (cpuTurn)
            {
                int[] move = CpuWinner();
                if (move!=null)
                {
                    int num1 = move[0];
                    int num2 = move[1];
                    board[num1, num2] = "O";
                }
                else
                {
                    Random r = new Random();
                    int ranNum1 = r.Next(0, 3);
                    int ranNum2 = r.Next(0, 3);
                    while (board[ranNum1, ranNum2] != " ")
                    {
                        ranNum1 = r.Next(0, 3);
                        ranNum2 = r.Next(0, 3);
                    }

                    board[ranNum1, ranNum2] = "O";
                }
                
                
                UpdateBoard();
                movesLeft -= 1;

                CheckWin();
                if (movesLeft == 0)
                {
                    MessageBox.Show("Draw");
                    ResetGame();
                }
                playerTurn = true;
            }
                
            
            
        }

        private int[] CpuWinner()
        {
            for (int f = 0; f < 2; f++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] == board[i, 1] && board[i, 0] != " " && board[i, 2] == " ")
                    {
                        if (board[i,0] == "X" && f == 1)
                        {
                            return new int[] { i, 2 };
                        }
                        else if (board[i,0] == "O")
                        {
                            return new int[] { i, 2 };

                        }
                    }
                    if (board[i, 0] == board[i, 2] && board[i, 0] != " " && board[i, 1] == " ")
                    {
                        if (board[i, 0] == "X" && f == 1)
                        {
                            return new int[] { i, 1 };
                        }
                        else if (board[i, 0] == "O")
                        {
                            return new int[] { i, 1 };

                        }
                    }
                    if (board[i, 1] == board[i, 2] && board[i, 1] != " " && board[i, 0] == " ")
                    {
                        if (board[i, 1] == "X" && f == 1)
                        {
                            return new int[] { i, 0 };
                        }
                        else if (board[i, 1] == "O")
                        {
                            return new int[] { i, 0 };

                        }
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (board[0, j] == board[1, j] && board[0, j] != " " && board[2, j] == " ")
                    {
                        if (board[0,j] == "X" && f == 1)
                        {
                            return new int[] { 2,j };
                        }
                        else if (board[0, j] == "O")
                        {
                            return new int[] { 2, j };

                        }
                    }
                    if (board[0, j] == board[2, j] && board[0, j] != " " && board[1, j] == " ")
                    {
                        if (board[0, j] == "X" && f == 1)
                        {
                            return new int[] { 1, j };
                        }
                        else if (board[0, j] == "O")
                        {
                            return new int[] { 1, j };

                        }
                    }
                    if (board[1, j] == board[2, j] && board[1, j] != " " && board[0, j] == " ")
                    {
                        if (board[1, j] == "X" && f == 1)
                        {
                            return new int[] { 0, j };
                        }
                        else if (board[1, j] == "O")
                        {
                            return new int[] { 0, j };

                        }
                    }
                }

                if (board[0, 0] == board[1, 1] && board[0, 0] != " " && board[2, 2] == " ")
                {
                    if (board[0, 0] == "X" && f == 1)
                    {
                        return new int[] { 2, 2 };
                    }
                    else if (board[0, 0] == "O")
                    {
                        return new int[] { 2, 2 };

                    }
                }
                if (board[0, 0] == board[2, 2] && board[0, 0] != " " && board[1, 1] == " ")
                {
                    if (board[0, 0] == "X" && f == 1)
                    {
                        return new int[] { 1, 1 };
                    }
                    else if (board[0, 0] == "O")
                    {
                        return new int[] { 1,1 };

                    }
                }
                if (board[1, 1] == board[2, 2] && board[1, 1] != " " && board[0, 0] == " ")
                {
                    if (board[1, 1] == "X" && f == 1)
                    {
                        return new int[] { 0, 0 };
                    }
                    else if (board[1,1] == "O")
                    {
                        return new int[] { 0,0 };

                    }
                }

                if (board[0, 2] == board[1, 1] && board[0, 2] != " " && board[2, 0] == " ")
                {
                    if (board[0, 2] == "X" && f == 1)
                    {
                        return new int[] { 2, 0 };
                    }
                    else if (board[0, 2] == "O")
                    {
                        return new int[] { 2, 0 };

                    }
                }
                if (board[0, 2] == board[2, 0] && board[0, 2] != " " && board[1, 1] == " ")
                {
                    if (board[0, 2] == "X" && f == 1)
                    {
                        return new int[] { 1, 1 };
                    }
                    else if (board[0, 2] == "O")
                    {
                        return new int[] { 1,1 };

                    }
                }
                if (board[1, 1] == board[2, 0] && board[1, 1] != " " && board[0, 2] == " ")
                {
                    if (board[1, 1] == "X" && f == 1)
                    {
                        return new int[] { 0, 2 };
                    }
                    else if (board[1,1] == "O")
                    {
                        return new int[] { 0, 2 };

                    }
                }
            }
            return null;
        }

        private Control GetCell(int i,int j)
        {
            return tableLayoutPanel1.GetControlFromPosition(i, j);
        }

        private void CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != " ")
                {
                    if (board[i, 0] == "X")
                    {
                        MessageBox.Show("Player Wins");
                        ResetGame();
                    }
                    else if (board[i,0] == "O")
                    {
                        MessageBox.Show("Cpu Wins");
                        ResetGame();

                    }
                    return;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[1, j] != " ")
                {
                    if (board[1, j] == "X")
                    {
                        MessageBox.Show("Player Wins");
                        ResetGame();
                    }
                    else if(board[1, j] == "O")
                    {
                        MessageBox.Show("Cpu Wins");
                        ResetGame();

                    }
                    return;
                }
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != " ")
            {
                if (board[0,0] == "X")
                {
                    MessageBox.Show("Player Wins");
                    ResetGame();
                }
                else if (board[0,0] == "O")
                {
                    MessageBox.Show("Cpu Wins");
                    ResetGame();

                }
                return;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != " ")
            {
                if (board[0,2] == "X")
                {
                    MessageBox.Show("Player Wins");
                    ResetGame();
                }
                else if (board[0,2] == "O")
                {
                    MessageBox.Show("Cpu Wins");
                    ResetGame();

                }
                return;
            }
        }
    }
}