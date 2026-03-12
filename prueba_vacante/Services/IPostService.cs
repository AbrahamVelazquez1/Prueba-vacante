using prueba_vacante.Models;
using System.Collections.Generic;
namespace System.Threading.Tasks;

public interface IPostService{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post?> CreatePostAsync(Post post);
    Task<bool> UpdatePostAsync(int id, Post post);
    Task<bool> DeletePostAsync(int id);
}