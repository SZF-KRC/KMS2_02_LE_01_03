using System;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace KMS2_02_LE_01_03.SaveData
{
    /// <summary>
    /// Statische Klasse zur Handhabung von Dateispeicherdialogen.
    /// </summary>
    public static class SaveDialog
    {
        /// <summary>
        /// Öffnet einen Dateispeicherdialog und gibt den Pfad der ausgewählten Datei zurück.
        /// </summary>
        /// <param name="prompt">Der Titel des Dateispeicherdialogs.</param>
        /// <returns>Der Pfad der ausgewählten Datei oder null, wenn keine Datei ausgewählt wurde.</returns>
        public static string SaveFile(string prompt)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = prompt,
                    DefaultExt = "csv"
                };
                return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
            }
            catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return null;
        }
    }
}