using GameMechanics.Persistence;
using System.ComponentModel;
using Moq;
using GameMechanics.Classes;
using System.Drawing;

namespace GameMechanicsMsTest {
    [TestClass]
    public class Test {

        private Game? _game = null;
        private Mock<IFileManager> _mock = null!;

        [TestInitialize]
        public void InitGameMechanicsTest() {
            _mock = new Mock<IFileManager>();
        }

        [TestMethod]
        public void LoadTest() {
            string[] mockFileData = new string[] {
                "3",              // size
                "0,1,0",          // field
                "0,0,0",
                "1,0,1",
                "1,Red,Player1",   //players
                "2,Blue,Player2",
                ""
            };
            _mock.Setup(m => m.Load()).Returns(string.Join("\n", mockFileData));

            _game = new Game();
            
            _game.LoadGame(_mock.Object);

            Assert.AreEqual(3, _game.field.Length);
            CollectionAssert.AreEqual(new int[] { 0, 1, 0 }, _game.field[0]);
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, _game.field[1]);
            CollectionAssert.AreEqual(new int[] { 1, 0, 1 }, _game.field[2]);

            Assert.AreEqual(2, _game.Players.Count);
            Assert.AreEqual("Player1", _game.Players[0].Name);
            Assert.AreEqual("Player2", _game.Players[1].Name);
            Assert.AreEqual(Color.Red, _game.Players[0].Color);
            Assert.AreEqual(Color.Blue, _game.Players[1].Color);
        }

        [TestMethod]
        public void SaveGameTest() {
            string path = "testSave.txt";
            String[][] players = {
                ["Player1", "red"],
                ["Player2", "blue"]
            };
            _game = new Game();

            _game.NewGame(3, players[0][0], players[0][1],
                players[1][0], players[1][1]);
            // Act
            _game.SaveGame(path);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var savedContent = File.ReadAllText(path).Split('\n');
            Assert.AreEqual("3", savedContent[0]);
            Assert.AreEqual("0,0,0", savedContent[1]);
            Assert.AreEqual("0,0,0", savedContent[2]);
            Assert.AreEqual("0,0,0", savedContent[3]);
            Assert.AreEqual("0,Red,Player1", savedContent[4]);
            Assert.AreEqual("0,Blue,Player2", savedContent[5]);
        }

        [TestMethod]
        public void ClearTest() {

            String[][] players = {
                ["Sanyika","gold"],
                ["Petike","green"]
            };
            _game = new Game();

            _game.NewGame(3, players[0][0], players[0][1],
                players[1][0], players[1][1]);
            _game.Step(["0", "0"], ["0", "1"]);

            _game.NewGame(3);

            // Assert
            foreach (var row in _game.field) {
                CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, row);
            }
            Assert.AreEqual(0, _game.Players[0].Points);
            Assert.AreEqual(0, _game.Players[1].Points);
        }

        [TestMethod]
        public void StepTest() {
            String[][] players = {
                ["Player1", "red"],
                ["Player2", "blue"]
            };
            _game = new Game();

            _game.NewGame(3, players[0][0], players[0][1],
                players[1][0], players[1][1]);

            _game.Step(["0", "0"], ["0", "1"]);

            Assert.AreEqual(1, _game.field[0][0]);
            Assert.AreEqual(1, _game.field[0][1]);
            Assert.AreEqual(2, _game.Players[0].Points);
            Assert.AreEqual(0, _game.Players[1].Points);
        }

        [TestMethod]
        public void EndGameTest() {
            String[][] players = {
                ["Player1", "red"],
                ["Player2", "blue"]
            };
            _game = new Game();

            _game.NewGame(3, players[0][0], players[0][1],
                players[1][0], players[1][1]);

            _game.Step(["0", "1"], ["0", "2"]);
            Assert.ThrowsException<ArgumentException>(() => _game.Step(["0", "2"], ["1", "0"]));

            _game.Step(["1", "0"], ["1", "1"]);
            

            bool isGameEnded = _game.EndGame();

            Assert.IsFalse(isGameEnded);

            _game.Step(["2", "1"], ["2", "2"]);
            isGameEnded = _game.EndGame();
            Assert.IsTrue(isGameEnded);
        }

        [TestMethod]
        public void WinnerTest() {
            IFileManager? fileManager = FileManagerFactory.CreateForPath("testWin.txt");

            Assert.IsNotNull(fileManager);
            _game = new Game();
            _game.LoadGame(fileManager);
            string winner = _game.Winner();

            Assert.AreEqual("gold", winner);
        }

        [TestMethod]
        public void TestFilling() {
            IFileManager? fileManager = FileManagerFactory.CreateForPath("testFilling.txt");

            Assert.IsNotNull(fileManager);
            _game = new Game();
            _game.LoadGame(fileManager);
            /*Table now:
             1,1,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             1,1,1,2,1,1,1,1
             1,1,1,2,0,0,0,1
             1,1,1,0,0,0,0,1
             1,1,1,0,1,1,1,1
            */

            _game.Step(["5", "4"], ["6", "4"]);
            /*Table now:
             1,1,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             0,0,2,2,2,2,2,2
             1,1,1,2,1,1,1,1
             1,1,1,2,1,1,1,1
             1,1,1,0,1,1,1,1
             1,1,1,0,1,1,1,1
            */
            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 2, 1, 1, 1, 1 }, 
                _game.field[5]);
            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 0, 1, 1, 1, 1 }, 
                _game.field[6]);
        }


        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void LoadTest_IOException() {
            _mock.Setup(m => m.Load()).Throws(new IOException());
            _game = new Game();
            _game.LoadGame(_mock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void LoadTestInvalidFileFormat() {
            string[] invalidData = new string[] {
                "NotAnInteger",
                "0,1,0",
                "1,Red,Player1",
    };
            _mock.Setup(m => m.Load()).Returns(string.Join("\n", invalidData));
            _game = new Game();
            _game.LoadGame(_mock.Object);
        }

        [TestMethod]
        public void TestTableReady() {
            String[][] players = {
                ["Player1", "red"],
                ["Player2", "blue"]
            };
            Game game = new Game();
            bool IsGameReadyInvoked = false;
            game.TableReady += (sender, args) => { IsGameReadyInvoked = true; };

            Assert.IsFalse(IsGameReadyInvoked);
            game.NewGame(10, players[0][0], players[0][1],
                players[1][0], players[1][1]);
            Assert.IsTrue(IsGameReadyInvoked);
        }

        //Can't test because NuGet
        /*[TestMethod]
        [ExpectedException(typeof(IOException))]
        public void LoadTest_NullFileManager_ThrowsIOException() {
            IFileManager ?fileManager = null;
            Assert.IsNull(fileManager);
            _game = new Game(fileManager);
        }*/

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Step_OutOfBounds_ThrowsIndexOutOfRangeException() {
            String[][] players = {
                ["Player1", "red"],
                ["Player2", "blue"]
            };
            _game = new Game();

            _game.NewGame(3, players[0][0], players[0][1],
                players[1][0], players[1][1]);

            _game.Step(["3", "3"], ["3", "4"]);
        }




    }
}