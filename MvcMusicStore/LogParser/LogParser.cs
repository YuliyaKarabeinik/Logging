//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace MvcMusicStore.LogParser
//{
//    public class LogParser
//    {
//        public double ParseW3CLog(string userID)
//        {

//            // prepare LogParser Recordset & Record objects
//            ILogRecordset rsLP = null;
//            ILogRecord rowLP = null;

//            LogQueryClassClass LogParser = null;
//            COMW3CInputContextClassClass W3Clog = null;

//            double UsedBW = 0;
//            int Unitsprocessed;
//            double sizeInBytes;

//            string strSQL = null;

//            LogParser = new LogQueryClassClass();
//            W3Clog = new COMW3CInputContextClassClass();

//            try
//            {
//                //W3C Logparsing SQL. Replace this SQL query with whatever 
//                //you want to retrieve. The example below 
//                //will sum up all the bandwidth
//                //Usage of a specific folder with name 
//                //"userID". Download Log Parser 2.2 
//                //from Microsoft and see sample queries.

//                strSQL = @"SELECT SUM(sc-bytes) from C:\\logs" +
//                         @"\\*.log WHERE cs-uri-stem LIKE '%/" +
//                         userID + "/%' ";

//                // run the query against W3C log
//                rsLP = LogParser.Execute(strSQL, W3Clog);

//                rowLP = rsLP.getRecord();

//                Unitsprocessed = rsLP.inputUnitsProcessed;

//                if (rowLP.getValue(0).ToString() == "0" ||
//                    rowLP.getValue(0).ToString() == "")
//                {
//                    //Return 0 if an err occured
//                    UsedBW = 0;
//                    return UsedBW;
//                }

//                //Bytes to MB Conversion
//                double Bytes = Convert.ToDouble(rowLP.getValue(0).ToString());
//                UsedBW = Bytes / (1024 * 1024);

//                //Round to 3 decimal places
//                UsedBW = Math.Round(UsedBW, 3);
//            }
//            catch
//            {
//                throw;
//            }

//            return UsedBW;
//        }
//    }
//}