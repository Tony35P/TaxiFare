using NUnit.Framework;
using System;

namespace CalcuNightFare_UnitTest
{
    public class Tests
    {
        
        [Test]
        public void Test_���{��500()
        {
            var order = new CalcuNightFare_UnitTest();
            var result = order.CalcuNightFare(500);
            Assert.AreEqual(85, result);
        }
        [Test]
        public void Test_���{��1250()
        {
            var order = new CalcuNightFare_UnitTest();
            int result = order.CalcuNightFare(1250);
            Assert.AreEqual(85, result);
        }
        [Test]
        public void Test_���{��1251()
        {
            var order = new CalcuNightFare_UnitTest();
            int result = order.CalcuNightFare(1251);
            Assert.AreEqual(90, result);
        }
        [Test]
        public void Test_���{��1450()
        {
            var order = new CalcuNightFare_UnitTest();
            int result = order.CalcuNightFare(1450);
            Assert.AreEqual(90, result);
        }
        [Test]
        public void Test_���{��1451()
        {
            var order = new CalcuNightFare_UnitTest();
            int result = order.CalcuNightFare(1451);
            Assert.AreEqual(95, result);
        }
        [Test]
        public void Test_���{��2000()
        {
            var order = new CalcuNightFare_UnitTest();
            int result = order.CalcuNightFare(2000);
            Assert.AreEqual(105, result);
        }
        
    }
    public class CalcuNightFare_UnitTest
    {
        /// <summary>
        /// �w�P�_�O�]���A�_�� 1250 ���� 85 ���A��� 200 ���� 5 ��
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public int CalcuNightFare(int distance)
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
    }
}