using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Application.Models.Entities;

public class AccountEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public int UserId { get; set; }

    public string? PinCode { get; set; }

    public double Balance { get; set; }

    public UserEntity? User { get; set; } = null;
}