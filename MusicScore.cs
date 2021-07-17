using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemTunesPlayer
{
    class MusicScore
    {
        public String id { get; set; }
        public String scoreName { get; set; }
        public String authorFullUsername { get; set; }
        public int downvoteCount { get; set; }
        public int upvoteCount { get; set; }
        public int bpm { get; set; }
        public List<MusicBeat> beats { get; set; }

    }
}
