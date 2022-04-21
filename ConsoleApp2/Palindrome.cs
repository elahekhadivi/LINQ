using System.Linq;

List<Customer> customers = new List<Customer>()
            {
                new Customer(){ID = Guid.NewGuid(), Age = 23, First = "Joe", Last = "Smith"},
                new Customer(){ID = Guid.NewGuid(), Age = 34, First = "Kevin", Last = "Costner"},
                new Customer(){ID = Guid.NewGuid(), Age = 23, First = "Sally", Last = "Smuthers"},
                new Customer(){ID = Guid.NewGuid(), Age = 56, First = "Mary", Last = "Jane"},
                new Customer(){ID = Guid.NewGuid(), Age = 48, First = "Jane", Last = "Kendall"},
                new Customer(){ID = Guid.NewGuid(), Age = 34, First = "Eve", Last = "Shrimp"},
                new Customer(){ID = Guid.NewGuid(), Age = 31, First = "Donna", Last = "Lynn"},
                new Customer(){ID = Guid.NewGuid(), Age = 21, First = "Sarah", Last = "Spicer"},
            };

List<Order> orders = new List<Order>()
            {
                new Order() {CustomerID = customers[0].ID, Description="Shoes", Price=150.23M, Quantity=1},
                new Order() {CustomerID = customers[0].ID, Description="Phone", Price=130.25M, Quantity=2},
                new Order() {CustomerID = customers[0].ID, Description="Jacket", Price=230.14M, Quantity=1},

                new Order() {CustomerID = customers[1].ID, Description="Phone", Price=130.25M, Quantity=1},
                new Order() {CustomerID = customers[1].ID, Description="Jacket", Price=230.14M, Quantity=2},
                new Order() {CustomerID = customers[1].ID, Description="Pants", Price=70.56M, Quantity=1},

                new Order() {CustomerID = customers[2].ID, Description="Jacket", Price=230.14M, Quantity=1},
                new Order() {CustomerID = customers[2].ID, Description="Pants", Price=70.56M, Quantity=3},
                new Order() {CustomerID = customers[2].ID, Description="Shirt", Price=49.99M, Quantity=1},

                new Order() {CustomerID = customers[3].ID, Description="Pants", Price=70.56M, Quantity=1},
                new Order() {CustomerID = customers[3].ID, Description="Shirt", Price=49.99M, Quantity=2},
                new Order() {CustomerID = customers[3].ID, Description="Scarf", Price=23.69M, Quantity=1},

                new Order() {CustomerID = customers[4].ID, Description="Shirt", Price=49.99M, Quantity=3},
                new Order() {CustomerID = customers[4].ID, Description="Scarf", Price=23.69M, Quantity=1},
                new Order() {CustomerID = customers[4].ID, Description="Car", Price=24200.15M, Quantity=1},

                new Order() {CustomerID = customers[5].ID, Description="Scarf", Price=23.69M, Quantity=2},
                new Order() {CustomerID = customers[5].ID, Description="Car", Price=24200.15M, Quantity=1},
                new Order() {CustomerID = customers[5].ID, Description="Computer", Price=650.00M, Quantity=1},

                new Order() {CustomerID = customers[6].ID, Description="Car", Price=24200.15M, Quantity=1},
                new Order() {CustomerID = customers[6].ID, Description="Computer", Price=650.00M, Quantity=1},
                new Order() {CustomerID = customers[6].ID, Description="Shoes", Price=150.23M, Quantity=1},

                new Order() {CustomerID = customers[7].ID, Description="Computer", Price=650.00M, Quantity=1},
                new Order() {CustomerID = customers[7].ID, Description="Jacket", Price=230.14M, Quantity=1},
                new Order() {CustomerID = customers[7].ID, Description="Pants", Price=70.56M, Quantity=1},

            };



foreach (var customer in customers.OrderBy(c => c.Last))
{
    Console.WriteLine("\n ----------------------- " + customer.First + " " + customer.Last + " ----------------------- ");
    foreach (var order in orders.Where(o => o.CustomerID == customer.ID).OrderByDescending(p => p.Price))
    {
        Console.WriteLine($"{order.Description},{order.Price},{order.Quantity}");
    }
}
Console.WriteLine($"The total number of orders : {orders.Count}");
Console.WriteLine($"The total number of orders $500 and under: {orders.Where(o => o.Price <= 500).Count()}");
Console.WriteLine($"The total number of orders over $500 : {orders.Where(o => o.Price > 500).Count()}");
Console.WriteLine($"The total cost of all orders : {orders.Sum(o => o.Price)}");
Console.WriteLine($"The 3 least expensive products: ");

var sumUnder30 = (from order in orders
             join customer in customers
                  on order.CustomerID equals customer.ID
             where customer.Age <= 30
             select order.Price).Sum();
Console.WriteLine($"Total cost for all orders for people 30 or under : {sumUnder30}");

var sumOver30 = (from order in orders
             join customer in customers
                  on order.CustomerID equals customer.ID
             where customer.Age > 30
             select order.Price).Sum();
Console.WriteLine($"Total cost for all orders for people over 30 : {sumOver30}");

foreach (var order in orders.DistinctBy(o=>o.Price).OrderBy(o => o.Price).Take(3))
{
    Console.WriteLine($"{order.Description} , {order.Price}");
}

Console.WriteLine($"The 3 most expensive products: ");
foreach (var order in orders.DistinctBy(o => o.Price).OrderByDescending(o => o.Price).Take(3))
{
    Console.WriteLine($"{order.Description} , {order.Price}");
}