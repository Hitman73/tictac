using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictacGame
{
    public partial class FormGame : Form
    {
        Button[] btns;
        Game g;
         int hod;
        bool isFinishedGame;
        public FormGame()
        {
            InitializeComponent();
            btns = new Button[] { button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9};
            isFinishedGame = false;
            hod = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //for (int i = 0; i < btns.Length; i++)
            {
                //if (((Button)sender) == btns[i]) 
                int row = tableLayoutPanel1.GetRow(((Button)sender));
                int column = tableLayoutPanel1.GetColumn(((Button)sender));
                int i = row * 3 + column;
                {
                    if (g.getStatusCell(column, row) == typeCell.empty)
                    {
                        g.nextStep();
                        if (hod == 0)
                        {
                            setImageToButton(column, row, typeCell.cross);
                        }
                        else
                        {
                            setImageToButton(column, row, typeCell.zero);
                        }
                        g.setStatusCell(column, row, (hod == 0 ? typeCell.cross : typeCell.zero));
                        hod = (hod + 1) & 1;
                        chekWin();
                        //break;
                    }
                    //else { return; }
                }
            }

            if (isFinishedGame == true)
            {
                unblockBtnStartGame();
                return;
            }
            //Ходит компьютер
            if (rbComp.Checked) {
                bool cell;
                int col = 0, row = 0;
                if ((cell = g.stepComp(typeCell.zero, ref col, ref row)) == true) {
                    setImageToButton(col, row, typeCell.zero);
                    hod = (hod + 1) & 1;
                    chekWin();
                }
                
            }
            if (isFinishedGame == true)
            {
                unblockBtnStartGame();
                return;
            }
        }
        /// <summary>
        /// Установка картинки для кнопки(ячейки)
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="type"></param>
        void setImageToButton(int column, int row, typeCell type) {
            Button btn;
            btn = (Button)tableLayoutPanel1.GetControlFromPosition(column, row);
            btn.Image = (type == typeCell.zero) ? Properties.Resources.zero : Properties.Resources.cross1;
            pbNextStep.Image = (type == typeCell.zero) ? Properties.Resources.cross1 : Properties.Resources.zero;
        }/// <summary>
        /// Проверка на победу
        /// </summary>
        void chekWin() {
            typeCell winer;
            if (g.isWin(out winer))
            {
                blockButtons();
                if (winer == typeCell.cross)
                {
                    MessageBox.Show("Победили крестики");
                }
                else if (winer == typeCell.zero)
                {
                    MessageBox.Show("Победили нолики");
                }
                isFinishedGame = true;
            }
            else if (g.isNextStep() == false)
            {
                MessageBox.Show("Ничья");
                blockButtons();
                isFinishedGame = true;
            }
        }
        /// <summary>
        /// Очистка изображения кнопок
        /// </summary>
        void clearButtons() {
            Button btn;
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++) {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    btn = (Button)tableLayoutPanel1.GetControlFromPosition(i, j);
                    btn.Enabled = true;
                    btn.Image = null;
                }
            }
            pbNextStep.Image = Properties.Resources.cross1;
            isFinishedGame = false;
            hod = 0;
        }
       /// <summary>
       /// Блокировка кнопок
       /// </summary>
        void blockButtons() {
            Button btn;
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    btn = (Button)tableLayoutPanel1.GetControlFromPosition(i, j);
                    btn.Enabled = false;
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            g = new Game(3);
            clearButtons();
            g.newGame();
            btnStartGame.Enabled = false;
            reset.Enabled = true;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            btnStartGame.Enabled = true;
            clearButtons();
            reset.Enabled = false;
        }
        /// <summary>
        /// Разблокировка кнопки Начать игру
        /// </summary>
        void unblockBtnStartGame() {
            btnStartGame.Enabled = true;
            reset.Enabled = false;
        }
        
    }
}
