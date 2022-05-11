﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Poker.DataModel;
using System;
using System.Collections.Generic;

namespace PokerClassLibrary
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Card> Deck { get; set; }
        public List<Pot> Pots { get; set; }
        public List<UserInRoom> Players = new List<UserInRoom>();
        public int TalkingPosition { get; set; }
        public int DealerPosition { get; set; }
        public int? Pot { get; set; }
    }
}