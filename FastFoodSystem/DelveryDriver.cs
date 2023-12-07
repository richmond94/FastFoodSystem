using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSystem
{
    public class DeliveryDriver : Person
    {
        private static int counter = 0;
        public int DriverID { get; private set; }
        public string DriverVehicle { get; private set; }

        public DeliveryDriver()
        {
            GetDriverID();
            GetDriverVehicle();
        }

        public DeliveryDriver(int driverID, string driverVehicle)
        {
            DriverID = driverID;
            DriverVehicle = driverVehicle;
        }

        private void GetDriverID()
        {
            DriverID = System.Threading.Interlocked.Increment(ref counter);
        }

        public void GetDriverVehicle()
        {
            Console.WriteLine("Vehicle Type:");
            DriverVehicle = Console.ReadLine();
        }

        public new void DisplayUser()
        {
            Console.WriteLine($"Driver ID: {DriverID}\nName: {name}\nVehicle Type: {DriverVehicle}\nNumber: {contactNumber}\n");
        }

        public string GetDriverName()
        {
            return name;
        }
    }
}
