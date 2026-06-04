using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (Product p in _products)
            total += p.GetTotalCost();

        decimal shipping = _customer.IsInUSA() ? 5.00m : 35.00m;
        return total + shipping;
    }

    

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
        }

        return sb.ToString().TrimEnd();
    }

   
    public string GetShippingLabel()
    {
        string shippingNote;

        if (_customer.IsInUSA())
        {
            shippingNote = "";
        }
        else
        {
            shippingNote = "\n(High international shipping cost applies)";
        }

        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}{shippingNote}";
    }
}