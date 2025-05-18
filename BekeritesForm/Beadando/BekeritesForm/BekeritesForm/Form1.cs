using GameMechanics.Classes;
using GameMechanics.Persistence;
using iText.IO.Exceptions;
using iText.StyledXmlParser.Node;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace BekeritesForm {
    public partial class Form1 : Form {
        //LE KELL VENNI AZ EVENTEKET!!!! -- done
        //nem valtoznak a pontok -- done
        //remake Game -- done
        // --Events -- done
        // --One Constructor --done
        // --Only one NewGame --done
        // --Separate LoadGame --done
        List<Button> selectedButtons;
        Game game;
        string[] Players;
        int size = 8;
        //bool loadedGame = false;

        public Form1() {
            InitializeComponent();
            selectedButtons = new List<Button>();
            Players = new string[2];
            //NuGet dumb dumb
            game = new Game();
            AddEvents();
        }

        

        private void RadioHandler(object? sender, EventArgs e) {
            if (sender is RadioButton radio) {
                int.TryParse(radio.Text.Split(" X ")[0], out size);
            }
        }



        private void startButton_Click(object sender, EventArgs e) {
            //if there is no players and the game havent been loaded
            if (Players[0] == null && (game == null || game.isNuget)) {
                MessageBox.Show("Add players first or load game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if they did not load the game
            if (Players != null && Players.Count() == 2
                && Players[0] != null && Players[1] != null) {
                string[] player1Info = Players[0].Split(',');
                string[] player2Info = Players[1].Split(',');
                //AddEvents();
                game.NewGame(size, player1Info[0], player1Info[1], player2Info[0], player2Info[1]);
            }
            //if the gameboard is empty after new game
            else if (game != null && gameBoard.Controls.Count != 0) {
                DialogResult result = MessageBox.Show("Do you really want to start a new game?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    game.NewGame(size);
                }
            }
        }

        private void genTable(int size) {
            Size btnSize = new Size(gameBoard.Width / size, gameBoard.Height / size);
            gameBoard.Controls.Clear();
            selectedButtons.Clear();
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Button button = new Button();
                    button.Location = new Point(j * btnSize.Width, i * btnSize.Height);
                    button.Tag = $"{i},{j}";
                    button.Size = btnSize;
                    button.BackColor = Color.White;
                    //hozza kell adni az eventet!
                    button.MouseClick += ButtonClick;
                    gameBoard.Controls.Add(button);
                }
            }
        }

        private void AddEvents() {
            game.TableChanged += TableChanged;
            game.TableReady += TableReady;
            game.GameEnded += GameEnded;
            game.PointsChanged += PointsChanged;
            game.NameChanged += NameChanged;
        }

        private void NameChanged(object? sender, EventArgs e) {
            player1NameLabel.Text = game.Players[0].Name;
            player2NameLabel.Text = game.Players[1].Name;
        }

        private void RemoveEvents() {
            game.TableChanged += TableChanged;
            game.TableReady += TableReady;
            game.GameEnded += GameEnded;
            game.PointsChanged += PointsChanged;
        }

        private void PointsChanged(object? sender, EventArgs e) {
            player1PointLabel.Text = $"Points: {game.Players[0].Points}";
            player2PointLabel.Text = $"Points: {game.Players[1].Points}";
        }

        private void ButtonClick(object? sender, EventArgs e) {
            if (sender is Button clickedButton) {
                if (selectedButtons.Count < 2) {
                    selectedButtons.Add(clickedButton);

                    if (selectedButtons.Count == 2) {
                        //de nem lehet null......
                        string[]? firstCoords = selectedButtons[0].Tag?.ToString()?.Split(',');//???????????????
                        string[]? secondCoords = selectedButtons[1].Tag?.ToString()?.Split(',');
                        //nem hiszem el
                        try {
                            game.Step(firstCoords, secondCoords);
                            foreach (Button button in selectedButtons) {
                                button.BackColor = game.PlayerColor((game.nextPLayer + 1) % 2);
                            }
                        } catch (Exception) {
                            MessageBox.Show("Press buttons beside each other!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        selectedButtons.Clear();
                    }
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //SaveGame
            if (!game.isNuget) {
                using (FileSelect fileSelect = new FileSelect()) {
                    if (fileSelect.ShowDialog() == DialogResult.OK) {
                        String path = fileSelect.InputText;
                        try {
                            if (path.Contains('.')) {
                                game.SaveGame(path);
                            } else {
                                game.SaveGame(path + ".txt");
                            }
                        } catch (System.IO.IOException) {
                            MessageBox.Show("Something went wrong! Try to save to a txt file", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                    }
                }
            } else {
                MessageBox.Show("Can't  save empty game! Start a game before saving!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            //LoadGame
            using (FileSelect fileSelect = new FileSelect()) {
                if (fileSelect.ShowDialog() == DialogResult.OK) {
                    //AddEvents();
                    String path = fileSelect.InputText;
                    try {
                        IFileManager? fileManager;
                        if (path.Contains('.')) {
                            fileManager = FileManagerFactory.CreateForPath(path);
                        } else {
                            fileManager = FileManagerFactory.CreateForPath(path + ".txt");
                        }
                        if (fileManager == null) {
                            throw new System.IO.IOException();
                        }

                        game.LoadGame(fileManager);
                    } catch (System.IO.IOException) {
                        MessageBox.Show($"File not found! Try to load a txt file", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //genTable(game.field.GetLength(0));
                    player1PointLabel.Enabled = true;
                    player2PointLabel.Enabled = true;
                    player1NameLabel.Text = game.Players[0].Name;
                    player2NameLabel.Text = game.Players[1].Name;
                    //loadedGame = true;
                }
            }
        }

        private void TableReady(object? sender, EventArgs e) {
            genTable(game.field.GetLength(0));
        }

        private void TableChanged(object? sender, EventArgs e) {
            player1PointLabel.Text = $"Points: {game.Players[0].Points}";
            //player1NameLabel.Text = game.Players[0].Name;
            player2PointLabel.Text = $"Points: {game.Players[1].Points}";
            //player2NameLabel.Text = game.Players[1].Name;

            int size = game.field.GetLength(0);
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    switch (game.field[i][j]) {
                        case 0:
                            gameBoard.Controls[j + i * size].BackColor = Color.White;
                            break;
                        case 1:
                            gameBoard.Controls[j + i * size].BackColor = game.PlayerColor(0);
                            //debugLabel.Text += gameBoard.Controls[j + i * size].BackColor;
                            break;
                        case 2:
                            gameBoard.Controls[j + i * size].BackColor = game.PlayerColor(1);
                            //debugLabel.Text += gameBoard.Controls[j + i * size].BackColor;
                            break;
                    }
                }
            }
        }

        private void GameEnded(object? sender, EventArgs e) {
            String winner = game.Winner();
            if (winner == "Draw") {
                MessageBox.Show($"Game over. The winner is... Well, both of you", "Never Gonna Give You Up",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show($"Game over. The winner is {game.Winner()}", "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            game.NewGame(size);
        }

        private void playerAdderButton_Click(object sender, EventArgs e) {
            using (PlayerSelect playerSelect = new PlayerSelect()) {
                if (playerSelect.ShowDialog() == DialogResult.OK) {
                    Players = playerSelect.Players;
                    player1PointLabel.Enabled = true;
                    player2PointLabel.Enabled = true;
                } else {
                    MessageBox.Show("This is not good! Your players have been vaporated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
