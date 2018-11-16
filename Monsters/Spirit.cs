﻿using Capstonia.Core;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Rectangle = RogueSharp.Rectangle;

namespace Capstonia.Monsters
{
    public class Spirit : Monster
    {
        int oldPlayerX;
        int oldPlayerY;
        // constructor
        public Spirit(GameManager game) : base(game)
        {
            Level = 4;
            // every point above 10 gives a health bonus
            Constitution = 10 + Level;
            // every point above 10 gives a dodge bonus
            Dexterity = 10 + Level;
            // health total for Capstonian; if the values reaches 0, the Capstonain is killed
            MaxHealth = 10 * Level;
            // current health for Capstonian; if the values reaches 0, the Capstonain is killed
            CurrHealth = 10 * Level;
            // max dmg Capstonian can cause
            MaxDamage = 3 * Level;
            // min dmg Capstonain can cause
            MinDamage = 1;
            // name of monster
            Name = "Spirit";
            // every point above 10 gives a dmg bonus
            Strength = 10 + Level;
            //Level = 4;
            MinGlory = 1;
            MaxGlory = 3;
            Sprite = game.spirit;
            oldPlayerX = game.Player.X;
            oldPlayerY = game.Player.Y;
            
        }
    }
}