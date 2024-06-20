using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace KMS2_02_LE_01_03.Manager
{
    /// <summary>
    /// Klasse zur Verwaltung der Filterung von Büchern.
    /// </summary>
    public class FilterManager
    {
        /// <summary>
        /// Wendet den angegebenen Filter auf die Buchsammlung an.
        /// </summary>
        /// <param name="books">Die Sammlung der zu filternden Bücher.</param>
        /// <param name="filterText">Der Text, nach dem gefiltert werden soll.</param>
        /// <param name="selectedFilterOption">Die ausgewählte Filteroption.</param>
        /// <returns>Eine gefilterte Sammlung von Büchern.</returns>
        public ObservableCollection<Book> ApplyFilter(ObservableCollection<Book> books, string filterText, string selectedFilterOption)
        {
            var filteredBooks = new ObservableCollection<Book>();
            var filtered = books.AsQueryable();

            if (!string.IsNullOrEmpty(filterText))
            {
                if (!string.IsNullOrEmpty(filterText))
                {
                    switch (selectedFilterOption)
                    {
                        case "By Title":
                            filtered = filtered.Where(book => book.Title != null && book.Title.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);
                            break;
                        case "By Author":
                            filtered = filtered.Where(book => book.Author != null && book.Author.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);
                            break;
                        case "By Genre":
                            filtered = filtered.Where(book => book.Genre != null && book.Genre.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);
                            break;
                        case "By Status":
                            filtered = filtered.Where(book => book.Status != null && book.Status.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);
                            break;
                        case "By Date":
                            if (DateTime.TryParse(filterText, out DateTime date))
                            {
                                filtered = filtered.Where(book => book.PublicationDate.HasValue && book.PublicationDate.Value.Date == date.Date);
                            }
                            else
                            {
                                filtered = filtered.Where(book => book.PublicationDate.HasValue && book.PublicationDate.Value.ToString("yyyy-MM-dd").Contains(filterText));
                            }
                            break;
                    }
                }
            }

            foreach (var book in filtered)
            {
                filteredBooks.Add(book);
            }

            return filteredBooks;
        }
    }
}
