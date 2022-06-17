using Microsoft.AspNetCore.Mvc;
using MoveService.Models;

[Route("api/[controller]")]
[ApiController]
public class MoveController : ControllerBase
{

    private readonly DataContext context;

    public MoveController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Move>>> Get()
    {
        return Ok(await context.Moves.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Move>>> Get(int id)
    {
        var dbMove = context.Moves.FindAsync(id);
        if (dbMove == null)
            return BadRequest("Move not found");
        return Ok(dbMove);
    }

    [HttpPost]
    public async Task<ActionResult<List<Move>>> AddMove(Move move)
    {
        context.Moves.Add(move);
        await context.SaveChangesAsync();
        return Ok(await context.Moves.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Move>>> UpdateMove(Move req)
    {
        var dbMove = context.Moves.Find(req.Id);
        if (dbMove == null)
            return BadRequest("Move not found");

        dbMove.Name = req.Name;
        dbMove.Damage = req.Damage;
        dbMove.Speed = req.Speed;
        dbMove.Accuracy = req.Accuracy;
        dbMove.MoveType = req.MoveType;

        await context.SaveChangesAsync();
        
        return Ok(await context.Moves.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Move>>> DeleteMove(int id)
    {
        var dbMove = context.Moves.Find(id);
        if (dbMove == null)
            return BadRequest("Move not found");

        context.Moves.Remove(dbMove);
        await context.SaveChangesAsync();
        return Ok(context.Moves.ToListAsync());
    }
}

