using KMS2_02_LE_01_03.MVVM;
using System;

namespace KMS2_02_LE_01_03.Model
{
    public class Book : ViewModelBase
    {
        private int _id;
        private string _title;
        private string _author;
        private string _genre;
        private DateTime _publicationDate;
        private string _status;


        public int ID 
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public string Title 
        { 
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }
        public string Author 
        { 
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }
        public string Genre 
        { 
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }
        public DateTime PublicationDate 
        {
            get => _publicationDate;
            set { _publicationDate = value; OnPropertyChanged(); }
        }
        public string Status 
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }
    }
}
