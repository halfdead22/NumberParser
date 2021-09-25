using BAL.Entities;
using BAL.Factory;
using System;

namespace NumberParser
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData inputData = new InputData();
            inputData.inputTime = DateTime.Now; //capture inpute time
            try
            {
                if (validateInput(args))
                {
                    var _businessObject = BusinessFactory.GetObject();
                    inputData.integerArray = Array.ConvertAll(args[0].Split(','), int.Parse);
                    inputData.Filetype = args[1].ToLower();
                    if (_businessObject.PerformNumberParser(inputData))
                        Console.WriteLine("Output Generated Successfully in " + inputData.Filetype + " file");
                    else
                        Console.WriteLine("There was error in generating Output");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " +ex.Message);
            }
        }

        public static bool validateInput(string[] inputArray)
        {
            if (inputArray != null && inputArray.Length != 2)
                throw new ArgumentException("Invalid number of Input Parameters");

            if (!(inputArray[1].ToLower().Equals("xml") || inputArray[1].ToLower().Equals("json") || inputArray[1].ToLower().Equals("text")))
                throw new ArgumentException("Invalid File Format");

            try
            {
                int[] nums = Array.ConvertAll(inputArray[0].Split(','), int.Parse);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error in comma separated integer input");
            }
            return true;
        }
    }
}
