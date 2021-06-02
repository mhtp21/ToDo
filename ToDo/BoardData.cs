using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public static class BoardData
    {
        public static Board Board;

        static BoardData() { Board = StartBoard(); }

        static Board StartBoard()
        {
            return new Board()
            {
                BoardTypes = new List<BoardTypes>()
                {
                    new BoardTypes()
                    {
                        Card =  new Card("1.Başlık","İçerik 1", 1, SizeType.M),
                        Status = StatusType.TODO
                    },

                    new BoardTypes()
                    {
                         Card = new Card("2.Başlık","İçerik 2", 2, SizeType.L),
                        Status = StatusType.INPROGRESS
                    },

                     new BoardTypes()
                    {
                        Card = new Card("3.Başlık","İçerik 3", 3, SizeType.XL),
                        Status = StatusType.DONE
                    }

                }
            };
        }
    }
}
