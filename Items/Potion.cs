﻿using System;
using System.Collections.Generic;
using RogueSharp;
using Capstonia.Core;

namespace Capstonia.Items
{
    public class Potion: Item
    {

        public enum Pots
        {
            Healing,
            Greater_Healing
        }

        private Pots brew;
        public Pots Brew { get { return brew; } set { brew = value; } }
        RogueSharp.Random.DotNetRandom Die = new RogueSharp.Random.DotNetRandom();

        public Potion(GameManager game): base(game)
        {
            Name = "Potion";
            Brew = PotionType();
            Damage = 0;
            Defense = 0;
            Value = HealValue();
            History = "Never too early for a drink.";
            Interactive = true;
            Consumable = true;
        }
        private Pots PotionType()
        {
            Array store = Enum.GetValues(typeof(Pots));
            int x = Die.Next(0, store.Length - 1);
            return (Pots)store.GetValue(x);
        }
        private int HealValue()
        {
            int tmp;

            switch (this.Brew)
            {
                case Pots.Healing:
                    tmp= 5;
                    break;
                case Pots.Greater_Healing:
                    tmp = 10;
                    break;
                default:
                    tmp = 0;
                    break;
            }

            return tmp;
        }

        public override void AddStat()
        {
            game.Player.Health += Value;
            if(game.Player.Health > game.Player.MaxHealth)
            {
                game.Player.Health = game.Player.MaxHealth; // if we heal more than cap, set to cap
            }
        }

        public override void RemoveStat()
        {
            game.messages.AddMessage("No self hurt here.");
        }
        public override void Broadcast()
        {
            game.messages.AddMessage("Cherry-Limeade?");
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