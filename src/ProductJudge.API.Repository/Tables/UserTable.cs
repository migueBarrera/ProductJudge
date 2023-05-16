using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductJudge.API.Repository.Tables;

[Table("Users")]
public class UserTable
{
    [Key]
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Pass { get; set; } = string.Empty;
}
