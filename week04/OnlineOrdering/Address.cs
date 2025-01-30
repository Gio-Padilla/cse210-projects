using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private List<string> _usNames = new List<string>
        {
            "usa",
            "united states",
            "america",
            "the united states of america",
            "united states of america",
            "the usa"
        };

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }

    public bool IsInAmerica()
    {
        
        if (_usNames.Contains(_country.ToLower()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}