﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace HubServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://*:8082";

            using (WebApplication.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // This will map out to http://localhost:8080/signalr by default
            app.MapHubs();
        }
    }

    public class Chat : Hub
    {
        public void Send(string message)
        {
            // Call the addMessage method on all clients            
            Clients.All.addMessage(message);
        }

        public string Send2(string message)
        {
            Thread.Sleep(5000);
            return message;
        }

        public object Send3(string message)
        {

            return new { Name = message, Age = 10 };
        }

    }

    public class Calculator : Hub
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public string GetName()
        {
            return "Erik";
        }
        public string Mix(int i, string s)
        {
            return s + i.ToString();
        }
    }
}
