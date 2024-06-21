using KMS2_02_LE_01_03.Manager;
using KMS2_02_LE_01_03.Model;
using KMS2_02_LE_01_03.MVVM;
using KMS2_02_LE_01_03.SaveData;
using KMS2_02_LE_01_03.UploadData;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace KMS2_02_LE_01_03.ViewModels
{
    /// <summary>
    /// Haupt-ViewModel-Klasse zur Verwaltung der Buchansicht.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private BookManager _bookManager;
        private Book _selectedBook;
        private string _filterText;
        private string _selectedFilterOption;
        private Book _selectedValue;

        private readonly FilterManager _bookFilter;

        /// <summary>
        /// Sammlung aller Bücher.
        /// </summary>
        public ObservableCollection<Book> Books { get; }

        /// <summary>
        /// Gefilterte Buchsammlung basierend auf dem Filtertext und der ausgewählten Filteroption.
        /// </summary>
        public ObservableCollection<Book> FilteredBooks { get; set; }

        /// <summary>
        /// Befehl zum Hinzufügen eines neuen Buches.
        /// </summary>
        public RelayCommand AddBookCommand => new RelayCommand(AddBook,CanAddBook);

        /// <summary>
        /// Befehl zum Entfernen eines ausgewählten Buches.
        /// </summary>
        public RelayCommand RemoveBookCommand => new RelayCommand(RemoveBook, CanRemoveBook);

        /// <summary>
        /// Befehl zum Hochladen von Büchern.
        /// </summary>
        public RelayCommand UploadBookCommand => new RelayCommand(UploadBooks);

        /// <summary>
        /// Befehl zum Speichern der Bücher.
        /// </summary>
        public RelayCommand SaveBookCommand => new RelayCommand(SaveBook, CanSave);

        /// <summary>
        /// Befehl zum Aktualisieren der Bücher.
        /// </summary>
        public RelayCommand UpdateBookCommand => new RelayCommand(UpdateBook, CanUpdateBook);

        private void UpdateBook()
        {
            _bookManager.UpdateBook(_selectedBook);
            UpdatePositions();
        }

        /// <summary>
        /// Konstruktor für das MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            _bookManager = new BookManager();
            _bookFilter = new FilterManager();

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

        /// <summary>
        /// Filtert die Bücher basierend auf dem Filtertext und der ausgewählten Filteroption.
        /// </summary>
        private void FilterBooks()
        {
            FilteredBooks = _bookFilter.ApplyFilter(Books, FilterText, SelectedFilterOption);
            OnPropertyChanged(nameof(FilteredBooks));
        }

        /// <summary>
        /// Filtertext zum Filtern der Bücher.
        /// </summary>
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                FilterBooks(); 
            }
        }

        /// <summary>
        /// Ausgewähltes Buch.
        /// </summary>
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook != value)
                {
                    _selectedBook = value;
                    
                    OnPropertyChanged(nameof(SelectedBook));
                }
            }
        }

        public Book SelectedValue
        {
            get => _selectedValue;
            set
            {
                if (_selectedValue != value)
                {
                    _selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                    if (_selectedValue != null)
                    {
                        SelectedBook = _selectedValue;
                    }
                }
            }
        }

        /// <summary>
        /// Ausgewählte Filteroption zum Filtern der Bücher.
        /// </summary>
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

        /// <summary>
        /// Speichert die Bücher in einer CSV-Datei.
        /// </summary>
        private void SaveBook() { SaveCSV.Save(FilteredBooks.ToList()); }

        /// <summary>
        /// Überprüft, ob Bücher gespeichert werden können.
        /// </summary>
        private bool CanSave() { return Books.Count > 0; }

        /// <summary>
        /// Lädt Bücher hoch und aktualisiert die Liste.
        /// </summary>
        private void UploadBooks()
        {
            _bookManager.Books.Clear();
            Books.Clear();

            var books = UploadCSV.Upload();

            if (books !=null)
            {
                _bookManager.AddBooks(books);
                UpdatePositions();
            }


        }

        /// <summary>
        /// Fügt ein neues Buch hinzu.
        /// </summary>
        private void AddBook()
        {
            Book newBook = new Book
            {
                ID = Books.Count > 0 ? Books.Max(b => b.ID) + 1 : 1,
                Title = SelectedBook.Title,
                Author = SelectedBook.Author,
                Genre = SelectedBook.Genre,
                PublicationDate = SelectedBook.PublicationDate,

                Status = SelectedBook.Status,
            };
            _bookManager.AddBook(newBook);
            UpdatePositions();
        }

        /// <summary>
        /// Aktualisiert die Positionen der Bücher in der Liste.
        /// </summary>
        private void UpdatePositions()
        {
            for (int i = 0; i < Books.Count; i++) { Books[i].ID = i + 1; CleanWindow(); }
        }

        /// <summary>
        /// Entfernt das ausgewählte Buch.
        /// </summary>
        private void RemoveBook()
        {
            if (SelectedBook != null)
            {
                _bookManager.RemoveBook(SelectedBook.ID);
            }
            UpdatePositions();
            OnPropertyChanged(nameof(SelectedBook));
        }

        /// <summary>
        /// Überprüft, ob ein Buch hinzugefügt werden kann.
        /// </summary>
        private bool CanAddBook()
        {
            return 
                   !string.IsNullOrWhiteSpace(SelectedBook?.Title) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Status) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Genre) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Author) &&
                   SelectedValue == null &&
                   SelectedBook.PublicationDate.HasValue;
        }
        /// <summary>
        /// Überprüft, ob ein Buch hinzugefügt werden kann.
        /// </summary>
        private bool CanUpdateBook()
        {
            return 
                   !string.IsNullOrWhiteSpace(SelectedBook?.Title) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Status) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Genre) &&
                   !string.IsNullOrWhiteSpace(SelectedBook?.Author) &&   
                   SelectedValue != null &&
                   SelectedBook.PublicationDate.HasValue;
        }

        /// <summary>
        /// Überprüft, ob ein Buch entfernt werden kann.
        /// </summary>
        private bool CanRemoveBook()
        {
            return SelectedValue != null;
        }

        /// <summary>
        /// Bereinigt das Fenster und setzt das ausgewählte Buch zurück.
        /// </summary>
        private void CleanWindow()
        {
            SelectedBook = new Book();
            SelectedValue = null;
        }
    }
}
