/*
Use Copilot to improve code coverage. Ensure that the OrderProcessor class is structured in a way that makes it easier to test all possible branches and exceptions. This can be achieved by refactoring the code to separate concerns and reduce complexity.
*/
using System;

public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        if (order.Items == null || order.Items.Count == 0)
        {
            throw new InvalidOperationException("Order must have at least one item.");
        }

        foreach (var item in order.Items)
        {
            if (item.Quantity <= 0)
            {
                throw new InvalidOperationException("Item quantity must be greater than zero.");
            }

            // Complex logic with multiple nested conditions
            if (item.ProductId == 0)
            {
                if (item.Price > 100)
                {
                    // Some complex business logic
                    Console.WriteLine("High value item with no product ID.");
                }
                else
                {
                    // Another complex business logic
                    Console.WriteLine("Low value item with no product ID.");
                }
            }
            else
            {
                if (item.Price > 100)
                {
                    // Some complex business logic
                    Console.WriteLine("High value item with product ID.");
                }
                else
                {
                    // Another complex business logic
                    Console.WriteLine("Low value item with product ID.");
                }
            }
        }

        // More complex logic
        if (order.Customer == null)
        {
            throw new InvalidOperationException("Order must have a customer.");
        }

        // Process payment
        ProcessPayment(order);
    }

    private void ProcessPayment(Order order)
    {
        // Payment processing logic
        Console.WriteLine("Processing payment for order.");
    }
}

public class Order
{
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; }
}

public class Customer
{
    public string Name { get; set; }
}

public class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}