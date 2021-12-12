using NUnit.Framework;
using System;

namespace CalcuFare_UnitTest
{
    public class Tests
    {
        [Test]
        public void CalcuFare_�դѨ��{2250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(9,2250);

            Assert.AreEqual(100, result);
        }
        [Test]
        public void CalcuFare_�դѨ��{2251()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(9,2251);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_�ߤW���{1450()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,1450);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_�ߤW���{1451()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,1451);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_���{0()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,0);

            Assert.AreEqual(0, result);
        }
        [Test]
        public void CalcuFare_���{���t()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,-20);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalcuFare_�ߤW���{800()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,800);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_23�I���{1249()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(23,1249);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_4�I���{1250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(4,1250);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_7�I���{2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(7,2000);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_8�I���{1500()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(8,1500);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_8�I���{1501()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(8,1501);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_12�I���{2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(12,2000);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_20�I���{1650()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(20,1650);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_24�I���{1651()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(24,1651);

            Assert.AreEqual(100, result);
        }
    }
    public class TaxiFare1_UnitTest
    {
        /// <summary>
        /// (a)�鶡�_�� 1500 ���� 85 ���A��� 250 ���� 5 ��(b) �]���_�� 1250 ���� 85 ���A��� 200 ���� 5 ��
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public int CalcuFare(int startTime, int distance)
        {

            if (distance <= 0) return 0;
            if (startTime >= 20 || startTime < 8)  //�]��
            {
                return CalcuNightFare(distance);
            }
            else  //�鶡
            {
                return CalcuDayFare(distance);
            }
        }
        private static int CalcuNightFare(int distance)
        {
            int basicFee = 85;
            int nightBasicDt = 1250;
            int nightCurrentDt = 200;
            int currentFee = 5;

            if (distance <= nightBasicDt)
            {
                return basicFee;
            }
            else
            {
                double overdist = distance - nightBasicDt;
                int over = Convert.ToInt32(Math.Ceiling(overdist / nightCurrentDt));
                return basicFee + over * currentFee;
            }
        }
        private static int CalcuDayFare(int distance)
        {
            int basicFee = 85;
            int dayBasicDt = 1500;
            int dayCurrentDt = 250;
            int currentFee = 5;

            if (distance <= dayBasicDt)
            {
                return basicFee;
            }
            else
            {
                double overdist = distance - dayBasicDt;
                int over = Convert.ToInt32(Math.Ceiling(overdist / dayCurrentDt));
                return basicFee + over * currentFee;
            }
        }
    }
}