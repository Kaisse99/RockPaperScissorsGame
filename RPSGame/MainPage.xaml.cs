namespace RPSGame;

public partial class MainPage : ContentPage
{
    private int playerScore = 0;
    private int systemScore = 0;
    private int playerWins = 0;
    private int systemWins = 0;
    private Random rand = new Random();
    public MainPage()
    {
        InitializeComponent();
    }

    private async Task AnimatedButtonImage(ImageButton button)
    {
        await button.ScaleTo(1.1, 100, Easing.Linear); 
        await button.ScaleTo(1.0, 100, Easing.Linear);
    }

    private async Task BouncingImages(Image image)
    {
        await image.TranslateTo(0, -20, 100, Easing.CubicIn); 
        await image.TranslateTo(0, 0, 100, Easing.CubicOut);   
        
    }

    private async void ButtonImageClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button)
        {
            // made so that user not able to click during animation as it cause bugs 
            Rock.IsEnabled = false;
            Paper.IsEnabled = false;
            Scissors.IsEnabled = false;
            
             await AnimatedButtonImage(button);
            
            string playerChoice = button.StyleId; 
            switch (playerChoice)
            {
                case "Rock":
                    PlayerChoiceImage.Source = ImageSource.FromFile($"rock.png");
                    break;
                case "Paper":
                    PlayerChoiceImage.Source = ImageSource.FromFile($"paper.png");
                    break;
                case "Scissors":
                    PlayerChoiceImage.Source = ImageSource.FromFile($"scissors.png");
                    break;
            }
            int systemChoice = rand.Next(1, 4);
            
            switch (systemChoice)
            {
                case 1:
                    SystemChoiceImage.Source = ImageSource.FromFile($"rock.png");
                    SystemChoiceLabel.Text = "System Choice: Rock";
                    break;
                case 2:
                    SystemChoiceImage.Source = ImageSource.FromFile($"paper.png");
                    SystemChoiceLabel.Text = "System Choice: Paper";
                    break;
                case 3:
                    SystemChoiceImage.Source = ImageSource.FromFile($"scissors.png");
                    SystemChoiceLabel.Text = "System Choice: Scissors";
                    break;
            }

            await Task.WhenAll(BouncingImages(PlayerChoiceImage), BouncingImages(SystemChoiceImage));
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

       
        PlayerScoreLabel.Text = $"Player Score: {playerScore}";
        SystemScoreLabel.Text = $"System Score: {systemScore}";
        
        Rock.IsEnabled = true;
        Paper.IsEnabled = true;
        Scissors.IsEnabled = true;

        if (playerScore == 30 || systemScore == 30)
        {
            if (playerScore == 30)
            {
                playerWins++;
                systemWins = 0;
            }
            else if (systemScore == 30)
            {
                systemWins++;
                playerWins = 0;
            }

            if (playerWins == 2 || systemWins == 2)
            {
                DisplayAlert("Match is Over",
                    playerWins == 2 ? "Player Wins The Match." : "System Wins The Match.", "OK");
                Rock.IsEnabled = false;
                Paper.IsEnabled = false;
                Scissors.IsEnabled = false;
                NewGame.IsEnabled = false;
                NewGame.Text = "GAME OVER";
            }
            else
            {
                NewGame.Text = "Start New Round";
                DisplayAlert("Round is Over", playerScore == 30 ? "You Win!" : "System Wins!", "OK");
                Rock.IsEnabled = false;
                Paper.IsEnabled = false;
                Scissors.IsEnabled = false;
                NewGame.IsEnabled = true;
            }
        }
    }

    private void NewGameClicked(object sender, EventArgs e)
    {
        PlayerScoreLabel.Text = "Player Score: 0";
        SystemScoreLabel.Text = "System Score: 0";
        playerScore = 0;
        systemScore = 0;
        
        Rock.IsEnabled = true;
        Paper.IsEnabled = true;
        Scissors.IsEnabled = true;
        NewGame.IsEnabled = false;
    }
    
}