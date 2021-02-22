using System;
using System.Collections.Generic;
using System.Linq;

namespace Militant_Rank_Management
{
    class Program { 
    public static void Main(String[] args)
    {

        int id = 1000;
        RankManagement manager = new RankManagement();
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            id++;
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int pay = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            manager.RankList.Add(new Rank(id, name, age, pay, type));

        }

        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            string Input = Console.ReadLine();
            string outFirst = manager.FindAvg(Input);
            Console.Write(outFirst);
        }
        else if (choice == 2)
        {
            Dictionary<string, string> dict = manager.FindType();

            if (dict.ContainsValue("Honorary Rank"))
            {
                foreach (KeyValuePair<string, string> kv in dict.OrderBy(o => o.Key))
                {
                    Console.WriteLine(kv.Key + "::" + kv.Value);
                }
            }
            else
            {
                Console.Write("Only Junior Officers are available in the list");
            }

        }

    }
}

class Rank
{
    public int RankId { get; set; }
    public string RankName { get; set; }
    public int RetirementAge { get; set; }
    public int RankPay { get; set; }
    public string RankType { get; set; }

    public Rank(int id, string name, int age, int pay, string type)
    {
        RankId = id;
        RankName = name;
        RetirementAge = age;
        RankPay = pay;
        RankType = type;
    }
}


class RankManagement
{
    public List<Rank> RankList { get; }

    public RankManagement()
    {
        RankList = new List<Rank>();
    }

    public string FindAvg(string type)
    {
        string save = type;
        string check = "";
        type = type.ToLower();
        int sum = 0, count = 0, avg = 0;
        for (int i = 0; i < RankList.Count; i++)
        {

            check = RankList[i].RankType;
            check = check.ToLower();
            if (check.Equals(type))
            {
                count++;
                sum = sum + RankList[i].RetirementAge;
            }

        }

        if (count > 0)
        {
            avg = sum / count;
            return save + "-" + avg;
        }
        else
        {
            return "No Ranks are found for the given RankType";
        }
    }

    public Dictionary<string, string> FindType()
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        for (int i = 0; i < RankList.Count; i++)
        {
            Rank r = RankList[i];

            if (r.RankType.Equals("Commissioned Officers") || r.RankType.Equals("Junior Commissioned Officers"))
            {
                list.Add(r.RankName, "Honorary Rank");
            }
            else
            {
                list.Add(r.RankName, "Non Commissioned Officers");
            }
        }

        return list;
    }
}






}