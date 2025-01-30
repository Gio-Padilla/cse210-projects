using System;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float GetTotalCost()
    {
        float totalCost = GetShippingCost();

        foreach(Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        return totalCost;
    }

    public string GetPackingString()
    {
        string packingString = "";
        foreach(Product product in _products)
        {
            packingString += product.GetPackingString();
            packingString += "\n";
        }
        packingString = packingString.TrimEnd('\n');
        
        return packingString;
    }

    public string GetShippingString()
    {
        string shippingString = _customer.GetName();
        shippingString += "\n";
        shippingString += _customer.GetAddress();
        return shippingString;
    }

    public int GetShippingCost()
    {
        int shippingCost;
        if (_customer.IsInAmerica() == true)
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }
        return shippingCost;
    }


}