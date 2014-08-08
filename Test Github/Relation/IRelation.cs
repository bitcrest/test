using System.Collections.Generic;

namespace Test_Github.Relation
{
    public interface IRelation
    {
        object this[int rowIndex, int colIndex] { get; }

        int RowCount { get; }

        int ColCount { get; }

        string[] ColumnNames { get; }

        Dictionary<string, int> ColumnMap { get; }

        int ColIndex(string colName);

        //        IRelation EquiJoin(IRelation other);
        //
        //        IRelation SemiJoin(IRelation other);
        //
        //        IRelation LeftJoin(IRelation other);
        //
        //        IRelation Project(string[] columnNames);
        //
        //        IRelation ProjectAway(string[] columnNames);
        //
        //        IRelation Minus(IRelation other);
        //
        //        IRelation Summarize(string[] groupBy, string[] columnToAggregate, string[] types);
        //
        //        IRelation Extend<T, TResult>(string newColumnName, Func<T, TResult> func);
    }
}