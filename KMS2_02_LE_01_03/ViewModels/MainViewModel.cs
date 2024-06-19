using KMS2_02_LE_01_03.Interfaces;
using KMS2_02_LE_01_03.Manager;
using KMS2_02_LE_01_03.Model;
using KMS2_02_LE_01_03.MVVM;
using KMS2_02_LE_01_03.UploadData;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace KMS2_02_LE_01_03.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IBookManager _bookManager;
        private Book _selectedBook;
        private string _filterText;
        private bool _isCalendarVisible;
        private DateTime? _publicationDate;
        private string _selectedFilterOption;
        private Book _book = new Book();


        public ObservableCollection<Book> Books { get; }
        public ObservableCollection<Book> FilteredBooks { get; set; }

        public RelayCommand AddBookCommand => new RelayCommand(AddBook,CanAddBook);
        public RelayCommand RemoveBookCommand => new RelayCommand(RemoveBook, CanModifyBook);
        //public RelayCommand UpdateBookCommand => new RelayCommand(UpdateBook,CanModifyBook);
       // public RelayCommand FilterBooksCommand => new RelayCommand(FilterBooks);
        public RelayCommand UploadBookCommand => new RelayCommand(UploadBooks);

        public MainViewModel()
        {
            _bookManager = new BookManager();
            Books = new ObservableCollection<Book>(_bookManager.Books);
            FilteredBooks = new ObservableCollection<Book>(Books);

            _bookManager.Books.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (Book book in e.NewItems)
                    {
                        Books.Add(book);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (Book book in e.OldItems)
                    {
                        var bookToRemove = Books.FirstOrDefault(b => b.ID == book.ID);
                        if (bookToRemove != null)
                        {
                            Books.Remove(bookToRemove);
                        }
                    }
                }
                FilterBooks();
            };
        }

        public int Id => _book.ID;
        public string NewTitle
        {
            get => _book.Title;
            set
            {
                if (_book.Title != value)
                {
                    _book.Title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewAuthor
        {
            get => _book.Author;
            set
            {
                if (_book.Author != value)
                {
                    _book.Author = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewGenre
        {
            get => _book.Genre;
            set
            {
                if (_book.Genre != value)
                {
                    _book.Genre = value;
                    OnPropertyChanged();
                }
            }
        }

        //public DateTime PublicationDate
        //{
        //    get => _book.PublicationDate;
        //    set
        //    {
        //        if (_book.PublicationDate != value)
        //        {
        //            _book.PublicationDate = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public string NewStatus
        {
            get => _book.Status;
            set
            {
                if (_book.Status != value)
                {
                    _book.Status = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _newFilterText;
        public string NewFilterText
        {
            get => _newFilterText;
            set
            {
                if (_newFilterText != value)
                {
                    _newFilterText = value;
                    OnPropertyChanged();
                }
            }
        }

        private void FilterBooks()
        {
            FilteredBooks.Clear();
            var filtered = Books.AsQueryable(); 

            if (!string.IsNullOrEmpty(FilterText))
            {
                switch (SelectedFilterOption)
                {
                    case "By Title":
                        filtered = filtered.Where(book => book.Title.Contains(FilterText));
                        break;
                    case "By Author":
                        filtered = filtered.Where(book => book.Author.Contains(FilterText));
                        break;
                    case "By Genre":
                        filtered = filtered.Where(book => book.Genre.Contains(FilterText));
                        break;
                    case "By Status":
                        filtered = filtered.Where(book => book.Status.Contains(FilterText));
                        break;
                    case "By Date":
                        if (DateTime.TryParse(FilterText, out DateTime date))
                        {
                            filtered = filtered.Where(book => book.PublicationDate.Date == date.Date);
                        }
                        break;
                }
            }

            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
            OnPropertyChanged(nameof(FilteredBooks)); // Notifikácia zmeny pre DataGrid
        }


        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                FilterBooks(); // Volanie filtrovania pri zmene textu filtra
            }
        }


        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook != value)
                {
                    _selectedBook = value;
                    OnPropertyChanged(nameof(SelectedBook));
                    OnSelectedBookChanged();
                }
            }
        }


        public string SelectedFilterOption
        {
            get => _selectedFilterOption;
            set
            {
                _selectedFilterOption = value;
                OnPropertyChanged(nameof(SelectedFilterOption));
                FilterBooks(); // Volanie filtrovania pri zmene možnosti filtra
            }
        }

        public DateTime? PublicationDate
        {
            get => _publicationDate;
            set
            {
                _publicationDate = value;
                OnPropertyChanged(nameof(PublicationDate));
                if (SelectedBook != null)
                {
                    SelectedBook.PublicationDate = value ?? DateTime.Now;
                }
                else { _publicationDate =  DateTime.Now; }
            }
        }
        public bool IsCalendarVisible
        {
            get => _isCalendarVisible;
            set
            {
                if (_isCalendarVisible != value)
                {
                    _isCalendarVisible = value;
                    OnPropertyChanged(nameof(IsCalendarVisible));
                }
            }
        }
        public void HideCalendar()
        {
            IsCalendarVisible = false;
        }

        public void ShowCalendar()
        {
            IsCalendarVisible = true;
        }
        private void OnSelectedBookChanged()
        {
            HideCalendar();
            if (SelectedBook != null)
            {
                PublicationDate = SelectedBook.PublicationDate;
            }        
        }


        public void UpdatePublicationDate()
        {
            OnPropertyChanged(nameof(SelectedBook.PublicationDate));
        }




        private void UploadBooks()
        {
            _bookManager.Books.Clear();
            UploadCSV.Upload();
            var books = new UploadCSV().GetBooks();
            _bookManager.AddBooks(books);
            UpdatePositions();
        }




        private void AddBook()
        {

            Book newBook = new Book
            {
                ID = FilteredBooks.Count > 0 ? Books.Max(b => b.ID) + 1 : 1,
                Title = NewTitle,
                Author = NewAuthor,
                Genre = NewGenre,
                PublicationDate = (DateTime)PublicationDate,
                Status = NewStatus
            };
            _bookManager.AddBook(newBook);
            UpdatePositions();
        }

        private void UpdatePositions()
        {
            for (int i = 0; i < Books.Count; i++) { FilteredBooks[i].ID = i + 1; }
        }

        private void RemoveBook()
        {
            if (SelectedBook != null)
            {
                _bookManager.RemoveBook(SelectedBook.ID);
            }
            UpdatePositions();
        }

        private void UpdateBook()
        {
            if (SelectedBook != null)
            {
                var book = new Book
                {
                    ID = SelectedBook.ID,
                    Title = SelectedBook.Title,
                    Author = SelectedBook.Author,
                    Genre = SelectedBook.Genre,
                    PublicationDate = SelectedBook.PublicationDate,
                    Status = SelectedBook.Status
                };
                _bookManager.UpdateBook(book);
            }
        }

        private bool CanAddBook()
        {
            return !string.IsNullOrWhiteSpace(NewTitle) &&
                !string.IsNullOrWhiteSpace(NewStatus) &&
                !string.IsNullOrWhiteSpace(NewGenre) &&
                !string.IsNullOrWhiteSpace(NewAuthor)&&
                PublicationDate.HasValue;
        }
        private bool CanModifyBook()
        {
            return SelectedBook != null;
        }

 
    }
}
