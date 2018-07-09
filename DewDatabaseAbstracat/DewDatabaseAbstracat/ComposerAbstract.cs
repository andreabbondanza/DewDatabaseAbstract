using System;
using System.Collections.Generic;
using System.Text;

namespace DewCore.Abstract.Database
{
    /// <summary>
    /// Simple query composer
    /// </summary>
    public interface ISimpleQueryComposer
    {
        /// <summary>
        /// Select composition
        /// </summary>
        /// <param name="columns">if null is *</param>
        /// <returns></returns>
        ISimpleQueryComposer Select(params string[] columns);
        /// <summary>
        /// Select distinct composition
        /// </summary>
        /// <param name="columns">if null is *</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectDistinct(params string[] columns);
        /// <summary>
        /// Select count composition
        /// </summary>
        /// <param name="columns">if null is *</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectCount(params string[] columns);
        /// <summary>
        /// Select avg composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectAvg(string column);
        /// <summary>
        /// Select sum composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectSum(string column);
        /// <summary>
        /// Select min composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectMin(string column);
        /// <summary>
        /// Select max composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns></returns>
        ISimpleQueryComposer SelectMax(string column);
        /// <summary>
        /// Update composition, should be followed by Condition
        /// </summary>
        /// <param name="table">column name</param>
        /// <returns></returns>
        ISimpleQueryComposer Update(string table);
        /// <summary>
        /// Delete composition, should be followed by from
        /// </summary>
        /// <returns></returns>
        ISimpleQueryComposer Delete();
        /// <summary>
        /// Insert composition, should be followed by values
        /// </summary>
        /// <param name="table">table name</param>
        /// <param name="columns">columns</param>
        /// <returns></returns>
        ISimpleQueryComposer Insert(string table, params string[] columns);
        /// <summary>
        /// Return Values composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISimpleQueryComposer Values(params string[] columns);
        /// <summary>
        /// Return from composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        ISimpleQueryComposer From(string table);
        /// <summary>
        /// Return join composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        ISimpleQueryComposer Join(string table);
        /// <summary>
        /// Return left join composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        ISimpleQueryComposer LJoin(string table);
        /// <summary>
        /// Return right join composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        ISimpleQueryComposer RJoin(string table);
        /// <summary>
        /// Return where composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <param name="op">operation</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        ISimpleQueryComposer Where(string column, string op, string value);
        /// <summary>
        /// Return orderby composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISimpleQueryComposer OrderBy(params string[] columns);
        /// <summary>
        /// Return orderby desc composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISimpleQueryComposer OrderByDesc(params string[] columns);
        /// <summary>
        /// Return groupby composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISimpleQueryComposer GroupBy(params string[] columns);
        /// <summary>
        /// Return AND composition
        /// </summary>
        /// <param name="column">column name</param>
        /// <param name="op">operation</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        ISimpleQueryComposer AND(string column, string op, string value);
        /// <summary>
        /// Return single AND composition
        /// </summary>
        /// <returns></returns>
        ISimpleQueryComposer AND();
        /// <summary>
        /// Return a condition, followed by comma if needed
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <param name="comma"></param>
        /// <returns></returns>
        ISimpleQueryComposer Condition(string column, string op, string value, string comma);
        /// <summary>
        /// Return single OR composition
        /// </summary>
        /// <returns></returns>
        ISimpleQueryComposer OR();
        /// <summary>
        /// Return IN composition
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        ISimpleQueryComposer IN(ISimpleQueryComposer innerComposer);
        /// <summary>
        /// Return OR composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ISimpleQueryComposer OR(string column, string op, string value);
        /// <summary>
        /// Return Not composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ISimpleQueryComposer NOT(string column, string op, string value);
        /// <summary>
        /// Return single Not composition
        /// </summary>
        /// <returns></returns>
        ISimpleQueryComposer NOT();
        /// <summary>
        /// Return between composition {column} BETWEEN {before} AND {after}
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        ISimpleQueryComposer Between(string column, string before, string after);
        /// <summary>
        /// Return brackets ({composition})
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        ISimpleQueryComposer Brackets(ISimpleQueryComposer innerComposer);
        /// <summary>
        /// Return ON composition
        /// </summary>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        /// <returns></returns>
        ISimpleQueryComposer ON(string columnA, string columnB);
        /// <summary>
        /// Clear current query
        /// </summary>
        /// <returns></returns>
        ISimpleQueryComposer Reset();
        /// <summary>
        /// Get composet query
        /// </summary>
        /// <returns></returns>
        string ComposedQuery();
    }

    /// <summary>
    /// Complex query composer
    /// </summary>
    public interface IQueryComposer
    {
        /// <summary>
        /// Reset current query
        /// </summary>
        void Reset();
        /// <summary>
        /// Get composed query
        /// </summary>
        /// <returns></returns>
        string ComposedQuery();
        /// <summary>
        /// Append a new composition
        /// </summary>
        /// <param name="compose"></param>
        /// <returns></returns>
        IQueryComposer Compose(IQueryComposer compose);
        /// <summary>
        /// Append a column
        /// </summary>
        /// <typeparam name="T">Target query composition object</typeparam>
        /// <param name="column">Column name</param>
        /// <returns></returns>
        T Column<T>(string column) where T : class, IQueryComposer;
        /// <summary>
        /// Set a query when the constructor can't be called
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        T SetQuery<T>(string query) where T : class, IQueryComposer;

    }

    /// <summary>
    /// Root query composer
    /// </summary>
    public interface IRootComposer
    {
        /// <summary>
        /// Select composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISelectComposer Select(params string[] columns);
        /// <summary>
        /// Select distinct composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISelectComposer SelectDistinct(params string[] columns);
        /// <summary>
        /// Select count composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISelectComposer SelectCount(params string[] columns);
        /// <summary>
        /// Select avg
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        ISelectComposer SelectAvg(string column);
        /// <summary>
        /// Select Sum
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        ISelectComposer SelectSum(string column);
        /// <summary>
        /// Select min
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        ISelectComposer SelectMin(string column);
        /// <summary>
        /// Select max
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        ISelectComposer SelectMax(string column);
        /// <summary>
        /// Update composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IUpdateComposer Update(string table);
        /// <summary>
        /// Delete composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IDeleteComposer Delete(string table);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        IInsertComposer Insert(string table, params string[] columns);
    }

    /// <summary>
    /// Update composer
    /// </summary>
    public interface IUpdateComposer : IQueryComposer
    {
        /// <summary>
        /// Condition composition,
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <param name="comma"></param>
        /// <returns></returns>
        IConditionComposer Condition(string column, string op, string value, string comma);
    }
    /// <summary>
    /// Select composer
    /// </summary>
    public interface ISelectComposer : IQueryComposer
    {
        /// <summary>
        /// From composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IFromComposer From(string table);
    }
    /// <summary>
    /// Delete composer
    /// </summary>
    public interface IDeleteComposer : IQueryComposer
    {
        /// <summary>
        /// Where composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWhereComposer Where(string column, string op, string value);
        /// <summary>
        /// Where single composition
        /// </summary>
        /// <returns></returns>
        IWhereComposer Where();
    }
    /// <summary>
    /// Insert composer
    /// </summary>
    public interface IInsertComposer : IQueryComposer
    {
        /// <summary>
        /// Values composition
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        IValuesComposer Values(params string[] values);
        /// <summary>
        /// Select composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISelectComposer Select(params string[] columns);
        /// <summary>
        /// Select distinct composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        ISelectComposer SelectDistinct(params string[] columns);
    }
    /// <summary>
    /// Values composer
    /// </summary>
    public interface IValuesComposer : IQueryComposer
    {

    }
    /// <summary>
    /// On composer
    /// </summary>
    public interface IOnComposer : IQueryComposer
    {
        /// <summary>
        /// Where composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWhereComposer Where(string column, string op, string value);
        /// <summary>
        /// Where single composition
        /// </summary>
        /// <returns></returns>
        IWhereComposer Where();
        /// <summary>
        /// Group by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IGroupByComposer GroupBy(params string[] columns);
        /// <summary>
        /// Order by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderBy(params string[] columns);
        /// <summary>
        /// Order by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderByDesc(params string[] columns);
        /// <summary>
        /// Brackets composition
        /// </summary>
        /// <typeparam name="T">Target composer</typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
    }
    /// <summary>
    /// From composer
    /// </summary>
    public interface IFromComposer : IQueryComposer
    {
        /// <summary>
        /// Join composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IJoinComposer Join(string table);
        /// <summary>
        /// Left Join composotion
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IJoinComposer LJoin(string table);
        /// <summary>
        /// Right join composition
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        IJoinComposer RJoin(string table);
        /// <summary>
        /// Where composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWhereComposer Where(string column, string op, string value);
        /// <summary>
        /// Single Where composition
        /// </summary>
        /// <returns></returns>
        IWhereComposer Where();
        /// <summary>
        /// Group by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IGroupByComposer GroupBy(params string[] columns);
        /// <summary>
        /// Order by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderBy(params string[] columns);
        /// <summary>
        /// Order by desc composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderByDesc(params string[] columns);
        /// <summary>
        /// Bracket composer
        /// </summary>
        /// <typeparam name="T">Target composition</typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
    }
    /// <summary>
    /// Condition composer
    /// </summary>
    public interface IConditionComposer
    {
        /// <summary>
        /// Where composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWhereComposer Where(string column, string op, string value);
        /// <summary>
        /// Single where
        /// </summary>
        /// <returns></returns>
        IWhereComposer Where();
        /// <summary>
        /// Or composition
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Single Or Composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// And composition
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// Single And Composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
    }
    /// <summary>
    /// Group by composer
    /// </summary>
    public interface IGroupByComposer : IQueryComposer
    {
        /// <summary>
        /// Order by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderBy(params string[] columns);
        /// <summary>
        /// Order by desc composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderByDesc(params string[] columns);
    }
    /// <summary>
    /// Order by composer
    /// </summary>
    public interface IOrderByComposer : IQueryComposer
    {

    }
    /// <summary>
    /// Where composer
    /// </summary>
    public interface IWhereComposer : IQueryComposer
    {
        /// <summary>
        /// Not SINGLE composition
        /// </summary>
        /// <returns></returns>
        INotComposer Not();
        /// <summary>
        /// Not composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        INotComposer Not(string column, string op, string value);
        /// <summary>
        /// In composition
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        IInComposer In(IQueryComposer innerComposer);
        /// <summary>
        /// Or single composition
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// And single composition
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
        /// <summary>
        /// Like composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ILikeComposer Like(string column, string pattern);
        /// <summary>
        /// Between composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        IBetweenComposer Between(string column, string before, string after);
        /// <summary>
        /// Brackets composer
        /// </summary>
        /// <typeparam name="T">Target composer</typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
        /// <summary>
        /// Order by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderBy(params string[] columns);
        /// <summary>
        /// Order by composition desc
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderByDesc(params string[] columns);
        /// <summary>
        /// Group by composition
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IGroupByComposer GroupBy(params string[] columns);
    }
    /// <summary>
    /// Not composer
    /// </summary>
    public interface INotComposer : IQueryComposer
    {
        /// <summary>
        /// In composition
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        IInComposer In(IQueryComposer innerComposer);
        /// <summary>
        /// Single Or composition
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// Single And composition
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
        /// <summary>
        /// like composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ILikeComposer Like(string column, string pattern);
        /// <summary>
        /// Between composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        IBetweenComposer Between(string column, string before, string after);
        /// <summary>
        /// Brackets composer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();

    }
    /// <summary>
    /// Between composer
    /// </summary>
    public interface IBetweenComposer : IQueryComposer
    {
        /// <summary>
        /// Single or composition
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// Single and composition
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composition
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
    }
    /// <summary>
    /// Or composer
    /// </summary>
    public interface IOrComposer : IQueryComposer
    {
        /// <summary>
        /// Condition composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <param name="comma"></param>
        /// <returns></returns>
        IConditionComposer Condition(string column, string op, string value, string comma);
        /// <summary>
        /// Single not composing
        /// </summary>
        /// <returns></returns>
        INotComposer Not();
        /// <summary>
        /// Not composing
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        INotComposer Not(string column, string op, string value);
        /// <summary>
        /// In compser
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        IInComposer In(IQueryComposer innerComposer);
        /// <summary>
        /// Between composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        IBetweenComposer Between(string column, string before, string after);
        /// <summary>
        /// Brackets composer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
        /// <summary>
        /// Single And composer
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
        /// <summary>
        /// Like composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ILikeComposer Like(string column, string pattern);
    }

    /// <summary>
    /// And composer
    /// </summary>
    public interface IAndComposer : IQueryComposer
    {
        /// <summary>
        /// Condition composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <param name="comma"></param>
        /// <returns></returns>
        IConditionComposer Condition(string column, string op, string value, string comma);
        /// <summary>
        /// Single Not composer
        /// </summary>
        /// <returns></returns>
        INotComposer Not();
        /// <summary>
        /// Not composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        INotComposer Not(string column, string op, string value);
        /// <summary>
        /// In composer
        /// </summary>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        IInComposer In(IQueryComposer innerComposer);
        /// <summary>
        /// Between composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        IBetweenComposer Between(string column, string before, string after);
        /// <summary>
        /// Brackets composer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
        /// <summary>
        /// Single Or composer
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// Like composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ILikeComposer Like(string column, string pattern);
    }
    /// <summary>
    /// In composer
    /// </summary>
    public interface IInComposer : IQueryComposer
    {
        /// <summary>
        /// Single or composer
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// Single and composer
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
    }
    /// <summary>
    /// Like composer
    /// </summary>
    public interface ILikeComposer : IQueryComposer
    {
        /// <summary>
        /// Single or composer
        /// </summary>
        /// <returns></returns>
        IOrComposer Or();
        /// <summary>
        /// Or composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IOrComposer Or(string column, string op, string value);
        /// <summary>
        /// Single and composer
        /// </summary>
        /// <returns></returns>
        IAndComposer And();
        /// <summary>
        /// And composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndComposer And(string column, string op, string value);
    }
    /// <summary>
    /// Join composer
    /// </summary>
    public interface IJoinComposer : IQueryComposer
    {
        /// <summary>
        /// On composer
        /// </summary>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        /// <returns></returns>
        IOnComposer On(string columnA, string columnB);
        /// <summary>
        /// Where composer
        /// </summary>
        /// <param name="column"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWhereComposer Where(string column, string op, string value);
        /// <summary>
        /// Single where composer
        /// </summary>
        /// <returns></returns>
        IWhereComposer Where();
        /// <summary>
        /// Group By composer
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IGroupByComposer GroupBy(params string[] columns);
        /// <summary>
        /// Order by composer
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderBy(params string[] columns);
        /// <summary>
        /// Order by desc composer
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IOrderByComposer OrderByDesc(params string[] columns);
        /// <summary>
        /// Brackets composer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="innerComposer"></param>
        /// <returns></returns>
        T Brackets<T>(IQueryComposer innerComposer) where T : class, IQueryComposer, new();
    }

}
