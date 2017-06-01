using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStatistic.Models
{
    public class Statistika
    {
        // ID 
        public int Id { get; set; }
        public int countStep { get; set; }  //всего ходов
        public int winer { get; set; }  // победтель
        public DateTime date { get; set; }  //дата окончания игры
    }
}