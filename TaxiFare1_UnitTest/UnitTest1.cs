using NUnit.Framework;
using System;

namespace _TaxiFare1_UnitTest
{
    public class Tests
    {
        [Test]
        public void CalcuFare_白天里程2250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(2250, 9);

            Assert.AreEqual(100, result);
        }
        [Test]
        public void CalcuFare_白天里程2251()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(2251, 9);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_晚上里程1450()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1450, 21);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_晚上里程1451()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1451, 21);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_里程0()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(0, 21);

            Assert.AreEqual(0, result);
        }
        [Test]
        public void CalcuFare_里程為負()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(-20, 21);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalcuFare_晚上里程800()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(800, 21);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_23點里程1249()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1249, 23);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_4點里程1250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1250, 4);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_7點里程2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(2000, 4);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_8點里程1500()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1500, 8);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_8點里程1501()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1501, 8);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_12點里程2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(2000, 12);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_20點里程1650()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1650, 20);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_24點里程1651()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(1651, 24);

            Assert.AreEqual(100, result);
        }
    }
    public class TaxiFare1_UnitTest
    {
        /// <summary>
        /// (a)日間起跳 1500 公尺 85 元，續跳 250 公尺 5 元(b) 夜間起跳 1250 公尺 85 元，續跳 200 公尺 5 元
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public int CalcuFare(int distance, int startTime)
        {
            int basicFee = 85;
            int dayBasicDt = 1500;
            int dayCurrentDt = 250;
            int nightBasicDt = 1250;
            int nightCurrentDt = 200;
            int currentFee = 5;


            if (distance <= 0) return 0;
            if (startTime >= 20 || startTime < 8)  //夜間
            {
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
            else  //日間
            {
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
}