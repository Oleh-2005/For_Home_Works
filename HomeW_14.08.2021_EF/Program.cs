using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using HomeW_14._08._2021_EF.Entiti;

namespace HomeW_14._08._2021_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GamesDB();

            var GTA5 = new Game
            {
                Name = "GTA 5",
                Studio = "Rockstar gaming",
                Stayle = "Action",
                Reliase = new DateTime(2013, 11, 5)
            };
            var CrusaderKings2 = new Game
            {
                Name = "Crusader Kings 2",
                Studio = "Paradox games",
                Stayle = "Strategy",
                Reliase = new DateTime(2012, 9, 11)
            };
            var CrusaderKings3 = new Game
            {
                Name = "Crusader Kings 3",
                Studio = "Paradox games",
                Stayle = "Strategy",
                Reliase = new DateTime(2020, 10, 1)
            };
            context.Games.Add(GTA5);
            context.Games.Add(CrusaderKings3);
            context.Games.Add(CrusaderKings2);
            context.SaveChanges();

            foreach (Game item in context.Games)
            {
                Console.WriteLine($"Id : {item.Id}\tName : {item.Name}\tRealise : {item.Reliase}\tStudio : {item.Studio}\tStyle : {item.Stayle}");
            }
            int numb = 5000000;
            bool multi = true;
            foreach (Game item in context.Games)
            {
                item.NumberOfSells = numb;
                numb -= 1000000;
                item.MultiplayOrNot = multi;
                if (multi)
                {
                    multi = false;
                }
                else{
                    multi = true;
                }
            }
            context.SaveChanges();

        }
    }
}
