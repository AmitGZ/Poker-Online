﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Poker.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokerClassLibrary
{
    public partial class User
    {
        [NotMapped]
        public const int StartingMoney = 1000;
        public string Username { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
        public virtual UserInGame? UserInGame { get; set; }

        public User()
        {
            Money = StartingMoney;
            UserInGame = null;
        }
    }
}