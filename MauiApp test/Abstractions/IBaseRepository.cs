using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MauiApp_test.MVVM.Models;
namespace MauiApp_test.Abstractions
{
    public interface IBaseRepository<T> : IDisposable
         where T : TableData, new()
    {
        void SaveItem(T item);
        void SaveItemWithChildren(T item, bool recursive = false);
        T GetItem(int id);
        T GetItem(Expression<Func<T, bool>> predicate);
        List<T> GetItems();
        List<T> GetItems(Expression<Func<T, bool>> predicate);
        List<T> GetItemsWithChildren();
        void DeleteItem(T item);

        void DeleteRecord(int id);
        List<T>GetItemsById(int id);
        List<T> GetItemsByTerm(int Term);

        void UpdateItem(int Id, string name, string courseCode, string instructor, DateTime startDate, DateTime endDate, string status, int term, bool notifications);

    }
}
