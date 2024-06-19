using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KMS2_02_LE_01_03.Interfaces
{
    public interface IBookManager
    {
        void AddBook(Book book);
        void AddBooks(IEnumerable<Book> uploadBooks);
        void RemoveBook(int bookId);
        void UpdateBook(Book book);
        List<Book> FilterBooks(Func<Book, bool> filter);
        IEnumerable<Book> ListBooks();
        ObservableCollection<Book> Books { get; }
    }
}
