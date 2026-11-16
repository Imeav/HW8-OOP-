using System;

interface IDiscountable
{
    void ApplyDiscount(string discount);
}

interface IPromocodeApplicable
{
    void ApplyPromocode(string promocode);
}

interface IColorable
{
    void SetColor(byte color);
}

interface ISizable
{
    void SetSize(byte size);
}

interface IPriceable
{
    void SetPrice(double price);
}

class Book : IPriceable, IDiscountable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
    }

    public void ApplyDiscount(string discount)
    {
        Discount = discount;
    }
}

class Outerwear : IPriceable, IDiscountable, IColorable, ISizable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }
    public byte Color { get; private set; }
    public byte Size { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
    }

    public void ApplyDiscount(string discount)
    {
        Discount = discount;
    }

    public void SetColor(byte color)
    {
        Color = color;
    }

    public void SetSize(byte size)
    {
        Size = size;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(350.0);
        book.ApplyDiscount("10%");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(1800.0);
        jacket.ApplyDiscount("15%");
        jacket.SetColor(1);
        jacket.SetSize(48);

        Console.WriteLine("Book: price = " + book.Price +
                          ", discount = " + book.Discount);
        Console.WriteLine("Outerwear: price = " + jacket.Price +
                          ", discount = " + jacket.Discount +
                          ", color = " + jacket.Color +
                          ", size = " + jacket.Size);

    }
}

