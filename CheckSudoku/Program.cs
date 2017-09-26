using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuValidator sValidator = new SudokuValidator(args[0]);
            if (!sValidator.SudokuInputValid())
            {
                Console.WriteLine("Input not valid");
            }
            else
            {
                if (sValidator.SudokuSolutionValid())
                {
                    Console.WriteLine("Solution valid");
                } else
                {
                    Console.WriteLine("Solution not valid");
                }
            }
            
        }
    }
}
