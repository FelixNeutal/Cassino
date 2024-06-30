// See https://aka.ms/new-console-template for more information

using ConsoleGui;
using Domain;
using GameEngine;

Gui gui = new Gui();
Card c1 = new Card()
{
    Suit = ESuit.Clubs,
    Rank = ERank.Ten
};

Card c2 = new Card()
{
    Suit = ESuit.Diamonds,
    Rank = ERank.Six
};
gui.DrawCard(1, 1, c1);
gui.DrawCard(1, 1, c2);