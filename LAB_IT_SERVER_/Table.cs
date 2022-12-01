using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LAB_IT_SERVER_
{
    [Serializable]
    public enum ColumnType
    {
        Int,
        Double,
        Char,
        String,
        ComplexInteger,
        ComplexDouble,
    }

    [Serializable]
    public struct ComplexInt
    {
        public int a;
        public int b;

        public override string ToString()
        {
            return a.ToString() + " + " + b.ToString() + "i";
        }
    }

    [Serializable]
    public struct ComplexDouble
    {
        public double a;
        public double b;

        public override string ToString()
        {
            return a.ToString() + " + " + b.ToString() + "i";
        }
    }

    [Serializable]
    public class Column
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
    }

    [Serializable]
    public class Table
    {
        public string Name { get; set; }
        private Database ParentDatabase { get; set; }
        public List<Column> ColumnDefinitions { get; set; }
        public List<List<object>> Data { get; set; }

        #region Constructors
        public Table()
        {
            ParentDatabase = new Database();
            ColumnDefinitions = new List<Column>();
            Data = new List<List<object>>();
        }

        public Table(Database parentDatabase, string name, List<Column> columnDefinitions)
        {
            this.Name = name;
            this.ParentDatabase = parentDatabase;
            if (columnDefinitions.GroupBy(x => x.Name).Where(x => x.Count() > 1).Any())
            {
                throw new ArgumentException("Duplicate column names in column list!");
            }
            if (columnDefinitions.Count == 0)
            {
                throw new ArgumentException("Empty column list!");
            }
            this.ColumnDefinitions = columnDefinitions;
            this.Data = new List<List<object>>();
        }

        #endregion

        #region Main functions
        public void AddRow(List<object> row, int rowIndex = -1)
        {
            if (row.Count() != ColumnDefinitions.Count())
            {
                throw new ArgumentException(string.Format(
                    "Provided values count {0} is not equal to table's column count {1}",
                    row.Count(), this.ColumnDefinitions.Count()));
            }

            for (int i = 0; i < row.Count(); i++)
            {
                try
                {
                    switch (ColumnDefinitions[i].Type)
                    {
                        case ColumnType.Int:
                            row[i] = Convert.ToInt32(row[i]);
                            break;
                        case ColumnType.Double:
                            row[i] = Convert.ToDouble(row[i]);
                            break;
                        case ColumnType.Char:
                            row[i] = Convert.ToChar(row[i]);
                            break;
                        case ColumnType.String:
                            row[i] = Convert.ToString(row[i]);
                            break;
                        case ColumnType.ComplexInteger:
                            string complexInt = Convert.ToString(row[i]);
                            row[i] = new ComplexInt
                            {
                                a = Convert.ToInt32(complexInt.Substring(0, complexInt.IndexOf('+')).Trim()),
                                b = Convert.ToInt32(complexInt.Substring(complexInt.IndexOf('+') + 1,
                                        complexInt.IndexOf('i') - complexInt.IndexOf('+') - 1).Trim()),
                            };
                            break;
                        case ColumnType.ComplexDouble:
                            string complexDouble = Convert.ToString(row[i]);
                            row[i] = new ComplexDouble
                            {
                                a = Convert.ToDouble(complexDouble.Substring(0, complexDouble.IndexOf('+')).Trim()),
                                b = Convert.ToDouble(complexDouble.Substring(complexDouble.IndexOf('+') + 1,
                                        complexDouble.IndexOf('i') - complexDouble.IndexOf('+') - 1).Trim()),
                            };
                            break;
                    }
                }
                catch
                {
                    throw new ArgumentException(string.Format(
                        "Type mismatch for column '{0}'", ColumnDefinitions[i].Name));
                }
            }

            if (rowIndex == -1)
            {
                Data.Add(row);
            }
            else
            {
                Data.Insert(rowIndex, row);
            }
        }

        public void DeleteRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Data.Count())
            {
                throw new ArgumentException("Invalid row index for delete");
            }
            Data.RemoveAt(rowIndex);
        }

        public void UpdateRow(List<object> row, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex > Data.Count())
            {
                throw new ArgumentException("Invalid row index for update");
            }
            AddRow(row, rowIndex);
            if (rowIndex + 1 < Data.Count())
            {
                DeleteRow(rowIndex + 1);
            }
        }

        #endregion

        public bool ValidateDeserialization()
        {
            try
            {
                int n = Data.Count;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < Data[i].Count; j++)
                    {
                        Data[i][j] = ((JsonElement)Data[i][j]).ToString();
                    }
                    AddRow(Data[i]);
                }
                for (int i = 0; i < n; i++)
                {
                    DeleteRow(0);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<object>> ProjectionTables(Table table1, List<int> idxs)
        {
            var result = new List<List<object>>();
            foreach (var idx in idxs)
            {
                if (table1.ColumnDefinitions.Count < idx)
                {
                    throw new InvalidOperationException($"Index {idx} does not exist");
                }
            }

            foreach (var row in table1.Data)
            {
                List<object> newRow = new List<object>();
                foreach (var i in idxs)
                {
                    newRow.Add(row[i - 1]);
                }
                result.Add(newRow);
            }


            return result;
        }
    }
}
