using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class GameResult
    {
        public Result Result { get; set; }
        public WinnerType WinnerTtype { get; set; }
    }
}
