//	Auto-generated command skeleton class.
//	Use this as a basis for custom MCGalaxy commands.
//	File and class should be named a specific way. For example, /update is named 'CmdUpdate.cs' for the file, and 'CmdUpdate' for the class.
// As a note, MCGalaxy is designed for .NET 4.0

// To reference other assemblies, put a "Reference [assembly filename]" at the top of the file
//   e.g. to reference the System.Data assembly, put "Reference System.Data.dll"

// Add any other using statements you need after this
using System;
using System.Threading;

using MCGalaxy.Events.PlayerEvents;
using MCGalaxy.Tasks;
using MCGalaxy.Network;
using BlockID = System.UInt16;

namespace MCGalaxy.Commands.Chatting
{
	public sealed class CmdMeat : MessageCmd
	{
		// The command's name (what you put after a slash to use this command)
		static volatile Random rng;
        static readonly object rngLock = new object();
		public override string name { get { return "Meat"; } }
		public override string shortcut { get { return ""; } }
		// Determines which submenu this command displays in under /Help.
		public override string type { get { return "other"; } }
		// Determines whether or not this command can be used in a museum. Block/map altering commands should be made false to avoid errors.
		public override bool museumUsable { get { return true; } }
		public static string whodoneit = "Nobody has used /meat yet.";
		// Determines the default rank required to use this command. Valid values are:
		// LevelPermission.Nobody, LevelPermission.Banned, LevelPermission.Guest
		// LevelPermission.Builder, LevelPermission.AdvBuilder, LevelPermission.Operator, LevelPermission.Admin
		public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
		private readonly Random random = new Random();
		// This is where the magic happens, naturally.
		// p is the player object for the player executing the command. message is everything after the command invocation itself.
		
		public override void Use(Player p, string message, CommandData data) {

			if (p.money < 1 && message != "--nomoney") {p.Message("You don't have enough meats.");}
			else {
				string[] people = {
					p.ColoredName, "Henry", "Thomas",
					"Mr. Buxtehude", "Leaf", "Feather", "Spiny", "Bup", "Flyguy",
					"An Innocent Meat", "Baby Bear", "Bike Champ Guy", "Rabbit",
					"A Slab of Meat", "Cologaurd", "Brother Bear",
					"Cow-Lady", "An Evil Cannibal", "The Inca King", "The Panther of the Inca King",
					"Fincy Morris", "Kirk", "Spock", "Sulu", "Chekov", "Tom Nook",
					"Bunglobe", "eteled", "Mr. Monopoly"
				};
			
				int asdf = random.Next(people.Length);
				string[] rooms = {
					"Kitchen", "Ballroom", "Bathroom", "Observatory", "UFO", "Dining Room", "Living Room",
					"Hall", "M.P.P.", "Library", "Study", "Basement of the Alamo", "Middle of a Star", 
					"Billiard Room", "Box", "Park", "Apartment", "Trash Compactor"
				};
				string[] weapons = {
					"Knife", "Candlestick", "Rope", "Revolver", "Lead Pipe", "Wrench", "Star",
					"Wii Remote", "Stuffed Animal", "Slab of Meat", "Meat Processor"
				};
				int roomba = random.Next(rooms.Length);
				int weapon = random.Next(weapons.Length);
				int person = random.Next(people.Length);
				int person2 = random.Next(people.Length);
				bool StartsWithA = weapons[weapon].StartsWith("A");
				bool StartsWithE = weapons[weapon].StartsWith("E");
				bool StartsWithI = weapons[weapon].StartsWith("I");
				bool StartsWithO = weapons[weapon].StartsWith("O");
				bool StartsWithU = weapons[weapon].StartsWith("U");
				
				string AorAn;
				if (StartsWithA || StartsWithE || StartsWithI || StartsWithO || StartsWithU) AorAn = "an";
				else AorAn = "a";
				people[person] = people[person].Trim( new Char[] {'+'} );
				people[person2] = people[person2].Trim( new Char[] {'+'} );
				string[] dailymeat = {
					"$dm &m" + people[person] + "&f pushed &m" + people[person2] + "&f into a star!",
					"$dm &m" + people[person] + "&f ate &m" + people[person2] + "&f.",
					"$dm &fA group of cannibals surround &m" + people[person] + "&f!",
					"$dm &m" + people[person] + "&f steps on &m" + people[person2] + "&f.",
					"$dm &m" + people[person] + "&f dropped a boulder on &m" + people[person2] + "&f!!",
					"$dm &m" + people[person] + "&f stubbed their toe on a boulder.",
					"$dm &m" + people[person] + "&f rolled a boulder away, onto &m" + people[person2] + "&f!",
					"&c[!] &e" + people[person] + "&f suspects &c" + people[person2] + "&f did it in the &q" + rooms[roomba] + "&f with " + AorAn + "&] " + weapons[weapon] + "&f.",
					"&c[!] &e" + people[person] + "&f suspects &c" + people[person2] + "&f did it in the &q" + rooms[roomba] + "&f with " + AorAn + "&] " + weapons[weapon] + "&f.",
					"$dm &m" + people[person] + "&f hid in the &6" + rooms[roomba] + "&f to avoid &m" + people[person2] + "&f.",
					"$dm &m" + people[person] + "&f drop-kicks &m" + people[person2] + "&f.",
					"$dm &m" + people[person] + "&f saw &m" + people[person2] + "&f with " + AorAn + "&c " + weapons[weapon] + "&f!",
					"$dm &m" + people[person] + "&f is a cannibal, but &m" + people[person2] + "&f did not know this." + " ''Tasty!''",
					"$dm &m" + people[person] + "&f commits tax fraud.",
					"$dm &m" + people[person] + "&f pushes &m" + people[person2] + "&f into an electrical outlet, what happens next is shocking!",
					"&c[!] &fThere's &ea cannibal &fbehind &a" + people[person] + "&f." 
				};
				
				int blahblahblah = random.Next(dailymeat.Length);
				if(message == "--clue") {
					blahblahblah = 8;
					p.SetMoney(p.money + 1);
				}
				if(message != "who") {
					TryMessage(p,  dailymeat[blahblahblah], true);
					whodoneit = p.ColoredName;
					
				}
				if(message == "who") p.Message(whodoneit);
				
					/*
					if (number == 1){
						string msg = "&a[The Daily Meat]&m " +  people[person] + "&f has been eaten by &m" + people[person2]  + "&f!";
						TryMessage(p, msg);
					}
					if (number == 2){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f ate &m" + people[person2] + "&f!";
						TryMessage(p, msg);
					}
					if (number == 3){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f threw a box of meat off a bridge.";
						TryMessage(p, msg);
					}
					if (number == 4){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f dropped a boulder on their foot.";
						TryMessage(p, msg);
					}
					if (number == 5){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f ripped a hole in their sock.";
						TryMessage(p, msg);
					}
					if (number == 6){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f used &m" + people[person2] + "&f as a napkin!";
						TryMessage(p, msg);
					}
					if (number == 7){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f dropped a boulder on &m" + people[person2] + "&f.";
						TryMessage(p, msg);
					}
					if (number == 8){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f thought &m" + people[person2] + "&f was meat, until they thrashed.";
						TryMessage(p, msg);
					}
					if (number == 9){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f wanted an autograph from &m" + people[person2] + "&f, but ate them instead.";
						TryMessage(p, msg);
					}
					if (number == 10){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f turned &m" + people[person2] + "&f into a LaCroix flavor.";
						TryMessage(p, msg);
					}
					if (number == 11){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f pushed &m" + people[person2] + "&f into a star!";
						TryMessage(p, msg);
					}
					if (number == 12){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f stole &m" + people[person2] + "&f's ham!";
						TryMessage(p, msg);
					}
					if (number == 13){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f goes on Wheel of Fortune with &m" + people[person2] + "&f.";
						TryMessage(p, msg);
					}
					if (number == 14) {
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f used tackle on &m" + people[person2] + "&f. It's super effective!";
						TryMessage(p, msg);
					}
					if (number == 15){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f pushed &m" + people[person2] + "&f off a cliff!";
						TryMessage(p, msg);
					}
					if (number == 16){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f commits tax fraud";
						TryMessage(p, msg);
					}
					if (number == 17){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f and &m" + people[person2] + "&f become friends.";
						TryMessage(p, msg);
					}
					if (number == 18){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f and &m" + people[person2] + "&f become enemies.";
						TryMessage(p, msg);
					}
					if (number == 19){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f saw &m" + people[person2] + "&f in a restaraunt menu.";
						TryMessage(p, msg);
					}
					if (number == 20){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f unscrews the salt shaker lids at a restaraunt, forgets about it, and puts salt on their food.";
						TryMessage(p, msg);
					}
					if (number == 21){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f touched a star.";
						TryMessage(p, msg);
					}
					if (number == 22){
						string msg = "&a[The Daily Meat]&m " + people[person] + "&f threw a fork in the garbage disposal.";
						TryMessage(p, msg);
					}
					*/
				if(message != "--nomoney" || message != "who") p.SetMoney(p.money - 1);
				
			}
			
		}

		// This one controls what happens when you use /Help [commandname].
		public override void Help(Player p)
		{
			p.Message("%T/Meat%H - Gives a message from 'The Daily Meat.' Costs 1 meat.");
		}
	}
}
