namespace RPSGame;

public partial class MainPage : ContentPage
{
    private int playerScore = 0;
    private int systemScore = 0;
    private Random rand = new Random();
    public MainPage()
    {
        InitializeComponent();
    }

    private void ButtonImageClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button)
        {
            string playerChoice = button.StyleId; // or use button x:Name
            switch (playerChoice)
            {
                case "Rock":
                    playerChoiceImage.Source = ImageSource.FromFile($"rock.png");
                    break;
                case "Paper":
                    playerChoiceImage.Source = ImageSource.FromFile($"paper.png");
                    break;
                case "Scissors":
                    playerChoiceImage.Source = ImageSource.FromFile($"scissors.png");
                    break;
            }
            int systemChoice = rand.Next(1, 4);
            
            switch (systemChoice)
            {
                case 1:
                    systemChoiceImage.Source = ImageSource.FromFile($"rock.png");
                    break;
                case 2:
                    systemChoiceImage.Source = ImageSource.FromFile($"paper.png");
                    break;
                case 3:
                    systemChoiceImage.Source = ImageSource.FromFile($"scissors.png");
                    break;
            }
            CompScores(playerChoice, systemChoice);
        }
        
    }

    private void CompScores(string playerChoice, int systemChoice)
    {
        if ((playerChoice == "Rock" && systemChoice == 3) || 
            (playerChoice == "Paper" && systemChoice == 1) ||
            (playerChoice == "Scissors" && systemChoice == 2))
        {
            playerScore += 10;
        }

        if ((playerChoice == "Rock" && systemChoice == 2) ||
            (playerChoice == "Paper" && systemChoice == 3) ||
            (playerChoice == "Scissors" && systemChoice == 1))
        {
            systemScore += 10;
        }

        if ((playerChoice == "Rock" && systemChoice == 1) ||
            (playerChoice == "Paper" && systemChoice == 2) ||
            (playerChoice == "Scissors" && systemChoice == 3))
        {
            playerScore -= 5 ;
            systemScore -= 5;
        }  // if no winner, then both are loosers.
        
        playerScoreLabel.Text = $"Player Score: {playerScore}";
        systemScoreLabel.Text = $"System Score: {systemScore}";

        if (playerScore == 30 || systemScore == 30)
        {
            NewGame.Text = playerScore == 30 ? "You Win! Start New Game."  : "System Won! Start New Game.";
            DisplayAlert("Game Over", playerScore == 30 ? "You Win!" : "System Wins!", "OK");
            Rock.IsEnabled = false;
            Paper.IsEnabled = false;
            Scissors.IsEnabled = false;
            NewGame.IsEnabled = true;
            playerScoreLabel.Text = "Player Score: 0";
            systemScoreLabel.Text = "System Score: 0";
        }
        
    }

    private void NewGameClicked(object sender, EventArgs e)
    {
        playerScore = 0;
        systemScore = 0;
        
        Rock.IsEnabled = true;
        Paper.IsEnabled = true;
        Scissors.IsEnabled = true;
        NewGame.IsEnabled = false;
    }
    
}