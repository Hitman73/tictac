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
        public typeCell getStatusCell(int numCell)
        {
            return f.getStatusCell(numCell);
        }
        /// <summary>
        /// Установить тип ячейки
        /// </summary>
        /// <param name="numCell">номер ячейки</param>
        /// <param name="status">тип</param>
        public void setStatusCell(int numCell, typeCell status)
        {
            f.setStatusCell(numCell, status);
        }

        /// <summary>
        /// Начать новую игру
        /// </summary>
        public void newGame() { f.emptyFiled(); }

        /// <summary>
        /// Возвращаем номер не занятой ячейки
        /// </summary>
        /// <returns></returns>
        int getCellToStepInRow() {
            int numCell = -1;
            for (int i = 0; i < f.getMapLengtch(); i++)
            {
                if (getStatusCell(i) == typeCell.empty)
                {
                    numCell = i;
                    break;           
                }
            }
            return numCell;
        }
        /// <summary>
        /// Ход компьтера
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        public int stepComp(typeCell type) {
            int val;            
            nextStep();
            val = getCellToStepInRow();
            setStatusCell(val, type);
            return val;
        }
    }
}
