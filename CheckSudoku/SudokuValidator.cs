using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSudoku
{

    public class SudokuValidator
    {
       

        private int[,] SudokuInput = new int[9, 9];

        private string[] SudokuStrInput { get; set; }

        public SudokuValidator(string pathToFile)
        {
            LoadSudokuSolution(pathToFile);
        }
        
        public void Set2DNumericArray()
        {
            for (int i = 0; i < this.SudokuStrInput.Length; i++)
            {
                int[] numLine = this.SudokuStrInput[i].Select(c => c - '0').ToArray();
                for (int j = 0; j < numLine.Length; j++)
                {
                    SudokuInput[i, j] = numLine[j];
                }
            }
        }
        public bool SudokuInputValid()
        {
            bool inputValid = true;
            if (!this.InputRowsNumberValid())
            {
                inputValid = false;
            }
            else if (!this.InputRowsLengthValid())
            {
                inputValid = false;
            }
            else
            {
                Set2DNumericArray();
            }
            return inputValid;
        }

        public bool InputRowsLengthValid()
        {
            bool valid = true;
            for (int i = 0; i < this.SudokuStrInput.Length; i++)
            {
                valid = RowLengthValid(this.SudokuStrInput[i]);
                if (!valid)
                {
                    break;
                }
               
            }
            return valid;
        }

        private bool RowLengthValid(string row)
        {
            return row.Length == 9;
        }

        public bool InputRowsNumberValid()
        {
            return this.SudokuStrInput.Length == 9;
        }

       

        private void LoadSudokuSolution(string pathToFile)
        {
            var allRows = File.ReadAllLines(pathToFile);
            this.SudokuStrInput = allRows.Where(line => line.Length > 0).ToArray();
        }


        public bool CheckColumns()
        {
            bool[] checkAll = new bool[9];

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    int idx = this.SudokuInput[i,j] - 1;
                    checkAll[idx] = !checkAll[idx];
                }

            }
            bool retVal = true;
            for (int i = 0; i < 9; i++)
            {
                retVal = retVal & checkAll[i];
            }
            return retVal;

        }

        public bool CheckRows()
        {
            bool[] checkAll = new bool[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int idx = this.SudokuInput[i, j] - 1;
                    checkAll[idx] = !checkAll[idx];
                }
            }
            bool retVal = true;
            for (int i = 0; i < 9; i++)
            {
                retVal = retVal & checkAll[i];
            }
            return retVal;
        }


        public bool Check3x3()
        {
            bool[] checkAll = new bool[9];
            for (int iI = 0; iI < 9; iI += 3)
            {
                for (int jJ = 0; jJ < 9; jJ += 3)
                {
                    for (int i = iI; i < iI + 3; i++)
                    {
                        for (int j = jJ; j < jJ + 3; j++)
                        {
                            checkAll[this.SudokuInput[i,j] - 1] = !checkAll[this.SudokuInput[i,j] - 1];
                        }
                    }
                }
            }

            bool retVal = true;
            for (int i = 0; i < 9; i++)
            {
                retVal = retVal & checkAll[i];
            }
            return retVal;

        }

        public bool SudokuSolutionValid()
        {
            return this.CheckRows() && this.CheckColumns() && this.Check3x3(); 
        }
    }
}
