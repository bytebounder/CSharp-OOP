namespace _04.OnlineRadioDatabase.Core
{
    using _04.OnlineRadioDatabase.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {

            var numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    var inputArgs = Console.ReadLine().Split(";");

                    if (inputArgs.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    var artistName = inputArgs[0];
                    var songName = inputArgs[1];
                    var length = inputArgs[2].Split(":");

                    bool isMinutes = int.TryParse(length[0], out int minutes);
                    bool isSeconds = int.TryParse(length[1], out int seconds);

                    if (isMinutes == false)
                    {
                        throw new InvalidSongLengthException();
                    }

                    if (isSeconds == false)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int totalSeconds = songs.Sum(x => x.Minutes * 60 + x.Seconds);

            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}