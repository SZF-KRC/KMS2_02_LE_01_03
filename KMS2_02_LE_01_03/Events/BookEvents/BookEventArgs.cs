using System;

namespace KMS2_02_LE_01_03.Events.BookEvents
{
    /// <summary>
    /// Ereignisdaten für Buchereignisse.
    /// </summary>
    public class BookEventArgs : EventArgs
    {
        /// <summary>
        /// Die Nachricht, die das Ereignis beschreibt.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Der Zeitpunkt, zu dem das Ereignis abgeschlossen wurde.
        /// </summary>
        public DateTime CompletionTime { get; }

        /// <summary>
        /// Initialisiert eine neue Instanz der BookEventArgs-Klasse.
        /// </summary>
        /// <param name="message">Die Nachricht, die das Ereignis beschreibt.</param>
        /// <param name="completionTime">Der Zeitpunkt, zu dem das Ereignis abgeschlossen wurde.</param>
        public BookEventArgs(string message, DateTime completionTime)
        {
            Message = message;
            CompletionTime = completionTime;
        }
    }
}
