using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Library
{
    public class Message
    {
        public Message(String player, String text)
        {
            Player = player;
            Text = text;
        }

        public String Player { get; set; }
        public String Text { get; set; }
    }
}