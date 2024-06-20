using KMS2_02_LE_01_03.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KMS2_02_LE_01_03.SaveData
{
    /// <summary>
    /// Klasse zum Speichern von Büchern in einer CSV-Datei.
    /// </summary>
    public class SaveCSV
    {
        /// <summary>
        /// Speichert die Bücher in einer CSV-Datei.
        /// </summary>
        /// <param name="books">Die Liste der zu speichernden Bücher.</param>
        public static void Save(List<Book> books)
        {
            try
            {
                string filePath = SaveDialog.SaveFile("Save books to file...");
                if (string.IsNullOrEmpty(filePath)) return;

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("ID,Title,Author,Genre,PublicationDate,Status");
                    foreach (var book in books)
                    {
                        sw.WriteLine($"{book.ID},{book.Title},{book.Author},{book.Genre},{book.PublicationDate},{book.Status}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}