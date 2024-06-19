using System;
using System.Windows;

namespace KMS2_02_LE_01_03.Events.BookEvents
{
    public class Process
    {
        public event EventHandler<BookEventArgs> ProcessCompleted;
        public event EventHandler<BookEventArgs> BookAdded;
        public event EventHandler<BookEventArgs> BookRemoved;
        public event EventHandler<BookEventArgs> BookUpdated;

        public void StartProcess()
        {
            MessageBox.Show("Process started");
            System.Threading.Thread.Sleep(1000);

            OnProcessCompleted(new BookEventArgs("Process stoped !", DateTime.Now));
        }

        public void AddBook()
        {
            OnBookAdded(new BookEventArgs("Book succesfully added !", DateTime.Now));
        }

        public void RemoveBook()
        {
            OnBookRemoved(new BookEventArgs("Book successfully removed !", DateTime.Now));
        }

        public void UpdateBook()
        {
            OnBookUpdated(new BookEventArgs("Book successfully updated !", DateTime.Now));
        }

        protected virtual void OnProcessCompleted(BookEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnBookAdded(BookEventArgs e)
        {
            BookAdded?.Invoke(this, e);
        }

        protected virtual void OnBookRemoved(BookEventArgs e)
        {
            BookRemoved?.Invoke(this, e);
        }

        protected virtual void OnBookUpdated(BookEventArgs e)
        {
            BookUpdated?.Invoke(this, e);
        }

    }
}
