using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTech
{
    public class CorrectDigits
    {
        //rakam tutulan sayı içinde kullanılmışsa 1 aksi halde 0 olacak
        private readonly int[] digits;
        //ipuçların mutlak değerlerinin toplamı. Yani yerine bakılmaksızın doğru rakamlar mı?
        private int[] nodeClue;
        //birler basamağında kesin olmayanlar false
        private bool[] existUnits;
        //onlar basamağında kesin olmayanlar false
        private bool[] existTens;
        //yüzler basamağında kesin olmayanlar false
        private bool[] existHundreds;
        //binler basamağında kesin olmayanlar false
        private bool[] existThousands;
        //list sınıfının hazır contains metodu sayesinde daha önce yapılan 
        //tahminlerin içinde mevcut tahmin var mı bakılır.
        //bu liste rakamlarının yeri yanlış olsa da doğru rakamlardan oluşan tahminleri tutar 
        List<int> estimationsWithRealDigits;
        //tahmin düğümleri tahminleri ve özelliklerini tutar
        readonly EstimationNode[] estimationNodes;
        Random Random;
        public CorrectDigits()
        {
            Random = new Random();
            
            estimationsWithRealDigits = new List<int>();

            digits = new int[10];
            estimationNodes = new EstimationNode[9];
            existUnits = new bool[10];
            existTens = new bool[10];
            existHundreds = new bool[10];
            existThousands = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                existUnits[i] = true;
                existTens[i] = true;
                existHundreds[i] = true;
                existThousands[i] = true;
            }
        }
        //özel bir hesaplamayla gerçek rakamları bulur
        public int FindCorrectDigits(EstimationNode root)
        {
            
            int threeFirst;
            int threeSecond;
            int threeThird;
            nodeClue = new int[9];
            EstimationNode currentEstimationNode=root;
            for (int i = 0; i < 9; i++)
            {
                nodeClue[i] = currentEstimationNode.PlusClue + currentEstimationNode.MinusClue;
                if (currentEstimationNode.PlusClue == 0)
                {
                    existUnits[currentEstimationNode.Digits[0]] = false;
                    existTens[currentEstimationNode.Digits[1]] = false;
                    existHundreds[currentEstimationNode.Digits[2]] = false;
                    existThousands[currentEstimationNode.Digits[3]] = false;
                }
                estimationNodes[i] = currentEstimationNode;
                currentEstimationNode = currentEstimationNode.Next;
            }
            if (nodeClue[0] + nodeClue[1] + nodeClue[2] == 6)
                digits[0] = 1;
            else if (nodeClue[0] + nodeClue[1] + nodeClue[2] == 4)
                digits[0] = 0;
            else
                throw new Exception("hatalı ipucu verdiniz!");//çık
            threeFirst = nodeClue[0] - digits[0];
            threeSecond = nodeClue[1] - digits[0];
            threeThird = nodeClue[2] - digits[0];
            digits[estimationNodes[3].Digits[1]] = nodeClue[3] - threeFirst;
            digits[estimationNodes[4].Digits[1]] = nodeClue[4] - threeSecond;
            digits[estimationNodes[2].Digits[1]] = nodeClue[2] - digits[estimationNodes[3].Digits[1]]
                - digits[estimationNodes[4].Digits[1]] - digits[0];
            digits[estimationNodes[5].Digits[0]] = nodeClue[5] - threeThird;
            digits[estimationNodes[6].Digits[3]] = nodeClue[6] - threeThird;
            digits[estimationNodes[0].Digits[1]] = threeFirst - digits[estimationNodes[5].Digits[0]]
                - digits[estimationNodes[6].Digits[3]];
            digits[estimationNodes[7].Digits[2]]= nodeClue[7] - threeThird;
            digits[estimationNodes[8].Digits[1]] = nodeClue[8] - threeThird;
            digits[estimationNodes[1].Digits[1]] = threeSecond - digits[estimationNodes[7].Digits[2]]
                - digits[estimationNodes[8].Digits[1]];
            int estimation = 0;
            int tens = 1;
            for (int i = 0; i < 10; i++)
            {                
                if (digits[i] == 1)//kullanılanların 1 olacağını yukarıda açıklamıştım
                {
                    estimation += i * tens;
                    tens = tens * 10;
                }
            }
            estimation = OrderDigits(estimation);
            estimationsWithRealDigits.Add(estimation);
            return estimation;//filtreden geçir orderDigits()
        }
        public int OrderDigits(int _currentEstimation)
        {
            //sırala
            int[] digitsToOrder = new int[4];
            int number = _currentEstimation;
            for (int i = 0; i < 4; i++)
            {
                digitsToOrder[i] = number % 10;
                number = number / 10;
            }
            int orderedEstimate= Estimate(digitsToOrder);

            while (estimationsWithRealDigits.Contains(orderedEstimate))
            {
                //eski tahminle aynı ise tekrar tahmin yap
                orderedEstimate= Estimate(digitsToOrder);
            }
            return orderedEstimate;
        }
        private int Estimate(int[] _digits)
        {
            bool repeat = false;
            int round = 0;//sonsuz döngü varsa metodu tekrar çağır
            int[] newDigits = new int[4];
            int oldIndex1;
            int oldIndex2;
            int oldIndex3;
            int randomIndex = Random.Next(0, 4);
            //başa 0 gelmez
            while (_digits[randomIndex] == 0||existThousands[_digits[randomIndex]] == false)
            {
                randomIndex = Random.Next(0, 4);
                round++;
                if (round == 1000)
                {
                    round = 0;
                    repeat = true;
                    break;
                }
            }
            if (repeat == false)
            {
                newDigits[3] = _digits[randomIndex];
                oldIndex1 = randomIndex;
                randomIndex = Random.Next(0, 4);
                round = 0;
                while (existHundreds[_digits[randomIndex]] == false || oldIndex1 == randomIndex)
                {
                    randomIndex = Random.Next(0, 4);
                    round++;
                    if (round == 1000)
                    {
                        round = 0;
                        repeat = true;
                        break;
                    }
                }

                if (repeat == false)
                {
                    newDigits[2] = _digits[randomIndex];
                    oldIndex2 = randomIndex;

                    randomIndex = Random.Next(0, 4);
                    round = 0;
                    while (existTens[_digits[randomIndex]] == false 
                        || oldIndex1 == randomIndex || oldIndex2 == randomIndex)
                    {
                        randomIndex = Random.Next(0, 4);
                        round++;
                        if (round == 1000)
                        {
                            round = 0;
                            repeat = true;
                            break;
                        }
                    }
                    if (repeat == false)
                    {
                        newDigits[1] = _digits[randomIndex];
                        oldIndex3 = randomIndex;

                        for (int i = 0; i < 4; i++)
                        {
                            if (oldIndex1 != i && oldIndex2 != i && oldIndex3 != i)
                                randomIndex = i;
                        }
                        newDigits[0] = _digits[randomIndex];
                    }
                    else
                        return Estimate(_digits);
                }
                else
                    return Estimate(_digits);
            }
            else
                return Estimate(_digits);


            return newDigits[3]*1000+ newDigits[2] * 100 + newDigits[1] * 10 + newDigits[0];
        }
    }
}
