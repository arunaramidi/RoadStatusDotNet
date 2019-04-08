using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatusDotNet
{

    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                ConsumeRoadStatus objAsync = new ConsumeRoadStatus();
                objAsync.GetValidRoad(args[0]);
            }
           else
               Console.WriteLine("Invalid request parameters");

        }
    }

}
