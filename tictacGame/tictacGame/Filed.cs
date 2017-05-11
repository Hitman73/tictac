using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictacGame
{
    enum typeCell {empty, cross, zero };
    class Filed
    {
        private typeCell[] map;
        public int size { get; private set; }
        public Filed(int _size) {
            size = _size;
            map = new typeCell[size * size];
        }
        /// <summary>
        /// Возвращаем количество ячеек в поле
        /// </summary>
        /// <returns></returns>
        public int getMapLengtch() {
            return map.Length;
        }
        /// <summary>
        /// Очистка поля
        /// </summary>
        public void emptyFiled()
        {
            for (int i = 0; i < map.Length; i++) {
                    map[i] = typeCell.empty;
            }
        }
        /// <summary>
        /// Возвращаем тип ячейки
        /// </summary>
        /// <param name="numCell">номер ячейки</param>
        /// <returns></returns>
        public typeCell getStatusCell(int numCell) {
            return map[numCell];
        }

        /// <summary>
        /// Установить тип ячейки
        /// </summary>
        /// <param name="numCell">номер ячейки</param>
        /// <param name="status">тип</param>
        public void setStatusCell(int numCell, typeCell status)
        {
            if ((numCell >= 0) && (numCell < map.Length))
                 map[numCell] = status;
        }

        /// <summary>
        /// Победа по диагонали
        /// </summary>
        /// <param name="type">тип ячейки</param>
        /// <returns></returns>
        bool isWinDiagonal(typeCell type) {
            for (int i = 0; i <map.Length; i+=size+1)
            {
                if (map[i] == type)
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
            for (int i = size-1; i < map.Length-1; i += size - 1)
            {
                if (map[i] == type)
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
            for (int i = size * row; i < (size * row + 3); i++)
            {
                if (map[i] == type)
                {

                }
                else { return false; }
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
            for (int i = 0; i < size; i ++)
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
            for (int i = column; i < map.Length; i+=3)
            {
                if (map[i] == type)
                {

                }
                else { return false; }
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
