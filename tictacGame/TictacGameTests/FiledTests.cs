using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictacGame;

namespace TictacGameTests
{
    [TestClass]
    public class FiledTests
    {
        [TestMethod]
        public void clearFiledTest()
        {
            //arrange
            typeCell ex = typeCell.empty;
       
            //act
            Filed f = new Filed(3);
            //портим ячейку
            f.setStatusCell(1, 1, typeCell.cross);
            // очищаем поле
            f.clearFiled();
            typeCell act = f.getStatusCell(1, 1);

            //assert
            Assert.AreEqual(ex, act);
        }
        [TestMethod]
        public void getStatusCellTest()
        {
            //arrange
            typeCell ex = typeCell.cross;

            //act
            Filed f = new Filed(3);
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
            Filed f = new Filed(3);
            //присваиваем ячейке тип крестик
            f.setStatusCell(1, 1, typeCell.zero);
            typeCell act = f.getStatusCell(1, 1);

            //assert
            Assert.AreEqual(ex, act);
        }
      
        [TestMethod]
        public void isWinCrossDioganalTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 0, typeCell.cross);
            f.setStatusCell(1, 1, typeCell.cross);
            f.setStatusCell(2, 2, typeCell.cross);

            //act
            bool win = f.isWinCross();

            //assert
            Assert.IsTrue(win);
        }
        [TestMethod]
        public void isWinCrossDioganalNotTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 0, typeCell.cross);
            f.setStatusCell(1, 1, typeCell.zero);
            f.setStatusCell(2, 2, typeCell.cross);

            //act
            bool win = f.isWinCross();

            //assert
            Assert.IsFalse(win);
        }

        [TestMethod]
        public void isWinCrossRowTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 0, typeCell.cross);
            f.setStatusCell(0, 1, typeCell.cross);
            f.setStatusCell(0, 2, typeCell.cross);

            //act
            bool win = f.isWinCross();

            //assert
            Assert.IsTrue(win);
        }

        [TestMethod]
        public void isWinCrossColumnTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 1, typeCell.cross);
            f.setStatusCell(1, 1, typeCell.cross);
            f.setStatusCell(2, 1, typeCell.cross);

            //act
            bool win = f.isWinCross();

            //assert
            Assert.IsTrue(win);
        }

        [TestMethod]
        public void isWinCrossColumnNotTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 1, typeCell.cross);
            f.setStatusCell(1, 2, typeCell.cross);
            f.setStatusCell(2, 1, typeCell.cross);

            //act
            bool win = f.isWinCross();

            //assert
            Assert.IsFalse(win);
        }

        [TestMethod]
        public void isWinZeroColumnTest()
        {
            //arrange
            Filed f = new Filed(3);

            f.setStatusCell(0, 1, typeCell.zero);
            f.setStatusCell(1, 1, typeCell.zero);
            f.setStatusCell(2, 1, typeCell.zero);

            //act
            bool win = f.isWinZero();

            //assert
            Assert.IsTrue(win);
        }
    }
}
