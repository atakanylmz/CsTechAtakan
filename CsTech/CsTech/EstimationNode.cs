using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTech
{
    public class EstimationNode
    {
        public EstimationNode(int estimation)
        {
            this.Estimation = estimation;
            Digits = new int[4];
            int number = estimation;

            for (int i = 0; i < 4; i++)
            {
                Digits[i] = number % 10;
                number = number / 10;
            }
            
        }
        //bağlı listede sıradaki düğüm
        public EstimationNode Next=null;
        //düğümdeki tahmin
        public int Estimation { get; set; }
        //tahminin basamaklarındaki rakamlar
        public int[] Digits { get; private set; }
        //tahmine ait ipuçları
        public int PlusClue { get; set; }
        public int MinusClue { get; set; }
    }
}
