using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictacGame
{    
    class Game
    {
        int countStep;   //количество ходов
        private Filed f;
        public Game(int size) {
            f = new Filed(size);
            countStep = size * size;
        }
        /// <summary>
        /// Совершить ход
        /// </summary>
        public void nextStep() { countStep--; }
        /// <summary>
        /// Проверка на разрешение хода
        /// </summary>
        /// <returns></returns>
        public bool isNextStep() {
            return (countStep > 0) ? true : false;
        }
        /// <summary>
        /// Проверка на победу
        /// </summary>
        /// <returns></returns>
        public bool isWin(out typeCell winer) {
            if (f.isWinCross()) {
                winer = typeCell.cross;
                return true;
            } else if (f.isWinZero())
            {
                winer = typeCell.zero;
                return true;
            }

            winer = typeCell.empty;
            return false;
        }
        /// <summary>
        /// Возвращаем статус ячейки
        /// </summary>
        /// <param name="numCell">номер  ячейки</param>
        /// <returns></returns>
        public typeCell getStatusCell(int column, int row)
        {
            return f.getStatusCell(column, row);
        }
        /// <summary>
        /// Установить тип ячейки
        /// </summary>
        /// <param name="numCell">номер ячейки</param>
        /// <param name="status">тип</param>
        public void setStatusCell(int column, int row, typeCell status)
        {
            f.setStatusCell(column, row, status);
        }

        /// <summary>
        /// Начать новую игру
        /// </summary>
        public void newGame() { f.clearFiled(); }

        /// <summary>
        /// Поиск первой не занятой ячейки
        /// </summary>
        /// <param name="coluumn">столбец</param>
        /// <param name="row">строка</param>
        /// <returns></returns>
        bool getCellToStepInRow(ref int column, ref int row) {
            bool numCell = false;
            for (int i = 0; i < f.size; i++)
            {
                for (int j = 0; j < f.size; j++)
                {
                    if (getStatusCell(i,j) == typeCell.empty)
                    {
                        row = i;
                        column = j;
                        numCell = true;
                        break;
                    }
                }
            }
            return numCell;
        }
        /// <summary>
        /// Ход компьтера
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        public bool stepComp(typeCell type, ref int column, ref int row) {
            bool isFind = false;        
            nextStep();
            if ((isFind = getCellToStepInRow(ref column, ref row)) == true) 
                setStatusCell(column, row, type);
            return isFind;
        }
    }
}
