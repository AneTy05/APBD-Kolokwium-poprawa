namespace Kolokwium_poprawa.Models;

// [Table("Nazwa_tabeli")]
public class Template
{
    /*
    Przydatne dokoratory: [Key], [MaxLength(100)], [Required], [Column(TypeName = "decimal")]
    [Precision(10, 2)], [ForeignKey(nameof(Nazwa_kolumny_innej_tabeli_w_której jest klucz_główny], 
    [PrimaryKey(nameof(AvailableProgramId), nameof(CustomerId))]
    
    Przykładowe typy danych
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } - atrybut opcjonalny
    public float MaxWeight { get; set; }

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    
    W tabeli asocjacyjnej:
    [ForeignKey(nameof(ProgramId))]
    public WashProgram WashProgram { get; set; }
    [ForeignKey(nameof(WashinMachineId))]
    public WashingMachine WashingMachine { get; set; }
    
    
     */
}