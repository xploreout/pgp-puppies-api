using Microsoft.AspNetCore.Mvc;
using webapiEfPuppies.Api.Data;
using webapiEfPuppies.Api.Models;

namespace webapiEfPuppies.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PuppiesController : ControllerBase
{
    private PuppyContext _context;

    public PuppiesController(PuppyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ICollection<Puppy> GetPuppies()
    {
        var puppies = _context.Puppy.ToList();
        return puppies;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetPuppy(int id)
    {
        var puppy = _context.Puppy.FirstOrDefault(p=> p.Id == id);
        if (puppy == null)
        {
            return BadRequest($"Puppy with id '{id}' not found");
        }
        
        return Ok(puppy);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePuppy(int id)
    {
        var puppy = _context.Puppy.FirstOrDefault(p=> p.Id == id);
        if (puppy == null)
        {
            return BadRequest($"Puppy with id '{id}' not found");
        }

        _context.Puppy.Remove(puppy);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddPuppy([FromBody] PuppyDto puppyDto)
    {
        var puppy = new Puppy
        {
            Name = puppyDto.Name,
            Breed = puppyDto.Breed,
            BirthDate = puppyDto.BirthDate
        };
        
        _context.Puppy.Add(puppy);
         await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPuppy), new { Id = puppy.Id }, puppy);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdatePuppy([FromRoute] int id, [FromBody] PuppyDto puppyDto)
    {
        var puppy = await _context.Puppy.FindAsync(id);
        if (puppy ==  null)
        {
            return BadRequest($"Puppy with id '{id}' not found.");
        }

        puppy.Name = puppyDto.Name;
        puppy.Breed = puppyDto.Breed;
        puppy.BirthDate = puppyDto.BirthDate;

        await _context.SaveChangesAsync();
        return Ok(puppy);
    }
    
}




