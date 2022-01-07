using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoodBot.Data.Models
{
	public class Game : Entity
	{
		public string State { get; set; }

		public int GamePlayerTurnId { get; set; }

		public string ChannelId { get; set; }

		public string GuildId { get; set; }

		public int WinnerPlayerId { get; set; }

		public string Mode { get; set; }
	}
}

