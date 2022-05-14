﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poker.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokerClassLibrary
{
    public partial class Room
    {
        public int _id { get; set; }
        public string _name { get; set; }

        // TODO Create one to many relationship
        //public List<Card> _deck { get; set; }
        //public List<Pot> _pots { get; set; }
        //public List<User> _players { get ; set ;}
        public int? _talkingPosition { get; set; }
        public int? _dealerPosition { get; set; }
        public int? _pot { get; set; }
    }
}