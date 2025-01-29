using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Application.Models.Entities;

public class OperationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OperationId { get; set; }

    public int AccountId { get; set; }

    public double AmountBefore { get; set; }

    public double AmountDifference { get; set; }

    public double AmountAfter { get; set; }
}
