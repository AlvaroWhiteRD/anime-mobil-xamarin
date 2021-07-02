using System;
using System.Collections.Generic;
using System.Text;

namespace XanimeX.Model
{
    public class Episode
    {
        public int IdEpisode { get; set; }
        public string EpisodeVideo { get; set; }
        public int IdAnime { get; set; }
        public int EpisodeNumber { get; set; }
    }
}