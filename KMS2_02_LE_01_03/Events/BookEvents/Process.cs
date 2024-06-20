using System;

namespace KMS2_02_LE_01_03.Events.BookEvents
{
    /// <summary>
    /// Klasse zur Verwaltung von Buchprozessen und -ereignissen.
    /// </summary>
    public class Process
    {
        /// <summary>
        /// Ereignis, das ausgelöst wird, wenn ein Prozess abgeschlossen ist.
        /// </summary>
        public event EventHandler<BookEventArgs> ProcessCompleted;

        /// <summary>
        /// Ereignis, das ausgelöst wird, wenn ein Buch hinzugefügt wurde.
        /// </summary>
        public event EventHandler<BookEventArgs> BookAdded;

        /// <summary>
        /// Ereignis, das ausgelöst wird, wenn ein Buch entfernt wurde.
        /// </summary>
        public event EventHandler<BookEventArgs> BookRemoved;

        /// <summary>
        /// Ereignis, das ausgelöst wird, wenn ein Buch aktualisiert wurde.
        /// </summary>
        public event EventHandler<BookEventArgs> BookUpdated;

        /// <summary>
        /// Methode zum Hinzufügen eines Buches und Auslösen des entsprechenden Ereignisses.
        /// </summary>
        public void AddBook()
        {
            OnBookAdded(new BookEventArgs("Book succesfully added !", DateTime.Now));
        }

        /// <summary>
        /// Methode zum Entfernen eines Buches und Auslösen des entsprechenden Ereignisses.
        /// </summary>
        public void RemoveBook()
        {
            OnBookRemoved(new BookEventArgs("Book successfully removed !", DateTime.Now));
        }

        /// <summary>
        /// Methode zum Aktualisieren eines Buches und Auslösen des entsprechenden Ereignisses.
        /// </summary>
        public void UpdateBook()
        {
            OnBookUpdated(new BookEventArgs("Book successfully updated !", DateTime.Now));
        }

        /// <summary>
        /// Methode zum Auslösen des BookAdded-Ereignisses.
        /// </summary>
        /// <param name="e">Die Ereignisdaten.</param>
        protected virtual void OnBookAdded(BookEventArgs e)
        {
            BookAdded?.Invoke(this, e);
        }

        /// <summary>
        /// Methode zum Auslösen des BookRemoved-Ereignisses.
        /// </summary>
        /// <param name="e">Die Ereignisdaten.</param>
        protected virtual void OnBookRemoved(BookEventArgs e)
        {
            BookRemoved?.Invoke(this, e);
        }

        /// <summary>
        /// Methode zum Auslösen des BookUpdated-Ereignisses.
        /// </summary>
        /// <param name="e">Die Ereignisdaten.</param>
        protected virtual void OnBookUpdated(BookEventArgs e)
        {
            BookUpdated?.Invoke(this, e);
        }

    }
}
