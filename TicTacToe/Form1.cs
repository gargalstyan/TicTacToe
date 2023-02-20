namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<Button> availableButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterButtonEvents();
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

            string[,] ticTacToeBoard = ReturnCurrentState();
            if (CheckWinByColumn(ticTacToeBoard) || CheckWinByDiagonal(ticTacToeBoard) || CheckWinByRow(ticTacToeBoard))
            {
                MessageBox.Show("You win!");
                panelNumpad.Enabled = false;
                return;
            }
            
            ComputerMove();
        }
        private void ComputerMove()
        { 
            if(availableButtons.Count == 0)
            {
                return;
            }
            Random random = new Random();
            Button button = availableButtons[random.Next(0, availableButtons.Count - 1)];
            button.Text = "O";
            button.Enabled = false;
            availableButtons.Remove(button);
            string[,] ticTacToeBoard = ReturnCurrentState();
            if (CheckWinByColumn(ticTacToeBoard) || CheckWinByDiagonal(ticTacToeBoard) || CheckWinByRow(ticTacToeBoard))
            {
                MessageBox.Show("You lose!");
                panelNumpad.Enabled = false;
            }
        }
        private string[,] ReturnCurrentState()
        {
            string currentState = "";
            foreach (Control item in panelNumpad.Controls)
            {
                Button btn = item as Button;
                if (btn == null)
                    continue;
                if (string.IsNullOrEmpty(btn.Text))
                    currentState += " ";
                else
                    currentState += btn.Text;
            }
            char[] charArray = currentState.ToCharArray();
            Array.Reverse(charArray);
            string reverseText = new string(charArray);
            string[,] ticTacToeBoard = new string[3, 3];
            for (int i = 0, k = 0; i < 9 && k < 3; i += 3, k++)
            {
                string column = reverseText.Substring(i, 3);
                for (int j = 0; j < 3; j++)
                {
                    ticTacToeBoard[k, j] = column[j].ToString();
                }
            }
            return ticTacToeBoard;
        }
        private bool CheckWinByColumn(string[,] matrix)
        {
            bool winOrNot = false;
            for (int i = 0; i < 3; i++)
            {
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == "O")
                        countO++;
                    if (matrix[i, j] == "X")
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
        private bool CheckWinByDiagonal(string[,] matrix)
        {
            bool winOrNot = false;
            int countX = 0;
            int countO = 0;
            int countX1 = 0;
            int countO1 = 0;
            for (int i = 0; i < 3; i++)
            {

                if (matrix[i, 3 - 1 - i] == "X")
                    countX++;
                if (matrix[i, 3 - 1 - i] == "O")
                    countO1++;
                if (matrix[i, i] == "O")
                    countO++;
                if (matrix[i, i] == "X")
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
        private bool CheckWinByRow(string[,] matrix)
        {
            bool winOrNot = false;
            for (int i = 0; i < 3; i++)
            {
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[j, i] == "O")
                        countO++;
                    if (matrix[j, i] == "X")
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