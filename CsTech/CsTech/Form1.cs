using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace CsTech
{
    public partial class Form1 : Form
    {
        #region Fields
        //bilgisayarın tuttuğu sayı
        private int numberPcHold;
        //rakamları faklı sayı üreten sınıf
        RandomNumber number;
        //tahmin düğümü:tahmin ve o tahmine ait özellikleri barındırır
        //root bağlı listenin ilk düğümüdür
        EstimationNode EstimationRoot;
        EstimationNode CurrentEstimation;
        //kullanıcının tahminlerine ipucu üreten sınıf
        Clue clue;
        //düğümlerden doğru rakamları bulan sınıf
        CorrectDigits correctDigits;
        //kullanıcıya verilecek +ipucu
        private int plusClue = 0;
        //kullanıcıya verilecek -ipucu
        private int minusClue = 0;
        //kullanıcı tahmini
        private int playerEstimation = 0;
        #endregion

        #region Constructer
        public Form1()
        {
            number = new RandomNumber();
            numberPcHold = number.GetARandomNumber();
            
            InitializeComponent();
            clue = new Clue();
            correctDigits = new CorrectDigits();
            # region muhtemel ilk dokuz tahmin
            //en kötü ihtimalle bu dokuz tahmin sonunda hangi rakamların kullanılacağı ortaya çıkar.
            //rakamlar çıkınca yerleri tahmin edilir.
            //önce 0 hariç rakamları üçerli üç gruplara ayır, böylece ipuçlarını daha iyi değerlendir
            bool[] digits = new bool[10];
            for (int i = 0; i < 10; i++)
                digits[i] = false;
            digits[0] = true;

            int firstEstimation = number.GetThreeNumbersWithFalseDigits(digits)*10;
            EstimationRoot = new EstimationNode(firstEstimation);
            for (int i = 0; i < 4; i++)
                digits[EstimationRoot.Digits[i]] = true;
            

            int secondEstimation = number.GetThreeNumbersWithFalseDigits(digits) * 10;
            EstimationNode secondEstimationNode = new EstimationNode(secondEstimation);
            for (int i = 0; i < 4; i++)
            {
                digits[secondEstimationNode.Digits[i]] = true;
                digits[EstimationRoot.Digits[i]] = true;
            }
            EstimationRoot.Next = secondEstimationNode;

            int thirdEstimation = number.GetThreeNumbersWithFalseDigits(digits) * 10;
            EstimationNode thirdEstimationNode = new EstimationNode(thirdEstimation);
            secondEstimationNode.Next = thirdEstimationNode;

            //sıfırın durumu ortaya çıktı, artık dörderli iki gruba ayır

            int fourthEstimation = EstimationRoot.Digits[2]*1000+ EstimationRoot.Digits[3] * 100
                + thirdEstimationNode.Digits[3]*10+ EstimationRoot.Digits[1];
            EstimationNode fourthEstimationNode = new EstimationNode(fourthEstimation);
            thirdEstimationNode.Next = fourthEstimationNode;

            int fifthEstimation = secondEstimationNode.Digits[2] * 1000 + secondEstimationNode.Digits[3] * 100
                + thirdEstimationNode.Digits[2] * 10 + secondEstimationNode.Digits[1];
            EstimationNode fifthEstimationNode = new EstimationNode(fifthEstimation);
            fourthEstimationNode.Next = fifthEstimationNode;

            int sixthEstimation = thirdEstimation + EstimationRoot.Digits[3];
            EstimationNode sixthEstimationNode = new EstimationNode(sixthEstimation);
            fifthEstimationNode.Next = sixthEstimationNode;

            int seventhEstimation = sixthEstimation/10 + EstimationRoot.Digits[2]*1000;
            EstimationNode seventhEstimationNode = new EstimationNode(seventhEstimation);
            sixthEstimationNode.Next = seventhEstimationNode;

            int eighthEstimation = thirdEstimationNode.Digits[1]*1000 + secondEstimationNode.Digits[3]*100
                + thirdEstimationNode.Digits[3]*10+ thirdEstimationNode.Digits[2];
            EstimationNode eighthEstimationNode = new EstimationNode(eighthEstimation);
            seventhEstimationNode.Next = eighthEstimationNode;

            int ninthEstimation = thirdEstimationNode.Digits[2] * 1000 + thirdEstimationNode.Digits[1] * 100 
                + secondEstimationNode.Digits[2] * 10+ thirdEstimationNode.Digits[3];
            EstimationNode ninthEstimationNode = new EstimationNode(ninthEstimation);
            eighthEstimationNode.Next = ninthEstimationNode;

            fourthEstimationNode.Next = fifthEstimationNode;
            CurrentEstimation = this.EstimationRoot;
            #endregion
        }
        #endregion

        //ipucunu onayla butonu tıklandığında
        private void ApproveClueBtn_Click(object sender, EventArgs e)
        {

            CurrentEstimation.PlusClue = Convert.ToInt32(plusClueTxt.Text);
            CurrentEstimation.MinusClue = Convert.ToInt32(minusClueTxt.Text);

            if (CurrentEstimation.PlusClue == 4)
            {
                DialogResult dialog = MessageBox.Show("+ipucu=4, yani " + CurrentEstimation.Estimation + " tahminim doğru, ben kazandım!");
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            //doğru rakamlarda ipuçlarının mutlak değerleri toplamı 4 olur
            if (CurrentEstimation.PlusClue + CurrentEstimation.MinusClue < 4)
            {
                if (CurrentEstimation.Next != null)
                    CurrentEstimation = CurrentEstimation.Next;
                else
                {
                    //CurrentEstimation=sayılarıbelirle();
                    
                    EstimationNode _estimationNode = new EstimationNode(correctDigits.FindCorrectDigits(EstimationRoot));
                    CurrentEstimation = _estimationNode;
                }
            }
            else
            {
                EstimationNode _estimationNode = new EstimationNode(correctDigits.OrderDigits(CurrentEstimation.Estimation));
                CurrentEstimation = _estimationNode;

                //currentEstimation için yerdeğiş();
            }


            clueLbl.Text = "Yaptığın "+ playerEstimation + " tahmini için sana +"+plusClue+" ve -"+minusClue+" ipuçlarını veriyorum.";
            empty1Lbl.Text = "Yeni tahminin ne?";
            clueGbox.Visible = false;
            estimationGbox.Visible = true;
        }


        int count = 0;
       //tahmin onayla butonu tıklandığında
        private void ApproveEstimationBtn_Click(object sender, EventArgs e)
        {
            count++;
            playerEstimation = Convert.ToInt32(playerEstimationTxt.Text);
            clue.CalculateClue(numberPcHold, playerEstimation);
            plusClue = clue.PlusClue;
            minusClue = clue.MinusClue;
            if(plusClue==4)
            {
                DialogResult dialog = MessageBox.Show("Kazandınız!");
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            clueLbl.Text = "Senin tuttuğun sayı için "+count+"."+" tahminim "
                +CurrentEstimation.Estimation+" Bana ipucu verir misin?";
            empty1Lbl.Text = "Lütfen ipuçlarını doğru ver. Dikkat! Tuttuğun sayıyı bulmak için ";
                empty2Lbl.Text= "12'den fazla tahmin yapmışsam ipuçlarını yanlış vermiş olabilirsin.";
            clueGbox.Visible = true;
            estimationGbox.Visible = false;
        }

        #region Key Events
        private void EstimationTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //girilen değer sayı veya kontrol karakteri değilse atla 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //girilen değer sayı ise
            if (char.IsDigit(e.KeyChar))
            {
                string estimation = playerEstimationTxt.Text;
                //rakam tekrarı varsa yine atla
                bool state1 = (int.Parse(e.KeyChar.ToString()) == 0 && playerEstimationTxt.Text.Length == 0);
                bool state2= estimation.Contains(e.KeyChar.ToString());
                e.Handled = state1 || state2;
            }
        }

        private void EstimationTxt_KeyUp(object sender, KeyEventArgs e)
        {//tahmin 4 basamaklı ise onay açık
            if (playerEstimationTxt.Text.Length == 4)
                approveEstimationBtn.Enabled = true;
            else
                approveEstimationBtn.Enabled = false;
        }

        private void PlusClueTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //girilen değer sayı veya kontrol karakteri değilse atla 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //girilen değer sayı ise
            if (char.IsDigit(e.KeyChar))
            {
                if (minusClueTxt.Text == "" || string.IsNullOrWhiteSpace(minusClueTxt.Text))
                    minusClueTxt.Text = "0";
                byte plusClue = Byte.Parse(e.KeyChar.ToString());
                byte minusClue = Convert.ToByte(minusClueTxt.Text);
                //4 basamak için ipuçları toplamı 4'den büyükse atla
                e.Handled = (plusClue + minusClue) > 4 ? true : false;
            }
        }

        private void MinusClueTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //girilen değer sayı veya kontrol karakteri değilse atla 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //girilen değer sayı ise
            if (char.IsDigit(e.KeyChar))
            {
                if (plusClueTxt.Text == "" || string.IsNullOrWhiteSpace(plusClueTxt.Text))
                    plusClueTxt.Text = "0";
                byte minusClue = Byte.Parse(e.KeyChar.ToString());
                byte plusClue = Convert.ToByte(plusClueTxt.Text);
                //4 basamak için ipuçları toplamı 4'den büyükse atla
                e.Handled = (plusClue + minusClue) > 4 ? true : false;
            }
        }

        private void PlusClueTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (plusClueTxt.Text == "" || string.IsNullOrWhiteSpace(plusClueTxt.Text) ||
                minusClueTxt.Text == "" || string.IsNullOrWhiteSpace(minusClueTxt.Text))
                approveClueBtn.Enabled = false;
            else
                approveClueBtn.Enabled = true;
        }

        private void MinusClueTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (plusClueTxt.Text == "" || string.IsNullOrWhiteSpace(plusClueTxt.Text) ||
               minusClueTxt.Text == "" || string.IsNullOrWhiteSpace(minusClueTxt.Text))
                approveClueBtn.Enabled = false;
            else
                approveClueBtn.Enabled = true;
        }
        #endregion
    }
}
