using System;

namespace WebApplication1
{
    public class Player
    {
        public string NickName { get; set; }
        public DateTime TeamJoinDate { get; set; }
        public int Age { get; set; }
        public int TotalWinnings { get; set; }

        public Player(string nickName, DateTime teamJoinDate, int age, int totalWinnings)
        {
            NickName = nickName;
            TeamJoinDate = teamJoinDate;
            Age = age;
            TotalWinnings = totalWinnings;
        }
    }
}
