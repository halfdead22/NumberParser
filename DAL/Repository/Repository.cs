using DAL.Data;
using DAL.Data.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly NumberParserDbContext dbContext;
        public Repository()
        {
            dbContext = new NumberParserDbContext();
        }
        public bool CreateInputOutputResult(InputOutputResultModel inputOutputResultModel)
        {
            try
            {

                dbContext.InputOutputResult.Add(
                    new InputOutputResult
                    {
                        InputList = inputOutputResultModel.InputList,
                        OutputList = inputOutputResultModel.OutputList,
                        FileTypeId = (int)inputOutputResultModel.FileType,
                        InputTime = inputOutputResultModel.InputTime,
                        OutputTime = inputOutputResultModel.OutputTime
                    }
                    );
                var result =dbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
