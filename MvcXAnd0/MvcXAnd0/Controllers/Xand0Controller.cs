using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcXAnd0.Models;
namespace MvcXAnd0.Controllers
{
    public class Xand0Controller : Controller
    {
        //
        // GET: /Xand0/

        public ActionResult Index()
        {
            GameModel model = new GameModel()
            {
                CurrentGame = new List<Coord>(),
                EditCoordonate = new Coord()
            };
            HttpContext.Session["game"] = model.CurrentGame;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(GameModel game)
        {
            game.CurrentGame = (List<Coord>)HttpContext.Session["game"];
            Coord generateCoordinate = new Coord();
            game.EditCoordonate.Player = Player.X;
            game.CurrentGame.Add(game.EditCoordonate);
            Random rand = new Random();
            
            var pointIndex = rand.Next(9 - game.CurrentGame.Count + 1);
            int availableIndex = 0;
            int i = 0;
            while(availableIndex != pointIndex && i < 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game.CurrentGame.Any(x => x.CoordX == i && x.CoordY == j) == false)
                    {
                        availableIndex++;
                        if (availableIndex == pointIndex)
                        {
                            generateCoordinate.CoordX = i;
                            generateCoordinate.CoordY = j;
                            generateCoordinate.Player = Player.O;
                            break;
                        }
                    }
                }
                i++;
            }
            
            
           // game.CurrentGame = (List<Coord>)HttpContext.Session["game"];
            //game.CurrentGame.Add(generateCoordinate);
            //game.EditCoordonate.Player = Player.X;
            //game.CurrentGame.Add(game.EditCoordonate);
            if (GameEnd(game, Player.X))
            {
                game.GameEnded = true;
                game.Message = "Player X";
            }
            else
            {
                game.CurrentGame.Add(generateCoordinate);
                if (GameEnd(game, Player.O))
                {
                    game.GameEnded = true;
                    game.Message = "Player O";
                }
                HttpContext.Session["game"] = game.CurrentGame;
                game.EditCoordonate = new Coord();
            }
            return View(game);
        }
        private bool GameEnd(GameModel game, Player play)
        {
            for (int i = 0; i < 3; i++)
            {
                if (game.CurrentGame.Where(x => x.CoordX == i).Count(x => x.Player == play) == 3)
                {
                    return true;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (game.CurrentGame.Where(x => x.CoordY == j).Count(x => x.Player == play) == 3)
                {
                    return true;
                }
            }
            if (game.CurrentGame.Where(x => x.CoordX == x.CoordY).Count(x => x.Player == play) == 3)
            {
                return true;
            }
            if (game.CurrentGame.Where(x => x.CoordY + x.CoordX == 2).Count(x => x.Player == play) == 3)
            {
                return true;
            }
            return false;
        }
        private Coord GenerateCoordinate(GameModel game)
        {
            Coord generateCoordinate = new Coord();
            Random rand = new Random();
            var pointIndex = rand.Next(9 - game.CurrentGame.Count - 1);

            var pointsUsed = game.CurrentGame.Select(point => point.CoordX * 3 + point.CoordY);
            var possiblePoints = Enumerable.Range(0, 8).Where(point => pointsUsed.Contains(point) == false).ToArray();
            int generatedPoint = possiblePoints[pointIndex];
            generateCoordinate.CoordX = generatedPoint / 3;
            generateCoordinate.CoordY = generatedPoint % 3;
            generateCoordinate.Player = Player.O;

            return generateCoordinate;
        }

    }
}
