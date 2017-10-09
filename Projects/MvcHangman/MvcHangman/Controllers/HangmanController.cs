using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHangman.Models;

namespace MvcHangman.Controllers
{
    public class HangmanController : Controller
    {
        private List<string> worlds;
        private readonly int numberOfChoices;
        public HangmanController()
        {
            worlds = new List<string>() { "scoala", "masina", "avion", "carte", "barca", "bicicleta" };
            numberOfChoices = 7;
        }


        public ActionResult Index()
        {


            Random random = new Random();
            int index = random.Next(worlds.Count - 1);
            GameInfo gameInfo = new GameInfo()
            {
                hiddenWorld = worlds[index],
                letterUsed = "",
                lettersAvailable = Enumerable.Range(65, 26)
                    .Select(number => (char)number).Select(c => new SelectListItem() { Text = c.ToString(), Value = Char.ToLower(c).ToString()})
                    .ToList(),
                letterNext = ' '
            };
            foreach (var item in gameInfo.lettersAvailable)
                gameInfo.str = gameInfo.str + item + ",";
            gameInfo.str = gameInfo.str.Remove(gameInfo.str.Length - 1);
            gameInfo.numberChoices = numberOfChoices;
            return View(gameInfo);
        }

        [HttpPost]
        public ActionResult Index(GameInfo gameInfo)
        {
            if (ModelState.IsValid)
            {
                gameInfo.letterUsed += gameInfo.letterNext;
                ModelState.Clear();
            }
            gameInfo.numberChoices = numberOfChoices;
         
            foreach (var alfa in gameInfo.letterUsed)
            {
                if (gameInfo.hiddenWorld.Contains(Char.ToLower(alfa)) == false)
                {
                    gameInfo.numberChoices = gameInfo.numberChoices - 1;
                   
                }

                if (gameInfo.numberChoices == 0)
                {


                    return RedirectToAction("GameOver", "Hangman");
                    
                }
                else
                {
                    
                    if (IsVictory1(gameInfo))
                    {
                        return RedirectToAction("Victory", "Hangman");
                    }
                
                }
                

            }
           

            gameInfo.letterNext = ' ';
            gameInfo.lettersAvailable = Enumerable.Range(65, 26)
            .Select(number => (char)number)
            .Where(c => gameInfo.letterUsed.Contains(Char.ToLower(c)) == false && gameInfo.letterUsed.Contains(c) == false)
            .Select(c => new SelectListItem() {Text = c.ToString(), Value = Char.ToLower(c).ToString()})
            .ToList();
         
            foreach (var item in gameInfo.lettersAvailable)
                gameInfo.str = gameInfo.str + item + ",";
            gameInfo.str = gameInfo.str.Remove(gameInfo.str.Length - 1);
            
            return View(gameInfo);
        }
        public ActionResult GameOver()
        {
            return View();
        }
        public ActionResult Victory()
        {
            return View();
        }
        private bool IsVictory1(GameInfo gameInfo)
        {
            int countLetters = 0;
            bool continueGame = false;
            foreach (char c in gameInfo.hiddenWorld)
            {
                if (gameInfo.letterUsed.Contains(Char.ToLower(c)) == false )
                {
                    continueGame = true;
                    break;
                }
                else
                {
                    countLetters++;
                }
               
            }
            return continueGame == false;
        }

        private bool IsVictory2(GameInfo gameInfo)
        {
            int countLetters = 0;
            foreach (char c in gameInfo.hiddenWorld)
            {
                if (gameInfo.letterUsed.Contains(Char.ToUpper(c)))
                {
                    countLetters++;
                }
                
            }
            return gameInfo.hiddenWorld.Length == countLetters;
        
        }

        private bool IsVictory3(GameInfo gameInfo)
        {
            int countLetters = 0;
            
            foreach (char c in gameInfo.letterUsed)
            {
                countLetters = countLetters + gameInfo.hiddenWorld.Count(h => h == Char.ToLower(c));
            }
            return gameInfo.hiddenWorld.Length == countLetters;

        }



        

    }

}

