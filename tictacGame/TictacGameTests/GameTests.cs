using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictacGame;

namespace TictacGameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void isNextStepTest()
        {
            //arrange
            Game g = new Game(2);

            //act
            g.setStatusCell(1, 1, typeCell.zero);
            g.setStatusCell(0, 0, typeCell.cross);

            bool act = g.isNextStep();

            //assert
            Assert.IsTrue(act);
        }
        [TestMethod]
        public void isNextStepNotTest()
        {
            //arrange
            Game g = new Game(2);

            //act
            g.setStatusCell(1, 1, typeCell.zero);
            g.setStatusCell(0, 0, typeCell.cross);
            g.setStatusCell(0, 1, typeCell.zero);
            g.setStatusCell(1, 0, typeCell.cross);
            bool act = g.isNextStep();

            //assert
            Assert.IsFalse(act);
        }

        [TestMethod]
        public void isWinNotTest()
        {
            //arrange
            Game g = new Game(3);

            //act
            g.setStatusCell(1, 1, typeCell.zero);
            g.setStatusCell(0, 0, typeCell.cross);
            g.setStatusCell(0, 1, typeCell.zero);
            g.setStatusCell(1, 0, typeCell.cross);

            typeCell winer;
            bool act = g.isWin(out winer);

            //assert
            Assert.IsFalse(act);
        }

        [TestMethod]
        public void isWinCrossTest()
        {
            //arrange
            Game g = new Game(2);
            typeCell ex = typeCell.cross;

            //act
            g.setStatusCell(1, 1, typeCell.zero);
            g.setStatusCell(0, 0, typeCell.cross);
            g.setStatusCell(0, 1, typeCell.zero);
            g.setStatusCell(1, 0, typeCell.cross);

            typeCell winer;
            bool act = g.isWin(out winer);

            //assert
            Assert.AreEqual(ex, winer);
        }

        [TestMethod]
        public void getStatusCellTest()
        {
            //arrange
            typeCell ex = typeCell.cross;

            //act
            Game f = new Game(3);
            //присваиваем ячейке тип крестик
            f.setStatusCell(1, 1, typeCell.cross);
            typeCell act = f.getStatusCell(1, 1);

            //assert
            Assert.AreEqual(ex, act);
        }

        [TestMethod]
        public void setStatusCellTest()
        {
            //arrange
            typeCell ex = typeCell.zero;

            //act
            Game f = new Game(3);
            //присваиваем ячейке тип крестик
            f.setStatusCell(1, 1, typeCell.zero);
            typeCell act = f.getStatusCell(1, 1);

            //assert
            Assert.AreEqual(ex, act);
        }

        [TestMethod]
        public void newGameTest()
        {
            //arrange
            Game f = new Game(2);

            //act
            f.setStatusCell(1, 1, typeCell.zero);

            f.newGame();
            bool isClear = (f.getStatusCell(0, 0) == typeCell.empty) & (f.getStatusCell(0, 1) == typeCell.empty) &
                (f.getStatusCell(1, 0) == typeCell.empty) & (f.getStatusCell(1, 1) == typeCell.empty);

            //assert
            Assert.IsTrue(isClear);
        }

        [TestMethod]
        public void stepCompTest()
        {
            //arrange
            int ex_row = 0;
            int ex_col = 1;

            //act
            Game f = new Game(3);
            int row = 0, col = 0;
            f.setStatusCell(0, 0, typeCell.cross);

            f.stepComp(typeCell.zero, ref col, ref row);
           
            //assert
            Assert.AreEqual(ex_row,row);
            Assert.AreEqual(ex_col, col);
        }
    }
}
