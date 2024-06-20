using KMS2_02_LE_01_03.MVVM;
using System;

namespace KMS2_02_LE_01_03.Model
{
    /// <summary>
    /// Klasse, die ein Buch darstellt.
    /// </summary>
    public class Book : ViewModelBase
    {
        private int _id;
        private string _title;
        private string _author;
        private string _genre;
        private DateTime? _publicationDate;
        private string _status;

        /// <summary>
        /// Die eindeutige ID des Buches.
        /// </summary>
        public int ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Der Titel des Buches.
        /// </summary>
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Der Autor des Buches.
        /// </summary>
        public string Author
        {
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Das Genre des Buches.
        /// </summary>
        public string Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Der Veröffentlichungsstatus des Buches.
        /// </summary>
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Das Veröffentlichungsdatum des Buches.
        /// </summary>
        public DateTime? PublicationDate
        {
            get => _publicationDate;
            set { _publicationDate = value; OnPropertyChanged(); }
        }
    }
}
