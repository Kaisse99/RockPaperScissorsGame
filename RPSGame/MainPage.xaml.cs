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

    private void buttonImageClicked(object sender, EventArgs e)
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
        }
        
    }
    
}