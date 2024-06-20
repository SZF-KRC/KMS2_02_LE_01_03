using System;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace KMS2_02_LE_01_03.UploadData
{
    /// <summary>
    /// Statische Klasse zur Handhabung von Dateiöffnungsdialogen.
    /// </summary>
    public static class OpenDialog
    {
        /// <summary>
        /// Öffnet einen Dateiöffnungsdialog und gibt den Pfad der ausgewählten Datei zurück.
        /// </summary>
        /// <param name="prompt">Der Titel des Dateiöffnungsdialogs.</param>
        /// <returns>Der Pfad der ausgewählten Datei oder null, wenn keine Datei ausgewählt wurde.</returns>
        public static string OpenFile(string prompt)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.csv)|*.csv",
                    Title = prompt
                };
                return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
            }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return null;
        }
    }
}
