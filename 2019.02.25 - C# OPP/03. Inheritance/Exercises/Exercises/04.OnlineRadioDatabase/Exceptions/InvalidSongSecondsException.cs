﻿namespace _04.OnlineRadioDatabase.Exceptions
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException(string message = "Song seconds should be between 0 and 59.") 
            : base(message)
        {
        }
    }
}