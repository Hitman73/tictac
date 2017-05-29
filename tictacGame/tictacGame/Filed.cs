using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictacGame
{
    /// <summary>
    /// Тип ячейки
    /// </summary>
    enum typeCell {empty,   // ячейка пустая
                    cross,  // ячейка с крестиком 
                    zero    // ячейка с ноликом
                    };

    enum GameState {
        complete, // идет игра
        nichay, //ничья
        winerX, //победили крестики
        winerO  //победили нолики
    };
    class Filed
    {
        private typeCell[,] map;
        public int size { get; private set; }
        public Filed(int _size) {
            size = (_size < 2) ? 2 : _size;
            map = new typeCell[size, size];
        }
        /// <summary>
        /// Очистка поля
        /// </summary>
        public void clearFiled()
        {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++)
                {
                    map[i,j] = typeCell.empty;
                }
            }
        }
        /// <summary>
        /// Возвращаем тип ячейки
        /// </summary>
        /// <param name="column">номер колонки</param>
        /// <param name="row">номер строки</param>
        /// <returns></returns>
        public typeCell getStatusCell(int column, int row) {
            try
            {
                return map[row, column];
            }
            catch (System.IndexOutOfRangeException) { return typeCell.empty; }
        }

        /// <summary>
        /// Установить тип ячейки
        /// </summary>
        /// <param name="column">номер колонки</param>
        /// <param name="row">номер строки</param>
        /// <param name="status">тип</param>
        public void setStatusCell(int column, int row, typeCell status)
        {
            try { 
                map[row, column] = status;
             } catch (System.IndexOutOfRangeException) {}
        }

        /// <summary>
        /// Победа по диагонали
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        bool isWinDiagonal(typeCell type) {
            for (int i = 0; i <size; i++)
            {
                if (map[i, i] == type)
                {
                }
                else { return false; }
            }

            return true;
        }
       /// <summary>
       /// Поиск победы по обратной диагонали
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
        bool isWinDiagonal_2(typeCell type)
        {
            for (int i = 0; i < size; i++)
            {
                if (map[i, size-i-1] == type)
                {
                }
                else { return false; }
            }

            return true;
        }
        /// <summary>
        /// Проверка строки на заполненость крестиком или ноликом
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <param name="row">номер строки</param>
        /// <returns></returns>
        private bool checkRow(typeCell type, int row) {
            for (int i = 0; i < size; i++)
            {
                try { 
                    if (map[row, i] == type)
                    {
                    }
                    else { return false; }
                }
                catch (System.IndexOutOfRangeException) { return false; }
        }
            return true;
        }

        /// <summary>
        /// Ищем заполненую строку
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool isWinRow(typeCell type)
        {
            for (int i = 0; i < size; i++)
            {
                if (checkRow(type, i))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Проверка столбца на заполненость крестиком или ноликом
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <param name="row">номер столбца</param>
        /// <returns></returns>
        private bool checkColumn(typeCell type, int column)
        {
            for (int i = 0; i < size; i++)
            {
                try
                {
                    if (map[i, column] == type)
                    {
                    }
                    else { return false; }
                }
                catch (System.IndexOutOfRangeException) { return false; }               
            }
            return true;
        }
        /// <summary>
        /// Ищем заполненый столбец
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        private bool isWinColumn(typeCell type)
        {
            for (int i = 0; i < size; i++)
            {
                if (checkColumn(type, i))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Проверка на выигрыш
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        bool isWin(typeCell type) {
            if (isWinDiagonal(type)) { return true; }
            else if (isWinDiagonal_2(type)) { return true; }
            else if (isWinRow(type)) { return true; }
            else if (isWinColumn(type)) { return true; }
            return false;
        }
        /// <summary>
        /// Победили ли крестики
        /// </summary>
        /// <returns></returns>
        public bool isWinCross()
        {
            return isWin(typeCell.cross);
        }
        /// <summary>
        /// Победили ли нолики
        /// </summary>
        /// <returns></returns>
        public bool isWinZero()
        {
            return isWin(typeCell.zero);
        }
    }
}
