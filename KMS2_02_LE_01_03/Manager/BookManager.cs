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
    /// <summary>
    /// Klasse zur Verwaltung der Buchobjekte.
    /// </summary>
    public class BookManager : IBookManager
    {
        /// <summary>
        /// Sammlung der Bücher.
        /// </summary>
        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();

        private Process process = new Process();

        /// <summary>
        /// Konstruktor für BookManager.
        /// </summary>
        public BookManager()
        {
            process.BookAdded += Print_BookProcess;
            process.BookRemoved += Print_BookProcess;
            process.BookUpdated += Print_BookProcess;
        }

        /// <summary>
        /// Zeigt eine Meldung an, wenn ein Buch hinzugefügt wird.
        /// </summary>
        private static void Print_BookProcess(object sender, BookEventArgs e)
        {
            MessageBox.Show($"{e.Message} at {e.CompletionTime}");
        }

        /// <summary>
        /// Fügt ein Buch zur Sammlung hinzu.
        /// </summary>
        /// <param name="book">Das hinzuzufügende Buch.</param>
        public void AddBook(Book book)
        {
            Books.Add(book);
            process.AddBook();
        }

        /// <summary>
        /// Fügt mehrere Bücher zur Sammlung hinzu.
        /// </summary>
        /// <param name="uploadBooks">Die hinzuzufügenden Bücher.</param>
        public void AddBooks(List<Book> uploadBooks)
        {           
            foreach (Book book in uploadBooks)
            {
                Books.Add(book);
            }
            process.AddBooks();          
        }

        /// <summary>
        /// Filtert die Bücher basierend auf einem Filterkriterium.
        /// </summary>
        /// <param name="filter">Die Filterfunktion.</param>
        /// <returns>Eine Liste der gefilterten Bücher.</returns>
        public List<Book> FilterBooks(Func<Book, bool> filter)
        {
            return Books.Where(filter).ToList();
        }

        /// <summary>
        /// Entfernt ein Buch anhand seiner ID.
        /// </summary>
        /// <param name="bookId">Die ID des zu entfernenden Buches.</param>
        public void RemoveBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.ID == bookId);
            if (book != null)
            {
                Books.Remove(book);
                process.RemoveBook();
            }
            
        }

        /// <summary>
        /// Aktualisiert die Informationen eines Buches.
        /// </summary>
        /// <param name="book">Das zu aktualisierende Buch.</param>
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
                process.UpdateBook();
            }
        }

        /// <summary>
        /// Gibt alle Bücher zurück.
        /// </summary>
        /// <returns>Eine Auflistung aller Bücher.</returns>
        public IEnumerable<Book> ListBooks()
        {
            return Books;
        }
    }
}
