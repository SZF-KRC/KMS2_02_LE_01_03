using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KMS2_02_LE_01_03.Interfaces
{
    /// <summary>
    /// Schnittstelle zur Verwaltung von Buchobjekten.
    /// </summary>
    public interface IBookManager
    {
        /// <summary>
        /// Fügt ein Buch zur Sammlung hinzu.
        /// </summary>
        /// <param name="book">Das hinzuzufügende Buch.</param>
        void AddBook(Book book);

        /// <summary>
        /// Fügt mehrere Bücher zur Sammlung hinzu.
        /// </summary>
        /// <param name="uploadBooks">Die hinzuzufügenden Bücher.</param>
        void AddBooks(List<Book> uploadBooks);

        /// <summary>
        /// Entfernt ein Buch anhand seiner ID.
        /// </summary>
        /// <param name="bookId">Die ID des zu entfernenden Buches.</param>
        void RemoveBook(int bookId);

        /// <summary>
        /// Aktualisiert die Informationen eines Buches.
        /// </summary>
        /// <param name="book">Das zu aktualisierende Buch.</param>
        void UpdateBook(Book book);

        /// <summary>
        /// Filtert die Bücher basierend auf einem Filterkriterium.
        /// </summary>
        /// <param name="filter">Die Filterfunktion.</param>
        /// <returns>Eine Liste der gefilterten Bücher.</returns>
        List<Book> FilterBooks(Func<Book, bool> filter);

        /// <summary>
        /// Gibt alle Bücher zurück.
        /// </summary>
        /// <returns>Eine Auflistung aller Bücher.</returns>
        IEnumerable<Book> ListBooks();

        /// <summary>
        /// Sammlung der Bücher.
        /// </summary>
        ObservableCollection<Book> Books { get; }
    }
}
