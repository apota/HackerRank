using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace HackerRank.Solutions.Recursion.Crossword
{
    /// <summary>
    /// A class to model the vertical and horizontal gaps/slots on the puzzle that need to be filled. 
    /// </summary>
    public class Slot
    {

        public int FixedValue, Start, End;

        public SlotType SlotType;


        public int Length
        {
            get { return End - Start + 1; }
        }

        public Slot(int fixedValue, int start, int end, SlotType st)
        {
            FixedValue = fixedValue;
            Start = start;
            End = end;
            SlotType = st;
        }


        public override bool Equals(object o)
        {
            Slot that = o as Slot;
            return this.Start == that.Start && this.End == that.End && this.FixedValue ==
                   that.FixedValue && this.SlotType == that.SlotType;
        }

        public string CurrentWord { get; set; }

        /// <summary>
        /// A Slot A is compatible with slot B 
        ///     1. If A and B do not intersect (they are both vertical or horizontal)
        ///     2. If A and B intersect than the intersection point is a character that exists in both words.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Compatible(Slot y)
        {

            if (this.SlotType == y.SlotType)
            {
                return true;
            }


            if ((y.FixedValue > Start && y.FixedValue < End) ||
                (FixedValue > y.Start && FixedValue < y.End) ||
                (y.FixedValue == Start || y.FixedValue == End) ||
                (FixedValue == y.Start || FixedValue == y.End)
            )
            {
                string yFrag = null;
                string xFrag = null;

                if (FixedValue >= y.Start && y.CurrentWord.Length >= FixedValue - y.Start)
                {
                    yFrag = y.CurrentWord.Substring(FixedValue - y.Start, 1);
                }
                if (y.FixedValue >= Start && CurrentWord.Length >= y.FixedValue - Start)
                {
                    xFrag = CurrentWord.Substring(y.FixedValue - Start, 1);
                }

                if (xFrag == null || yFrag == null) return true;

                if (xFrag != yFrag)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (SlotType.FixedRow == SlotType)
            {
                sb.Append("R ");
            }
            else
            {
                sb.Append("C ");
            }
            sb.Append(FixedValue + " " + Start + ":" + End + ":" + CurrentWord);
            return sb.ToString();
        }

    }



}
