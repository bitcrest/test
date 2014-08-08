using System.Collections.Generic;

namespace Test_Github.Relation
{
    public abstract class AbstractRelation : IRelation
    {
        protected readonly string[] ColNames;
        protected Dictionary<string, int> ColMap;

        protected AbstractRelation(string[] colNames)
        {
            ColNames = colNames;
        }

        public abstract Dictionary<string, int> ColumnMap { get; }

        public abstract object this[int rowIndex, int colIndex] { get; }

        public abstract int RowCount { get; }

        public int ColCount
        {
            get { return ColNames.Length; }
        }

        public string[] ColumnNames
        {
            get { return ColNames; }
        }

        public int ColIndex(string colName)
        {
            return ColumnMap[colName];
        }
    }
}