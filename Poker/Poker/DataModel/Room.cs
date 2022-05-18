﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poker.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PokerClassLibrary
{
    public partial class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<Card> Deck { get; set; }
        public virtual List<Pot> Pots { get; set; }
        public virtual List<User> Users { get; set; }
        public short TalkingPosition { get; set; }
        public int DealerPosition { get; set; }
        public int Pot { get; set; }
        public int TurnStake { get; set; }
        public short Round { get; set; }

        public Room()
        {
            this.Users = new List<User>();
            this.Deck = new List<Card>();
            this.Pots = new List<Pot>();
            this.Pot = 0;
            this.TurnStake = 0;
            this.Round = 0;
            this.DealerPosition = 0;
            this.TalkingPosition = 0;
            this.Pot = 0;
        }

        public bool AddUser(PokerContext context, User user, int enterMoney)
        {
            if (this.Users.Count == 5)
            {
                return false;
            }

            // Getting available position
            List<short> positions = this.Users.Select(p => p.Position).ToList();
            short pos = 0;
            for (; pos < 5; pos++)
                if (!positions.Contains(pos))
                    break;

            // Adding the player to the room
            user.Money -= enterMoney;
            user.MoneyInTable = enterMoney;
            user.Position = pos;
            this.Users.Add(user);
            context.SaveChanges();

            // If enough players start game
            if (this.Users.Count() >= 2)
                this.StartGame(context);

            return true;
        }

        public bool StartGame(PokerContext context)
        {
            // Updating talking position
            this.TalkingPosition = this.Users.Select(u => u.Position).Min();

            // Getting talking user
            User talklingUser = this.Users.FirstOrDefault(u=>u.Position == this.TalkingPosition);

            // Set everyone active
            this.Users.ForEach(u => u.IsActive = true);

            // Updating database
            context.SaveChanges();

            return true;
        }

        public bool ReceiveAction(PokerContext context,string action, int? amount)
        {
            // Pervious talking user
            User talkingUser = this.Users.FirstOrDefault(u => u.Position == this.TalkingPosition);
            
            // Getting list of all player positions
            List<short> activePositions = this.Users.Where(u => u.IsActive == true).Select(u => u.Position).ToList();
            
            if(action == "Fold")
            {
                talkingUser.IsActive = false;
                if(activePositions.Count() == 2)
                {
                    // Set next player the winner
                    return false;
                }
            }
            else if(action == "Call")
            {
                // User has enough money
                if (TurnStake <= talkingUser.MoneyInTable)
                {
                    this.Pot += this.TurnStake - talkingUser.MoneyInTurn;
                    talkingUser.MoneyInTurn -= this.TurnStake - talkingUser.MoneyInTurn;
                }
                else
                {
                    // Open new pot
                }
            }
            else if (action == "Raise" && amount != null)
            {
                // Validating user can raise
                if (talkingUser.MoneyInTable < amount)
                    return false;

                this.TurnStake += (int)amount;
                talkingUser.MoneyInTable -= (int)amount;
                this.Pot += (int)amount;

                //going another round
                this.Users.Where(u => u.IsActive == true).ToList().ForEach(u => u.PlayedThisTurn = false);
            }

            // Setting player already played
            talkingUser.PlayedThisTurn = true;

            // Check if everyone played this turn
            if(this.Users.Where(u => u.IsActive == true && u.PlayedThisTurn == false).Count() ==0)
            {
                // Start new round
                this.Users.ForEach(u => u.PlayedThisTurn = false);
                this.Round++;
                if(Round == 4)
                {
                    // End game
                }
            }

            // Setting new talking position
            this.TalkingPosition = activePositions.ElementAt((activePositions.IndexOf(TalkingPosition)+1) % activePositions.Count());

            // Updating database
            context.SaveChanges();

            return true;
        }
    }
}