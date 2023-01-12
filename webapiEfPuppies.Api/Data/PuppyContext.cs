using Microsoft.EntityFrameworkCore;
using webapiEfPuppies.Api.Models;

namespace webapiEfPuppies.Api.Data;

public class PuppyContext: DbContext
{
    public PuppyContext (DbContextOptions<PuppyContext> options)
        : base(options)
    {
    }
    public DbSet<Puppy>Puppy { get; set; }
        
}
