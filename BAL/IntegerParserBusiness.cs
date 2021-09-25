using BAL.Entities;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BAL
{
    public class IntegerParserBusiness : IIntegerParserBusiness
    {
        private readonly IRepository _repository;
        private readonly IFileOperation _fileOperation;
        public IntegerParserBusiness()
        {
            _repository = new Repository();
            _fileOperation = new FileOperation();
        }
        public bool PerformNumberParser(InputData inputData)
        {
            try
            {
                InputOutputResultModel inputOutputResult = new InputOutputResultModel();
                if (_fileOperation.WriteToSpecifiedFile(sortArrayInDescending(inputData.integerArray), inputData.Filetype))
                {
                    inputOutputResult.OutputTime = DateTime.Now;
                    inputOutputResult.InputTime = inputData.inputTime;
                    inputOutputResult.FileType = getFileType(inputData.Filetype);
                    inputOutputResult.InputList = string.Join(",", inputData.integerArray);
                    inputOutputResult.OutputList = string.Join(",", sortArrayInDescending(inputData.integerArray));
                    return _repository.CreateInputOutputResult(inputOutputResult);
                }
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            return false;
        }


        private int[] sortArrayInDescending(int[] intArray)
        {
            Array.Sort(intArray);
            Array.Reverse(intArray);
            return intArray;
        }

        private FileType getFileType(string fileType)
        {
            if (fileType == "xml")
                return FileType.Xml;
            else if (fileType == "json")
                return FileType.Json;
            else
                return FileType.Text;
        }
    }
}
