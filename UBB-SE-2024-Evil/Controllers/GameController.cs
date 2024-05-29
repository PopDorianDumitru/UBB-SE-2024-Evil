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
        public static Game Game { get; set; }
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Game
        // Load saved game page
        // Allows the user to select a saved game to load or to create a new game
        public IActionResult Index()
        {
            List<GameSave> gameSaves = _context.GameSave.ToList();

            return View(gameSaves);
        }

        // GET: Game/GamePage
        // Main game page
        // Displays the current game state and allows the user to make moves
        // Also allows the user to save the run
        public IActionResult GamePage()
        {
            Game aux = Game;
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

        // GET: Game/NewRun
        // New run page
        // Allows the user to create a new game
        public IActionResult NewRun()
        {
            return View();
        }

        // GET: Game/DuplicateAdded
        // Duplicate added page
        // Displays a message indicating that a game save with the same name already exists
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
            }

            GameSave gameSave = _context.GameSave.FirstOrDefault(gs => gs.Id == gameSaveId);

            Game = new Game(gameSave);

            return RedirectToAction(nameof(GamePage));
        }

        // POST: Game/NewSave
        // New save endpoint
        // Creates a new game save and redirects to the main game page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSave(string runName)
        {
            if (runName.IsNullOrEmpty())
            {
                // TODO: Handle error
            }
            if (_context.GameSave.FirstOrDefault(g => g.Name == runName) != null)
            {
                ModelState.AddModelError("runName", "A game save with this name already exists.");
                return RedirectToAction(nameof(DuplicateAdded));
            }

            GameSave gameSave = new GameSave(runName);

            _context.GameSave.Add(gameSave);
            _context.SaveChanges();

            // Get the game save from the database to ensure that the ID is set
            gameSave = _context.GameSave.FirstOrDefault(g => g.Name == runName);
            Game = new Game(gameSave);

            return RedirectToAction(nameof(GamePage));
        }

        // Patch: Game/SaveGame
        // Save game endpoint
        // Saves the current game state
        [HttpPatch]
        [ValidateAntiForgeryToken]
        public void SaveGame()
        {
            GameSave gameSave = Game.GetGameSave();
            _context.GameSave.Update(gameSave);
            _context.SaveChanges();
        }

        // PATCH: Game/DoMove
        // Make move endpoint
        // Processes a move and refreshes the game page
        [HttpPatch]
        public IActionResult DoMove()
        {
            int damage = int.Parse(Request.Query["damage"]);
            int block = int.Parse(Request.Query["block"]);
            Move move = new Move(damage, block);

            if (move.EnergyCost > Game.Player.Energy)
            {
                // TODO: Handle error
            }

            Result result = Game.DoMove(move);
            if (result == Result.CONTINUE)
            {
                return PartialView("_GameScene", Game);
            }

            GameSave gameSave = Game.GetGameSave();
            _context.GameSave.Remove(gameSave);
            _context.SaveChanges();

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
