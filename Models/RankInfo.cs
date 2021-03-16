using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTest.Models
{
    public class RankInfo
    {
        public string[] userId = new string[10];
        public int[] userScore = new int[10];
        public string[] playTime = new string[10];
    }
}