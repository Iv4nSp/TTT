using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameStatus
    {
        private string[] TTTArray = new string[9];
        public bool WinnerFound()
        {
            if ((TTTArray[0] != "" && TTTArray[0] == TTTArray[1] && TTTArray[0] == TTTArray[2]) || (TTTArray[0] != "" && TTTArray[0] == TTTArray[3] && TTTArray[0] == TTTArray[6]) || (TTTArray[0] != "" && TTTArray[0] == TTTArray[4] && TTTArray[0] == TTTArray[8]))
                return true;
            if ((TTTArray[4] != "" && TTTArray[4] == TTTArray[1] && TTTArray[4] == TTTArray[7]) || (TTTArray[4] != "" && TTTArray[4] == TTTArray[3] && TTTArray[4] == TTTArray[5]) || (TTTArray[4] != "" && TTTArray[4] == TTTArray[6] && TTTArray[4] == TTTArray[2]))
                return true;
            if ((TTTArray[8] != "" && TTTArray[8] == TTTArray[5] && TTTArray[8] == TTTArray[2]) || (TTTArray[8] != "" && TTTArray[8] == TTTArray[7] && TTTArray[8] == TTTArray[6]))
                return true;
            return false;
        }

        public void Fill()
        {
            for (int j = 0; j < 9; j++)
                TTTArray[j] = "";
        }

        public bool IsFull()
        {
            for (int j = 0; j < 9; j++)
            {
                if (TTTArray[j] == "")
                    return false;
            }
            return true;
        }

        public void PutInArray(int positionInArray, string label)
        {
            TTTArray[positionInArray] = label;
        }
    }
}
