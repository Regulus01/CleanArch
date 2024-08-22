namespace CleanArchMvc.Domain.Entities;

public class Category
{
    // um modelo anemico é quando a classe não tem validações, contrutores parametrizado etc. Um exemplo é um dto
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Propriedade de navegação
    public ICollection<Product> Products { get; set; }
}