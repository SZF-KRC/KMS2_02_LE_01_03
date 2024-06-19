//using KMS2_02_LE_01_03.Model;
//using KMS2_02_LE_01_03.MVVM;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KMS2_02_LE_01_03.ViewModels
//{
//    public class BookViewModel : ViewModelBase
//    {
//        private Book _book;

//        public BookViewModel(Book book)
//        {
//            _book = book;
//        }
//        public int Id => _book.ID;
//        public string Title
//        {
//            get => _book.Title;
//            set
//            {
//                if (_book.Title != value)
//                {
//                    _book.Title = value;
//                    OnPropertyChanged(nameof(Title));
//                }
//            }
//        }

//        public string Author
//        {
//            get => _book.Author;
//            set
//            {
//                if (_book.Author != value)
//                {
//                    _book.Author = value;
//                    OnPropertyChanged(nameof(Author));
//                }
//            }
//        }

//        public string Genre
//        {
//            get => _book.Genre;
//            set
//            {
//                if ( _book.Genre != value)
//                {
//                    _book.Genre = value;
//                    OnPropertyChanged(nameof(Genre));
//                }
//            }
//        }

//        public DateTime PublicationDate
//        {
//            get => _book.PublicationDate;
//            set
//            {
//                if( _book.PublicationDate != value)
//                {
//                    _book.PublicationDate = value;
//                    OnPropertyChanged(nameof(PublicationDate));
//                }
//            }
//        }

//        public string Status
//        {
//            get => _book.Status;
//            set
//            {
//                if(_book.Status != value)
//                {
//                    _book.Status = value;
//                    OnPropertyChanged(nameof(Status));
//                }
//            }
//        }

//        private string _newFilterText;
//        public string NewFilterText
//        {
//            get => _newFilterText;
//            set
//            {
//                if (_newFilterText != value)
//                {
//                    _newFilterText = value;
//                    OnPropertyChanged(nameof(NewFilterText));
//                }
//            }
//        }
//    }
//}
