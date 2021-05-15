using DiscordBotAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Net.Http.Json;

namespace DiscordBotAPI2.DataAccess
{
    public class CharacterDB
    {
        string caminho = @"Data Source = DESKTOP-SUND5QP\SQLEXPRESS; Initial Catalog = AdventureGame; Integrated Security = True";

        public CharacterDB(){
            
        }
        
        public object GetCharacterInfo(string discordId)
        {
            using (var connection = new SqlConnection(caminho))
            {
                var characterInfo = connection.QueryFirstOrDefault<Character>($"SELECT * FROM userCharacter WHERE discordId = @discordid", new { discordid = discordId });
                return characterInfo;
            }
            
        }

        public object InsertCharacter(string discordId, string userName)
        {
            using (var connection = new SqlConnection(caminho))
            {
                var output = GetCharacterInfo(discordId);
                if (output == null)
                {
                    var insert = "INSERT INTO userCharacter VALUES(@userid, @discordid, @username, 1, 1, 0, 100)";
                    connection.Execute(insert, new { userid = Guid.NewGuid().ToString(), discordid = discordId, username = userName });
                    output = GetCharacterInfo(discordId);
                }
                else
                {
                    output = null;
                }
                
                return output;

            }

        }

    }
}
