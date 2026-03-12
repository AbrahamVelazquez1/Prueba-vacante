using Microsoft.AspNetCore.Mvc;
using prueba_vacante.Models;
using prueba_vacante.Services;
using System.Threading.Tasks;

namespace prueba_vacante.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _postService.GetAllPostsAsync();
        return View(posts);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var post = await _postService.GetPostByIdAsync(id.Value);
        if (post == null) return NotFound();

        return View(post);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Post post)
    {
        if (!ModelState.IsValid)
        {
            return View(post);
        }

        var createdPost = await _postService.CreatePostAsync(post);
        if (createdPost != null)
        {
            TempData["SuccessMessage"] = "Post creado exitosamente (simulado)";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError(string.Empty, "Error al crear el post");
        return View(post);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var post = await _postService.GetPostByIdAsync(id.Value);
        if (post == null) return NotFound();

        return View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Post post)
    {
        if (id != post.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            return View(post);
        }

        var success = await _postService.UpdatePostAsync(id, post);
        if (success)
        {
            TempData["SuccessMessage"] = "Post actualizado exitosamente (simulado)";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError(string.Empty, "Error al actualizar el post");
        return View(post);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var post = await _postService.GetPostByIdAsync(id.Value);
        if (post == null) return NotFound();

        return View(post);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var success = await _postService.DeletePostAsync(id);
        if (success)
        {
            TempData["SuccessMessage"] = "Post eliminado exitosamente (simulado)";
        }
        else
        {
            TempData["ErrorMessage"] = "No se pudo eliminar el post";
        }

        return RedirectToAction(nameof(Index));
    }

}