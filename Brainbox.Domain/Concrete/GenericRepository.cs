using Brainbox.Domain.Abstract;
using Brainbox.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Brainbox.Domain.Concrete;

//public class GenericRepository<T> : IGenericRepository<T> where T : class
//{
//    private readonly BrainboxDbContext context;

//    //public GenericRepository(BrainboxDbContext)
//    //{
//      //  this.this.context =  BrainboxDbContext();
//    //}

//    /// <summary>
//    /// The contructor requires an open DataContext to work with
//    /// </summary>
//    /// <param name="context">An open DataContext</param>
//    /// 
//    public GenericRepository(BrainboxDbContext context)
//    {
//        this.context = context;
//    }
//    /// <summary>
//    /// Returns a single object with a primary key of the provided id
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="id">The primary key of the object to fetch</param>
//    /// <returns>A single object with the provided primary key or null</returns>
//    public T Get(int id)
//    {
//        Console.WriteLine("Test");
//        return dbSet.Find(id);
//    }
//    /// <summary>
//    /// Returns a single object with a primary key of the provided id
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="id">The primary key of the object to fetch</param>
//    /// <returns>A single object with the provided primary key or null</returns>
//    public async Task<T> GetAsync(int id)
//    {
//        return await dbSet.FindAsync(id);
//    }
//    /// <summary>
//    /// Gets a collection of all objects in the database
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <returns>An ICollection of every object in the database</returns>
//    public ICollection<T> GetAll()
//    {
//        return dbSet.ToList();
//    }
//    /// <summary>
//    /// Gets a collection of all objects in the database
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <returns>An ICollection of every object in the database</returns>
//    public async Task<ICollection<T>> GetAllAsync()
//    {
//        return await dbSet.ToListAsync();
//    }
//    /// <summary>
//    /// Returns a single object which matches the provided expression
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="match">A Linq expression filter to find a single result</param>
//    /// <returns>A single object which matches the expression filter. 
//    /// If more than one object is found or if zero are found, null is returned</returns>
//    public T Find(Expression<Func<T, bool>> match)
//    {
//        return dbSet.SingleOrDefault(match);
//    }
//    /// <summary>
//    /// Returns a single object which matches the provided expression
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="match">A Linq expression filter to find a single result</param>
//    /// <returns>A single object which matches the expression filter. 
//    /// If more than one object is found or if zero are found, null is returned</returns>
//    public async Task<T> FindAsync(Expression<Func<T, bool>> match)
//    {
//        return await dbSet.SingleOrDefaultAsync(match);
//    }
//    /// <summary>
//    /// Returns a collection of objects which match the provided expression
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="match">A linq expression filter to find one or more results</param>
//    /// <returns>An ICollection of object which match the expression filter</returns>
//    public ICollection<T> FindAll(Expression<Func<T, bool>> match)
//    {
//        return dbSet.Where(match).ToList();
//    }
//    /// <summary>
//    /// Returns a collection of objects which match the provided expression
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="match">A linq expression filter to find one or more results</param>
//    /// <returns>An ICollection of object which match the expression filter</returns>
//    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
//    {
//        return await dbSet.Where(match).ToListAsync();
//    }
//    /// <summary>
//    /// Inserts a single object to the database and commits the change
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="t">The object to insert</param>
//    /// <returns>The resulting object including its primary key after the insert</returns>
//    public T Add(T t)
//    {
//        dbSet.Add(t);
//        this.context.SaveChanges();
//        return t;
//    }
//    /// <summary>
//    /// Inserts a single object to the database and commits the change
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="t">The object to insert</param>
//    /// <returns>The resulting object including its primary key after the insert</returns>
//    public async Task<T> AddAsync(T t)
//    {
//        dbSet.Add(t);
//        await this.context.SaveChangesAsync();
//        return t;
//    }
//    /// <summary>
//    /// Inserts a collection of objects into the database and commits the changes
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="tList">An IEnumerable list of objects to insert</param>
//    /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
//    public IEnumerable<T> AddAll(IEnumerable<T> tList)
//    {
//        dbSet.AddRange(tList);
//        this.context.SaveChanges();
//        return tList;
//    }
//    /// <summary>
//    /// Inserts a collection of objects into the database and commits the changes
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="tList">An IEnumerable list of objects to insert</param>
//    /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
//    public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList)
//    {
//        dbSet.AddRange(tList);
//        await this.context.SaveChangesAsync();
//        return tList;
//    }
//    /// <summary>
//    /// Updates a single object based on the provided primary key and commits the change
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="updated">The updated object to apply to the database</param>
//    /// <param name="key">The primary key of the object to update</param>
//    /// <returns>The resulting updated object</returns>
//    public T Update(T updated, int key)
//    {
//        if (updated == null)
//            return null;

//        T existing = dbSet.Find(key);
//        if (existing != null)
//        {
//            this.context.Entry(existing).CurrentValues.SetValues(updated);
//            this.context.SaveChanges();
//        }
//        return existing;
//    }
//    /// <summary>
//    /// Updates a single object based on the provided primary key and commits the change
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="updated">The updated object to apply to the database</param>
//    /// <param name="key">The primary key of the object to update</param>
//    /// <returns>The resulting updated object</returns>
//    public async Task<T> UpdateAsync(T updated, int key)
//    {
//        if (updated == null)
//            return null;

//        T existing = await dbSet.FindAsync(key);
//        if (existing != null)
//        {
//            this.context.Entry(existing).CurrentValues.SetValues(updated);
//            await this.context.SaveChangesAsync();
//        }
//        return existing;
//    }
//    /// <summary>
//    /// Deletes a single object from the database and commits the change
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <param name="t">The object to delete</param>
//    public void Delete(T t)
//    {
//        dbSet.Remove(t);
//        this.context.SaveChanges();
//    }
//    /// <summary>
//    /// Deletes a single object from the database and commits the change
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <param name="t">The object to delete</param>
//    public async Task<int> DeleteAsync(T t)
//    {
//        dbSet.Remove(t);
//        return await this.context.SaveChangesAsync();
//    }

//    /// <summary>
//    /// Gets the count of the number of objects in the databse
//    /// </summary>
//    /// <remarks>Synchronous</remarks>
//    /// <returns>The count of the number of objects</returns>
//    public int Count()
//    {
//        return dbSet.Count();
//    }
//    /// <summary>
//    /// Gets the count of the number of objects in the databse
//    /// </summary>
//    /// <remarks>Asynchronous</remarks>
//    /// <returns>The count of the number of objects</returns>
//    public async Task<int> CountAsync()
//    {
//        return await dbSet.CountAsync();
//    }
//}

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, new()
{
    private readonly BrainboxDbContext context;
    internal DbSet<T> dbSet;

    public GenericRepository(BrainboxDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }
    public T Get(int id)
    {
        Console.WriteLine("Test");
        
        return dbSet.Find(id);
    }
    /// <summary>
    /// Returns a single object with a primary key of the provided id
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="id">The primary key of the object to fetch</param>
    /// <returns>A single object with the provided primary key or null</returns>
    public async Task<T> GetAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
    /// <summary>
    /// Gets a collection of all objects in the database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>An ICollection of every object in the database</returns>
    public ICollection<T> GetAll()
    {
        return dbSet.ToList();
    }
    /// <summary>
    /// Gets a collection of all objects in the database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>An ICollection of every object in the database</returns>
    public async Task<ICollection<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }
    /// <summary>
    /// Returns a single object which matches the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match">A Linq expression filter to find a single result</param>
    /// <returns>A single object which matches the expression filter. 
    /// If more than one object is found or if zero are found, null is returned</returns>
    public T Find(Expression<Func<T, bool>> match)
    {
        return dbSet.SingleOrDefault(match);
    }
    /// <summary>
    /// Returns a single object which matches the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match">A Linq expression filter to find a single result</param>
    /// <returns>A single object which matches the expression filter. 
    /// If more than one object is found or if zero are found, null is returned</returns>
    public async Task<T> FindAsync(Expression<Func<T, bool>> match)
    {
        return await dbSet.SingleOrDefaultAsync(match);
    }
    /// <summary>
    /// Returns a collection of objects which match the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match">A linq expression filter to find one or more results</param>
    /// <returns>An ICollection of object which match the expression filter</returns>
    public ICollection<T> FindAll(Expression<Func<T, bool>> match)
    {
        return dbSet.Where(match).ToList();
    }
    /// <summary>
    /// Returns a collection of objects which match the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match">A linq expression filter to find one or more results</param>
    /// <returns>An ICollection of object which match the expression filter</returns>
    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
    {
        return await dbSet.Where(match).ToListAsync();
    }
    /// <summary>
    /// Inserts a single object to the database and commits the change
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t">The object to insert</param>
    /// <returns>The resulting object including its primary key after the insert</returns>
    public T Add(T t)
    {
        dbSet.Add(t);
        this.context.SaveChanges();
        return t;
    }
    /// <summary>
    /// Inserts a single object to the database and commits the change
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t">The object to insert</param>
    /// <returns>The resulting object including its primary key after the insert</returns>
    public async Task<T> AddAsync(T t)
    {
        dbSet.Add(t);
        await this.context.SaveChangesAsync();
        return t;
    }
    /// <summary>
    /// Inserts a collection of objects into the database and commits the changes
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="tList">An IEnumerable list of objects to insert</param>
    /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
    public IEnumerable<T> AddAll(IEnumerable<T> tList)
    {
        dbSet.AddRange(tList);
        this.context.SaveChanges();
        return tList;
    }
    /// <summary>
    /// Inserts a collection of objects into the database and commits the changes
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="tList">An IEnumerable list of objects to insert</param>
    /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
    public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList)
    {
        dbSet.AddRange(tList);
        await this.context.SaveChangesAsync();
        return tList;
    }
    /// <summary>
    /// Updates a single object based on the provided primary key and commits the change
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="updated">The updated object to apply to the database</param>
    /// <param name="key">The primary key of the object to update</param>
    /// <returns>The resulting updated object</returns>
    public T Update(T updated, int key)
    {
        if (updated == null)
            return null;

        T existing = dbSet.Find(key);
        if (existing != null)
        {
            this.context.Entry(existing).CurrentValues.SetValues(updated);
            this.context.SaveChanges();
        }
        return existing;
    }
    /// <summary>
    /// Updates a single object based on the provided primary key and commits the change
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="updated">The updated object to apply to the database</param>
    /// <param name="key">The primary key of the object to update</param>
    /// <returns>The resulting updated object</returns>
    public async Task<T> UpdateAsync(T updated, int key)
    {
        if (updated == null)
            return null;

        T existing = await dbSet.FindAsync(key);
        if (existing != null)
        {
            this.context.Entry(existing).CurrentValues.SetValues(updated);
            await this.context.SaveChangesAsync();
        }
        return existing;
    }
    /// <summary>
    /// Deletes a single object from the database and commits the change
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t">The object to delete</param>
    public void Delete(T t)
    {
        dbSet.Remove(t);
        this.context.SaveChanges();
    }
    /// <summary>
    /// Deletes a single object from the database and commits the change
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t">The object to delete</param>
    public async Task<int> DeleteAsync(T t)
    {
        dbSet.Remove(t);
        return await this.context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets the count of the number of objects in the databse
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>The count of the number of objects</returns>
    public int Count()
    {
        return dbSet.Count();
    }
    /// <summary>
    /// Gets the count of the number of objects in the databse
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>The count of the number of objects</returns>
    public async Task<int> CountAsync()
    {
        return await dbSet.CountAsync();
    }
}