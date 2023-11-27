using System;
using System.Collections.Generic;

class ParkingSystem
{
    // Dictionary to store receipts for each garage
    private Dictionary<int, double> garageReceipts = new Dictionary<int, double>
    {
        { 1, 0.0 },
        { 2, 0.0 },
        { 3, 0.0 }
    };

    // Method to calculate charges for a given garage and duration
    private double CalculateCharges(int garageNumber, int hoursParked)
    {
        double charge = 0.0;
        double perHourRate = 0.0;

        switch (garageNumber)
        {
            case 1:
                perHourRate = 0.50;
                break;
            case 2:
                perHourRate = 0.60;
                break;
            case 3:
                perHourRate = 0.75;
                break;
            default:
                break;
        }

        if (hoursParked <= 3)
        {
            charge = 2.00;
        }
        else
        {
            charge = 2.00 + perHourRate * (hoursParked - 3);
        }

        // Check if the charge exceeds the maximum daily charge
        if (charge > 10.00)
        {
            charge = 10.00;
        }

        return charge;
    }

    public void CalculateAndDisplayCharges(int garageNumber, int hoursParked, string customerRegistration)
    {
        double charge = CalculateCharges(garageNumber, hoursParked);
        Console.WriteLine($"Customer {customerRegistration} parked for {hoursParked} hours in Garage {garageNumber}. Charge: €{charge:F2}");

        // Update garage receipts
        garageReceipts[garageNumber] += charge;
    }

    public void DisplayGarageReceipts()
    {
        Console.WriteLine("\nYesterday's Receipts:");
        foreach (var garage in garageReceipts)
        {
            Console.WriteLine($"Garage {garage.Key}: €{garage.Value:F2}");
        }

        // Calculate total receipts
        double totalReceipts = garageReceipts[1] + garageReceipts[2] + garageReceipts[3];
        Console.WriteLine($"Total Receipts: €{totalReceipts:F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ParkingSystem parkingSystem = new ParkingSystem();

        // Simulating customer parking (You can replace these with actual customer details)
        parkingSystem.CalculateAndDisplayCharges(1, 5, "ABC123");
        parkingSystem.CalculateAndDisplayCharges(2, 2, "XYZ789");
        parkingSystem.CalculateAndDisplayCharges(3, 8, "DEF456");

        // Display garage receipts
        parkingSystem.DisplayGarageReceipts();
    }
}
