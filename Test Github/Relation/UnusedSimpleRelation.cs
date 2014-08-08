using System;
using System.Data;

namespace Test_Github.Relation
{
    internal class UnusedSimpleRelation
    {
        private DataTable _table;

        public UnusedSimpleRelation(string[] columnNames, Type[] types, object[,] values)
        {
            _table = new DataTable();

            if (columnNames.Length != types.Length)
            {
                throw new ArgumentOutOfRangeException("types", "Types must be the same length as columns");
            }
            for (int i = 0; i < columnNames.Length; i++)
            {
                _table.Columns.Add(columnNames[i], types[i]);
            }

            for (int i = 0; i < values.GetLength(0); i++)
            {
                var row = new object[values.GetLength(1)];
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    object val = values[i, j];
                    row[j] = val;
                }
                _table.Rows.Add(row);
            }
        }

        public IRelation EquiJoin(IRelation other)
        {
            throw new NotImplementedException();
        }

        public IRelation SemiJoin(IRelation other)
        {
            throw new NotImplementedException();
        }

        public IRelation LeftJoin(IRelation other)
        {
            throw new NotImplementedException();
        }

        public IRelation Project(string[] columnNames)
        {
            throw new NotImplementedException();
        }

        public IRelation ProjectAway(string[] columnNames)
        {
            throw new NotImplementedException();
        }

        public IRelation Minus(IRelation other)
        {
            throw new NotImplementedException();
        }

        public IRelation Summarize(string[] groupBy, string[] columnToAggregate, string[] types)
        {
            throw new NotImplementedException();
        }

        //        public IRelation Extend<T, TResult>(string newColumnName, Func<T, TResult> func)
        //        {
        //            //_table.Columns.Add()
        //            T arg = default(T);
        //            TResult result = func.Invoke(arg);
        //        }
    }
}