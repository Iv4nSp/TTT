using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        private string rememberPlayer = "";
        public string SelectFirstPlayer()
        {
            Random rnd = new Random();
            int NumericalValueOfFirstPlayer = rnd.Next(0, 2);
            if (NumericalValueOfFirstPlayer == 0)
            {
                rememberPlayer = "X";
            }
            else
            {
                rememberPlayer = "O";
            }
            return rememberPlayer;

        }

        public string PlayerPlaying()
        {
            return rememberPlayer;
        }

        public void NextPlaying()
        {
            if (rememberPlayer == "X")
                rememberPlayer = "O";
            else
                rememberPlayer = "X";
        }
    }
}
