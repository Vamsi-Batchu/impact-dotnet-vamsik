using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment
{
    public class Playlist
    {
        private string[] songs = new string[5];

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < songs.Length)
                {
                    return songs[index];
                }

                return "Invalid Index";
            }

            set
            {
                if (index >= 0 && index < songs.Length)
                {
                    songs[index] = value;
                }
            }
        }

        public char this[string word, int index]
        {
            get
            {
                if (!string.IsNullOrEmpty(word) &&
                    index >= 0 &&
                    index < word.Length)
                {
                    return word[index];
                }

                return '\0';
            }
        }
    }
}