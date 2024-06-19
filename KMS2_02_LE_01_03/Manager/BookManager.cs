using KMS2_02_LE_01_03.Events.BookEvents;
using KMS2_02_LE_01_03.Interfaces;
using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace KMS2_02_LE_01_03.Manager
{
    public class BookManager : IBookManager
    {
        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();

        private Process process = new Process();

        public BookManager()
        {
            process.BookAdded += Print_BookProcess;
        }

        private static void Print_BookProcess(object sender, BookEventArgs e)
        {
            MessageBox.Show($"{e.Message} at {e.CompletionTime}");
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            process.AddBook();
        }

        public void AddBooks(IEnumerable<Book> uploadBooks)
        {
            foreach (Book book in uploadBooks)
            {
                Books.Add(book);
                
            }
            process.AddBook();
        }

        public List<Book> FilterBooks(Func<Book, bool> filter)
        {
            return Books.Where(filter).ToList();
        }

        public void RemoveBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.ID == bookId);
            if (book != null)
            {
                Books.Remove(book);
            }
        }

        public void UpdateBook(Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.ID == book.ID);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.Status = book.Status;
            }
        }

        public IEnumerable<Book> ListBooks()
        {
            return Books;
        }
    }
}






//using KMS2_02_LE_01_03.Events.BookEvents;
//using KMS2_02_LE_01_03.Interfaces;
//using KMS2_02_LE_01_03.Model;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Windows.Forms;


//namespace KMS2_02_LE_01_03.Manager
//{


//    public class BookManager : IBookManager
//    {
//        //private List<Book> books = new List<Book>();

//        private ObservableCollection<Book> Books {  get; set; } = new ObservableCollection<Book>();

//        private Process process = new Process();


//        public BookManager()
//        {
//            process.BookAdded += Print_BookProcess;
//        }

//        //public void AddProcess()
//        //{
//        //    process.BookAdded += Print_BookProcess;
//        //    process.AddBook();

//        //}

//        private static void Print_BookProcess(object sender, BookEventArgs e)
//        {
//            MessageBox.Show($"{e.Message} at {e.CompletionTime}");
//        }

//        public void AddBook(Book book)
//        {
//            //books.Add(book);
//            Books.Add(book);
//            //AddProcess();
//            process.AddBook();

//        }


//        //public void AddBooks(Book uploadBooks)
//        //{
//        //    books.Add(uploadBooks);

//        //}

//        public void AddBooks(IEnumerable<Book> uploadBooks)
//        {
//            foreach (Book book in uploadBooks) 
//            { 
//                Books.Add(book);
//            }
//            process.AddBook();
//        }


//        public List<Book> FilterBooks(Func<Book, bool> filter)
//        {
//            return Books.Where(filter).ToList();
//        }

//        //public List<Book> ListBooks()
//        //{
//        //    return books;
//        //}


//        public void RemoveBook(int bookId)
//        {
//            var book = Books.FirstOrDefault(b => b.ID == bookId);
//            if(book != null)
//            {
//                Books.Remove(book);
//               // books.Remove(book);

//            }
//        }

//        public void UpdateBook(Book book)
//        {
//            var existingBook = Books.FirstOrDefault(b => b.ID == book.ID);
//            if(existingBook != null)
//            {
//                existingBook.Title = book.Title;
//                existingBook.Author = book.Author;
//                existingBook.Genre = book.Genre;
//                existingBook.PublicationDate = book.PublicationDate;
//                existingBook.Status = book.Status;

//            }
//        }

//        public IEnumerable<Book> ListBooks() { return Books; }
//    }
//}
