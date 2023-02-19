using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoDotNetExpert.Models;

public class Filme
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Título é obrigatório.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo Titulo deve ter entre 3 e 60 caracteres.")]
    public string Titulo { get; set; }
    
    [DataType(DataType.DateTime, ErrorMessage = "Data em formado incorreto.")]
    [Required(ErrorMessage = "Campo DataDeLancamento é obrigatório.")]
    [Display(Name = "Data de Lançamento")] //nome a ser exibido
    public DateTime DataDeLancamento { get; set; }
    
    [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Gênero em formato inválido.")]
    [StringLength(30, ErrorMessage = "Máximo de 30 caracteres.") , Required(ErrorMessage = "O campo Gênero é obrigatório.")]
    public string Genero { get; set; }
    
    [Range(1, 1000, ErrorMessage = "Valor de 1 a 1000.")]
    [Required(ErrorMessage = "Preencha o campo Valor.")]
    [Column(TypeName = "decimal(18,2)")] // expressa como será a coluna do banco de dados
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Preencha o campo Avaliação.")]
    [Display(Name = "Avaliação")]
    [RegularExpression(@"^[0-5]*", ErrorMessage = "Somente números.")]
    public int Avaliacao { get; set; }
}