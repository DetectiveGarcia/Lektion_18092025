namespace Infrastructure.Models;

public class ProductResult
{
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
    //public Product? Content { get; set; }

}


//Nu har ProductResult<T> alla egenskaper from ProductResult plus public T? Content { get; set; } o på så sätt UTÖKA
public class ProductResult<T> : ProductResult
{
    public T? Content { get; set; }
}
