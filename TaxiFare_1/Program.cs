using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//(a)日間起跳 1500 公尺 85 元，續跳 250 公尺 5 元
//(b) 夜間起跳 1250 公尺 85 元，續跳 200 公尺 5 元
namespace TaxiFare_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new TaxiFareService();
            int startTime = DateTime.Now.Hour;

            Console.WriteLine("請輸入里程數");
            int travelledDistance = Convert.ToInt32(Console.ReadLine());

            int result = service.CalcuFare(startTime, travelledDistance);
            Console.WriteLine("車費: " + result);

        }   
    }
    public class TaxiFareService
    {
        public int CalcuFare(int startTime, int distance)
        {

            if (distance <= 0) return 0;
            if (startTime >= 20 || startTime < 8)  
            {
                return CalcuNightFare(distance);
            }
            else  
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
