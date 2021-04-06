using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whac_A_Mole.Models
{
    public class SquareModel
    {
        private bool isShown;
        public int Id { get; set; }
        public string Src { get; set; }
        public bool IsShown
        {
            get => isShown;
            set
            {
                isShown = value;
                if (isShown)
                {
                    Src = "mole";
                    Console.WriteLine($"Was changed to mole {Id}");
                }
                else
                {
                    Src = "hole";
                }
            }
        }
    }
}
