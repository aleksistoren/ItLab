using NUnit.Framework;
using System.Collections.Generic;
using LAB_IT_SERVER_;

namespace DataBaseTests
{
    public class TableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProjectTablesTest()
        {
            Database database = new Database("db");
            var columnDefinitions = new List<Column>
            {
                new Column { Name = "a", Type = ColumnType.Int },
                new Column { Name = "b", Type = ColumnType.Double },
                new Column { Name = "c", Type = ColumnType.Int }
            };
            Table table1 = new Table(database, "t1", columnDefinitions);
            table1.AddRow(new List<object> { 1, -1, 3 });
            table1.AddRow(new List<object> { 2, 3.122, 4 });
            table1.AddRow(new List<object> { 1, 2.1251, 3 });
            table1.AddRow(new List<object> { 1, 2.12511, 3 });

            List<List<object>> expected = new List<List<object>>
            {
                new List<object> { 1, -1},
                new List<object> { 2, 3.122},
                new List<object> { 1, 2.1251},
                new List<object> { 1, 2.12511},
            };

            var l = new List<int>();
            l.Add(1);
            l.Add(2);

            List<List<object>> actual = Table.ProjectionTables(table1, l);

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Count, actual[i].Count);
                for (int j = 0; j < expected[i].Count; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j], string.Format("Row {0}, Column {1}", i, j));
                }
            }
        }

        [Test]
        public void AddRowTest()
        {
            Database database = new Database("db");
            var columnDefinitions = new List<Column>
            {
                new Column { Name = "a", Type = ColumnType.Int },
                new Column { Name = "b", Type = ColumnType.Double },
                new Column { Name = "c", Type = ColumnType.String }
            };
            Table table = new Table(database, "t1", columnDefinitions);
            table.AddRow(new List<object> { 1, -1, "smth" });
            table.AddRow(new List<object> { 2, 3.122, "" });
            table.AddRow(new List<object> { 1, 2.1251, "cd" });
            table.AddRow(new List<object> { 1, 2.12511, "ab" });
            List<List<object>> expected = new List<List<object>>
            {
                new List<object> { 1, -1.0, "smth" },
                new List<object> { 2, 3.122, "" },
                new List<object> { 1, 2.1251, "cd" },
                new List<object> { 1, 2.12511, "ab" }
            };
            List<List<object>> actual = table.Data;

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Count, actual[i].Count);
                for (int j = 0; j < expected[i].Count; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j], string.Format("Row {0}, Column {1}", i, j));
                }
            }
        }


    }
}