using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Solutions.Recursion.Crossword
{
    public class Grid
    {
        public const char EmptyCell = '-';
        public char[,] data;
        public List<Slot> slots = new List<Slot>();
        public List<string> words = new List<string>();

        public Grid(char[,] data, List<string> words)
        {
            this.words = words;
            this.data = data;
            ProcessInput();
        }

  
      
        public void Solve()
        {
            //This is the recursion part...
            List<List<string>> wordCombos = AlgorithmUtility.Permutations(words);

            //Try each word combo with the slot list
            foreach (List<string> wordCombo in wordCombos)
            {
                if (SlotsMatchWordCombo(wordCombo))
                {
                    foreach (Slot slot in slots)
                    {
                        if (slot.SlotType == SlotType.FixedColumn)
                        {
                            int j = 0;
                            for (int i = slot.Start; i <= slot.End; ++i)
                            {
                                data[i, slot.FixedValue] = slot.CurrentWord[j];
                                ++j;
                            }
                        }
                        else
                        {
                            int j = 0;
                            for (int i = slot.Start; i <= slot.End; ++i)
                            {
                                data[slot.FixedValue, i] = slot.CurrentWord[j];
                                ++j;
                            }

                        }
                        //Debug.WriteLine(slot);
                    }
                    return;
                    //Slap this wordcombo on to the slots.
                }
            }
             
            Print();
        }

        private bool SlotsMatchWordCombo(List<string> wordCombo)
        {
            for (int i = 0; i < slots.Count; ++i)
            {
                //if any of the word's length does not match the assigned slots length.. then ignore this wordcombo.
                if (slots[i].Length != wordCombo[i].Length) return false;
            }
            //We have a situation where we have matched each word in the combo to its slot.. based on just the length.
            //Now check if the intersecting characters line up..(that's what makes it a crossword.. right?).
            for (int i = 0; i < slots.Count; ++i)
            {
                //if any of the word's length does not match the assigned slots length.. then ignore this wordcombo.
                slots[i].CurrentWord = wordCombo[i];
            }
            
            for (int i = 0; i < slots.Count; ++i)
            {
                 for (int j = 0; j < slots.Count; ++j)
                {
                    if (!slots[i].Compatible(slots[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        #region utility 

        public void Print()
        {
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    Debug.Write(data[i, j]);

                }
                Debug.WriteLine("");
            }

        }
        private int GRIDSIZE = 10;
        private void ProcessInput()
        {
            for (int row = 0; row < GRIDSIZE; ++row)
            {
                int start = -1;
                int end = -1;
                for (int col = 0; col < GRIDSIZE; ++col)
                {
                    bool isCurrentCellEmpty = EmptyCell == data[row, col];
                    if (!isCurrentCellEmpty) continue;

                    bool isPrevCellEmpty = col == 0 ? false : data[row, col - 1] == EmptyCell;
                    bool isNextCellEmpty = col == GRIDSIZE - 1 ? false : (data[row, col + 1] == EmptyCell);

                    if (start < 0 &&  !isPrevCellEmpty)
                    {
                        start = col;
                    }
                    if (end < 0 && !isNextCellEmpty)
                    {
                        end = col;
                    }
                    if (start >= 0 && end >= 0)
                    {
                        Slot s = new Slot(row, start, end, SlotType.FixedRow);
                        if (!slots.Contains(s)) slots.Add(s);
                        start = -1;
                        end = -1;
                    }
                }
            }

            for (int col = 0; col < GRIDSIZE; ++col)
            {
                int start = -1;
                int end = -1;
                for (int row = 0; row < GRIDSIZE; ++row)
                {
                    bool isCurrentCellEmpty = EmptyCell == data[row, col];
                    if (!isCurrentCellEmpty) continue;
                    bool isPrevCellEmpty = row == 0 ? false : data[row - 1, col] == EmptyCell;
                    bool isNextCellEmpty = row == GRIDSIZE - 1 ? false : (data[row + 1, col] == EmptyCell);

                    if (start < 0 && !isPrevCellEmpty)
                    {
                        start = row;
                    }
                    if (end < 0 && !isNextCellEmpty)
                    {
                        end = row;
                    }

                    if (start >= 0 && end >= 0)
                    {
                        Slot s = new Slot(col, start, end, SlotType.FixedColumn);
                        if (!slots.Contains(s)) slots.Add(s);
                        start = -1;
                        end = -1;
                    }
                }
            }

            //TODO Base it on words being processed
            slots.RemoveAll(x => x.Start == x.End);


        }

        #endregion


    }

}
