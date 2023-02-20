namespace TicTacToe
{
    public partial class Form1 : Form
    {
        int countWinForYou = 0;
        int countWinForComp = 0;
        List<Button> availableButtons = new List<Button>();
        Button[,] ticTacToeBoard = new Button[3,3];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterButtonEvents();
            ticTacToeBoard = CurrentState(availableButtons);
        }
        private void RegisterButtonEvents()
        {
            foreach (Control item in panelNumpad.Controls)
            {
                Button btn = item as Button;
                if (btn == null)
                    continue;
                availableButtons.Add(btn);
                btn.Click += MyClick;
                btn.Enabled = true;

            }
        }
        private void MyClick(object sender, EventArgs e)
        {
            string[,] tictactoeBoard = new string[3, 3];
            Button button = sender as Button;
            button.Text = "X";
            button.Enabled = false;
            availableButtons.Remove(button);

           if (CheckWinByColumn(ticTacToeBoard) || CheckWinByDiagonal(ticTacToeBoard) || CheckWinByRow(ticTacToeBoard))
            {
                MessageBox.Show("You win!");
                panelNumpad.Enabled = false;
                countWinForYou++;
                textBox1.Text = countWinForYou.ToString();
                return;
            }

            ComputerMove();
        }
        private void ComputerMove()
        {
            Button button1 = CheckMovesRow();
            Button button2 = CheckMovesColumn();
            Button button3 = CheckDiagonalMove();
            if (button1 != null)
            {
                button1.Text = "O";
                button1.Enabled = false;
                availableButtons.Remove(button1);
            }
            else if (button2 != null)
            {
                button2.Text = "O";
                button2.Enabled = false;
                availableButtons.Remove(button2);
            }
            else if(button3!=null)
            {
                button3.Text = "O";
                button3.Enabled = false;
                availableButtons.Remove(button3);
            }
            else
            {
                if (availableButtons.Count == 0)
                {
                    return;
                }
                Random random = new Random();
                Button button = availableButtons[random.Next(0, availableButtons.Count - 1)];
                button.Text = "O";
                button.Enabled = false;
                availableButtons.Remove(button);
            }
            
            if (CheckWinByColumn(ticTacToeBoard) || CheckWinByDiagonal(ticTacToeBoard) || CheckWinByRow(ticTacToeBoard))
            {
                MessageBox.Show("You lose!");
                panelNumpad.Enabled = false;
                countWinForComp++;
                textBox2.Text = countWinForComp.ToString();
            }
        }
        private Button[,] CurrentState(List<Button> buttons )
        {   buttons.Reverse();
            Button[,] board = new Button[3, 3];
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = buttons[index++];
                }
            }
            return board;
        }

       
        private bool CheckWinByColumn(Button[,] matrix)
        {
            bool winOrNot = false;
            for (int i = 0; i < 3; i++)
            {
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j].Text == "O")
                        countO++;
                    if (matrix[i, j].Text == "X")
                        countX++;
                }
                if (countO == 3 || countX == 3)
                {
                    winOrNot = true;
                    break;
                }
                else
                    winOrNot = false;

            }
            return winOrNot;
        }
        private Button CheckMovesRow()
        {
            Button button = null;
            for (int i = 0; i < 3; i++)
            {
                Button button1 = null;
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (ticTacToeBoard[j, i].Text == String.Empty)
                        button1 = ticTacToeBoard[j, i];
                    if (ticTacToeBoard[j, i].Text == "O")
                        countO++;
                    if (ticTacToeBoard[j, i].Text == "X")
                        countX++;
                }
                if (countO == 2)
                {
                    button = button1;
                    break;
                }
                else if (countX == 2)
                {
                    button = button1;
                }

            }
            return button;

        }
        private Button CheckMovesColumn()
        {
            Button button = null;
            for (int i = 0; i < 3; i++)
            {
                Button button1 = null;
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (ticTacToeBoard[i, j].Text == String.Empty)
                        button1 = ticTacToeBoard[i, j];
                    if (ticTacToeBoard[i, j].Text == "O")
                        countO++;
                    if (ticTacToeBoard[i, j].Text == "X")
                        countX++;
                }
                if (countO == 2 ) 
                {
                    button = button1;
                    break;
                }
                else if(countX==2)
                {
                    button = button1;
                }

            }
            return button;

        }
        private Button CheckDiagonalMove()
        {
            Button button = null;
            int countX = 0;
            int countO = 0;
            int countX1 = 0;
            int countO1 = 0;
            Button button1 = null;
            Button button2 = null;
            Button button3 = null;
            Button button4 = null;
            for (int i = 0; i < 3; i++)
            {
                if (ticTacToeBoard[i, 3 - 1 - i].Text == String.Empty)
                    button1 = ticTacToeBoard[i, 3 - 1 - i];
                if (ticTacToeBoard[i, i].Text == String.Empty)
                    button2 = ticTacToeBoard[i, i];
                if (ticTacToeBoard[i, 3 - 1 - i].Text == "X")
                    countX++;
                if (ticTacToeBoard[i, 3 - 1 - i].Text == "O")
                    countO1++;
                if (ticTacToeBoard[i, i].Text == "O")
                    countO++;
                if (ticTacToeBoard[i, i].Text == "X")
                    countX1++;

                if (countO == 2 ) 
                {
                    button = button2;
                    break;
                }
                else if(countO1 == 2)
                {
                    button = button1;
                }
                else if(countX == 2) 
                {
                    button = button1;
                }
                else if(countX1 == 2 )
                {
                    button = button2;
                }

            }
            return button;
        }
        private bool CheckWinByDiagonal(Button[,] matrix)
        {
            bool winOrNot = false;
            int countX = 0;
            int countO = 0;
            int countX1 = 0;
            int countO1 = 0;
            for (int i = 0; i < 3; i++)
            {

                if (matrix[i, 3 - 1 - i].Text == "X")
                    countX++;
                if (matrix[i, 3 - 1 - i].Text == "O")
                    countO1++;
                if (matrix[i, i].Text == "O")
                    countO++;
                if (matrix[i, i].Text == "X")
                    countX1++;

                if (countO == 3 || countX == 3 || countX1 == 3 || countO1 == 3)
                {
                    winOrNot = true;
                }
                else
                    winOrNot = false;

            }
            return winOrNot;
        }
        private bool CheckWinByRow(Button[,] matrix)
        {
            bool winOrNot = false;
            for (int i = 0; i < 3; i++)
            {
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[j, i].Text == "O")
                        countO++;
                    if (matrix[j, i].Text == "X")
                        countX++;
                }
                if (countO == 3 || countX == 3)
                {
                    winOrNot = true;
                    break;
                }
                else
                    winOrNot = false;

            }
            return winOrNot;
        }


        private void NewGame_Click(object sender, EventArgs e)
        {
            availableButtons.Clear();
            foreach (Control item in panelNumpad.Controls)
            {
                Button btn = item as Button;
                if (btn == null)
                    continue;
                btn.Text = string.Empty;
                availableButtons.Add(btn);
                btn.Enabled = true;
            }
            panelNumpad.Enabled = true;
        }
    }
}