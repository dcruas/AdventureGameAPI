using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotAPI2.Models
{
    public class Character
    {
        public object userId { get; set; }
        public string discordId { get; set; }
        public string userName { get; set; }
        public int classId { get; set; }
        public int level { get; set; }
        public int exp { get; set; }
        public int totalExp { get; set; }

    }
}
