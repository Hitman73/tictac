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
        private Filed f;
        public int countStep {get; private set;}
        public Game(int size) {
            f = new Filed(size);
            countStep = 0;
        }
        /// <summary>
        /// Проверка на разрешение хода
        /// </summary>
        /// <returns></returns>
        public bool isNextStep() {
            for (int i = 0; i < f.size; i++)
            {
                for (int j = 0; j < f.size; j++)
                {
                    if (getStatusCell(i, j) == typeCell.empty)
                    {
                        return true;
                    }

                }
            }
            return false;
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
            countStep++;
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
            for (int i = 0; i < f.size; i++)
            {
                for (int j = 0; j < f.size; j++)
                {
                    if (getStatusCell(j,i) == typeCell.empty)
                    {
                        row = i;
                        column = j;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Ход компьтера
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        public bool stepComp(typeCell type, ref int column, ref int row) {
            bool isFind = false;        
            if ((isFind = getCellToStepInRow(ref column, ref row)) == true) 
                setStatusCell(column, row, type);
            return isFind;
        }
    }
}
