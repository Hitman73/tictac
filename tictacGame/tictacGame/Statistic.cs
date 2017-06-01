﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictacGame
{
    public class Statistic
    {
        public int countStep { get; set; }  //всего ходов
        public int winer { get; set; }  // победтель
        public DateTime date { get; set; }  //дата окончания игры
        public Statistic() { }
    public Statistic(int _countStep, int _winer, DateTime _date) {
            countStep = _countStep;
            winer = _winer;
            date = _date;
        }
    }
}
