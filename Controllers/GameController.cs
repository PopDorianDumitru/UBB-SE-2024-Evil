using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UBB_SE_2024_Evil.Data;
using UBB_SE_2024_Evil.Models.Spartacus;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace UBB_SE_2024_Evil.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        { 
            _context = context;
        }

		Game Game { get; set; }

        // GET: Game
        // Load saved game page
        // Allows the user to select a saved game to load or to create a new game
        public IActionResult Index()
        {
			List<GameSave> gameSaves = _context.GameSave.ToList();
	
            //return View(saves);
            return View(gameSaves);
            //return View();
        }

        // GET: Game/GamePage
        // Main game page
        // Displays the current game state and allows the user to make moves
        // Also allows the user to save the run
        public IActionResult GamePage()
        {
            return View(Game);
        }

        // GET: Game/Win
        // Win page
        // Displays a message indicating that the user has won the game
        // Allows the user to return to the main menu
        public IActionResult Win()
        {
            return View();
        }

        // GET: Game/Lose
        // Lose page
        // Displays a message indicating that the user has lost the game
        // Allows the user to return to the main menu
        public IActionResult Lose()
        {
            return View();
        }

        public IActionResult NewRun() {
            return View();
        }

        public IActionResult DuplicateAdded()
        {
            return View();
        }

        // POST: Game/LoadSave
        // Load save endpoint
        // Loads a saved game and redirects to the main game page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoadSave(int gameSaveId)
        {
            if (gameSaveId <= 0)
            {
                // TODO: Handle error
                return RedirectToAction(nameof(Index));
            }

            GameSave gameSave = _context.GameSave.FirstOrDefault(gs => gs.Id == gameSaveId);

            //TODO
            //Game = new Game(gameSave);
            return RedirectToAction(nameof(GamePage));
        }

        // POST: Game/NewSave
        // New save endpoint
        // Creates a new game save and redirects to the main game page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewSave(string runName)
        {
            if (runName.IsNullOrEmpty())
            {
                // TODO: Handle error
                return RedirectToAction(nameof(Index));
            }
            if (_context.GameSave.FirstOrDefault(g => g.Name == runName) != null){
                ModelState.AddModelError("runName", "A game save with this name already exists.");
                return RedirectToAction(nameof(DuplicateAdded));
            }

            GameSave gameSave = new GameSave(runName);

            _context.GameSave.Add(gameSave);
            await _context.SaveChangesAsync();

            // Get the game save from the database to ensure that the ID is set
            gameSave = _context.GameSave.FirstOrDefault(g => g.Name == runName);
            //Game = new Game(gameSave);


            return RedirectToAction(nameof(GamePage));
        }

        // POST: Game/SaveGame
        // Save game endpoint
        // Saves the current game state and redirects to the load save page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGame()
        {
            GameSave gameSave = Game.GetGameSave();
            _context.GameSave.Update(gameSave);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // PATCH: Game/DoMove
        // Make move endpoint
        // Processes a move and refreshes the game page
        [HttpPatch]
        [ValidateAntiForgeryToken]
        public IActionResult DoMove(Move move)
        {
            if (move.EnergyCost > Game.Player.Energy)
            {
                // TODO: Handle error
                return RedirectToAction(nameof(GamePage));
            }

            Result result = Game.DoMove(move);
            if (result == Result.CONTINUE)
            {
                return RedirectToAction(nameof(GamePage));
            }

            GameSave gameSave = Game.GetGameSave();
            _context.GameSave.Remove(gameSave);

            if (result == Result.WIN)
            {
                return RedirectToAction(nameof(Win));
            }
            else
            {
                return RedirectToAction(nameof(Lose));
            }
        }
    }
}
