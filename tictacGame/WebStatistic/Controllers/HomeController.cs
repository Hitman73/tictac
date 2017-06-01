using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tictacGame;
using WebStatistic.Models;

namespace WebStatistic.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        StatContext db = new StatContext();
        public ActionResult Index()
        {
            // получаем из бд все объекты
            IEnumerable<Statistika> statistika = db.Stats;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.List = statistika;
            // расчитываем процент побед
            List<Statistika> list = db.Stats.Select(i => i).ToList();
            ViewBag.Proc = calcProcent(list);    
            // возвращаем представление        
            return View();
        }

        private float calcProcent(List<Statistika> list) {
            float proc = 0;
            if (list.Count > 0)
            {
                proc = (from i in list where i.winer == 2 select i).Count() * 100.0f / (float)list.Count;
            }
            return proc;
        }
        [HttpPost]
        public string SaveStatistic(Statistic param)
        {
            Statistika s = new Statistika();
            s.countStep = param.countStep;
            s.date = param.date;
            s.winer = param.winer;
            s.Id = db.Stats.Count() + 1;
            // добавляем информацию о статистике в базу данных
            db.Stats.Add(s);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Статистика сохранена!";
        }
    }
}