using NUnit.Framework;
using System;

namespace CalcuDayFare_UnitTest
{
    public class Tests
    {        
        [Test]
        public void Test_ń祘计500()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(500);
            Assert.AreEqual(85, result);
        }
        [Test]
        public void Test_ń祘计1500()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(1500);
            Assert.AreEqual(85, result);
        }
        [Test]
        public void Test_ń祘计1501()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(1501);
            Assert.AreEqual(90, result);
        }
        [Test]
        public void Test_ń祘计1750()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(1750);
            Assert.AreEqual(90, result);
        }
        [Test]
        public void Test_ń祘计1751()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(1751);
            Assert.AreEqual(95, result);
        }
        [Test]
        public void Test_ń祘计2100()
        {
            var order = new CalcuDayFare_UnitTest();
            var result = order.CalcuDayFare(2100);
            Assert.AreEqual(100, result);
        }
    }
    public class CalcuDayFare_UnitTest
    {
        /// <summary>
        /// 耞琌ら丁癬铬 1500 そへ 85 じ尿铬 250 そへ 5 じ
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public int CalcuDayFare(int distance)
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