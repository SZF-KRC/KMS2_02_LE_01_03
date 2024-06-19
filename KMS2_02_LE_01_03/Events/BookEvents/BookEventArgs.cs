using System;

namespace KMS2_02_LE_01_03.Events.BookEvents
{
    public class BookEventArgs : EventArgs
    {
        public string Message { get; }
        public DateTime CompletionTime { get; }

        public BookEventArgs(string message, DateTime completionTime)
        {
            Message = message;
            CompletionTime = completionTime;
        }
    }
}
