﻿namespace Lab6Starter;
/**
 * 
 * Name: D'Asia Harvey, Justin Vang
 * Date: How about this?
 * Description:
 * Bugs:
 * Reflection:
 * 
 */

using Lab6Starter;


/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage
{
    TicTacToeGame ticTacToe; // model class
    Button[,] grid;          // stores the
    int ScoreForX;
    int ScoreForO;

    /// <summary>
    /// initializes the component
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        ticTacToe = new TicTacToeGame();
        grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };
        ScoreForX = ticTacToe.XScore;
        ScoreForO = ticTacToe.OScore;

    }

    /// <summary>
    /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
    /// Checks to see if there is a victory - if so, invoke 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleButtonClick(object sender, EventArgs e)
    {
        Player victor;
        Player currentPlayer = ticTacToe.CurrentPlayer;

        Button button = (Button)sender;
        int row;
        int col;

        FindTappedButtonRowCol(button, out row, out col);
        if (button.Text.ToString() != "")
        { // if the button has an X or O, bail
            DisplayAlert("Illegal move", "Fill this in with something more meaningful", "OK");
            return;
        }
        button.Text = currentPlayer.ToString();
        Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

        if (gameOver)
        {
            CelebrateVictory(victor);

        }
    }

    /// <summary>
    /// Returns the row and col of the clicked row
    /// There used to be an easier way to do this ...
    /// </summary>
    /// <param name="button"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void FindTappedButtonRowCol(Button button, out int row, out int col)
    {
        row = -1;
        col = -1;

        for (int r = 0; r < TicTacToeGame.GRID_SIZE; r++)
        {
            for (int c = 0; c < TicTacToeGame.GRID_SIZE; c++)
            {
                if(button == grid[r, c])
                {
                    row = r;
                    col = c;
                    return;
                }
            }
        }
        
    }


    /// <summary>
    /// Celebrates victory, displaying a message box and resetting the game
    /// </summary>
    private void CelebrateVictory(Player victor)
    {
        Player currentPlayer = ticTacToe.CurrentPlayer;
        String Winner = currentPlayer.ToString();
        DisplayAlert("Congratulations", $" Player {Winner} You are the big winner today!", " Play Again");
        //MessageBox.Show(Application.Current.MainWindow, String.Format("Congratulations, {0}, you're the big winner today", victor.ToString()));
        if (Winner == Player.X.ToString()) {
            XScoreLBL.Text = String.Format($"X's Score: {ScoreForX++}");
        }
        else {
            OScoreLBL.Text = String.Format($"O's Score: {ScoreForO++}");
        }

        ResetGame();
    }

    /// <summary>
    /// Resets the grid buttons so their content is all ""
    /// </summary>
    private void ResetGame()
    {
        

        for (int row = 0; row < TicTacToeGame.GRID_SIZE; row++)
        {
            for(int col = 0; col < TicTacToeGame.GRID_SIZE; col++)
            {
                grid[row, col].Text = "";
            }
        }

        ticTacToe.ResetGame();
       
    }

}



