// See https://aka.ms/new-console-template for more information

using ConsoleGui;
using Domain;
using GameEngine;

Gui gui = new Gui();

List<Card> cards = new List<Card>()
{
    new Card()
    {
    Suit = ESuit.Clubs,
    Rank = ERank.Ten
},

new Card()
{
    Suit = ESuit.Diamonds,
    Rank = ERank.Six
},

new Card()
{
    Suit = ESuit.Hearts,
    Rank = ERank.Jack
},

new Card()
{
    Suit = ESuit.Spades,
    Rank = ERank.Ace
}   
};

gui.DrawPlayerHand(cards);