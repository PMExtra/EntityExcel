using System;
using System.Data;
using System.IO;
using Excel;

namespace EntityExcel
{
    public class ExcelReader : IDisposable
    {
        private readonly IExcelDataReader _dataReader;
        private readonly FileStream _fileStream;

        public ExcelReader(string path)
        {
            _fileStream = File.OpenRead(path);

            var extension = Path.GetExtension(path)?.ToLower();
            switch (extension)
            {
                case ".xls":
                    FileType = EFileType.Excel97;
                    _dataReader = ExcelReaderFactory.CreateBinaryReader(_fileStream);
                    break;

                case ".xlsx":
                    FileType = EFileType.Excel2007;
                    _dataReader = ExcelReaderFactory.CreateOpenXmlReader(_fileStream);
                    break;

                default:
                    throw new NotSupportedException("Only support excel workbook file that extension name is '.xls' or '.xlsx'.");
            }
            _dataReader.IsFirstRowAsColumnNames = true;
            DataSet = _dataReader.AsDataSet();
        }

        public EFileType FileType { get; private set; }

        public DataSet DataSet { get; }

        public DataTable this[int index] => DataSet.Tables[index];

        public DataTable this[string name] => DataSet.Tables[name];

        public void Dispose()
        {
            _dataReader.Dispose();
            _fileStream.Dispose();
        }
    }
}