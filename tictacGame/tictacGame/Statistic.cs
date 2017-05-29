using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictacGame
{
    public class Statistic
    {
        public int countStep { get; set; }
        public int winer { get; set; }

        public Statistic() { }
    public Statistic(int _countStep, int _winer) {
            countStep = _countStep;
            winer = _winer; 
        }
    }
}
