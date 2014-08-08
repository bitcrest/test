using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Github.Relation
{
    public class Join : AbstractRelation
    {
        //private readonly Dictionary<string, int> _colMap;
        private readonly int _columnOffset;

        private readonly IRelation _rel1;
        private readonly IRelation _rel2;
        private readonly List<Tuple<int, int>> _valueMap;

        public Join(IRelation rel1, IRelation rel2)
            : base(MergeUnique(rel1.ColumnMap, rel2.ColumnMap).Keys.ToArray())
        {
            _rel1 = rel1;
            _rel2 = rel2;
            _columnOffset = rel1.ColCount;
            ColMap = MergeUnique(rel1.ColumnMap, rel2.ColumnMap);
            _valueMap = ProcessJoin();
        }

        public override Dictionary<string, int> ColumnMap
        {
            get { return ColMap; }
        }

        public override object this[int rowIndex, int colIndex]
        {
            get
            {
                if (colIndex < _columnOffset)
                {
                    int trueRowIndex = _valueMap[rowIndex].Item1;
                    int trueColIndex = colIndex;
                    return _rel1[trueRowIndex, trueColIndex];
                }
                else
                {
                    int trueRowIndex = _valueMap[rowIndex].Item2;
                    int trueColIndex = colIndex + _columnOffset;
                    return _rel2[trueRowIndex, trueColIndex];
                }
            }
        }

        public override int RowCount
        {
            get { return _valueMap.Count; }
        }

        private List<Tuple<int, int>> ProcessJoin()
        {
            var res = new List<Tuple<int, int>>();
            int I = _rel1.RowCount;
            int J = _rel2.RowCount;
            List<Tuple<int, int>> common = CommonColumns(_rel1.ColumnMap, _rel2.ColumnMap);
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (SatisfyJoinCondition(_rel1, i, _rel2, j, common))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", i, j, _rel1[i, 0], _rel2[j, 0]);
                        // output tuple <R, S>
                        res.Add(new Tuple<int, int>(i, j));
                        break;
                    }
                }
            }
            return res;
        }

        private static bool SatisfyJoinCondition(IRelation rel1, int i, IRelation rel2, int j, IEnumerable<Tuple<int, int>> commonColumns)
        {
            return commonColumns.All(commonColumn => rel1[i, commonColumn.Item1].Equals(rel2[j, commonColumn.Item2]));
        }

        private static List<Tuple<int, int>> CommonColumns(Dictionary<string, int> dic1, Dictionary<string, int> dic2)
        {
            return (from x in dic1.Keys where dic2.ContainsKey(x) select new Tuple<int, int>(dic1[x], dic2[x])).ToList();
        }

        private static Dictionary<string, int> MergeUnique(Dictionary<string, int> dic1, Dictionary<string, int> dic2)
        {
            var res = new Dictionary<string, int>(dic1);
            int offset = dic1.Count;
            foreach (string x in dic2.Keys.Where(x => !dic1.ContainsKey(x)))
            {
                res.Add(x, dic2[x] + offset);
            }
            return res;
        }
    }
}