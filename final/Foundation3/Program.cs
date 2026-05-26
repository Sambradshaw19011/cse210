using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        Address lectureAddress = new Address("525 S Center Street", "Rexburg", "Idaho", "USA");
        Lecture lecture = new Lecture(
            "Career Success Night",
            "A lecture about preparing for internships and future careers.",
            "June 10, 2026",
            "6:00 PM",
            lectureAddress,
            "Dr. James Wilson",
            150
        );

        Address receptionAddress = new Address("1200 College Avenue", "Provo", "Utah", "USA");
        Reception reception = new Reception(
            "Alumni Networking Reception",
            "An evening for students and alumni to meet and build professional connections.",
            "July 18, 2026",
            "7:30 PM",
            receptionAddress,
            "rsvp@eventplanning.com"
        );

        Address outdoorAddress = new Address("80 River Park Drive", "Idaho Falls", "Idaho", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Community Summer Picnic",
            "A family-friendly picnic with food, games, and live music.",
            "August 5, 2026",
            "12:00 PM",
            outdoorAddress,
            "Sunny with a high of 78 degrees"
        );

        events.Add(lecture);
        events.Add(reception);
        events.Add(outdoorGathering);

        foreach (Event eventItem in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(eventItem.GetStandardDetails());

            Console.WriteLine("\nFull Details:");
            Console.WriteLine(eventItem.GetFullDetails());

            Console.WriteLine("\nShort Description:");
            Console.WriteLine(eventItem.GetShortDescription());

            Console.WriteLine("\n-----------------------------\n");
        }
    }
}