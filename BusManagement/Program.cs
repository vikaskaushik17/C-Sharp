using System;
using System.Collections.Generic;
using System.Linq;

namespace BusManagement
{
    class Program
    {
        static void Main(String[] args)
        {

            BusManagement manager = new BusManagement();

            int buses = int.Parse(Console.ReadLine());

            for (int i = 0; i < buses; i++)
            {

                int BusNumber = int.Parse(Console.ReadLine());
                string BusState = Console.ReadLine();
                string BusType = Console.ReadLine();
                int BusTicketPrice = int.Parse(Console.ReadLine());

                manager.buses.Add(new Bus(BusNumber, BusState, BusType, BusTicketPrice));

            }

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string location = Console.ReadLine();
                List<Bus> listBus = manager.FindBus(location);

                if (listBus.Count > 0)
                {

                    for (int i = 0; i < listBus.Count; i++)
                    {
                        Bus bus = listBus[i];

                        Console.WriteLine(bus.GetBusNumber() + ":" + bus.GetBusType() + "," + bus.GetBusTicketPrice());
                    }

                }
                else
                {
                    Console.WriteLine("No bus found with given state");
                }

            }
            else if (choice == 2)
            {
                int input = int.Parse(Console.ReadLine());
                List<Bus> afterDisc = manager.Discount(input);

                if (afterDisc.Count > 0)
                {

                    for (int i = 0; i < afterDisc.Count; i++)
                    {
                        Bus bus = afterDisc[i];

                        Console.WriteLine(bus.GetBusNumber() + ":" + bus.GetBusType() + "," + bus.GetBusTicketPrice());
                    }

                }
            }


        }
    }

    class Bus
    {
        private int BusNumber;
        private string BusState;
        private string BusType;
        private int BusTicketPrice;

        public Bus(int BusNumber, string BusState, string BusType, int BusTicketPrice)
        {

            this.BusNumber = BusNumber;
            this.BusState = BusState;
            this.BusType = BusType;
            this.BusTicketPrice = BusTicketPrice;

        }

        public int GetBusNumber()
        {
            return BusNumber;
        }

        public string GetBusState()
        {
            return BusState;
        }
        public string GetBusType()
        {
            return BusType;
        }
        public int GetBusTicketPrice()
        {
            return BusTicketPrice;
        }

        public void Discount(int value)
        {
            int num = 100 - value;

            double price = (this.BusTicketPrice * num) / 100;
            this.BusTicketPrice = (int) Math.Round(price, MidpointRounding.AwayFromZero);
            
        }
    }

    class BusManagement
    {
        public List<Bus> buses { get; }

        public BusManagement()
        {
            buses = new List<Bus>();
        }

        public List<Bus> FindBus(string state)
        {
            List<Bus> list = new List<Bus>();
            state = state.ToLower();
            string check = "";

            for (int i = 0; i < buses.Count; i++)
            {
                check = buses[i].GetBusState().ToLower();

                if (check.Equals(state))
                {
                    list.Add(buses[i]);
                }
            }

            List<Bus> sorted = list.OrderBy(o => o.GetBusNumber()).ToList();
            return sorted;
        }

        public List<Bus> Discount(int disc)
        {
            List<Bus> list = new List<Bus>();
            string busT = "public", ListBusT = "";
            int total = 0;
            for (int i = 0; i < buses.Count; i++)
            {

                ListBusT = buses[i].GetBusType().ToLower();
                if (ListBusT.Equals(busT))
                {
                    total = disc + 5;
                    buses[i].Discount(total);
                    list.Add(buses[i]);
                }
                else
                {
                    buses[i].Discount(disc);
                    list.Add(buses[i]);
                }

            }
            
            List<Bus> sorted = list.OrderBy(o => o.GetBusNumber()).ToList();

            return sorted;
        }
    }

}
