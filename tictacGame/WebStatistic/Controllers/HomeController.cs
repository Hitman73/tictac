using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tictacGame;

namespace WebStatistic.Controllers
{
    public class HomeController : Controller
    {
        private string fileName = @"c:\webstat.json";
        public ActionResult Index()
        {
            //выведем статистику из файла\
            List<Statistic> list = null;
            try {
                list = MySerilize.readResult(fileName);
            }
            catch { }

            ViewBag.Proc = calcProcent(list);
            ViewBag.List = list;
            return View();
        }

        private float calcProcent(List<Statistic> list) {
            float proc = 0;
            if (list.Count > 0)
            {
                proc = (from i in list where i.winer == 2 select i).Count() * 100.0f / (float)list.Count;
            }
            return proc;
        }
        [HttpPost]
        public string SaveStatistic(int countStep, int winer, DateTime date)
        {
            //сохраним статистику в файл
            List<Statistic> list = new List<Statistic>();
            try
            {
                list = MySerilize.readResult(fileName);
            }
            catch { }
            if (list == null) { list = new List<Statistic>(); }
            list.Add(new Statistic((int)countStep, (int)winer, (DateTime)date));
            MySerilize.saveResult(list, fileName);
            return "Статистика сохранена!";
        }
    }
}