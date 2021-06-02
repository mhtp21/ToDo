using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo
{
    public class BoardManager
    {
        public List<BoardTypes> ListBoardTypes()
        {
            return BoardData.Board.BoardTypes.ToList();
        }

        public bool AddCardToBoard(Card card)
        {
            try
            {
                BoardData.Board.BoardTypes.Add(new BoardTypes(card, StatusType.TODO));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public BoardTypes FindBoardElementByCard(string cardTitle)
        {
            return BoardData.Board.BoardTypes.FirstOrDefault(x => x.Card.Title.ToLower() == cardTitle.ToLower());
        }

        public bool RemoveBoardTypes(BoardTypes boardTypes)
        {
            try
            {
                BoardData.Board.BoardTypes.Remove(boardTypes);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TransportCard(BoardTypes boardTypes)
        {
            try
            {
                foreach(var item in BoardData.Board.BoardTypes)
                {
                    if (item == boardTypes)
                    {
                        item.Status = boardTypes.Status;
                        break;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
