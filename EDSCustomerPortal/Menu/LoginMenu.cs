using EDSCustomerPortal.Services;
using EDSCustomerPortal.Services.IServices;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSCustomerPortal.Menu
{
    public class LoginMenu
    {
        readonly SubscriptionMenuNav subscriptionMenuNav = new SubscriptionMenuNav();

        readonly IAuthenticationService authenticationService = new AuthenticationService();
        public void ViewCustomerData(string id)
        {
            List<string> myvalues = new List<string>
            {
                authenticationService.GetCustomerById(id).FirstName,
                authenticationService.GetCustomerById(id).LastName,
                authenticationService.GetCustomerById(id).EmailAddress,
                authenticationService.GetCustomerById(id).PhoneNumber,
                authenticationService.GetCustomerById(id).MeterNumber,
                authenticationService.GetCustomerById(id).CreatedDateTime.ToString()
            };

            Console.WriteLine();
            Console.WriteLine($"{"First Name", -10} .....");
            //Add formatted Heading....
            foreach (var item in myvalues)
            {
                Console.Write($"{item}  ");
            }
            
            Console.ReadKey();
        }

        public static void UpdatePersonalInfo(string id)
        {
            CustomerService service = new CustomerService();
            var customerDetail = service.GetCustomerById(id);
            //var customerDetail = AuthenticationService.GetCustomerById(id);
            bool inputAnother;

            do
            {
                Console.WriteLine($"What would you like to Update?\n 1. First Name      2. Last Name        3. Email Address        4. Phone Number     5. Password");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.WriteLine("Please enter your new First Name :");
                        customerDetail.FirstName = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "2":
                        Console.WriteLine("Please enter your new Last Name :");
                        customerDetail.LastName = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "3":
                        Console.WriteLine("Please enter your new Email Address :");
                        customerDetail.EmailAddress = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "4":
                        Console.WriteLine("Please enter your new Phone Number :");
                        customerDetail.PhoneNumber = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "5":
                        Console.WriteLine("Please enter your new Password :");
                        customerDetail.Password = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                }

                Console.WriteLine("Would you like to update another information? (Y/N)");
                var continueEditing = Console.ReadLine();

                if (continueEditing.ToLower() == "y")
                {
                    inputAnother = true;
                }
                else
                {
                    inputAnother = false;
                }

            } while (inputAnother);

            //AuthenticationService.UpdateCustomerData(customerDetail);
            service.UpdateCustomer(customerDetail);

            Console.WriteLine("Successful!!!\nLog Out to Effect the Changes....");
            Thread.Sleep(3000);
        }

        public void ViewSubscription(string meterNumber)
        {

            try
            {
                List<string> subcriptionValues = new List<string>
                {
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).MeterNumber,
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).TariffId,
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).PricePerUnit,
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).AmountPaid,
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).NumberOfUnit,
                    authenticationService.ViewCustomerSubscriptionByMeterNumber(meterNumber).DateOfPayment.ToString()
                };

                Console.WriteLine();
                Console.WriteLine($"{"Meter Number",-20} .....");

                //Add formatted Heading....
                foreach (var item in subcriptionValues)
                {
                    Console.Write($"{item}  ");
                }

                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Not Subcribed!!!!\nRedericting....");
                Thread.Sleep(3000);
            }
            
        }

        public void MakeSubscription(string meterId)
        {
            
            try
            {
                subscriptionMenuNav.CalculateElectricityBill(meterId);
                Console.WriteLine($" Validated!!!\n Payment Successfull!!!");
                Thread.Sleep(3000);
            }
            catch (Exception)
            {

                Console.WriteLine("Error!!! Subcription Not Successful.\nRedericting....");
                Thread.Sleep(3000);
            }

        }

        public void CancelSubscription(string meterNumber)
        {
            try
            {
                Console.WriteLine($"Are you sure you want to Cancel Subscription? \nEnter 1. To Continue     2. To Go Back");
                string getInput = Console.ReadLine();
                switch (getInput)
                {
                    case "1":
                        authenticationService.DeleteSubscription(meterNumber);
                        Console.WriteLine("Subscription Cancelled.\nRedirecting....");
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not Subcribed!!!!\nRedericting....");
                Thread.Sleep(3000);

            }
            
           
        }

       
    }
}
