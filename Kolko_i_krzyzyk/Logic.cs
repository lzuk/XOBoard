using System;
using System.Collections;

namespace Kolko_i_krzyzyk
{
    public static class Logic
    {
        private static readonly Random random = new Random();
        private static XOBoard xoBoard;

        static Logic()
        {
            xoBoard = XOBoard.Instance;
            Algorithm = Algorithms.RandomAvailable;
        }

        private static ArrayList CreateHashMapWithEmptyField()
        {
            ArrayList freeLocationArrayList = new ArrayList();
            for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                {
                    if (xoBoard.Board[wiersz, kolumna].FieldStatus == FieldStatus.Empty)
                    {
                        freeLocationArrayList.Add(new Location(wiersz, kolumna));
                    }
                }
            }
            return freeLocationArrayList;
        }

        public static Location Location()
        {
            ArrayList freeLocationArrayList = CreateHashMapWithEmptyField();
            if (freeLocationArrayList.Count == 0)
            {
                return new Location(-1,-1);
            }
            switch (Algorithm)
            {
                case Algorithms.FirstAvailable:
                {
                    return (Location) freeLocationArrayList[0];
                }
                case Algorithms.RandomAvailable:
                {
                    return (Location)freeLocationArrayList[random.Next(freeLocationArrayList.Count)];
                }
                default:
                    throw new ArgumentOutOfRangeException("algorithms");
            }
        }

        public static Algorithms Algorithm { get; set; }
    }

    public enum Algorithms
    {
        FirstAvailable,
        RandomAvailable
    }
}
