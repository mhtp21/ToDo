using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int MemberId { get; set; }
        public SizeType Size { get; set; }

        public Card() { }
        public Card(string title, string content, int MemberId, SizeType size)
        {
            this.Title = title;
            this.Content = content;
            this.MemberId = MemberId;
            this.Size = size;
        }
    }
}
