using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTech
{
    public class RandomNumber
    {
        Random random;
        public RandomNumber()
        {
            random = new Random();
        }
        public int GetARandomNumber()
        {
            bool[] UsingNumber = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                UsingNumber[i] = false;

            }            
            return GetARandomNumberWithFalseDigits(UsingNumber);
        }

        public int GetARandomNumberWithFalseDigits(bool[] digits)
        {

            int unitsDigit;
            int tensDigit;
            int hundredsDigit;
            //binler basamağında sıfır olmaz 
            int thousandsDigit;
            //kullanılan rakamı tekrar kullanmamak için bool tipinde tut.
            bool[] UsingNumber = digits;
            int trues = 0;
            bool temp = digits[0];
            //ilk basamak sıfır olamayacağı için geçici olarak true yap
            UsingNumber[0] = true;
            for (int i = 0; i < 10; i++)
            {
                if (UsingNumber[i] == true)
                    trues++;
            }
            thousandsDigit = CreateDigit(UsingNumber, trues);
            //geçici durumu eski haline getir
            UsingNumber[0] = temp;
            trues = 0;
            for (int i = 0; i < 10; i++)
            {
                if (UsingNumber[i] == true)
                    trues++;
            }
            hundredsDigit = CreateDigit(UsingNumber, trues);
            tensDigit = CreateDigit(UsingNumber, trues+1);
            unitsDigit = CreateDigit(UsingNumber, trues+2);
            for (int i = 0; i < 10; i++)
            {
                UsingNumber[i] = false;
            }
            return 1000 * thousandsDigit + 100 * hundredsDigit + 10 * tensDigit + unitsDigit;
        }


        private int CreateDigit(bool[] usingNumber,int trues)
        {            
            //falses=kullanılmamış rakamların adedi içinde gitmek istenen rastgele yer
            int falses = random.Next(1, 11 - trues);
            for (int i = 0; i < 10; i++)
            {
                //rakamların tekrar etmemesi için  kullanılan rakamlarda azaltma yapma
                if (!usingNumber[i])
                    falses--;
                //istenen yere ulaşılınca dur
                if (falses == 0)
                {
                    usingNumber[i] = true;
                    return i;
                }
            }
            return 0;
        }


        public int GetThreeNumbersWithFalseDigits(bool[] digits)
        {

            int unitsDigit;
            int tensDigit;
            int hundredsDigit;
            //yüzler basamağında sıfır olmaz 
            //kullanılan rakamı tekrar kullanmamak için bool tipinde tut.
            bool[] UsingNumber = digits;
            int trues = 0;
            bool temp = digits[0];
            //ilk basamak sıfır olamayacağı için geçici olarak true yap
            UsingNumber[0] = true;
            for (int i = 0; i < 10; i++)
            {
                if (UsingNumber[i] == true)
                    trues++;
            }
            hundredsDigit = CreateDigit(UsingNumber, trues);
            //geçici durumu eski haline getir
            UsingNumber[0] = temp;
            trues = 0;
            for (int i = 0; i < 10; i++)
            {
                if (UsingNumber[i] == true)
                    trues++;
            }
            tensDigit = CreateDigit(UsingNumber, trues);
            unitsDigit = CreateDigit(UsingNumber, trues + 1);
            for (int i = 0; i < 10; i++)
            {
                UsingNumber[i] = false;
            }
            return   100 * hundredsDigit + 10 * tensDigit + unitsDigit;
        }
    }
}
