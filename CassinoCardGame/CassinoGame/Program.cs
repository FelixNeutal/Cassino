// See https://aka.ms/new-console-template for more information

using ConsoleGui;
using Controller;
using GameEngine;

Game game = new Game();
Gui gui = new Gui();
GameController controller = new GameController(game, gui);
controller.RunGame();