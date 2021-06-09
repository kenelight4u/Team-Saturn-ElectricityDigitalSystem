using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.AgentMenu.AgentLogInMenu.CustomerPortfolio
{
    public class CustomerPortMenuNav
    {

        public void CustomerPortPageMenuNav(string registeringAgent)
        {
            CustomerPortMenu customerPortMenu = new CustomerPortMenu();

            bool inLoginPage = true;

            while (inLoginPage)
            {
                Console.Clear();
                Console.WriteLine("Welcome To AGENT CUSTOMER'S PAGE.");
                Console.WriteLine("Choose an Option : \n1. Register A Customer \n2. View Customer Details  \n3. View All Registered Customer \n4. Update Customers Information  \n5. Make Subscription  \n6. Cancel Subscription  \n7. View Subscription  \n8. Go Back To LogIn Page");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        customerPortMenu.RegisterCustomer(registeringAgent);
                        break;
                    case "2":
                        customerPortMenu.ViewCustomerInfo();
                        break;
                    case "3":
                        customerPortMenu.ViewAllRegisteredCustomer();
                        break;
                    case "4":
                        customerPortMenu.UpdatePersonalInfo();
                        break;
                    case "5":
                        customerPortMenu.MakeSubscription();
                        break;
                    case "6":
                        customerPortMenu.CancelSubscription();
                        break;
                    case "7":
                        customerPortMenu.ViewSubcription();
                        break;
                    case "8":
                        inLoginPage = false;
                        break;
                }


            }

        }
    }
}
