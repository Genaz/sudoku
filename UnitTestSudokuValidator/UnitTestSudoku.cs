using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSudoku;

namespace UnitTestSudokuValidator
{
    [TestClass]
    public class SudokuValidatorTests    {
        public string Path { get; set; }

        public SudokuValidatorTests()
        {
           this.Path = @"C:/sudoku/input_sudoku.txt";
        }
        [TestMethod]
        public void InputRowsNumberShouldBeEqual9()
        {
            SudokuValidator sValidator = new SudokuValidator(this.Path);
            sValidator.Set2DNumericArray();
            Assert.IsTrue(sValidator.InputRowsNumberValid());
        }

        [TestMethod]
        public void AllInputRowsLengthShouldBeEqual9()
        {
            SudokuValidator sValidator = new SudokuValidator(this.Path);
            Assert.IsTrue(sValidator.InputRowsLengthValid());
        }

        [TestMethod]
        public void AllDigitAreDifferentForEachRow()
        {
            SudokuValidator sValidator = new SudokuValidator(this.Path);
            Assert.IsTrue(sValidator.SudokuInputValid() && sValidator.CheckRows());
        }

        [TestMethod]
        public void  AllDigitAreDifferentForEachColumn()
        {
            SudokuValidator sValidator = new SudokuValidator(this.Path);
            Assert.IsTrue(sValidator.SudokuInputValid() && sValidator.CheckColumns());
        }

        [TestMethod]
        public void AllDigitAreDifferentForEach3x3()
        {
            SudokuValidator sValidator = new SudokuValidator(this.Path);
            Assert.IsTrue(sValidator.SudokuInputValid() && sValidator.Check3x3());
        }
    }
}
