using System.ComponentModel.DataAnnotations;

namespace webapiEfPuppies.Api.Models;

public class Puppy
{
    [Key]public int Id { get; set; }
    public string? Name { get; set; }
    public string? Breed { get; set; }
    public DateTime? BirthDate { get; set; }
}

// /projects/pgp/pgp-webapi-puppies/webapiEfPuppies.Api