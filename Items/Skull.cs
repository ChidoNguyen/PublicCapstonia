﻿using System;
using System.Collections.Generic;
using RogueSharp;
using Capstonia.Core;

namespace Capstonia.Items
{
    public class Skull:  Item
    {
        RogueSharp.Random.DotNetRandom Die = new RogueSharp.Random.DotNetRandom();

        public Skull(GameManager game): base(game)
        {
            Name = "Score";
            Damage = 0;
            Defense = 0;
            Value = ValuePoints();
            History = "ChittyChittyBangBang";
            Interactive = true;
            Consumable = false;
        }

        private int ValuePoints()
        {
            return Die.Next(1, 50); // returns a value for skull object between 1 and 50 inclusive
        }

        public override void AddStat()
        {
            //Should be adding to SCORE here//
        }
        public override void RemoveStat()
        {
            game.messages.AddMessage("Losing is never fun, so not allowed.");
        }

        public override void Broadcast()
        {
            //https://stackoverflow.com/questions/7227413/c-sharp-variables-in-strings //
            string tmp = String.Format("Found {0} worth of Skulls!.", Value);
            game.messages.AddMessage(tmp);
        }

        // UseItem()
        // DESC:    Overrides parent class function and uses the item
        // PARAMS:  None.
        // RETURNS: Bool. True if item is used, False otherwise.
        protected override bool UseItem()
        {
            //If item is picked up
            AddStat();

            //TODO - RETURN FALSE JUST THERE FOR COMPILATION REASONS, WILL UPDATE
            return false;
        }


    }
}