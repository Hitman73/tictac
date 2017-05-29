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
        Game g;
        int hod;
        private string fileName;
        GameState status;

        public FormGame()
        {
            InitializeComponent();
            hod = 0;
            fileName = @"c:\stat.json";
            status = GameState.complete;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                int row = tableLayoutPanel1.GetRow(((Button)sender));
                int column = tableLayoutPanel1.GetColumn(((Button)sender));
                int i = row * 3 + column;
                if (g.getStatusCell(column, row) == typeCell.empty)
                {
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
                }
            }

            //Ходит компьютер
            if (rbComp.Checked && (status == GameState.complete)) {
                bool cell;
                int col = 0, row = 0;
                if ((cell = g.stepComp(typeCell.zero, ref col, ref row)) == true) {
                    setImageToButton(col, row, typeCell.zero);
                    hod = (hod + 1) & 1;
                    chekWin();
                }
                
            }
            if (status != GameState.complete)
            {
                unblockBtnStartGame();
                List<Statistic> list = MySerilize.readResult(fileName);
                list.Add(new Statistic(g.countStep, (int)status));
                MySerilize.saveResult(list, fileName);
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
            try
            {
                btn = (Button)tableLayoutPanel1.GetControlFromPosition(column, row);
                btn.Image = (type == typeCell.zero) ? Properties.Resources.zero : Properties.Resources.cross1;
            }
            catch (System.NullReferenceException) { }
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
                    status = GameState.winerX;
                    MessageBox.Show("Победили крестики");
                }
                else if (winer == typeCell.zero)
                {
                    status = GameState.winerO;
                    MessageBox.Show("Победили нолики");
                }
            }
            else if (g.isNextStep() == false)
            {
                status = GameState.nichay;
                MessageBox.Show("Ничья");
                blockButtons();
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
            status = GameState.complete;
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

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            FormStatistic fs = new FormStatistic();
            fs.dataGridView1.DataSource = MySerilize.readResult(fileName);
            fs.ShowDialog();
        }
    }
}
