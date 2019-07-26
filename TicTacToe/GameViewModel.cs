using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TicTacToe
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public GameViewModel()
        {
            ButtonClickCommand = new CommandHandler(CanExecuteButtonClickCommand, ExecuteButtonClickCommand);
            ButtonNewGame = new CommandHandlerNew(CanExecuteButtonClickCommandNew, ExecuteButtonClickCommandNew);
            Player = new Player();
            GameStatus = new GameStatus();
            StartNewGame();
        }

        private string button00;
        private string button01;
        private string button02;
        private string button12;
        private string button10;
        private string button11;
        private string button20;
        private string button21;
        private string button22;


        public void StartNewGame()
        {
            GameStatus.Fill();
            Button00 = "";
            Button01 = "";
            Button02 = "";
            Button10 = "";
            Button11 = "";
            Button12 = "";
            Button20 = "";
            Button21 = "";
            Button22 = "";
            Player.SelectFirstPlayer();
            UpdatePlayerLabel();
        }

        public ICommand ButtonClickCommand
        {
            get; set;
        }
        public bool CanExecuteButtonClickCommand(object parameter)
        {
            return true;
        }
        public Player Player;
        private GameStatus gameStatus;
        public void ExecuteButtonClickCommand(object parameter)
        {
            string labelOfPlayer = Player.PlayerPlaying();
            string stringParameter = parameter.ToString();
            if (stringParameter == "0")
            {
                if (Button00 == "")
                    Button00 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "1")
            {
                if (Button01 == "")
                    Button01 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "2")
            {
                if (Button02 == "")
                    Button02 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "3")
            {
                if (Button10 == "")
                {
                    Button10 = labelOfPlayer;
                }
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "4")
            {
                if (Button11 == "")
                    Button11 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "5")
            {
                if (Button12 == "")
                    Button12 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "6")
            {
                if (Button20 == "")
                    Button20 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "7")
            {
                if (Button21 == "")
                    Button21 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }
            if (stringParameter == "8")
            {
                if (Button22 == "")
                    Button22 = labelOfPlayer;
                else
                {
                    MessageBox.Show("Polje je popunjeno!");
                    return;
                }
            }

            int inArray = Int32.Parse(stringParameter);
            GameStatus.PutInArray(inArray, labelOfPlayer);


            if (GameStatus.WinnerFound())
                NovaIliIzlaz("Pobjedio je " + labelOfPlayer + "!");
            if (GameStatus.IsFull())
                NovaIliIzlaz("Nema pobjednika!");

            Player.NextPlaying();
            UpdatePlayerLabel();
            
        }
        private void UpdatePlayerLabel()
        {
            NextPlayer = $"Na redu je: {Player.PlayerPlaying()}";
        }
        public ICommand ButtonNewGame
        {
            get; set;
        }
        public bool CanExecuteButtonClickCommandNew(object parameter)
        {
            return true;
        }
        public void ExecuteButtonClickCommandNew(object parameter)
        {
            StartNewGame();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string nextPlayer;
        public string NextPlayer
        {
            get => nextPlayer; set
            {
                if (nextPlayer == value) return;
                nextPlayer = value;
                OnPropertyChanged(nameof(NextPlayer));
            }
        }


        public string Button00
        {
            get => button00; set
            {
                if (button00 == value) return;
                button00 = value;
                OnPropertyChanged(nameof(Button00));
            }
        }
        public string Button01
        {
            get => button01; set
            {
                if (button01 == value) return;
                button01 = value;
                OnPropertyChanged(nameof(Button01));
            }
        }
        public string Button02
        {
            get => button02; set
            {
                if (button02 == value) return;
                button02 = value;
                OnPropertyChanged(nameof(Button02));
            }
        }
        public string Button10
        {
            get => button10; set
            {
                if (button10 == value) return;
                button10 = value;
                OnPropertyChanged(nameof(Button10));
            }
        }
        public string Button11
        {
            get => button11; set
            {
                if (button11 == value) return;
                button11 = value;
                OnPropertyChanged(nameof(Button11));
            }
        }
        public string Button12
        {
            get => button12; set
            {
                if (button12 == value) return;
                button12 = value;
                OnPropertyChanged(nameof(Button12));
            }
        }
        public string Button20
        {
            get => button20; set
            {
                if (button20 == value) return;
                button20 = value;
                OnPropertyChanged(nameof(Button20));
            }
        }
        public string Button21
        {
            get => button21; set
            {
                if (button21 == value) return;
                button21 = value;
                OnPropertyChanged(nameof(Button21));
            }
        }
        public string Button22
        {
            get => button22; set
            {
                if (button22 == value) return;
                button22 = value;
                OnPropertyChanged(nameof(Button22));
            }
        }

        internal GameStatus GameStatus { get => gameStatus; set => gameStatus = value; }

        public void NovaIliIzlaz(string winner)
        {
            MessageBoxResult result = MessageBox.Show(winner + "\nŽelite li pokrenuti novu igru?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        StartNewGame();
                        break;
                    }
                case MessageBoxResult.No:
                    {
                        App.Current.Shutdown();
                        break;
                    }
            }
        }
    }
}
