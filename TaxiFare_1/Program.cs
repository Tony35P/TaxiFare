using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//(a)日間起跳 1500 公尺 85 元，續跳 250 公尺 5 元
//(b) 夜間起跳 1250 公尺 85 元，續跳 200 公尺 5 元
namespace _TaxiFare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startTime = DateTime.Now.Hour;

            Console.WriteLine("請輸入里程數");
            int travelledDistance = Convert.ToInt32(Console.ReadLine());

            int result = CalcuFare(travelledDistance, startTime);

            Console.WriteLine("車費: " + result);

        }
        static int CalcuFare(int distance, int startTime)
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