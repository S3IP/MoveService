using Microsoft.AspNetCore.Mvc;
using MoveService.Models;

[Route("api/[controller]")]
[ApiController]
public class MoveController : ControllerBase
{

    private static List<Move> moves = new List<Move>()
    {
        new Move()
        {
            Id = 1,
            Name = "FlameThrower",
            Damage = 25, Speed = 60,
            Accuracy = 80
        },
        new Move()
        {
            Id = 2,
            Name = "Watergun",
            Damage = 20,
            Speed = 70,
            Accuracy = 85
        }
    };

    [HttpGet]
    public async Task<ActionResult<List<Move>>> Get()
    {
        return Ok(moves);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Move>>> Get(int id)
    {
        var move = moves.Find(x => x.Id == id);
        if (move == null)
            return BadRequest("Move not found");
        return Ok(move);
    }

    [HttpPost]
    public async Task<ActionResult<List<Move>>> AddMove(Move move)
    {
        moves.Add(move);
        return Ok(moves);
    }

    [HttpPut]
    public async Task<ActionResult<List<Move>>> UpdateMove(Move req)
    {
        var move = moves.Find(x => x.Id == req.Id);
        if (move == null)
            return BadRequest("Move not found");

        move.Name = req.Name;
        move.Damage = req.Damage;
        move.Speed = req.Speed;
        move.Accuracy = req.Accuracy;
        return Ok(moves);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Move>>> DeleteMove(int id)
    {
        var move = moves.Find(x => x.Id == id);
        if (move == null)
            return BadRequest("Move not found");
        
        moves.Remove(move);
        return Ok(moves);
    }
}

