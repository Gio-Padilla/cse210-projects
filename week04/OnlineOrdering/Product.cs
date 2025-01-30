using System;
using System.Data.Common;

public class Product
{
    private string _name;
    private int _id;
    private float _price;
    private int _quantity;
    private float _totalPrice;
    
    public Product(string name, int id, float price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
        _totalPrice = _price * _quantity;
    }

    public float GetTotalCost()
    {
        return _totalPrice;
    }

    public string GetPackingString()
    {
        return $"{_name} X {_quantity} = ${_totalPrice:f2} - ID:{_id}";
    }
}