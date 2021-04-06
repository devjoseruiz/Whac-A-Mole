using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whac_A_Mole.Models;

namespace Whac_A_Mole.Pages
{
    public partial class WhacAMole
    {
        private int score = 0;
        private int time = 60;
        int hitPosition = 0;
        private bool hitted = false;
        private bool restart = false;
        bool gameIsRunning = true;

        public List<SquareModel> Squares { get; set; } =
            new List<SquareModel>();
        
        public WhacAMole()
        {
            for(int i = 0; i < 9; i++)
            {
                Squares.Add(new SquareModel
                {
                    Id = i,
                    Src = "hole"
                });
            }
        }

        private void MouseUp(SquareModel s)
        {
            if(s.Id == hitPosition && gameIsRunning && !hitted)
            {
                hitted = true;
                score++;
            }
        }

        private void ChooseSquare()
        {
            int randomPosition;
            do {
                randomPosition = new Random().Next(0, 9);
            } while(randomPosition == hitPosition);
            
            Squares[hitPosition].IsShown = false;
            hitPosition = randomPosition;
            Squares[randomPosition].IsShown = true;
            hitted = false;
            StateHasChanged();
        }

        private async Task GameLoop()
        {
            while(gameIsRunning)
            {
                time--;
                if(time == 0)
                {
                    restart = true;
                    gameIsRunning = false;
                }
                ChooseSquare();
                await Task.Delay(1000);
            }
        }

        private async Task RestartGame()
        {
            score = 0;
            time = 60;
            restart = false;
            gameIsRunning = true;
            await GameLoop();
        }

        protected override async void OnInitialized()
        {
            await GameLoop();
        }
    }
}
