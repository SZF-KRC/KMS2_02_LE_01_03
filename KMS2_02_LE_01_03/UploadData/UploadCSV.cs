using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KMS2_02_LE_01_03.UploadData
{
    /// <summary>
    /// Klasse zum Hochladen von Büchern aus einer CSV-Datei.
    /// </summary>
    public class UploadCSV
    {
        private static List<Book> _books;

        /// <summary>
        /// Öffnet einen Dateiöffnungsdialog und lädt die Bücher aus der ausgewählten CSV-Datei.
        /// </summary>
        public static List<Book> Upload()
        {
            try
            {
                string filePath = OpenDialog.OpenFile("Enter book please...");
                if(filePath == null) { return null; }
                _books = new List<Book>();
                using(StreamReader sr = new StreamReader(filePath))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length > 0)
                        {
                            _books.Add(new Book { ID = Int32.Parse(parts[0]), Title = parts[1], Author = parts[2], Genre = parts[3], PublicationDate = DateTime.Parse(parts[4]), Status = parts[5] });
                        }
                    }
                }
            }
            catch (FileFormatException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return _books;
        }

        /// <summary>
        /// Gibt die Liste der hochgeladenen Bücher zurück.
        /// </summary>
        /// <returns>Eine Liste der Bücher.</returns>
        public List<Book> GetBooks() => _books;
    }
}
