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
            if(isFinishedGame == true)
            {
                unblockBtnStartGame();
                return;
            };
            for (int i = 0; i < btns.Length; i++) {
                if (((Button)sender) == btns[i]) {
                    if (g.getStatusCell(i) == typeCell.empty)
                    {
                        g.nextStep();
                        if (hod == 0)
                        {
                            setImageToButton(i, typeCell.cross);
                        }
                        else
                        {
                            setImageToButton(i, typeCell.zero);
                        }
                        g.setStatusCell(i, (hod == 0 ? typeCell.cross : typeCell.zero));
                        hod = (hod + 1) & 1;
                        chekWin();
                        break;
                    }
                    else { return; }
                }
            }

            if (isFinishedGame == true)
            {
                unblockBtnStartGame();
                return;
            }
            //Ходит компьютер
            if (rbComp.Checked) {
                int cell;
                if ((cell = g.stepComp(typeCell.zero)) != -1) {
                    setImageToButton(cell, typeCell.zero);
                    hod = (hod + 1) & 1;
                    chekWin();
                }
                
            }
        }
        /// <summary>
        /// Установка картинки для кнопки(ячейки)
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="type"></param>
        void setImageToButton(int cell, typeCell type) {
            btns[cell].Image = (type == typeCell.zero) ? Properties.Resources.zero : Properties.Resources.cross1;
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
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Enabled = true;
                btns[i].Image = null;
            }
            pbNextStep.Image = Properties.Resources.cross1;
            isFinishedGame = false;
            hod = 0;
        }
       /// <summary>
       /// Блокировка кнопок
       /// </summary>
        void blockButtons() {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Enabled = false;
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
