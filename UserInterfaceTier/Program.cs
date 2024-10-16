using ApplicationTier.Classes;

//Console.WriteLine("Please enter your customer firstname?");

//string firstname = Console.ReadLine();
//Console.WriteLine("Please enter your customer lastname?");

//string lastname = Console.ReadLine();

//DateTime? dateOfBirth = DateTime.Now.AddYears(-20);


var customerMethods = new CustomerMethods();


//var customer = await customerMethods.AddCustomer(firstname, lastname, dateOfBirth);


//Console.WriteLine($"Your customer has been added. Customer name is {customer.FullName}, Id is {customer.Id}");


Console.WriteLine("please enter your customer id which one you want to delete ?");
int cId = Convert.ToInt32(Console.ReadLine());

var customerId = await customerMethods.RemoveCustomer(cId);


