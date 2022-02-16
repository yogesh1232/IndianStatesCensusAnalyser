using System.Collections.Generic;
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {

        string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string indianStateCensusFilePath = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        string indianStateCodeFilePath = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        string wrongIndianStateCensusFilePath = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        string wrongIndianStateCodeFilePath = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaCode.csv";
        string wrongIndianStateCensusFiletype = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        string wrongIndianStateCodeFiletype = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        string wrongIndianStateCensusFileDelimiter = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongIndianStateCodeFileDelimeter = @"C:\Users\sanjay\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm,Rank";
        string wrongIndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode,Popularity";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC-1.1
        /// </summary>
        [TestMethod]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// TC-1.2
        /// </summary>
        [TestMethod]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.type);
        }
        /// <summary>
        /// TC-1.3
        /// </summary>
        [TestMethod]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFiletype, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.type);
        }
        /// <summary>
        /// TC-1.4
        /// </summary>
        [TestMethod]
        public void GivenWrongIndianCensusDataFileDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.type);
        }
        /// <summary>
        /// TC-1.5
        /// </summary>
        [TestMethod]
        public void GivenIndianCensusDataFileNotProperHeader_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileDelimiter, wrongIndianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.type);
        }

        /// <summary>
        /// TC 2.1
        /// </summary>
        [Test]
        public void GivenStateCodeDataFile_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// TC 2.2 
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.type);
        }
        /// <summary>
        /// TC 2.3 
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.type);
        }
        /// <summary>
        /// TC 2.4 delimeter is not proper
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileNotProperDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.type);
        }
        /// <summary>
        /// TC 2.5 headers are not proper
        /// </summary>
        [Test]
        public void GivenWrongStateCodeDataFileNotProperHeaders_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileDelimeter, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.type);
        }
    }
}
