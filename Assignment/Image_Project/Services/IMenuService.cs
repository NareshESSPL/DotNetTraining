using Image_Project.Models;
namespace Image_Project.Services { 

public interface IMenuService
{
    Task<List<Menu>> GetMenusAsync();
}

}
