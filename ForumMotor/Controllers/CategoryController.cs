using ForumMotor.Data;
using ForumMotor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumMotor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kategóriák lekérdezése
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // Új jegyzet létrehozása
        [HttpPost]
        public async Task<ActionResult<Category>> CreateJegyzet(Category newCategory)
        {
            try
            {
                // Ellenőrizzük, hogy a kapcsolódó kártya létezik-e
                if (await _context.Categories.AnyAsync(k => k.Id == newCategory.Id))
                {
                    return BadRequest("A megadott kártya nem létezik.");
                }

                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Jegyzet módosítása
        //[HttpPut("{cardId}/{noteId}")]
        //public async Task<ActionResult> PutJegyzet(int cardId, int noteId, Jegyzet modositottJegyzet)
        //{
        //    if (modositottJegyzet.KartyaId != cardId || modositottJegyzet.Id != noteId)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(modositottJegyzet).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        // Jegyzet törlése
        [HttpDelete("{catId}")]
        public async Task<ActionResult> DeleteJegyzet(int catId)
        {
            var deletingCategory = await _context.Categories.FirstOrDefaultAsync(j => j.Id == catId);

            if (deletingCategory == null)
            {
                return NotFound("A kategória nem található.");
            }

            _context.Categories.Remove(deletingCategory);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //// Jegyzet áthelyezése
        //[HttpPut("{fromCardId}/{fromNoteId}/{toCardId}")]
        //public async Task<ActionResult> ChangePositionOfNote(int fromCardId, int fromNoteId, int toCardId)
        //{
        //    var jegyzet = await _context.Jegyzetek.FirstOrDefaultAsync(j => j.KartyaId == fromCardId && j.Id == fromNoteId);

        //    if (jegyzet == null)
        //    {
        //        return NotFound("A jegyzet nem található.");
        //    }

        //    jegyzet.KartyaId = toCardId;

        //    _context.Entry(jegyzet).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
