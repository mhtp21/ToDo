using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class BoardTypes
    {
        public Card Card { get; set; }
        public StatusType Status { get; set; }

        public BoardTypes() { }

        public BoardTypes(Card card, StatusType status)
        {
            this.Card = card;
            this.Status = status;
        }
    }


}
