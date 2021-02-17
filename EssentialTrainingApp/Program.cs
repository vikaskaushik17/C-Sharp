using System;
using System.Collections.Generic;

namespace EssentialTrainingApp
{
    public class Program
    {
        static void Main(string[] args)
        {


            List<string> list;

            Apartment manager = new Apartment();

            int noOfObject = int.Parse(Console.ReadLine());
            for (int i = 0; i < noOfObject; i++)
            {
                int flatNo = int.Parse(Console.ReadLine());
                int flatSize = int.Parse(Console.ReadLine());
                string ownerName = Console.ReadLine();
                string status = Console.ReadLine();
                int noOfPeople = int.Parse(Console.ReadLine());
                manager.residents.Add(new Resident(flatNo, flatSize, ownerName, status, noOfPeople));
            }

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {

                list = manager.FindStatusWiseTotalNoOfPeople();

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }

            }
            else if (choice == 2)
            {

                int flatNoChoice = int.Parse(Console.ReadLine());
                Resident res = manager.FindResidentByFlatNo(flatNoChoice);
                string owner = res.GetOwnerName();
                if (owner.Length > 0)
                {
                    Console.WriteLine(owner + "," + res.GetNoPeople());
                }
                else
                {
                    Console.Write("No resident found");
                }

            }

        }
    }



    //********************************************************
    public class Resident
    {
        private int flatNo;
        private int flatSize;
        private string ownerName;
        private string status;
        private int noOfPeople;

        public Resident(int flatNo, int flatSize, string ownerName, string status, int noOfPeople)
        {
            this.flatNo = flatNo;
            this.flatSize = flatSize;
            this.ownerName = ownerName;
            this.status = status;
            this.noOfPeople = noOfPeople;
        }

        public int GetFlatNo()
        {
            return flatNo;
        }

        public int GetFlatSize()
        {
            return flatSize;
        }

        public string GetOwnerName()
        {
            return ownerName;
        }
        public string GetStatus()
        {
            return status;
        }

        public int GetNoPeople()
        {
            return noOfPeople;
        }


    }

    //*******************************************************

    public class Apartment
    {

        public List<Resident> residents { get; set; }
        public Apartment()
        {
            residents = new List<Resident>();
        }
        int flag = 1;

        public List<string> FindStatusWiseTotalNoOfPeople()
        {
            string owner = " ", tenant = "", check = "";
            int countOwner = 0, countTenant = 0;
            for (int i = 0; i < residents.Count; i++)
            {

                check = residents[i].GetStatus();

                check = check.ToLower();

                if (check == "owner")
                {
                    countOwner += residents[i].GetNoPeople();

                }
                else if (check == "tenant")
                {
                    countTenant += residents[i].GetNoPeople();

                }
                else
                {
                    flag = 0;
                }
            }

            List<string> output = new List<string>();

            if (flag == 1)
            {
                owner = "Owner#" + countOwner;
                tenant = "Tenant#" + countTenant;

                if (countOwner < countTenant)
                {
                    output.Add(owner);
                    output.Add(tenant);
                }
                else
                {
                    output.Add(tenant);
                    output.Add(owner);
                }
            }
            else
            {
                output.Add("Invalid Data");
            }

            return output;

        }

        public Resident FindResidentByFlatNo(int flat)
        {
            int number = 0;
            int get = -1;
            for (int i = 0; i < residents.Count; i++)
            {

                number = residents[i].GetFlatNo();

                if (flat == number)
                {
                    get = i;
                    break;
                }

            }
            return residents[get];

        }

    }

}

    





