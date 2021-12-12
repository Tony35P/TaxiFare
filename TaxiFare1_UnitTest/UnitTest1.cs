using NUnit.Framework;
using System;

namespace CalcuFare_UnitTest
{
    public class Tests
    {
        [Test]
        public void CalcuFare_白天里程2250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(9,2250);

            Assert.AreEqual(100, result);
        }
        [Test]
        public void CalcuFare_白天里程2251()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(9,2251);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_晚上里程1450()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,1450);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_晚上里程1451()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,1451);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_里程0()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,0);

            Assert.AreEqual(0, result);
        }
        [Test]
        public void CalcuFare_里程為負()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,-20);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalcuFare_晚上里程800()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(21,800);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_23點里程1249()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(23,1249);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_4點里程1250()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(4,1250);

            Assert.AreEqual(85, result);
        }

        [Test]
        public void CalcuFare_7點里程2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(7,2000);

            Assert.AreEqual(105, result);
        }
        [Test]
        public void CalcuFare_8點里程1500()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(8,1500);

            Assert.AreEqual(85, result);
        }
        [Test]
        public void CalcuFare_8點里程1501()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(8,1501);

            Assert.AreEqual(90, result);
        }
        [Test]
        public void CalcuFare_12點里程2000()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(12,2000);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_20點里程1650()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(20,1650);

            Assert.AreEqual(95, result);
        }
        [Test]
        public void CalcuFare_24點里程1651()
        {
            var order = new TaxiFare1_UnitTest();
            var result = order.CalcuFare(24,1651);

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
        public int CalcuFare(int startTime, int distance)
        {

            if (distance <= 0) return 0;
            if (startTime >= 20 || startTime < 8)  //夜間
            {
                return CalcuNightFare(distance);
            }
            else  //日間
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