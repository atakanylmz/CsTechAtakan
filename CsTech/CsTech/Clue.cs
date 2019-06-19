using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTech
{
    public class Clue
    {
        public int PlusClue { get; private set; }
        public int MinusClue { get; private set; }
        //kullanıcının tahmini ile bilgisayarın tuttuğu sayı karşılaştırılıp ipucu üretir
        public void CalculateClue(int real,int estimation)
        {
            PlusClue = 0;
            MinusClue = 0;
            char[] realNumber = real.ToString().ToCharArray();
            char[] estimationNumber = estimation.ToString().ToCharArray();
            for (int i = 0; i < estimationNumber.Length; i++)
            {
                for (int k = 0; k < realNumber.Length; k++)
                {
                    if (estimationNumber[i] == realNumber[k])
                    {
                        if (i == k)
                            this.PlusClue++;
                        else
                            this.MinusClue++;
                    }
                }
            }
        }
    }
}
