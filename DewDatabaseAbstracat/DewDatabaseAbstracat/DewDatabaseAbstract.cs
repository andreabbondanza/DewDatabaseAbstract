using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace DewCore.Abstract.Database
{
    /// <summary>
    /// DatabaseError Class
    /// </summary>
    public sealed class DatabaseError
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Number
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="errn"></param>
        public DatabaseError(string desc, int errn)
        {
            Description = desc;
            Number = errn;
        }
    }
    /// <summary>
    /// Database table ORM Interface
    /// </summary>
    public interface IDatabaseTable
    {
        /// <summary>
        /// Returns table fields
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Check local if fields constraints are valid (only when possible)
        /// </summary>
        /// <returns></returns>
        bool CheckConstarints();
    }
    /// <summary>
    /// MySQL Response object for INSERT\DELETE\UPDATE
    /// </summary>
    public interface IDatabaseResponse
    {
        /// <summary>
        /// Return query error
        /// </summary>
        /// <returns></returns>
        DatabaseError GetError();
        /// <summary>
        /// True if query success
        /// </summary>
        /// <returns></returns>
        bool IsSuccess();
        /// <summary>
        /// Get last inserted row
        /// </summary>
        /// <returns></returns>
        long GetLastInsertedId();
        /// <summary>
        /// Get affected rows
        /// </summary>
        /// <returns></returns>
        long GetRowsAffected();
        /// <summary>
        /// Get the number of columns
        /// </summary>
        /// <returns></returns>
        int GetFieldCount();
    }
    /// <summary>
    /// MySQLClient dew interface
    /// </summary>
    public interface IDatabaseClient<T1> where T1 : IDatabaseResponse
    {
        /// <summary>
        /// Perform a query and return result in a ICollection of array
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="values">ICollection of binded values</param>
        /// <returns>ICollection of array objects (rows)</returns>
        Task<ICollection<object[]>> QueryArrayAsync(string query, ICollection<DbParameter> values);
        /// <summary>
        /// Perform a query (good for SELECT) : 
        /// </summary>
        /// <typeparam name="T">Result type object</typeparam>
        /// <param name="query">Query</param>
        /// <param name="values">ICollection of binded values</param>
        /// <returns>ICollection of T objects (rows)</returns>
        Task<ICollection<T>> QueryAsync<T>(string query, ICollection<DbParameter> values) where T : class, new();
        /// <summary>
        /// Select directly in LINQ. NOTE: T name must be the Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        Task<ICollection<T>> Select<T>(Func<T, bool> predicate, string tablePrefix) where T : class, new();
        /// <summary>
        /// Select directly in LINQ. NOTE: T name must be the Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        Task<ICollection<T>> Select<T>(string tablePrefix) where T : class, new();
        /// <summary>
        /// Perform a query (good for insert, update, delete)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task<T1> QueryAsync(string query, ICollection<DbParameter> values);
        /// <summary>
        /// Update a row into the T table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toFind">The searched row</param>
        /// <param name="toUpdate">the row</param>
        /// <param name="tablePrefix">a table prefix if exists</param>
        /// <returns></returns>
        Task<T1> UpdateAsync<T>(T toFind, T toUpdate, string tablePrefix = null) where T : class;
        /// <summary>
        /// Update a row into the T table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toFind">The searched row</param>
        /// <param name="toUpdate">the row</param>
        /// <param name="toIgnore">Fields to ignore (do NOT override field attribute)</param>
        /// <param name="tablePrefix">a table prefix if exists</param>
        /// <returns></returns>
        Task<T1> UpdateAsync<T>(T toFind, T toUpdate, List<string> toIgnore, string tablePrefix = null) where T : class;
        /// <summary>
        /// Delete a row into the T table. Works only with "=" assertions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toDelete">The data</param>
        /// <param name="tablePrefix">a table prefix if exists</param>
        /// <returns></returns>
        Task<T1> DeleteAsync<T>(T toDelete, string tablePrefix = null) where T : class;
        /// <summary>
        /// Insert a row into the T table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newRow">The data</param>
        /// <param name="tablePrefix">a table prefix if exists</param>
        /// <returns></returns>
        Task<T1> InsertAsync<T>(T newRow, string tablePrefix = null) where T : class;
        /// <summary>
        /// Commit a transaction
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// Rollback a transaction
        /// </summary>
        Task RollbackAsync();
        /// <summary>
        /// Begin a transiction
        /// </summary>
        /// <returns></returns>
        Task<bool> BeginTransactionAsync(IsolationLevel isolationLevel);
        /// <summary>
        /// Close database connection
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// Close database connection in async way
        /// </summary>
        /// <returns></returns>
        Task CloseConnectionAsync();
        /// <summary>
        /// Open database connection in async way
        /// </summary>
        /// <returns></returns>
        Task OpenConnectionAsync();
        /// <summary>
        /// Open database connection
        /// </summary>
        void OpenConnection();
    }
    /// <summary>
    /// Connection string interface
    /// </summary>
    public interface IConnectionString
    {
        /// <summary>
        /// Return database connection string
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
    /// <summary>
    /// Ignore this attribute when you are in the insert query
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreInsert : Attribute
    {

    }
    /// <summary>
    /// This attribute must be checked in conditional phase for delete
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class CheckDelete : Attribute
    {

    }
    /// <summary>
    /// Ignore this property when you are in the set phase in update query
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreUpdate : Attribute
    {

    }
    /// <summary>
    /// Ignore this property when you are in the conditional phase in update query
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class CheckUpdate : Attribute
    {

    }
    /// <summary>
    /// This property isn't on database table
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class NoColumn : Attribute
    {

    }

}