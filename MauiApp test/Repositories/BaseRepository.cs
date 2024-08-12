﻿using MauiApp_test.Abstractions;
using MauiApp_test.MVVM.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;




namespace MauiApp_test.Repositories
{
    public class BaseRepository<T> :
          IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            try
            {
                connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
                connection.CreateTable<T>();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error initializing database: {ex.Message} ";
                throw; // Optionally rethrow to detect during testing
            }
        }

        public void DeleteItem(T item)
        {
            try
            {
                //connection.Delete(item);
                connection.Delete(item, true);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public void DeleteRecord(int Id)
        {
            try
            {
                connection.Execute($"DELETE FROM {typeof(T).Name} WHERE Id = ?", Id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public void Dispose()
        {
            connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return
                     connection.Table<T>()
                     .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>()
                     .Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage =
                   $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                      $"Error: {ex.Message}";
            }
            return null;
        }

        public void SaveItem(T item)
        {
            int result = 0;
            try
            {
                if (item.Id != 0)
                {
                    result =
                         connection.Update(item);
                    StatusMessage =
                         $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(item);
                    StatusMessage =
                        $"{result} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
                Console.WriteLine(ex);
            }
        }

        public void SaveItemWithChildren(T item, bool recursive = false)
        {
            connection.InsertWithChildren(item, recursive);
        }

        public List<T> GetItemsWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                   $"Error: {ex.Message}";
            }
            return null;
        }

        //return all course information
        public List<T> GetItemsById(int id)
        {
            try
            {
                return connection.Table<T>()
                    .Where(x => x.Id == id)
                    .ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItemsByTerm(int Term)
        {
            try
            {
                return connection.Query<T>($"SELECT * FROM Courses WHERE Term = {Term}");
               
                  
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
        // Update item in the Courses table by Id sql query 
        public void UpdateItem(int Id, string name, string courseCode, string instructor, DateTime startDate, DateTime endDate, string status, int term, bool notifications)
        {
            try
            {
                connection.Execute($"UPDATE Courses SET Name = ?, CourseCode = ?, Instructor = ?, StartDate = ?, EndDate = ?, Status = ?, Term = ?, Notifications = ? WHERE Id = {Id}",
                    name, courseCode, instructor, startDate, endDate, status, term, notifications);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

       
        

        
    }
}
