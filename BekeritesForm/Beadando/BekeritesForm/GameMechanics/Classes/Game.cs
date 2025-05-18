using GameMechanics.Persistence;
using System.Drawing;

namespace GameMechanics.Classes { //view csak viewmodellel kommunikál!!
    public class Game {
        #region Properties
        public List<Player> Players { get; private set; }
        public int[][] field { get; private set; }
        public int nextPLayer { get; private set; }
        public bool isNuget { get; private set; }
        public event EventHandler? TableChanged;
        public event EventHandler? GameEnded;
        public event EventHandler? TableReady;
        public event EventHandler? PointsChanged;
        public event EventHandler? NameChanged;
        #endregion

        #region Constructor
        //console tester
        /*public Game(int[][] field) {
            this.field = field;
            Players = new List<Player>();
            nextPLayer = 0;
            isNuget = false;
        }*/

        public Game() {
            this.field = new int[8][];
            Players = new List<Player>();
            nextPLayer = 0;
            isNuget = true;
        }

        private void OnTableReady() {
            TableReady?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Public methods
        public void NewGame(int size, String? player1Name = null, String? player1Color = null, String? player2Name = null, String? player2Color = null) {
            if (player1Color != null && player1Name != null && player2Name != null && player2Color != null) {
                Players.Clear();
                Players.Add(new Player(0, Color.FromName(player1Color), player1Name));
                Players.Add(new Player(0, Color.FromName(player2Color), player2Name));
                OnPointsChanged();
                OnNameChanged();
            } else {
                if (Players.Count == 0) throw new ArgumentException();
                foreach (Player player in Players) {
                    player.ClearPoints();
                    OnPointsChanged();
                }
            }
            field = new int[size][];
            for (int i = 0; i < size; i++) {
                field[i] = Enumerable.Repeat(0, size).ToArray();
            }
            OnTableReady();
            OnTableChanged();
        }

        public void LoadGame(IFileManager fileManager) {
            if (fileManager == null) {
                throw new IOException();
            } else {
                Players.Clear();
                try {
                    String[] loadedGame = fileManager.Load().Split('\n');
                    //A fajl elso sora a matrix meret, majd maga a matrix *majd a két player színe* *optional*
                    int size = int.Parse(loadedGame[0]);
                    field = new int[size][];
                    for (int i = 0; i < size; i++) {
                        field[i] = loadedGame[i + 1].Split(',').Select(num => int.Parse(num)).ToArray();
                    }
                    OnTableReady();
                    //Mivel lesz még egy plusz enter utána!!
                    Players.Clear();
                    for (int i = size + 1; i < loadedGame.Length - 1; i++) {
                        String[] currentPlayer = loadedGame[i].Split(',');
                        Players.Add(new Player(int.Parse(currentPlayer[0]), Color.FromName(currentPlayer[1]), currentPlayer[2]));
                    }
                    isNuget = false;
                    OnTableChanged();
                    OnNameChanged();
                    OnPointsChanged();
                    EndGame();
                } catch (IOException) {
                    throw new IOException();
                }
            }

        }

        public void SaveGame(String path) {
            //tabla beirasa
            if (File.Exists(path)) {
                File.Delete(path);
            }
            File.AppendAllText(path, field.GetLength(0) + "\n");
            for (int i = 0; i < field.GetLength(0); i++) {
                if (field[i] == null) {
                    throw new NullReferenceException();
                } else {
                    File.AppendAllText(path, String.Join(",", field[i]) + "\n");
                }
            }
            //playerek beirasa
            foreach (Player player in Players) {
                File.AppendAllText(path, player.ToString() + "\n");
            }
        }

        /*public void Clear(int size) {
            field = new int[size][];
            for (int i = 0; i < size; i++) {
                field[i] = Enumerable.Repeat(0, size).ToArray();
            }
            OnTableReady();
            OnTableChanged();
            foreach (Player player in Players) {
                player.ClearPoints();
                OnPointsChanged();
            }
        }*/

        public void Step(String[]? firstCoords, String[]? secondCoords) {
            if (firstCoords == null || secondCoords == null) throw new ArgumentException();
            int x1 = int.Parse(firstCoords[0]);
            int y1 = int.Parse(firstCoords[1]);
            int x2 = int.Parse(secondCoords[0]);
            int y2 = int.Parse(secondCoords[1]);

            bool areAdjacent = (Math.Abs(x1 - x2) == 1 && y1 == y2) || (Math.Abs(y1 - y2) == 1 && x1 == x2);

            if (areAdjacent && field[x1][y1] == 0 && field[x2][y2] == 0) {
                field[x1][y1] = nextPLayer + 1;
                field[x2][y2] = nextPLayer + 1;
                DetectAndFillRectangle(nextPLayer + 1);
                Players[nextPLayer].AddToPoint();
                Players[nextPLayer].AddToPoint();
                OnPointsChanged();

                EndGame();

                nextPLayer++;
                nextPLayer %= 2;
            } else {
                throw new ArgumentException();
            }
        }

        public Color PlayerColor(int playerId) {
            return Players[playerId].Color;
        }

        public bool EndGame() {
            for (int row = 0; row < field.Length; row++) {
                for (int col = 0; col < field[row].Length; col++) {
                    if (field[row][col] == 0) {
                        if (col + 1 < field[row].Length && field[row][col + 1] == 0) {
                            Console.WriteLine("Adjacent empty spaces found at: (" + row + ", " + col + ") and (" + row + ", " + (col + 1) + ")");
                            return false;
                        }

                        if (row + 1 < field.Length && field[row + 1][col] == 0) {
                            Console.WriteLine("Adjacent empty spaces found at: (" + row + ", " + col + ") and (" + (row + 1) + ", " + col + ")");
                            return false;
                        }
                    }
                }
            }
            GameEnded?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public String Winner() {
            bool arePointsEqual = Players.Select(player => player.Points)
                             .Aggregate((acc, point) => acc == point ? acc : -1) != -1;
            if (arePointsEqual) {
                return "Draw";
            }
            String winnerName= Players.Where(player => player.Points == Players.Max(player => player.Points)).First().Name;
            return winnerName;
        }

        #endregion

        #region Private methods
        //checks edges
        // ide kell az esemény tábla változásakor!!!
        // majd az endgame-hez
        private void DetectAndFillRectangle(int playerId) {
            for (int topRow = 0; topRow < field.Length; topRow++) {
                for (int leftCol = 0; leftCol < field[topRow].Length; leftCol++) {
                    if (field[topRow][leftCol] == playerId) {
                        for (int bottomRow = topRow + 1; bottomRow < field.Length; bottomRow++) {
                            for (int rightCol = leftCol + 1; rightCol < field[bottomRow].Length; rightCol++) {
                                if (field[bottomRow][leftCol] == playerId &&
                                    field[topRow][rightCol] == playerId &&
                                    field[bottomRow][rightCol] == playerId) {
                                    if (IsPerimeterFilled(topRow, leftCol, bottomRow, rightCol, playerId)) {
                                        FillRectangle(topRow, leftCol, bottomRow, rightCol, playerId);
                                        //Ebbe kell az event hívás
                                        OnTableChanged();
                                    }
                                } 
                            }
                        }
                    } 
                }
            }
        }

        private void OnTableChanged() {
            TableChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnPointsChanged() {
            PointsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnNameChanged() {
            NameChanged?.Invoke(this, EventArgs.Empty);
        }



        //checks sides
        private bool IsPerimeterFilled(int topRow, int leftCol, int bottomRow, int rightCol, int playerId) {
            for (int col = leftCol; col <= rightCol; col++) {
                if (field[topRow][col] != playerId || field[bottomRow][col] != playerId) {
                    return false;
                }
            }

            for (int row = topRow; row <= bottomRow; row++) {
                if (field[row][leftCol] != playerId || field[row][rightCol] != playerId) {
                    return false;
                }
            }
            return true;
        }

        // Filelr
        private void FillRectangle(int topRow, int leftCol, int bottomRow, int rightCol, int playerId) {
            for (int i = topRow; i <= bottomRow; i++) {
                for (int j = leftCol; j <= rightCol; j++) {
                    if(field[i][j] != playerId) {
                        field[i][j] = playerId;
                        Players[playerId - 1].AddToPoint();
                        OnPointsChanged();
                    }
                    
                }
            }
        }
        #endregion
    }
}
