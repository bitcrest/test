using System.Collections.Generic;

namespace Test_Github.Relation
{
    public class SimpleRelation : AbstractRelation
    {
        //private readonly Dictionary<string, int> _colMap;
        private readonly object[,] _values;

        public SimpleRelation(object[,] values, string[] colNames)
            : base(colNames)
        {
            _values = values;
            ColMap = new Dictionary<string, int>();
            for (int i = 0; i < ColNames.Length; i++)
            {
                ColMap.Add(ColNames[i], i);
            }
        }

        public override Dictionary<string, int> ColumnMap
        {
            get { return ColMap; }
        }

        public override object this[int rowIndex, int colIndex]
        {
            get { return _values[rowIndex, colIndex]; }
        }

        public override int RowCount
        {
            get { return _values.GetLength(0); }
        }
    }
}