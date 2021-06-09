//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EDSAgentPortal.AgentMenu.AgentLogInMenu.CustomerPortfolio
//{
//    public class CustomerPortMenu
//    {
//        public void ViewCustomerData(string id)
//        {
//            Console.WriteLine();
//            Console.WriteLine($"{"Full Name",-20} : {authenticationService.GetCustomerById(id).FirstName} {authenticationService.GetCustomerById(id).LastName}");
//            Console.WriteLine($"{"Email Address",-20} : {authenticationService.GetCustomerById(id).EmailAddress} ");
//            Console.WriteLine($"{"Phone Number",-20} : {authenticationService.GetCustomerById(id).PhoneNumber} ");
//            Console.WriteLine($"{"Meter Number",-20} : {authenticationService.GetCustomerById(id).MeterNumber} ");
//            Console.WriteLine($"{"Created Date Time",-20} : {authenticationService.GetCustomerById(id).CreatedDateTime} ");
//            Console.WriteLine($"{"Modified Date Time",-20} : {authenticationService.GetCustomerById(id).ModifiedDateTime} ");

//            Console.ReadKey();
//        }

//        public static void UpdatePersonalInfo(string id)
//        {
//            CustomerService service = new CustomerService();
//            var customerDetail = service.GetCustomerById(id);
//            //var customerDetail = AuthenticationService.GetCustomerById(id);
//            bool inputAnother;

//            do
//            {
//                Console.WriteLine($"What would you like to Update?\n 1. First Name      2. Last Name        3. Email Address        4. Phone Number     5. Password");
//                string response = Console.ReadLine();

//                switch (response)
//                {
//                    case "1":
//                        Console.WriteLine("Please enter your new First Name :");
//                        customerDetail.FirstName = Console.ReadLine();
//                        customerDetail.ModifiedDateTime = DateTime.Now;
//                        break;
//                    case "2":
//                        Console.WriteLine("Please enter your new Last Name :");
//                        customerDetail.LastName = Console.ReadLine();
//                        customerDetail.ModifiedDateTime = DateTime.Now;
//                        break;
//                    case "3":
//                        Console.WriteLine("Please enter your new Email Address :");
//                        customerDetail.EmailAddress = Console.ReadLine();
//                        customerDetail.ModifiedDateTime = DateTime.Now;
//                        break;
//                    case "4":
//                        Console.WriteLine("Please enter your new Phone Number :");
//                        customerDetail.PhoneNumber = Console.ReadLine();
//                        customerDetail.ModifiedDateTime = DateTime.Now;
//                        break;
//                    case "5":
//                        Console.WriteLine("Please enter your new Password :");
//                        customerDetail.Password = Console.ReadLine();
//                        customerDetail.ModifiedDateTime = DateTime.Now;
//                        break;
//                }

//                Console.WriteLine("Would you like to update another information? (Y/N)");
//                var continueEditing = Console.ReadLine();

//                if (continueEditing.ToLower() == "y")
//                {
//                    inputAnother = true;
//                }
//                else
//                {
//                    inputAnother = false;
//                }

//            } while (inputAnother);

//            //AuthenticationService.UpdateCustomerData(customerDetail);
//            service.UpdateCustomer(customerDetail);

//            Console.WriteLine("Successful!!!\nLog Out to Effect the Changes....");
//            Thread.Sleep(3000);
//        }
//    }
//}
